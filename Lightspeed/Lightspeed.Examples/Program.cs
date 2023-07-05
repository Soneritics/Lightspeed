using Lightspeed.Api.Authorization;
using Lightspeed.Examples.Examples;

Console.WriteLine("Welcome to the Lightspeed.Api examples!");
Console.WriteLine("Provide the credentials to get started");

var apiSecrets = new ApiSecrets()
{
    Cluster = new Cluster(Cluster.ClusterType.Eu),
    Language = new Language(Language.LanguageCode.Nl),
    ApiKey = "",
    ApiSecret = ""
};

var exit = false;
do
{
    Console.ReadKey();
    Console.Clear();
    Console.WriteLine("Pick an example:");
    Console.WriteLine(" 0. Exit");
    Console.WriteLine(" 1. WebhookExample");

    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            var webhookExample = new WebhookExample(apiSecrets);
            await webhookExample.RunAsync();
            break;
        
        default:
            exit = true;
            break;
    }
} while (!exit);
