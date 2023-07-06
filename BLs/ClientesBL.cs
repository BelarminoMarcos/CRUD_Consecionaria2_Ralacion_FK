using Consecionaria2.DTOs;
using Consecionaria2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Consecionaria2.BLs
{
    public class ClientesBL
    {
        private readonly ConsecionariaContext dbContext;

        public ClientesBL(ConsecionariaContext context)
        {
            dbContext = context;
        }

        public async Task<(int StatusCode, List<Cliente>)> ObtenerCliente()
        {

            try
            {
                var usuarios = await dbContext.Clientes.Select(usuarios => usuarios).ToListAsync();
                if (usuarios.IsNullOrEmpty())
                {
                    return (StatusCodes.Status404NotFound, new List<Cliente>());
                }
                return (StatusCodes.Status200OK, (usuarios));
            }
            catch
            {
                return (StatusCodes.Status500InternalServerError, new List<Cliente>());
            }
        }

        public async Task<(int StatusCode, string Mensaje)> CrearCliente(ClienteDTO usuarios)
        {
            try
            {
                var NewUser = new Cliente
                {
                    Name = usuarios.Name,
                    FirstName = usuarios.FirstName,
                    IdAutoC = usuarios.IdAutoC
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

        public async Task<(int StatusCode, Cliente)> BuscarClientePorId(int Id)
        {
            try
            {
                var usuarios = await dbContext.Clientes.Where(usuarios => usuarios.Id.Equals(Id)).FirstOrDefaultAsync();
                if (usuarios == null)
                {
                    return (StatusCodes.Status404NotFound, new Cliente());
                }
                return (StatusCodes.Status200OK, (usuarios));
            }
            catch
            {
                return (StatusCodes.Status500InternalServerError, new Cliente());
            }

        }

        public async Task<(int StatusCode, string Mensaje)> ActualizarCliente(ClienteDTO usuarios)
        {
            try
            {
                var UsuarioExistente = await dbContext.Clientes.Where(a => a.Id == usuarios.Id).FirstOrDefaultAsync();
                if (UsuarioExistente == null)
                    return (StatusCodes.Status404NotFound, "No se enconto el Dato");
                UsuarioExistente.Name = UsuarioExistente.Name;
                UsuarioExistente.FirstName = UsuarioExistente.FirstName;
                UsuarioExistente.IdAutoC = UsuarioExistente.IdAutoC;

                dbContext.Clientes.Update(UsuarioExistente);
                await dbContext.SaveChangesAsync();
                return (StatusCodes.Status200OK, "Actualizacion exitosa");
            }
            catch (Exception)
            {

                return (StatusCodes.Status500InternalServerError, "error interno");
            }
        }

        public async Task<(int StatusCode, string Mensaje)> BorraCliente(int id)
        {
            try
            {

                var UsuarioExistente = await dbContext.Clientes.Where(a => a.Id == id).FirstOrDefaultAsync();

                if (UsuarioExistente == null) return (StatusCodes.Status404NotFound, "No se encontro la pertenencia");


                dbContext.Clientes.Remove(UsuarioExistente);
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
