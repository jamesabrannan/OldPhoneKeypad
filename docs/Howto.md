# HOWTO

The easiest way to run the application and visualize the endpoint is through Visual Studio. Follow the steps in this document to successfully run the demo application. You can also use curl to demo the endpoint.

## Assumptions

Running this demo application assumes the following setup configuration.

- Visual Studio 2026 or later is installed with the ASP.NET and .NET workloads.
- .NET 10 SDK is installed for the REST demo and test projects.
- curl is installed and available from the command line for command-line testing examples.
- HTTPS is enabled for the ASP.NET Core REST demo.
- If local ASP.NET Core development certificates are not already installed or trusted, Visual Studio or the .NET SDK may prompt to install and trust a local development certificate during first launch.

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

* Open  `RestDemo.http` in Visual Studio while `RestDemo` is running.

![fig2](./images/fig2.png)



* Click `Send Request` in any request block to execute the request.

### Example Requests

The following three example requests illustrate running the demo application.

#### OldPhonePad - HELLO example

Example request:

![](./images/fig3.png)

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
#### OldPhonePad - invalid input example

Example request:

![](./images/fig4.png)

```http
POST {{RestDemo_HostAddress}}/api/ironoldphonekeypad/oldphonepad
Content-Type: application/json

{
  "input": "44A#"
}
```

Example response:

```json
{
  "error": "Invalid keypad character: A"
}
```
#### OldPhonePad - single character example

Example request:

![](./images/fig5.png)

```http
POST {{RestDemo_HostAddress}}/api/ironoldphonekeypad/oldphonepad
Content-Type: application/json

{
  "input": "33#"
}
```

Example response:

```json
{
  "input": "33#",
  "output": "E"
}
```
---

## Running with curl

If curl is installed, you can also demo the endpoint using curl. Be certain the  `RestDemo` application is running and can accept requests to the endpoint.

To test using curl open the Command Prompt and paste the desired curl command into the command-line.

```bash
curl -X POST "https://localhost:7001/api/ironoldphonekeypad/oldphonepad" -H "Content-Type: application/json" -d "{\"input\":\"222 2 22#\"}""
```

---

## Error Handling

Invalid input and other errors return a `400 Bad Request` response where the error is returned as a JSON response.

```json
{
  "error": "Input must contain the '#' terminator."
}
```
