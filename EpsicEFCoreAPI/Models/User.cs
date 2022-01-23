

namespace EpsicEFCoreAPI
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        public string Name_User { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public List<Subject> Subjects { get; set; }
    }
}
