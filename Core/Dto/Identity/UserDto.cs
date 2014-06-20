using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbi.Core.DTO.Identity
{
    public class UserDto
    {
        #region Properties

        public long Id { get; set; }

        public string Username { get; set; }

        public string Nickname { get; set; }
 
        public EmailDto PrimaryEmail { get; set; }

        public PhoneDto PrimaryPhone { get; set; }

        #endregion Properties
    }
}
