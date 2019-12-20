using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    public class LeaveFeedback
    {
        public string Message { get; set; }

        public LeaveFeedback(string message)
        {
            Message = message;
        }
    }
}
