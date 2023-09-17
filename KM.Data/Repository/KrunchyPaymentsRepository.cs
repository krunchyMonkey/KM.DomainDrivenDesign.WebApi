using Km.Data.Interface;
using KM.Data.Models;

namespace Km.Data.Repository
{
    public class KrunchyPaymentsRepository : IKrunchyPaymentsRepository
    {
        public KrunchyPaymentsRepository() { }

        public List<Person> FetchPerson() 
        {
            var context = new KrunchypaymentsContext();

            var people = context
                .People
                .Where(p => p.Id == new Guid("DA9562B2-BD30-414A-B878-19579FFC3043"))
                .ToList();

            return people;

        }
    }
}
