using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.NetworkInformation;

namespace Common.Models
{
    public class Visitor
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public IPAddress IP { get; set; }

        [Required]
        public PhysicalAddress MACAddress { get; set; }
    }
}
