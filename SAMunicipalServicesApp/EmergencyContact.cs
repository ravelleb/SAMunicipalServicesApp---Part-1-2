using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMunicipalServicesApp
{
    public class EmergencyContact
    {
        public string Name { get; set; }
        public string ServiceType { get; set; }
        public string PhoneNumber { get; set; }

        public EmergencyContact(string name, string serviceType, string phoneNumber)
        {
            Name = name;
            ServiceType = serviceType;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Name} ({ServiceType}) - {PhoneNumber}";
        }
    }
}

