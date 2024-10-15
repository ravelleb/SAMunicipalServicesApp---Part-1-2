using System;
using System.Collections.Generic;

namespace SAMunicipalServicesApp
{
    public class EmergencyContactService
    {
        public List<EmergencyContact> GetEmergencyContacts()
        {
            // Dummy data, which could be from a database in a real-world scenario
            return new List<EmergencyContact>
            {
                new EmergencyContact("Fire Department", "Emergency Service", "10111"),
                new EmergencyContact("Ambulance", "Medical Emergency", "10177"),
                new EmergencyContact("Police", "Law Enforcement", "10111")
            };
        }

        public bool SendEmergencyRequest(EmergencyContact contact, string message)
        {
            // Sending an emergency request
            Console.WriteLine($"Emergency Request Sent to: {contact.Name} ({contact.ServiceType}) with message: {message}");
            return true;
        }
    }
}

