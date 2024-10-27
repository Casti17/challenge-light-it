using Microsoft.EntityFrameworkCore;
using PatientRegistry.Data;
using PatientRegistry.Domain;

namespace PatientRegistry.Services
{
    public class PatientsService
    {
        private readonly AppDbContext _context;

        public PatientsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterPatientAsync(Patient patient, IFormFile documentPhoto)
        {
            try
            {
                if (documentPhoto != null && documentPhoto.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(documentPhoto.FileName);
                    var filePath = Path.Combine("wwwroot/images", fileName); // Save to wwwroot/images

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await documentPhoto.CopyToAsync(stream);
                    }

                    // Store the file path in the database
                    patient.DocumentPhotoPath = "/images/" + fileName; // Relative path for the frontend
                }


                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();

                // Send confirmation email asynchronously
                await MailService.SendConfirmationEmailAsync(patient.Email);

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
