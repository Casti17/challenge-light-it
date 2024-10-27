using System.ComponentModel.DataAnnotations;

namespace PatientRegistry.Domain
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public required string Name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public required string Email { get; set; }

        [Required, MaxLength(15)]
        public required string PhoneNumber { get; set; }

        public string? DocumentPhotoPath { get; set; }
    }
}

