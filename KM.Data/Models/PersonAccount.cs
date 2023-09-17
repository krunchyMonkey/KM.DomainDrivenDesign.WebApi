using KM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Models
{
    public class PersonAccount
    {
        public Guid PersonId { get; set; }
        public Guid AccountId { get; set; }
    }
}
