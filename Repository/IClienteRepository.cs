using BackCustomerWithRelations.Models;

namespace BackCustomerWithRelations.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetOne(int id);
        Task<Cliente> PostCliente(Cliente cliente);

        Task PutMascota(Cliente cliente);

        Task Delete(Cliente cliente);
    }
}
