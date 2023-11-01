using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class EmergencyContactDto
{
    public long EmergencyContactId { get; set; }
    public string EmergencyContactNumber { get; set; }
    public string? HospitalName { get; set; }
    public string? PersonName { get; set; }
    public string? Profession { get; set; }
    public string? Description { get; set; }
    public string? EmergencySpecialNote { get; set; } 

    public EmergencyContactDto( long emergencyContactId, string emergencyContactNumber, string hospitalName, string personName, string profession, string description, string emergencySpecialNote )
    {
        EmergencyContactId = emergencyContactId;
        EmergencyContactNumber = emergencyContactNumber;
        HospitalName = hospitalName;
        PersonName = personName;
        Profession = profession;
        Description = description;
        EmergencySpecialNote = emergencySpecialNote;
    }
    
}