using System.ComponentModel.DataAnnotations;

namespace Dashboard.API.DTOs
{
    public class UserForRegisterDTo
    {
        [Required]
        public string Username {get;set;}
         [Required]
        public string Password {get;set;}
    }
}