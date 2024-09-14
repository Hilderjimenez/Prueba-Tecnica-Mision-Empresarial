using APIMercancías_JyC.Data;
using APIMercancías_JyC.DTOs;
using APIMercancías_JyC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMercancías_JyC.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly MercanciasJyCContext _context;

        public ClientesController(MercanciasJyCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> CreateCliente(ClienteDTO cliente)
        {
            Cliente insertar = new Cliente();
            insertar.Nombre = cliente.Nombre;
            insertar.Direccion = cliente.Direccion;

            _context.Clientes.Add(insertar);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Nombre }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, ClienteDTO cliente)
        {

            if (!ClienteExists(id))
            {
                return NotFound();
            }

            var clienteExistente = await _context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Direccion = cliente.Direccion;

            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound(); 
                }
                else
                {
                    throw; 
                }
            }

            return NoContent(); // Actualización exitosa
        }
    
    

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
