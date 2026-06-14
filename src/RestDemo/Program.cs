using IronOldPhoneKeypad;
using RestDemo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/ironoldphonekeypad/oldphonepad",
    delegate (ParseRequest request)
    {
        if (request == null)
        {
            return Results.BadRequest("Request body is required.");
        }

        string input = request.Input ?? string.Empty;
        string output = PhoneKeypad.OldPhonePad(input);

        return Results.Ok(new ParseResponse(input, output));
    });

app.Run();