using BlueGrassDigital.Models.Person;

namespace BlueGrassDigital.Models.Admin
{
    public class ChangedModel
    {
        public PersonResponse Original { get; set; }
        public PersonEdit Changed { get; set; }
        public List<string> ChangedProperties { get; set; }
    }
}
