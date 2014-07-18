using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbi.Core.Dto.Device;

namespace Symbi.Core.Dto.Network
{
    public class NetworkDto
    {
        #region Properties

		public long Id { get; set; }

        public string FriendlyName { get; set; }

		public string NetworkSsid { get; set; }

        public List<DeviceDto> DeviceList { get; set; }

        #endregion Properties
    }
}
