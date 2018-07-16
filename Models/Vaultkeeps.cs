using System;

namespace Keepr.Models
{   
    public class VaultKeeps
    {
        public int Id { get; set; }
        public int vaultId {get; set; }
        public int keepId {get; set; }
        public string userId {get; set; }
    }
}