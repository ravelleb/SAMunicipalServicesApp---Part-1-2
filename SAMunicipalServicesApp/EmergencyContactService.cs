using System;
using System.Collections.Generic;

namespace SAMunicipalServicesApp
{
    public class EmergencyContactService
    {
        public List<string> GetEmergencyContacts()
        {
            //data from a database
            return new List<string> {
                "Fire Department - 10111",
                "Ambulance - 10177",
                "Police - 10111"
            };
        }

        public bool SendEmergencyRequest(string contactName, string message)
        {
            // emergency request
            Console.WriteLine($"Emergency Request Sent to: {contactName} with message: {message}");
            return true;
        }
    }
}
