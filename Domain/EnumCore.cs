namespace Domain
{
    public class EnumCore
    {
        public enum LicenseStatus : byte
        {
            Active = 0,
            Disabled = 1,
        }
        public enum TypeQuestion : byte
        {
            TrueFalse = 0,
            Question5 = 1,
            Question10 = 2,
            Choose = 3,
            MultiChoose = 4,
        }

        public enum Status_Question : byte
        {
            New = 0,
            Diseible = 1,
            Active =2,
        }
    }
}