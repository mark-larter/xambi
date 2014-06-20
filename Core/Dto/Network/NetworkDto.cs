using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbi.Core.Dto.Network
{
    public class NetworkDto
    {
        #region Properties

		public long Id { get; set; }

        public string FriendlyName { get; set; }

        public List<DeviceDto> DeviceList { get; set; }

        #endregion Properties
    }
}
