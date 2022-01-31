namespace EpsicEFCoreAPI.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SubjectViewModel> Subjects { get; set; }

    }
}
