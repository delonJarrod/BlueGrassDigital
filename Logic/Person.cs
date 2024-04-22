using BlueGrassDigital.Interface;
using BlueGrassDigital.Models.Person;
using Newtonsoft.Json;

namespace BlueGrassDigital.Logic
{
    public class Person : IPerson
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<PersonResponse>> GetAllPerson(string text)
        {
            try
            {
                var uri = "https://localhost:44370/Person/Get_Person";
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri)
                };

                using var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();


                List<PersonResponse> people = JsonConvert.DeserializeObject<List<PersonResponse>>(body);
                if (!string.IsNullOrEmpty(text))
                {
                    var priorityMatches = people
                        .Where(p =>
                            p.FirstName.Equals(text, StringComparison.OrdinalIgnoreCase) ||
                            p.LastName.Equals(text, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    var remainingMatches = people
                        .Except(priorityMatches)
                        .Where(p =>
                            p.AddressCountry.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                            p.AddressCity.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                            p.Gender.Equals(text, StringComparison.OrdinalIgnoreCase) ||
                            p.Email.Contains(text, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    people = priorityMatches.Concat(remainingMatches).ToList();
                }
                else
                {
                    // reverse oder if there is no input to get latest added user
                    people.Reverse();
                }
                return people;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching person data", ex);
            }
        }

    }
}
