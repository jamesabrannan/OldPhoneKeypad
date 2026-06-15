```bash
# OldPhonePad - HELLO example
curl -X POST "https://localhost:7001/api/ironoldphonekeypad/oldphonepad" -H "Content-Type: application/json" -d "{\"input\":\"4433555 555666#\"}"
```

```bash
C:\>curl -X POST "https://localhost:7001/api/ironoldphonekeypad/oldphonepad" -H "Content-Type: application/json" -d "{\"input\":\"4433555 555666#\"}"
{"input":"4433555 555666#","output":"HELLO"}
```

```bash
# OldPhonePad - Error Example
curl -X POST "https://localhost:7001/api/ironoldphonekeypad/oldphonepad" -H "Content-Type: application/json" -d "{\"input\":\"466\"}"
```

```bash
C:\>curl -X POST "https://localhost:7001/api/ironoldphonekeypad/oldphonepad" -H "Content-Type: application/json" -d "{\"input\":\"466\"}"
{"error":"Input must contain the '#' terminator."}
```

```bash
# OldPhonePad - Not JSON REQUEST Error Example
curl -X POST "https://localhost:7001/api/ironoldphonekeypad/oldphonepad" -H "Content-Type: application/json" -d "\466\"}"
```

