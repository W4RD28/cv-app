using CVApp.Dto.Work;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.AspNetCore.Mvc;

namespace CVApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkController : ControllerBase
{
    private readonly IWorkService _workService;
    public WorkController(IWorkService workService)
    {
        _workService = workService;
    }

    [HttpGet]
    public async Task<IEnumerable<Work>> GetWorks(WorkParams @params)
    {
        return await _workService.GetWorks(@params);
    }

    [HttpGet("{id}")]
    public async Task<Work> GetWork(int id)
    {
        return await _workService.GetWork(id);
    }

    [HttpPost]
    public async Task<Work> AddWork([FromBody] WorkCreateDto work)
    {
        return await _workService.AddWork(work);
    }

    [HttpPut("{id}")]
    public async Task<Work> UpdateWork([FromQuery] WorkUpdateDto work, int id)
    {
        return await _workService.UpdateWork(work, id);
    }

    [HttpDelete("{id}")]
    public async Task<Work> RemoveWork(int id)
    {
        return await _workService.RemoveWork(id);
    }
}