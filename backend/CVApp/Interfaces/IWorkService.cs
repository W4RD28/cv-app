using CVApp.Dto.Work;
using CVApp.Models;
using CVApp.Params;

namespace CVApp.Interfaces;

public interface IWorkService
{
    public Task<IEnumerable<Work>> GetWorks(WorkParams @params);
    public Task<Work> GetWork(int id);
    public Task<Work> AddWork(WorkCreateDto work);
    public Task<Work> UpdateWork(WorkUpdateDto work, int id);
    public Task<Work> RemoveWork(int id);
}