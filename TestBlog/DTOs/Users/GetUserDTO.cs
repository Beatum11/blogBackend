namespace TestBlog.DTOs.Users
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Age { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int PostCount { get; set; }

    }
}
