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
                .ToList();

            return people;

        }

        public void InsertPerson(Person person) 
        {
            var context = new KrunchypaymentsContext();
            context.People.Add(person);

            context.SaveChanges();
        }
    }
}
