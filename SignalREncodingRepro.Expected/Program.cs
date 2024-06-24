using System.Text.Encodings.Web;
using System.Text.Json;

var options = new JsonSerializerOptions
{
    Encoder = JavaScriptEncoder.Default
};

var json = JsonSerializer.Serialize(
    new Person("Joey", "<script>alert('Bad Guy');</script>"),
    options
);

Console.WriteLine(json);
Console.ReadLine();