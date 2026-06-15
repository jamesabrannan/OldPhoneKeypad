using IronOldPhoneKeypad;
using RestDemo.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/ironoldphonekeypad/oldphonepad",
    static async (HttpContext context) =>
    {
        ParseRequest? request;

        try
        {
            request = await JsonSerializer.DeserializeAsync<ParseRequest>(
                context.Request.Body);
        }
        catch (JsonException)
        {
            return Results.BadRequest(new
            {
                error = "Request body must be valid JSON."
            });
        }

        if (request == null)
        {
            return Results.BadRequest(new
            {
                error = "Request body is required."
            });
        }

        string input = request.Input ?? string.Empty;

        try
        {
            string output = PhoneKeypad.OldPhonePad(input);
            return Results.Ok(new ParseResponse(input, output));
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new
            {
                error = ex.Message
            });
        }
    });

app.Run();