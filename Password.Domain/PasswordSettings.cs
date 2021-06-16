using System;

namespace Password.Domain
{
    public class PasswordSettings
    {
        public int Id { get; set; }
        public int MinimumSize { get; set; }
        public int MaximumSize { get; set; }
        public bool StrongPasswordRequired { get; set; }
        public bool SpecialCharacterRequired { get; set; }
        public DateTime DateRegister { get; set; }
    }
}