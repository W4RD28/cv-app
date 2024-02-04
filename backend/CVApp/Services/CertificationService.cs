using CVApp.Context;
using CVApp.Dto.Certification;
using CVApp.Interfaces;
using CVApp.Models;
using CVApp.Params;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Services;

public class CertificationService : ICertificationService
{
    private readonly ApplicationDbContext _context;
    public CertificationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Certification>> GetCertifications()
    {
        return await _context.Certifications
            .ToListAsync();
    }

    public async Task<IEnumerable<Certification>> GetCertifications(CertificationParams @params)
    {
        var query = _context.Certifications.AsQueryable();

        if (@params.UserId != null)
        {
            query = query.Where(c => c.UserId == @params.UserId);
        }

        if (@params.Authority != null)
        {
            query = query.Where(c => c.Authority == @params.Authority);
        }

        if (@params.Name != null)
        {
            query = query.Where(c => c.Name == @params.Name);
        }

        query = query.OrderBy(c => c.Date);

        return await query.ToListAsync();
    }

    public async Task<Certification> GetCertification(int id)
    {
        return await _context.Certifications
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Certification> AddCertification(CertificationCreateDto certification)
    {
        var data = new Certification
        {
            Name = certification.Name,
            Authority = certification.Authority,
            Date = certification.Date,
            Url = certification.Url,
            ExpirationDate = certification.ExpirationDate,
            LicenseNumber = certification.LicenseNumber,
            Description = certification.Description,
            UserId = certification.UserId
        };

        _context.Certifications.Add(data);
        await _context.SaveChangesAsync();
        return data;
    }

    public async Task<Certification> UpdateCertification(CertificationUpdateDto certification, int id)
    {
        var certificationToUpdate = await _context.Certifications
            .FirstOrDefaultAsync(c => c.Id == id);
        if (certificationToUpdate == null)
        {
            return null;
        }
        certificationToUpdate.Name = certification.Name;
        certificationToUpdate.Authority = certification.Authority;
        certificationToUpdate.Date = certification.Date;
        certificationToUpdate.Url = certification.Url;
        certificationToUpdate.ExpirationDate = certification.ExpirationDate;
        certificationToUpdate.LicenseNumber = certification.LicenseNumber;
        certificationToUpdate.Description = certification.Description;

        await _context.SaveChangesAsync();
        return certificationToUpdate;
    }

    public async Task<Certification> RemoveCertification(int id)
    {
        var certification = await _context.Certifications
            .FirstOrDefaultAsync(c => c.Id == id);
        _context.Certifications.Remove(certification);
        await _context.SaveChangesAsync();
        return certification;
    }
}