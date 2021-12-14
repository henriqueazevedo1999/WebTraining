using MetaData.Entities;
using System.Threading.Tasks;
using Utils.Response;

namespace BusinessLogicalLayer.Interfaces;

public interface IRepository<T> where T: Entity, new()
{
    Task<SingleResponse<T>> Insert(T t);
    Task<SingleResponse<T>> Update(T t);
    Task<Response> Delete(int id);
    Task<SingleResponse<T>> Deactivate(int id);
    Task<SingleResponse<T>> Get(int id);
    Task<DataResponse<T>> GetAll();
}
