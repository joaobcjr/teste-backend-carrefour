using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces.Services;
using API.Models;
using EFCore.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Services
{
    public class ClienteService : IClienteService
    {

        private readonly ClienteRepository _repo;
        public ClienteService(ClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            int tipoEnd;

            var Verifica_cliente = await _repo.GetAllAsyncDapper(new ClienteConsulta
            {
                Cod_empresa = cliente.Cod_empresa,
                CPF = cliente.CPF
            });

            if (Verifica_cliente.Count != 0)
            {
                throw new Exception("Cliente já cadastrado na mesma empresa");
            }

            for (int x = 0; x < cliente.clienteEndereco.Count; x++)
            {
                tipoEnd = cliente.clienteEndereco[x].endereco.Tipo_endereco;

                for (int y = x + 1; y < cliente.clienteEndereco.Count; y++)
                {
                    if (tipoEnd == cliente.clienteEndereco[y].endereco.Tipo_endereco)
                    {
                        throw new Exception("Não é possível cadastrar dois endereços do mesmo tipo para o mesmo cliente");
                    }

                }

            }

            return await _repo.AddAsync(cliente);
        }

        public async Task<List<Cliente>> GetAll(ClienteConsulta cliente)
        {
            //return await _repo.GetAllAsync();
            return await _repo.GetAllAsyncDapper(cliente);
        }


        public async Task<Cliente> GetById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }
        public async Task<Cliente> Update(ClienteConsulta cliente, int id)
        {
            return await _repo.Update(cliente, id);
        }
    }
}
