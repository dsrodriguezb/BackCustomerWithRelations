using BackCustomerWithRelations.Context;
using BackCustomerWithRelations.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BackCustomerWithRelations.Repository
{
    public class ClienteRepository: IClienteRepository
    {
        //Es variable de solo lectura
        private readonly AppDbContext _appDbContext;

        public ClienteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Delete(Cliente cliente)
        {
            _appDbContext.Clientes.Remove(cliente);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _appDbContext.Clientes
                    .Include(c => c.MstPais) // Incluye la información del país
                    .Include(c => c.MstCiudad) // Incluye la información de la ciudad
                .ToListAsync();

            
        }

        public async Task<Cliente> GetOne(int id)
        {
            return await _appDbContext.Clientes
                    .Include(c => c.MstPais) // Incluye la información del país
                    .Include(c => c.MstCiudad) // Incluye la información de la ciudad
                    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> PostCliente(Cliente cliente)
        {
            _appDbContext.Clientes.Add(cliente);
            await _appDbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task PutMascota(Cliente cliente)
        {
            var clienteItem = await _appDbContext.Clientes.FirstOrDefaultAsync(x => x.Id == cliente.Id);

            if(clienteItem != null)
            {
                clienteItem.Nombre = cliente.Nombre;
                clienteItem.Apellido = cliente.Apellido;
                clienteItem.IdPais = cliente.IdPais;
                clienteItem.IdCiudad = cliente.IdCiudad;
                clienteItem.Direccion = cliente.Direccion;
                clienteItem.Telefono = cliente.Telefono;
                clienteItem.FechaNacimiento = cliente.FechaNacimiento;
                clienteItem.Email = cliente.Email;
                clienteItem.Active = cliente.Active;
                clienteItem.Status = cliente.Status;
                await _appDbContext.SaveChangesAsync();
            }
            
        }
    }
}
