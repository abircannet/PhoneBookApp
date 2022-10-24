using Cdr.ContactMicroservice.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Cdr.ContactMicroservice.RestfullAPI.DTOs
{
    public class AddContactDetailInputDTO
    {
        [Required]
        public ContactDetailType ContactDetailType { get; set; }
        [Required]
        [StringLength(512)]
        public string Content { get; set; }
        [Required]
        public string ContactId { get; set; }
    }
}
