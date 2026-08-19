namespace MiniFacebook.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string userName;
        public string Email;
        public int PasswordHash { get; set; }
        public string? Bio { get; set; }
        public int PhoneNumber;
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        //public string FullName { get; set { FirstName + " " + LastName } }
        //public string userName;
    }
}
