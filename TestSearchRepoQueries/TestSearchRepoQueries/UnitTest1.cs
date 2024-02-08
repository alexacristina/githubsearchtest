using System.Diagnostics;
using System.Net;
using Octokit;
using System.Text.Json;
using Newtonsoft.Json;

namespace TestSearchRepoQueries;

public class Repository
{
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("pushed_at")]
    public DateTime PushedAt { get; set; }
    [JsonProperty("id")]
    public Int64 Id { get; set; }
    [JsonProperty("node_id")]
    public string? NodeId {get; set;}
    [JsonProperty("full_name")]
    public string? FullName {get; set;}

    
}

public class RepositoriesResult
{
    [JsonProperty("total_count")]
    public int TotalCount { get; set; }
    [JsonProperty("incomplete_results")]
    public bool IncompleteResults { get; set; }
    [JsonProperty("items")]
    public List<Repository>? Repositories { get; set; }
}

public class EndPointAddress
{
    private static string HttpAddress = "https://api.github.com/";
    public static string EndPointUri = "search/repositories";

    public RestClient Client;

    private static EndPointAddress instance = null;

    public static EndPointAddress Instance{
        get {
            if (instance == null)
            {
                instance = new EndPointAddress();
            }
            return instance;
        }
    }

    private EndPointAddress()
    {
        Client = new RestClient(HttpAddress);
    }

    private void Dispose()
    {
        Client.Dispose();
    }

    ~EndPointAddress()
    {
        Dispose();
    }

} 

public class Tests
{

    [OneTimeSetUp]
    public void StartTest()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
    }

    [OneTimeTearDown]
    public void EndTest()
    {
        Trace.Flush();
    }

    [Test]
    public void TetrisCSharpCount()
    {
        RestRequest request = new RestRequest(EndPointAddress.EndPointUri, Method.Get);
        request.AddHeader("Accept", "application/vnd.github+json");

        request.AddParameter("q", "tetris language:csharp");
        
        RestResponse response = EndPointAddress.Instance.Client.Execute(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

         var jsonSerializerSettings = new JsonSerializerSettings();
        jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

        Assert.NotNull(response.Content);
        var repositoriesResult = 
            JsonConvert.DeserializeObject<RepositoriesResult>(response.Content, jsonSerializerSettings) ;

        Assert.NotNull(repositoriesResult);

        Assert.That(repositoriesResult.TotalCount, Is.EqualTo(4588));
    }

    [Test]
    public void TetrisCSharpOrderedByUpdated()
    {
        RestRequest request = new RestRequest(EndPointAddress.EndPointUri, Method.Get);
        request.AddHeader("Accept", "application/vnd.github+json");

        request.AddParameter("q", "tetris language:csharp");
        request.AddParameter("sort", "updated");
        request.AddParameter("order", "asc" );

        RestResponse response = EndPointAddress.Instance.Client.Execute(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        var jsonSerializerSettings = new JsonSerializerSettings();
        jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

        Assert.NotNull(response.Content);
        var repositoriesResult = 
            JsonConvert.DeserializeObject<RepositoriesResult>(response.Content, jsonSerializerSettings) ;

        Assert.NotNull(repositoriesResult);

        Assert.NotNull(repositoriesResult.Repositories);

        Trace.WriteLine(repositoriesResult.Repositories.Count());
        repositoriesResult.Repositories.ForEach(_ => 
            Trace.WriteLine(string.Join(" ", _.FullName, _.PushedAt.ToLongDateString())));
        
        Assert.That(repositoriesResult.Repositories, Is.Ordered.By("PushedAt"));
    }
}