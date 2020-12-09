using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace Api.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> AddAsync(Cliente cliente);
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<bool> Delete(int id);
        Task<Cliente> Update(ClienteConsulta cliente, int id);
    }
}
