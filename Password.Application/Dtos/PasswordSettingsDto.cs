using System.Runtime.Serialization;

namespace Password.Application.Dtos
{
    [DataContract]
    public class PasswordSettingsDto
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int MinimumSize { get; set; }
        [DataMember]
        public int MaximumSize { get; set; }
        [DataMember]
        public bool StrongPasswordRequired { get; set; }
        [DataMember]
        public bool SpecialCharacterRequired { get; set; }
    }
}