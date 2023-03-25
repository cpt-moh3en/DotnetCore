using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.Models.Entities
{
    public class Reserve
    {
        [Key]
        public long Id { get; set; }        
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte Age { get; set; }
        public byte RoomNumber { get; set; }
        public DateTime ReserveDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        
    }
}