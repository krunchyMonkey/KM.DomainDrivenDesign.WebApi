using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Km.Data.Interface;
using KM.Data.Models;

namespace KM.DomainDrivenDesign.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IKrunchyPaymentsRepository _krunchyPaymentsRepository;

        public PersonController(IKrunchyPaymentsRepository krunchyPaymentsRepository) 
        {
            _krunchyPaymentsRepository = krunchyPaymentsRepository;
        }

        [HttpGet(Name = "GetPerson")]
        public List<Person> Get() 
        {
            return _krunchyPaymentsRepository.FetchPerson();
        }

        [HttpPost(Name = "AddPerson")]
        public void Post(Person person)
        {
            person.Id = Guid.NewGuid();
            _krunchyPaymentsRepository.InsertPerson(person);
        }
    }
}
