using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task4_userAPI.Models
{
    public class user :baseMode
    {
        public string fname { get; set; } = String.Empty;
        public string lname { get; set; } = String.Empty;
        public ICollection<post> posts { get; set; }   
    }
}
