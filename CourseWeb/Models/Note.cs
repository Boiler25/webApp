using System;
using System.Collections.Generic;

namespace CourseWeb.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }

        public User User { get; set; }
    }
}
