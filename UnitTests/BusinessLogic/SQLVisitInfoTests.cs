using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Common.BusinessLogic;
using NUnit.Framework;

namespace UnitTests.BusinessLogic
{
    public class SQLVisitInfoTests
    {
        const int ID = 0;

        static readonly SQLVisitorInfo _sqlVisitInfo = new SQLVisitorInfo(ID);

        [Test]
        public void Constructor_WithIdParameter_CreatesValidInstance()
        {
            Assert.DoesNotThrow(() => new SQLVisitorInfo(ID));
        }

        [Test]
        public void UserId_EqualsIdThatPassedInConstructor()
        {
            Assert.AreEqual(ID, _sqlVisitInfo.Id);
        }

        [Test]
        public void Date_EqualsCurrentTime()
        {
            DateTime currentDate = DateTime.Now;
            DateTime sqlVisitInfoDate = _sqlVisitInfo.Date;

            string expected = $"{currentDate.Year}:{currentDate.Month}:{currentDate.DayOfWeek}:{currentDate.Day}:" +
                $"{currentDate.Hour}:{currentDate.Minute}:{currentDate.Second}";

            var actual = $"{sqlVisitInfoDate.Year}:{sqlVisitInfoDate.Month}:{sqlVisitInfoDate.DayOfWeek}:" +
                $"{sqlVisitInfoDate.Day}:{sqlVisitInfoDate.Hour}:{sqlVisitInfoDate.Minute}:{sqlVisitInfoDate.Second}";

            // This difficulty because different milliseconds on creating two instances

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IP_EqualsIdOfThisPC()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            var expectedIp = (from ip in host.AddressList
                              where ip.AddressFamily == AddressFamily.InterNetwork
                              select ip).First();
        
            Assert.AreEqual(expectedIp, _sqlVisitInfo.IP);
        }

        [Test]
        public void MACAddress_EqualsMACAddressOfThisPC()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            var expectedMACAddress = (from nic in networkInterfaces
                                      where nic.OperationalStatus == OperationalStatus.Up
                                      select nic.GetPhysicalAddress()).FirstOrDefault();

            Assert.AreEqual(expectedMACAddress, _sqlVisitInfo.MACAddress);
        }
    }
}
