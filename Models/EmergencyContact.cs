using VenomVerseApi.DTO;

namespace VenomVerseApi.Models
{
    public class EmergencyContact {
        public long EmergencyContactId { get; set; }
        public string? EmergencyContactNumber { get; set; }
        public string? HospitalName { get; set; }
        public string? PersonName { get; set; }
        public string? Profession { get; set; }
        public string? Description { get; set; }
        public string? EmergencySpecialNote { get; set; } 

        public static EmergencyContactDto EmergencyContactToEmergencyContactDto(EmergencyContact emergencyContact)
        {
            var em_contact = new EmergencyContactDto(
                emergencyContact.EmergencyContactId,
                emergencyContact.EmergencyContactNumber!,
                emergencyContact.HospitalName!,
                emergencyContact.PersonName!,
                emergencyContact.Profession!,
                emergencyContact.Description!,
                emergencyContact.EmergencySpecialNote!
            )
            {
                EmergencyContactId = emergencyContact.EmergencyContactId,
                EmergencyContactNumber = emergencyContact.EmergencyContactNumber!,
                HospitalName = emergencyContact.HospitalName,
                PersonName = emergencyContact.PersonName,
                Profession = emergencyContact.Profession,
                Description = emergencyContact.Description,
                EmergencySpecialNote = emergencyContact.EmergencySpecialNote
            };
            return em_contact;
        }

        public static EmergencyContact EmergencyContactDtoToEmergencyContact(EmergencyContactDto emergencyContactDto) =>
        new()
        {
            EmergencyContactId = emergencyContactDto.EmergencyContactId,
            EmergencyContactNumber = emergencyContactDto.EmergencyContactNumber,
            HospitalName = emergencyContactDto.HospitalName,
            PersonName = emergencyContactDto.PersonName,
            Profession = emergencyContactDto.Profession,
            Description = emergencyContactDto.Description,
            EmergencySpecialNote = emergencyContactDto.EmergencySpecialNote
        };
    }

}