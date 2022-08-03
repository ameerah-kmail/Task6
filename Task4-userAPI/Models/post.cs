using System.ComponentModel.DataAnnotations;

namespace Task4_userAPI.Models
{
    public class post : baseMode
    {
        public string Title { get; set; }=String.Empty;
        public user user { get; set; }
        public int userId { get; set; }
    }
}
