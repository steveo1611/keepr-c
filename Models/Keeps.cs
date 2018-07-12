using System;

namespace Keepr.Models
{   
    public class Keep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ContentURL { get; set; }
        public string UserId { get; set; }
        public bool IsPublic { get; set; }
        public int viewed { get; set; }
        public int inVault { get; set; }
    }
}