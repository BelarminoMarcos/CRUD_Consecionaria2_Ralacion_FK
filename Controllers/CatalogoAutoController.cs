using Consecionaria2.BLs;
using Consecionaria2.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Consecionaria2.Controllers
{
    public class CatalogoAutoController : ControllerBase
    {
        private readonly CatalogoAutosBL catalogoAutosBL;
        public CatalogoAutoController(CatalogoAutosBL catalogoAutosBL) {
            this.catalogoAutosBL = catalogoAutosBL;
        }

        [HttpGet("ObtenerCatalogo")]
        public async Task<IActionResult> ObtenerCatalogoo()
        {
            var (status, List) = await catalogoAutosBL.ObtenerCatalogo();
            return StatusCode(status, List);
        }


        [HttpPost("CrearCatalogo")]
        public async Task<IActionResult> CrearCatalogoo([FromBody] CatalogoAutoDTO UsuarioCatalogo)
        {
            var result = await catalogoAutosBL.CrearCatalogo(UsuarioCatalogo);
            return StatusCode(result.StatusCode, result.Mensaje);

        }

        [HttpGet("ObtenerCatalogoPoId")]
        public async Task<IActionResult> ObtenerCatalogoPorId(int UsuarioId)
        {
            var result = await catalogoAutosBL.BuscarPorId(UsuarioId);
            return StatusCode(result.StatusCode, result.Item2);

        }

        [HttpPut("ActualizaCatalogo")]
        public async Task<IActionResult> ActualizarCatalogoo([FromBody] CatalogoAutoDTO UsuarioCatalogo)
        {
            var result = await catalogoAutosBL.ActualizarCatalogo(UsuarioCatalogo);
            return StatusCode(result.StatusCode, result.Mensaje);
        }

        [HttpDelete("BorrarCatalogo")]
        public async Task<IActionResult> DeletePertenenciaP(int id)
        {
            var result = await catalogoAutosBL.BorraCatalogo(id);
            return StatusCode(result.StatusCode, result.Mensaje);
        }
    }
}
