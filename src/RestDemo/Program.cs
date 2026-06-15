using IronOldPhoneKeypad;
using RestDemo.Models;
using System.Text.Json;

// Creates the web application builder.
var builder = WebApplication.CreateBuilder(args);

// Adds OpenAPI support for API documentation and testing.
builder.Services.AddOpenApi();

// Builds the web application.
var app = builder.Build();

// Maps the OpenAPI endpoint.
app.MapOpenApi();

// Redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Creates a POST endpoint for converting old phone keypad input into text.
app.MapPost("/api/ironoldphonekeypad/oldphonepad",
    static async (HttpContext context) =>
    {
        ParseRequest? request;

        try
        {
            // Reads and deserializes the JSON request body into a ParseRequest object.
            request = await JsonSerializer.DeserializeAsync<ParseRequest>(
                context.Request.Body,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
        catch (JsonException)
        {
            // Returns a 400 response if the request body contains invalid JSON.
            return Results.BadRequest(new
            {
                error = "Request body must be valid JSON."
            });
        }

        // Ensures a request body was provided.
        if (request == null)
        {
            return Results.BadRequest(new
            {
                error = "Request body is required."
            });
        }

        // Prevents null input values.
        string input = request.Input ?? string.Empty;

        try
        {
            // Converts the old phone keypad input into text.
            string output = PhoneKeypad.OldPhonePad(input);

            // Returns the original input and parsed output.
            return Results.Ok(new ParseResponse(input, output));
        }
        // Return all errors as JSON for demo purposes.
        catch (Exception ex)
        {
            return Results.BadRequest(new
            {
                error = ex.Message
            });
        }
    });

app.Run();