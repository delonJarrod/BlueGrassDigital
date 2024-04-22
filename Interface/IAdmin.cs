using BlueGrassDigital.Models.Admin;
using BlueGrassDigital.Models.Person;

namespace BlueGrassDigital.Interface
{
    public interface IAdmin
    {
        public Task<PersonDetails> AddPerson(PersonDetails data);
        public Task<List<ChangedModel>> ViewChanged();

    }
}
