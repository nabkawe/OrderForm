

namespace OrderAppMAUI.Services;

public class SampleDataService
{
    public async Task<IEnumerable<Invoice>> GetItems()
    {
        await Task.Delay(1000); // Artifical delay to give the impression of work

        var printed = new List<Invoice>();


        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        var client = new RestClient(Preferences.Default.Get("IP_Path","404") + "/LoadDB/GetList");
        var request = new RestRequest();
        request.AddParameter("inv", "printed");
        RestResponse response = client.Get(request);
        if (response != null)
        {
            if (response.StatusCode.ToString() == "OK")
            {
                printed = JsonConvert.DeserializeObject<List<Invoice>>(response.Content.ToString());// <Invoice>(item);
                return printed;
            }
            else return printed;

        }
        else return printed;

    }
}
