using KM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Km.Data.Interface
{
    public interface IKrunchyPaymentsRepository
    {
        List<Person> FetchPerson();
    }
}
