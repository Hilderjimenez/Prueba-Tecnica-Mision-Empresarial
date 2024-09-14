using APIMercancías_JyC.Data;
using APIMercancías_JyC.DTOs;
using APIMercancías_JyC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace APIMercancías_JyC.Controllers
{
    [ApiController]
    [Route("Pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly MercanciasJyCContext _context;

        public PedidosController(MercanciasJyCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {

            return await _context.Pedidos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }
            return pedido;

        }

        [HttpPost]
        public async Task<ActionResult<PedidoCreateDTO>> CreatePedido(PedidoCreateDTO pedidoDTO)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            using (var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("VerificarCreacionPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaPedido", pedidoDTO.FechaPedido);
                    command.Parameters.AddWithValue("@EntregaDeseada", pedidoDTO.FechaEntrega);

                    //Valida si se cumple con las condiciones de entrega

                    var result = await command.ExecuteScalarAsync();
                    var errorMessage = result as string;

                    if (!string.IsNullOrEmpty(errorMessage) && errorMessage != "SI")
                    {
                        return BadRequest(errorMessage);
                    }
                }
            }

            try
            {
                //#1 Insertar el encabezado del pedido
                Pedido pedidoInsertar = new Pedido();
                {
                    pedidoInsertar.ClienteId = pedidoDTO.ClienteId;
                    pedidoInsertar.FechaPedido = pedidoDTO.FechaPedido;
                    pedidoInsertar.FechaEntrega = pedidoDTO.FechaEntrega;
                    pedidoInsertar.Total = pedidoDTO.Total;

                };

                _context.Pedidos.Add(pedidoInsertar); 
                await _context.SaveChangesAsync();

                // #2 Insertar detalle del pedido 
                var pedidoId = pedidoInsertar.PedidoId;
                var fechaEntrega = pedidoInsertar.FechaEntrega;

                foreach (var productoDTO in pedidoDTO.PedidoProductos)
                {
                    PedidoProducto productoInsertar = new PedidoProducto();
                    {
                        productoInsertar.PedidoId = pedidoInsertar.PedidoId;
                        productoInsertar.ProductoId = productoDTO.ProductoId;
                        productoInsertar.Cantidad = productoDTO.Cantidad;

                    };
                    

                    _context.PedidoProductos.Add(productoInsertar);
                    

                }
                await _context.SaveChangesAsync();

                //#3 Insertar entrega pedido
                Entrega entregaRealizar = new Entrega();
                {
                    entregaRealizar.PedidoId = pedidoInsertar.PedidoId;
                    entregaRealizar.FechaEntrega = pedidoInsertar.FechaEntrega;
                    entregaRealizar.Estado = "Pendiente";
                };

                _context.Entregas.Add(entregaRealizar);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPedido), new { id = pedidoInsertar.PedidoId }, pedidoDTO);
            }
            catch (SqlException ex)
            {
                
                return BadRequest($"Error al validar el pedido: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error al guardar el pedido: {ex.Message}");
            }

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePedido(int id, PedidoUpdateDTO pedido)
        {
            
            //Valida si el id del pedido existe dentro de la base de datos

            if (!PedidoExists(id))
            {
                return NotFound();
            }

            

            // Se Obtiene el pedido existente

            var pedidoExistente = await _context.Pedidos.Include(p => p.PedidoProductos).Include(p => p.Entrega).FirstOrDefaultAsync(p => p.PedidoId == id);

            if (pedidoExistente == null)
            {
                return NotFound();
            }
            // Actualizar el pedido
            pedidoExistente.ClienteId = pedido.ClienteId;
            pedidoExistente.FechaPedido = pedido.FechaPedido;
            pedidoExistente.FechaEntrega = pedido.FechaEntrega;
            pedidoExistente.Total = pedido.Total;

            _context.PedidoProductos.RemoveRange(pedidoExistente.PedidoProductos);

            // Agregar detalles actualizados
            foreach (var productoDTO in pedido.PedidoProductos)
            {
                var productoInsertar = new PedidoProducto
                {
                    PedidoId = id,
                    ProductoId = productoDTO.ProductoId,
                    Cantidad = productoDTO.Cantidad
                };

                _context.PedidoProductos.Add(productoInsertar);

            }

            // Actualizar entrega
            if (pedidoExistente.Entrega == null)
            {
                pedidoExistente.Entrega = new Entrega
                {
                    PedidoId = id

                };
            }

            pedidoExistente.Entrega.FechaEntrega = pedido.FechaEntrega;
            pedidoExistente.Entrega.Estado = pedido.Entrega.Estado;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}
