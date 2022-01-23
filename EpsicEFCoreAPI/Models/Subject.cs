global using System.ComponentModel.DataAnnotations;
global using System.Text.Json.Serialization;

namespace EpsicEFCoreAPI
{
    public class Subject
    {
        [Key]
        public int Id_Subject { get; set; }
        public string Name_Subject { get; set; } = string.Empty;
        [JsonIgnore]
        public User User { get; set; } 

        public int UserId { get; set; }

        public List<Result> Results { get; set; }
    }
}
