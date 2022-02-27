using System;
using System.Linq;
using System.Net.NetworkInformation;
using Common.Models;

namespace Common.BusinessLogic
{
    public class SQLVisitInfo : VisitInfo
    {
        private static int _id = 0;

        public int Id { get; set; }

        public SQLVisitInfo()
        {
            Id = _id++;
            Date = DateTime.Now;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            MACAddress = (from nic in networkInterfaces
                          where nic.OperationalStatus == OperationalStatus.Up
                          select nic.GetPhysicalAddress().ToString())
                         .FirstOrDefault();
        }
    }
}