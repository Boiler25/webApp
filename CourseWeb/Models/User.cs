using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CourseWeb.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Friend = new HashSet<Friend>();
            Note = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public ICollection<Friend> Friend { get; set; }
        public ICollection<Note> Note { get; set; }
    }
}
