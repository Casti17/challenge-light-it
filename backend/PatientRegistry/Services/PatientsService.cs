using Microsoft.EntityFrameworkCore;
using PatientRegistry.Data;
using PatientRegistry.Domain;

namespace PatientRegistry.Services
{
    public class PatientsService
    {
        private readonly AppDbContext _context;
        private readonly MailService _mailService;

        public PatientsService(AppDbContext context, MailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        public async Task<string> RegisterPatientAsync(Patient patient, IFormFile documentPhoto)
        {
            try
            {
                if (documentPhoto != null && documentPhoto.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(documentPhoto.FileName);
                    var filePath = Path.Combine("wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await documentPhoto.CopyToAsync(stream);
                    }

                    patient.DocumentPhotoPath = "/images/" + fileName;
                }

                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();

                await _mailService.SendConfirmationEmailAsync(patient.Email);

                return "Patient registered successfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<List<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }
    }
}
