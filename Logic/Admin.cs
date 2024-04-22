using BlueGrassDigital.Interface;
using BlueGrassDigital.Models.Admin;
using BlueGrassDigital.Models.Person;
using Newtonsoft.Json;

namespace BlueGrassDigital.Logic
{
    public class Admin : IAdmin
    {

        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<PersonDetails> AddPerson(PersonDetails data)
        {
            try
            {
                var uri = "https://localhost:44370/Admin/Add_Person";

                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(uri),
                    Content = content
                };

                using var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Throw an exception if the request fails

                var body = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON to a list of PersonResponse objects
                var people = JsonConvert.DeserializeObject<PersonDetails>(body);

                return people;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Adding person data", ex);
            }
        }

        public async Task<List<ChangedModel>> ViewChanged()
        {
            try
            {
                var uri = "https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/testing-skqpg/service/myProfileApi/incoming_webhook/GetEdited";

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri)
                };

                using var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Throw an exception if the request fails

                var body = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON to a list of PersonResponse objects
                var people = JsonConvert.DeserializeObject<List<ChangedModel>>(body);

                return people;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching person data", ex);
            }
        }

    }
}
