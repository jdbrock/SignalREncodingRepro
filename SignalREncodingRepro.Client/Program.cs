using Microsoft.AspNetCore.SignalR.Client;

await Task.Delay(5000);

var client = new HubConnectionBuilder()
    .WithUrl("http://localhost:5065/person")
    .Build();

await client.StartAsync();

var json = await client.InvokeAsync<object>("GetPerson");

Console.WriteLine(json);
Console.ReadLine();