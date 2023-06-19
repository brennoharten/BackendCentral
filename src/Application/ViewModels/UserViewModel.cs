using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Application.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
