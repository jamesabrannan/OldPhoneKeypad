# IronOldPhoneKeypad

IronOldPhoneKeypad is a simple C# class library that converts old mobile phone keypad input sequences into text output. The project also includes a minimal ASP.NET Core REST API demo showing how the library can be integrated into a web application.

## Installation

Clone the repository:

```bash
git clone https://github.com/jamesabrannan/OldPhoneKeypad.git
```

Build the solution:

```bash
dotnet build
```

## API Summary

```json
{
  "library": "IronOldPhoneKeypad",
  "namespace": "IronOldPhoneKeypad",
  "class": "PhoneKeypad",
  "method": "OldPhonePad",
  "methodType": "static",
  "example": "PhoneKeypad.OldPhonePad(\"4433555 555666#\")",
  "returns": "HELLO"
}
```
## Library Usage

```csharp
using IronOldPhoneKeypad;

string result = PhoneKeypad.OldPhonePad("4433555 555666#");

// HELLO
```

### Example Inputs

| Input           | Output |
| --------------- | ------ |
| 33#             | E      |
| 227*#           | B      |
| 4433555 555666# | HELLO  |
| 222 2 22#       | CAB    |

## REST API Quick Start

Endpoint:

```http
POST /api/ironoldphonekeypad/oldphonepad
```

Example Request:

```json
{
  "input": "4433555 555666#"
}
```

Example Response:

```json
{
  "input": "4433555 555666#",
  "output": "HELLO"
}
```

## Solution Structure

```text
IronOldPhoneKeypadSolution
│
├── src
│   ├── IronOldPhoneKeypad
│   └── RestDemo
│
├── tests
│   └── Tests
│
└── docs
```

### Projects

| Project            | Description                                                  |
| ------------------ | ------------------------------------------------------------ |
| IronOldPhoneKeypad | Core reusable keypad parsing library targeting .NET Standard 2.0 |
| RestDemo           | ASP.NET Core REST API demonstrating library integration      |
| Tests              | xUnit test project validating keypad parsing behavior        |

---

## Old Phone Keypad Rules

The keypad mappings follow the traditional mobile phone keypad layout:

| Key | Letters |
| --- | ------- |
| 2   | ABC     |
| 3   | DEF     |
| 4   | GHI     |
| 5   | JKL     |
| 6   | MNO     |
| 7   | PQRS    |
| 8   | TUV     |
| 9   | WXYZ    |

### Special Characters

| Character | Description                          |
| --------- | ------------------------------------ |
| Space     | Pause between repeated key sequences |
| *         | Backspace/delete previous character  |
| #         | Terminates input                     |

---

## REST API Demo

The solution includes a minimal ASP.NET Core REST API project. The REST API project is intentionally thin and delegates all parsing logic to the reusable core library.

### Endpoint

```http
POST /api/ironoldphonekeypad/oldphonepad
```

### Request

```json
{
  "input": "4433555 555666#"
}
```

### Response

```json
{
  "input": "4433555 555666#",
  "output": "HELLO"
}
```

### Validation Rules

- Input must terminate with `#`
- Consecutive repeated keys require spaces
- `*` acts as backspace

### Error Responses

The API returns standard HTTP status codes along with a JSON error response body.

| Status Code | Description      |
| ----------- | ---------------- |
| 200         | Successful parse |
| 400         | Invalid input    |

Example error response:

```json
{
  "error": "Input must contain the '#' terminator."
}
```

---

## Running the REST Demo

### Visual Studio

1. Open the solution
2. Set `RestDemo` as the startup project
3. Press `F5` or `Ctrl+F5`

The REST API launches using the configured local development profile.

Refer to the document [How To Run](./docs/howtorun.md) for more detailed instructions on running the REST demo.

### Test Requests

The `RestDemo` project includes a `RestDemo.http` file containing sample API requests that can be executed directly from Visual Studio.

### Example curl Request

The project also includes example curl requests in [curltests.txt](./docs/curltests.txt).

```bash
curl -X POST https://localhost:5001/api/ironoldphonekeypad/oldphonepad \
-H "Content-Type: application/json" \
-d "{\"input\":\"4433555 555666#\"}"
```

---

## Running Unit Tests

The project uses xUnit for automated testing.

From Visual Studio:

* Open Test Explorer.
* Run All Tests.

Or from the command line:

```bash
dotnet test
```

---

## Framework Targets

| Project            | Target Framework  |
| ------------------ | ----------------- |
| IronOldPhoneKeypad | .NET Standard 2.0 |
| RestDemo           | .NET 10           |
| Tests              | .NET 10           |

The core library targets .NET Standard 2.0 to maximize compatibility across .NET implementations.
