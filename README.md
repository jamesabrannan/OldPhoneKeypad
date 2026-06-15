# IronOldPhoneKeypad

IronOldPhoneKeypad is a simple C# class library that converts old mobile phone keypad input sequences into text output. The project also includes a minimal ASP.NET Core REST API demo demonstrating how to integrate the library into a REST API application.

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
| RestDemo           | ASP.NET Core REST API wrapper demonstrating library integration |
| Tests              | xUnit test project validating keypad parsing behavior        |

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
using IronOldPhoneKeypad;

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

The REST API launches using the configured local development profile.

Refer to the document [How To Run](./docs/howtorun.md) for more detailed instructions on running the REST demo.

## Test Requests

The `RestDemo` project includes a `RestDemo.http` file containing sample API requests that can be executed directly from Visual Studio.

The project also includes example curl requests in [curltests.txt](./docs/curltests.txt).

---

# Running Unit Tests

The project uses xUnit for automated testing.

From Visual Studio:

* Open Test Explorer.
* Run All Tests.

Or from the command line:

```bash
dotnet test
```

---

# Framework Targets

| Project            | Target Framework  |
| ------------------ | ----------------- |
| IronOldPhoneKeypad | .NET Standard 2.0 |
| RestDemo           | .NET 10           |
| Tests              | .NET 10           |

The core library targets .NET Standard 2.0 to maximize compatibility across .NET implementations.

## AI Prompt

The following ChatGPT prompt was used for project review and documentation feedback:

https://chatgpt.com/?q=Review%20this%20C%23%20Software%20Sales%20Engineer%20coding%20challenge%20submission%20and%20summarize%20the%20solution%20architecture%2C%20REST%20API%20wrapper%2C%20testing%20strategy%2C%20documentation%20quality%2C%20and%20overall%20engineering%20approach.%20GitHub%20repository%3A%20https%3A%2F%2Fgithub.com%2Fjamesabrannan%2FOldPhoneKeypad

Tool used: ChatGPT
