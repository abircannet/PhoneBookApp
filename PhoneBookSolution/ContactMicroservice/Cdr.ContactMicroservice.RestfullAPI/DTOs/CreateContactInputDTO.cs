using System.ComponentModel.DataAnnotations;

namespace Cdr.ContactMicroservice.RestfullAPI.DTOs
{
    public class CreateContactInputDTO
    {
        [StringLength(64)]
        [Required]
        public string Name { get; set; }
        [StringLength(64)]
        [Required]
        public string Surname { get; set; }
        [StringLength(256)]
        public string CompanyName { get; set; }
    }
}
