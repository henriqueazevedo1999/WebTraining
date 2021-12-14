using MetaData.Entities;
using System.Threading.Tasks;
using Utils.Response;

namespace BusinessLogicalLayer.Interfaces;

public interface IClienteService : IRepository<Cliente>
{
    Task<SingleResponse<Cliente>> GetByCPF(string cpf);
}
