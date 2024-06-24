using Microsoft.AspNetCore.SignalR;
using System.Text.Encodings.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSignalR()
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.Encoder = JavaScriptEncoder.Default;
    });

var app = builder.Build();
app.MapHub<PersonHub>("/person");
app.Run();

public class PersonHub : Hub
{
    public Person GetPerson()
        => new Person("Joey", "<script>alert('Bad Guy');</script>");
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}