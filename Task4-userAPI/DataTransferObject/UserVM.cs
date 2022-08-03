using Task4_userAPI.Models;

namespace Task4_userAPI.DataTransferObject
{
    public class UserVM
    {
        public int Id { get; set; }
        public string fname { get; set; } = String.Empty;
        public string lname { get; set; } = String.Empty;
        //public int postId { get; set; }
        public ICollection<int> postId { get; set; }
        //public ICollection<post> posts { get; set; }
    }
}
