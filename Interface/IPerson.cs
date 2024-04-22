using BlueGrassDigital.Models.Person;

namespace BlueGrassDigital.Interface
{
    public interface IPerson
    {
        public Task<List<PersonResponse>> GetAllPerson(string text);
    }
}
