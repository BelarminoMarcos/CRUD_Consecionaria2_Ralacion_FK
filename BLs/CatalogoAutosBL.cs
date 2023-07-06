using Consecionaria2.DTOs;
using Consecionaria2.Model;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Consecionaria2.BLs
{
    public class CatalogoAutosBL
    {
        private readonly ConsecionariaContext dbContext;

        public CatalogoAutosBL(ConsecionariaContext context)
        {
            dbContext = context;
        }

        public async Task<(int StatusCode, List<CatalogoAuto>)> ObtenerCatalogo()
        {

            try
            {
                var usuarios = await dbContext.CatalogoAutos.Select(usuarios => usuarios).ToListAsync();
                if (usuarios.IsNullOrEmpty())
                {
                    return (StatusCodes.Status404NotFound, new List<CatalogoAuto>());
                }
                return (StatusCodes.Status200OK, (usuarios));
            }
            catch
            {
                return (StatusCodes.Status500InternalServerError, new List<CatalogoAuto>());
            }
        }

        public async Task<(int StatusCode, string Mensaje)> CrearCatalogo(CatalogoAutoDTO usuarios) {
            try
            {
                var NewUser = new CatalogoAuto
                {
                    Marca = usuarios.Marca,
                    Modelo = usuarios.Modelo
                };
                dbContext.Add(NewUser);
                await dbContext.SaveChangesAsync();
                return (StatusCodes.Status201Created, "Registrado");

            }
            catch (Exception)
            {
                return (StatusCodes.Status500InternalServerError, "No se pudo guardar");
            }
        }

        public async Task<(int StatusCode, CatalogoAuto)> BuscarPorId(int Id) {
            try
            {
                var usuarios = await dbContext.CatalogoAutos.Where(usuarios => usuarios.Id.Equals(Id)).FirstOrDefaultAsync();
                if (usuarios == null)
                {
                    return (StatusCodes.Status404NotFound, new CatalogoAuto());
                }
                return (StatusCodes.Status200OK, (usuarios));
            }
            catch
            {
                return (StatusCodes.Status500InternalServerError, new CatalogoAuto());
            }

        }

        public async Task<(int StatusCode, string Mensaje)> ActualizarCatalogo(CatalogoAutoDTO usuarios) {
            try
            {
                var UsuarioExistente = await dbContext.CatalogoAutos.Where(a => a.Id == usuarios.Id).FirstOrDefaultAsync();
                if (UsuarioExistente == null)
                    return (StatusCodes.Status404NotFound, "No se enconto el Dato");
                UsuarioExistente.Marca = UsuarioExistente.Marca;
                UsuarioExistente.Modelo = UsuarioExistente.Modelo;

                dbContext.CatalogoAutos.Update(UsuarioExistente);
                await dbContext.SaveChangesAsync();
                return (StatusCodes.Status200OK, "Actualizacion exitosa");
            }
            catch (Exception)
            {

                return (StatusCodes.Status500InternalServerError, "error interno");
            }
        }

        public async Task<(int StatusCode, string Mensaje)> BorraCatalogo(int id)
        {
            try
            {

                var UsuarioExistente = await dbContext.CatalogoAutos.Where(a => a.Id == id).FirstOrDefaultAsync();

                if (UsuarioExistente == null) return (StatusCodes.Status404NotFound, "No se encontro la pertenencia");


                dbContext.CatalogoAutos.Remove(UsuarioExistente);
                await dbContext.SaveChangesAsync();

                return (StatusCodes.Status200OK, "Pertenencia eliminado");
            }
            catch
            {
                return (StatusCodes.Status500InternalServerError, "error interno");
            }
        }



    }
}
