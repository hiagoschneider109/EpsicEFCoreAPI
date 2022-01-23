namespace EpsicEFCoreAPI.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public IEnumerable<SubjectViewModel> Subjects { get; set; }

    }
}
