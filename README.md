# OldPhoneKeypad

OldPhoneKeypad is a simple C# class library that converts old mobile phone keypad input sequences into text output. The project also includes a minimal ASP.NET Core REST API demo showing how the library can be integrated into a real-world application.

## Solution Structure

```text
OldPhoneKeypad
│
├── src
│   ├── OldPhoneKeypad
│   └── RestDemo
│
├── tests
│   └── OldPhoneKeypad.Tests
│
├── docs
└── samples
```

### Projects

| Project              | Description                                                      |
| -------------------- | ---------------------------------------------------------------- |
| OldPhoneKeypad       | Core reusable keypad parsing library targeting .NET Standard 2.0 |
| RestDemo             | ASP.NET Core REST API wrapper demonstrating library integration  |
| OldPhoneKeypad.Tests | xUnit test project validating keypad parsing behavior            |

---

# Old Phone Keypad Rules

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

## Special Characters

| Character | Description                          |
| --------- | ------------------------------------ |
| Space     | Pause between repeated key sequences |
| *         | Backspace/delete previous character  |
| #         | Terminates input                     |

---

# Library Usage

```csharp
using OldPhoneKeypad;

string result = PhoneKeypad.OldPhonePad("4433555 555666#");

// HELLO
```

## Example Inputs

| Input           | Output |
| --------------- | ------ |
| 33#             | E      |
| 227*#           | B      |
| 4433555 555666# | HELLO  |
| 222 2 22#       | CAB    |

---

# REST API Demo

The solution includes a minimal ASP.NET Core REST API wrapper project.

## Endpoint

```http
POST /api/ironoldphonekeypad/oldphonepad
```

## Request

```json
{
  "input": "4433555 555666#"
}
```

## Response

```json
{
  "input": "4433555 555666#",
  "output": "HELLO"
}
```

## Error Response

```json
{
  "error": "Input must contain the '#' terminator."
}
```

---

# Running the REST Demo

## Visual Studio

1. Open the solution
2. Set `RestDemo` as the startup project
3. Press `F5` or `Ctrl+F5`

The API will launch using the local development profile.

## Test Requests

The project includes a `RestDemo.http` file containing sample API requests that can be executed directly from Visual Studio.

---

# Running Unit Tests

The project uses xUnit for automated testing.

From Visual Studio:

* Open Test Explorer
* Run All Tests

Or from the command line:

```bash
dotnet test
```

---

# Framework Targets

| Project              | Target Framework  |
| -------------------- | ----------------- |
| OldPhoneKeypad       | .NET Standard 2.0 |
| RestDemo             | .NET 10           |
| OldPhoneKeypad.Tests | .NET 10           |

The core library targets .NET Standard 2.0 to maximize compatibility across .NET implementations.
