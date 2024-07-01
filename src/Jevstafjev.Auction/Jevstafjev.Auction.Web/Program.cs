using Jevstafjev.Auction.Web.Definitions.Base;

var builder = WebApplication.CreateBuilder(args);
builder.AddDefinitions(typeof(Program));

var app = builder.Build();
app.UseDefinitions();

app.Run();
