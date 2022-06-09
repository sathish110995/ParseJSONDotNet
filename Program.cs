using Newtonsoft.Json;
using System.Text.Json;

parseJSON();
Console.ReadLine();

void parseJSON()
{
    string searchCondition = "";
    string jsonString = @"{
                           ""searchCriteria"": {
                                               ""Context"": {
                                                           ""ChannelId"": 68719479780,
                                                           ""CatalogId"": 0
                                                              },
                                               ""Refinement"": [
                                               ],
                                               ""IncludeAttributes"": true,
                                               ""SkipVariantExpansion"": true,
                                               ""SearchCondition"": ""history""
                                               }
                           }";


    using JsonDocument doc = JsonDocument.Parse(jsonString);
    var parentElement = doc.RootElement.GetProperty("searchCriteria");
    var props = parentElement.EnumerateObject();

    while (props.MoveNext())
    {
        var prop = props.Current;
        switch (prop.Name) {
            case "SearchCondition":
                searchCondition = prop.Value.ToString();
                break;
        }
    }

    var outputJSON = new
    {
        count = true,
        search = searchCondition
    };

    string jsonData = JsonConvert.SerializeObject(outputJSON);
    Console.WriteLine(jsonData);
}
