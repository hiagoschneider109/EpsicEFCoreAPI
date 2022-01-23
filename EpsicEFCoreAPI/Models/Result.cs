

namespace EpsicEFCoreAPI
{
    public class Result
    {
        [Key]
        public int Id_Result { get; set; }
        public double Num_Result { get; set; }
        [JsonIgnore]
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        
    }
}
