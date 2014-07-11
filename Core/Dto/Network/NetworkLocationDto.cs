using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbi.Core.Dto.Network
{
    public class NetworkLocationDto
    {
        #region Properties

        public string IpAddress { get; set; }

		public string CountryCode { get; set; }

		public string Country { get; set; }

		public string RegionCode { get; set; }

		public string Region { get; set; }

		public string City { get; set; }

		public string Postal { get; set; }

		public double Lat { get; set; }

		public double Lon { get; set; }

		public string Timezone { get; set; }

		public string Isp { get; set; }

        #endregion Properties
    }
}
