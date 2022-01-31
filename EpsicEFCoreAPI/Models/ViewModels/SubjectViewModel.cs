namespace EpsicEFCoreAPI.Models
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Subject { get; set; }
        public IEnumerable<ResultViewModel> Results { get; set; }

        
    }
}
