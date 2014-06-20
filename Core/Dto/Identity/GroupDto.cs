using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbi.Core.Dto.Identity
{
    public class GroupDto
    {
        #region Properties

        public long Id { get; set; }

        public string Name { get; set; }

        public IList<long> UserIds { get; set; }

        #endregion Properties
    }
}
