using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces.Services
{
    public interface IClienteService
    {
        Task<Cliente> Add(Cliente cliente);
        Task<List<Cliente>> GetAll(ClienteConsulta cliente);
        Task<Cliente> GetById(int id);
        Task<Cliente> Update(ClienteConsulta cliente, int id);
        Task<bool> Delete(int id);
    }
}
