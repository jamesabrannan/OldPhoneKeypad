# HOWTO

The easiest way to run the application and visualize the endpoint is through Visual Studio.

## Assumptions

The following assumptions were made for this demo application:

- Visual Studio 2026 or later is installed with the ASP.NET and .NET workloads
- .NET 10 SDK is installed for the REST demo and test projects
- curl is installed and available from the command line for command-line testing examples
- HTTPS is enabled for the ASP.NET Core REST demo
- If local ASP.NET Core development certificates are not already installed or trusted, Visual Studio or the .NET SDK may prompt to install and trust a local development certificate during first launch

## Running the REST Demo

1. Open the solution in Visual Studio.
2. Set `RestDemo` as the startup project if not already.
3. Press `F5` or `Ctrl+F5`.

The REST API will start locally using the configured development profile.

Default URLs:

```text
https://localhost:7001
http://localhost:5059
```

---

## Sending Requests

The project includes a `RestDemo.http` file containing ready-to-run example requests.

Open the file in Visual Studio.

![fig2](./images/fig2.png)



 and click `Send Request` above any request block.

Example request:

```http
POST https://localhost:7001/api/ironoldphonekeypad/oldphonepad
Content-Type: application/json

{
  "input": "4433555 555666#"
}
```

Example response:

```json
{
  "input": "4433555 555666#",
  "output": "HELLO"
}
```

---

## Running with curl

Example:

```bash
curl -X POST "https://localhost:7001/api/ironoldphonekeypad/oldphonepad" -H "Content-Type: application/json" -d "{\"input\":\"4433555 555666#\"}"
```

---

## Error Handling

Invalid input returns a `400 Bad Request` response.

Example:

```json
{
  "error": "Input must contain the '#' terminator."
}
```
