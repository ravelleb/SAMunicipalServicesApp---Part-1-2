using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMunicipalServicesApp
{
    public class UserEngagement
    {
        public int SubmissionCount { get; set; } = 0;
        public List<string> UserFeedback { get; set; } = new List<string>();

        public void AddSubmission()
        {
            SubmissionCount++;
        }

        public void AddFeedback(string feedback)
        {
            UserFeedback.Add(feedback);
        }
    }
}

