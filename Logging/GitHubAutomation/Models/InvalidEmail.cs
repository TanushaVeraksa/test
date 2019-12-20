using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    public class InvalidEmail
    {
        public string EmailAdress { get; set; }

        public InvalidEmail(string email)
        {
            EmailAdress = email;
        }
    }
}
