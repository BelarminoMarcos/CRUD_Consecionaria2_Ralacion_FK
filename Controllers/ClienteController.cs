using Consecionaria2.BLs;
using Consecionaria2.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Consecionaria2.Controllers
{
    public class ClienteController : ControllerBase
    {
        private readonly ClientesBL clientesBL;
        public ClienteController(ClientesBL clientesBL)
        {
            this.clientesBL = clientesBL;
        }

        [HttpGet("ObtenerCliente")]
        public async Task<IActionResult> ObtenerCatalogoo()
        {
            var (status, List) = await clientesBL.ObtenerCliente();
            return StatusCode(status, List);
        }


        [HttpPost("CrearCliente")]
        public async Task<IActionResult> CrearClientee([FromBody] ClienteDTO UsuarioCatalogo)
        {
            var result = await clientesBL.CrearCliente(UsuarioCatalogo);
            return StatusCode(result.StatusCode, result.Mensaje);

        }



        [HttpGet("ObtenerClientePoId")]
        public async Task<IActionResult> ObtenerClienteePorId(int UsuarioId)
        {
            var result = await clientesBL.BuscarClientePorId(UsuarioId);
            return StatusCode(result.StatusCode, result.Item2);

        }

        [HttpPut("ActualizaCliente")]
        public async Task<IActionResult> ActualizarClientee([FromBody] ClienteDTO UsuarioCliente)
        {
            var result = await clientesBL.ActualizarCliente(UsuarioCliente);
            return StatusCode(result.StatusCode, result.Mensaje);
        }

        [HttpDelete("BorrarCliente")]
        public async Task<IActionResult> DeleteClientee(int id)
        {
            var result = await clientesBL.BorraCliente(id);
            return StatusCode(result.StatusCode, result.Mensaje);
        }
    }
}
