using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators.Cliente;
using DataAccessLayer;
using MetaData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Extensions;
using Utils.Response;

namespace BusinessLogicalLayer
{
    public class ClienteBLL : BaseValidator<Cliente>, IClienteService
    {
        public async Task<SingleResponse<Cliente>> Insert(Cliente cliente)
        {
            this.Normatize(cliente);
            var response = new InsertClienteValidator().Validate(cliente).ToResponse();

            if (!response.HasSuccess)
            {
                return ResponseFactory.CreateSingleResponseFailure<Cliente>(response.Message);
            }

            try
            {
                using (FarmaBruContext db = new())
                {
                    await Task.Run(() => db.Clientes.Add(cliente));
                    await Task.Run(() => db.SaveChangesAsync());
                }

                ReNormatize(cliente);

                return ResponseFactory.CreateSingleResponseSuccess<Cliente>(cliente);
            }
            catch (Exception ex)
            {
                //Erros possíveis:
                //1 - Banco fora
                //2 - Banco lotado
                //3 - Erro de chave única
                return ResponseFactory.CreateSingleResponseFailure<Cliente>(ex);
            }
        }

        public async Task<SingleResponse<Cliente>> Deactivate(int id)
        {
            try
            {
                var response = await Task.Run(() => Get(id));
                if (!response.HasSuccess)
                {
                    return ResponseFactory.CreateSingleResponseFailure<Cliente>(response.Message);
                }

                Cliente cliente = response.Item;
                cliente.Ativo = false;

                await Task.Run(() => Update(cliente));
                return ResponseFactory.CreateSingleResponseSuccess(cliente);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateSingleResponseFailure<Cliente>(ex);
            }
        }

        public async Task<Response> Delete(int id)
        {
            try
            {

                var response = await Task.Run(() => Get(id));
                if (!response.HasSuccess)
                {
                    return ResponseFactory.CreateFailureResponse(response);
                }

                using (var db = new FarmaBruContext())
                {
                    await Task.Run(() => db.Clientes.Remove(response.Item));
                    await db.SaveChangesAsync();
                }
                return new Response(true, "Cliente removido com sucesso");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateFailureResponse(ex);
            }
        }

        public async Task<DataResponse<Cliente>> GetAll()
        {
            try
            {
                List<Cliente> clientes;

                using (FarmaBruContext db = new FarmaBruContext())
                {
                    clientes = await Task.Run(() => db.Clientes.ToListAsync());
                }

                clientes.ForEach(cliente => this.ReNormatize(cliente));

                return ResponseFactory.CreateDataResponseSuccess(clientes);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateDataResponseFailure<Cliente>(ex);
            }
        }

        public async Task<SingleResponse<Cliente>> GetByCPF(string cpf)
        {
            cpf = cpf.RemoveMask();

            if (!cpf.IsValidCPF())
            {
                return ResponseFactory.CreateSingleResponseFailure<Cliente>("CPF inválido.");
            }

            try
            {
                Cliente cliente;
                using (FarmaBruContext db = new FarmaBruContext())
                {
                    cliente = await Task.Run(() => db.Clientes.First(c => c.CPF == cpf));
                }

                if (cliente == null)
                {
                    return ResponseFactory.CreateNotFoundResponseFailure<Cliente>();
                }

                ReNormatize(cliente);
                return ResponseFactory.CreateSingleResponseSuccess(cliente);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateSingleResponseFailure<Cliente>(ex);
            }
        }

        public async Task<SingleResponse<Cliente>> Get(int id)
        {
            if (id <= 0)
            {
                return ResponseFactory.CreateSingleResponseFailure<Cliente>("Id inválido.");
            }

            try
            {
                Cliente cliente;

                //task.run??
                //se não encontrar por id, vai retornar null
                using (var db = new FarmaBruContext())
                {
                    cliente = await db.Clientes.FindAsync(id);
                }

                if (cliente == null)
                {
                    return ResponseFactory.CreateNotFoundResponseFailure<Cliente>();
                }

                ReNormatize(cliente);
                return ResponseFactory.CreateSingleResponseSuccess(cliente);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateSingleResponseFailure<Cliente>(ex);
            }
        }

        public async Task<SingleResponse<Cliente>> Update(Cliente cliente)
        {
            this.Normatize(cliente);
            var response = new UpdateClienteValidator().Validate(cliente).ToResponse();

            if (!response.HasSuccess)
            {
                return ResponseFactory.CreateSingleResponseFailure<Cliente>(response.Message);
            }

            try
            {
                using (var db = new FarmaBruContext())
                {
                    await Task.Run(() => db.Clientes.Update(cliente));
                    await db.SaveChangesAsync();
                }
                return ResponseFactory.CreateSingleResponseSuccess(cliente);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateSingleResponseFailure<Cliente>(ex);
            }
        }

        protected override void Normatize(Cliente item)
        {
            item.Nome = item.Nome.Normatize();
            item.Telefone = item.Telefone.RemoveMask();
            item.CPF = item.CPF.RemoveMask();
        }

        protected override void ReNormatize(Cliente item)
        {
            item.CPF = item.CPF.FormatAsCPF();
        }
    }
}
