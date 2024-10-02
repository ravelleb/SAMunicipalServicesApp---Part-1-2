using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMunicipalServicesApp
{
    public class RequestService
    {
        public List<string> GetAvailableServices()
        {
            // List of services that the municipality offers
            return new List<string> {
            "Water Supply Issue",
            "Road Maintenance",
            "Electricity Issue",
            "Garbage Collection"
        };
        }

        public bool SubmitServiceRequest(string serviceType, string location, string description)
        {
            // Simulate submission of service request
            // Normally, you'd store this in a database or send it to an API
            Console.WriteLine($"Service Request Submitted: {serviceType} at {location}, Description: {description}");
            return true;
        }
    }
}
