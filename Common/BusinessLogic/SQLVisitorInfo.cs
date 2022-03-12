using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Common.Models;

using System.ComponentModel.DataAnnotations;

namespace Common.BusinessLogic
{
    public class SQLVisitorInfo : Visitor
    {
        [Required]
        public int Id { get; set; }

        public SQLVisitorInfo(int id)
        {
            Id = id;

            SetDateTime();
            SetMACAdress();
            SetIP();
        }

        private void SetDateTime()
        {
            Date = DateTime.Now;
        }
        private void SetMACAdress()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            MACAddress = (from nic in networkInterfaces
                          where nic.OperationalStatus == OperationalStatus.Up
                          select nic.GetPhysicalAddress()).FirstOrDefault();
        }
        private void SetIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            IP = (from ip in host.AddressList
                  where ip.AddressFamily == AddressFamily.InterNetwork
                  select ip).First();
        }
    }
}