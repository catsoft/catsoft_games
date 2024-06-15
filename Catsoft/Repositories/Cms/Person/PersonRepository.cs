using App.cms.Repositories;
using App.Models;
using App.Models.Booking;

namespace App.Repositories.Cms.Person
{
    public class PersonRepository(CatsoftContext catsoftContext)
        : CmsBaseRepository<PersonModel, CatsoftContext>(catsoftContext), IPersonRepository
    {
    }
}