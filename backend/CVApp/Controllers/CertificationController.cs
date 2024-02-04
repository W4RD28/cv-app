using CVApp.Dto.Certification;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.AspNetCore.Mvc;

namespace CVApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificationController : ControllerBase
{
    private readonly ICertificationService _certificationService;
    public CertificationController(ICertificationService certificationService)
    {
        _certificationService = certificationService;
    }

    [HttpGet]
    public async Task<IEnumerable<Certification>> GetCertifications([FromQuery] CertificationParams @params)
    {
        return await _certificationService.GetCertifications(@params);
    }

    [HttpGet("{id}")]
    public async Task<Certification> GetCertification(int id)
    {
        return await _certificationService.GetCertification(id);
    }

    [HttpPost]
    public async Task<Certification> AddCertification([FromBody] CertificationCreateDto @params)
    {
        return await _certificationService.AddCertification(@params);
    }

    [HttpPut("{id}")]
    public async Task<Certification> UpdateCertification([FromBody] CertificationUpdateDto @params, int id)
    {
        return await _certificationService.UpdateCertification(@params, id);
    }

    [HttpDelete("{id}")]
    public async Task<Certification> RemoveCertification(int id)
    {
        return await _certificationService.RemoveCertification(id);
    }
}