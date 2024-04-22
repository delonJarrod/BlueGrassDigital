using System.ComponentModel.DataAnnotations;

namespace BlueGrassDigital.Models.Admin
{
    public class PersonDetails
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string AddressCountry { get; set; }
        [Required]
        public string AddressCity { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }

    }
}
