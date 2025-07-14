
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Have not added any Filters as not mentioned in the handson word file and there was no context for relating previous handson

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();
app.Run();
