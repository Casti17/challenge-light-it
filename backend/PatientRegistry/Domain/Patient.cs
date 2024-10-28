using System.ComponentModel.DataAnnotations;

namespace PatientRegistry.Domain
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters.")]
        public required string Name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email must be a valid Gmail address.")]
        public required string Email { get; set; }

        [Required, MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        public required string PhoneNumber { get; set; }

        public string? DocumentPhotoPath { get; set; }
    }
}

