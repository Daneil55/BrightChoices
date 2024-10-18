using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightChoices.Models
{
    class RegistrationModel
    {
        public int Id { get; set; }
        public byte[] profileimage { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public DateTime date { get; set; } = DateTime.Now;

    }
}
