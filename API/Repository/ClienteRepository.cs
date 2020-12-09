using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces.Repository;
using API.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace EFCore.Repo
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApiContext _context;
        private IConfiguration _configuracoes;

        public ClienteRepository(ApiContext context, IConfiguration config)
        {
            _context = context;
            _configuracoes = config;
        }


        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            try
            {

                _context.Add(cliente);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cliente;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _context.Tb_cliente.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                {
                    return false;
                }

                _context.Tb_cliente.Remove(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            var clientes = await _context.Tb_cliente.ToListAsync();
            return clientes;
        }

        public async Task<List<Cliente>> GetAllAsyncDapper(ClienteConsulta cliente)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _configuracoes.GetConnectionString("ConexaoBanco")))
            {
                string query = " SELECT *                                                          " +
                               "   FROM tb_cliente                                                 " +
                               "  WHERE nome = IFNULL(@nome,nome)                                  " +
                               "    AND rg = IFNULL(@rg,rg)                                        " +
                               "    AND cpf = IFNULL(@cpf,cpf)                                     " +
                               "    AND data_nascimento = IFNULL(@data_nascimento,data_nascimento) " +
                               "    AND telefone = IFNULL(@telefone,telefone)                      " +
                               "    AND cod_empresa = IFNULL(@cod_empresa,cod_empresa)             " +
                               "    AND email = IFNULL(@email,email)                               ";

                var clientes = (List<Cliente>)await conexao.QueryAsync<Cliente>(query, cliente);

                return clientes;
            }
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            var cliente = await _context.Tb_cliente.Include(x => x.clienteEndereco).ThenInclude(x => x.endereco).FirstOrDefaultAsync(x => x.Id == id);
            return cliente;
        }

        public async Task<Cliente> Update(ClienteConsulta cliente, int id)
        {
            var result = await _context.Tb_cliente.SingleOrDefaultAsync(c => c.Id.Equals(id));
            if (result == null)
            {
                return null;
            }
            cliente.Nome = cliente.Nome == null ? result.Nome : cliente.Nome;
            cliente.RG = cliente.RG == null ? result.RG : cliente.RG;
            cliente.CPF = cliente.CPF == null ? result.CPF : cliente.CPF;
            cliente.Data_nascimento = cliente.Data_nascimento == null ? result.Data_nascimento : (DateTime)cliente.Data_nascimento;
            cliente.Telefone = cliente.Telefone == null ? result.Telefone : cliente.Telefone;
            cliente.Email = cliente.Email == null ? result.Email : cliente.Email;
            cliente.Cod_empresa = cliente.Cod_empresa == null ? result.Cod_empresa : (int)cliente.Cod_empresa;

            _context.Entry(result).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
