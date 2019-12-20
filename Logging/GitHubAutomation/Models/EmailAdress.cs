using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    class EmailAdress
    {
        public string AdressOfEmail { get; set; }

        public EmailAdress(string email)
        {
            AdressOfEmail = email;
        }
    }
}
