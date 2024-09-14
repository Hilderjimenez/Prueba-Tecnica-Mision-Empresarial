using APIMercancías_JyC.Data;
using APIMercancías_JyC.DTOs;
using APIMercancías_JyC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMercancías_JyC.Controllers
{
    [ApiController]
    [Route("Productos")]
    public class ProductosController : ControllerBase
    {
        private readonly MercanciasJyCContext _context;

        public ProductosController(MercanciasJyCContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> CreateProducto(ProductoDTO producto)
        {
            Producto insertar = new Producto();
            insertar.Nombre = producto.Nombre;
            insertar.Descripcion = producto.Descripcion;

            _context.Productos.Add(insertar);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Nombre }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, ProductoDTO producto)
        {
            if (!ProductoExists(id))
            {
                return NotFound();
            }

            var productoExistente = await _context.Productos.FirstOrDefaultAsync(c => c.ProductoId == id);

            if (productoExistente == null)
            {
                return NotFound();
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }
    }
}
