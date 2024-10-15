using System;
using System.Collections.Generic;

namespace SAMunicipalServicesApp
{
    public class EmergencyContactService
    {
        private CustomLinkedList<EmergencyContact> emergencyContacts;

        public EmergencyContactService()
        {
            emergencyContacts = new CustomLinkedList<EmergencyContact>();
            // Adding some initial contacts
            emergencyContacts.Add(new EmergencyContact("Fire Department", "Emergency Service", "10111"));
            emergencyContacts.Add(new EmergencyContact("Ambulance", "Medical Emergency", "10177"));
            emergencyContacts.Add(new EmergencyContact("Police", "Law Enforcement", "10111"));
        }

        public IEnumerable<EmergencyContact> GetEmergencyContacts()
        {
            return emergencyContacts.GetAll();
        }

        public bool SendEmergencyRequest(EmergencyContact contact, string message)
        {
            Console.WriteLine($"Emergency Request Sent to: {contact.Name} ({contact.ServiceType}) with message: {message}");
            return true;
        }
    }
}
