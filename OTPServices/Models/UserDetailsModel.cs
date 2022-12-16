using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPServices.Entity
{
    public class UserDetailsModel
    {
        [Required]
        [StringLength(50,ErrorMessage = "Name must be maximum 50 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
    }
}
