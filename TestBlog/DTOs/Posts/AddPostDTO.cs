﻿namespace TestBlog.DTOs.Posts
{
    public class AddPostDTO
    {
        public string? Title { get; set; }
        public string? Body { get; set; }

        public int UserId { get; set; }
    }
}
