using CVApp.Dto.Certification;
using CVApp.Models;
using CVApp.Params;

namespace CVApp.Interfaces;

public interface ICertificationService
{
    public Task<IEnumerable<Certification>> GetCertifications(CertificationParams @params);
    public Task<Certification> GetCertification(int id);
    public Task<Certification> AddCertification(CertificationCreateDto certification);
    public Task<Certification> UpdateCertification(CertificationUpdateDto certification, int id);
    public Task<Certification> RemoveCertification(int id);
}