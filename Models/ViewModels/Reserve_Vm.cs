using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.Models.ViewModels
{
    public class Reserve_Vm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte Age { get; set; }
        public byte RoomNumber { get; set; }
        public DateTime ReserveDateTime { get; set; }
        public string strReserveDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public string strStartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string strEndDateTime { get; set; }
        public IFormFile fileImage { get; set; }
        public string strImage { get; set; }
        public bool Status { get; set; }
    }
}