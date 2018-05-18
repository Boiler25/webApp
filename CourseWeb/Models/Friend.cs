using System;
using System.Collections.Generic;

namespace CourseWeb.Models
{
    public partial class Friend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public User User { get; set; }
    }
}
