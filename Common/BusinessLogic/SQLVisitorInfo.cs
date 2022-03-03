using System;
using System.Linq;
using System.Net.NetworkInformation;
using Common.Models;

namespace Common.BusinessLogic
{
    public class SQLVisitorInfo : Visitor
    {
        private static int _id = 0;

        public int Id { get; set; }

        public SQLVisitorInfo()
        {
            Id = _id++; // ID должен получаться из BD и увеличиваться максимальный ID

            SetDateTime();
            SetMACAdress();

            //SetLocation();
            //SetBrowser();
            //Device();
            //SetIP(); 
        }

        public void SetDateTime()
        {
            Date = DateTime.Now;
        }

        public void SetMACAdress()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            MACAddress = (from nic in networkInterfaces
                          where nic.OperationalStatus == OperationalStatus.Up
                          select nic.GetPhysicalAddress().ToString())
                         .FirstOrDefault();
        }
    }
}