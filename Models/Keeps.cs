using System;

namespace Keepr.Models
{   
    public class Keep
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public bool IsPublic { get; set; }
    }
}