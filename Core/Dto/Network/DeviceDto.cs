using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbi.Core.Dto.Network
{
    public class DeviceDto
    {
        #region Properties

        public long Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string FriendlyName { get; set; }

        public string UserFriendlyName { get; set; }

        public string MacAddress { get; set; }

        public List<string> AlternateMacAddresses { get; set; }

        public string IpAddress { get; set; }

        public string Description { get; set; }

        public string DeviceType { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Version { get; set; }

        public string SerialNumber { get; set; }

        public string ManagementUrl { get; set; }

        public DateTime FirstSeen { get; set; }

        public DateTime LastSeen { get; set; }

        public string ParentKey { get; set; }

        #endregion Properties
    }
}
