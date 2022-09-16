# F# Bricks
Reusable "bricks" of F# code for scripting and command development. All of the modules are self-contained, so you can load it into any FSI session and starting using it right away.

The philosophy behind this project is to keep it simple and restrict each "brick" to a single file. Its purpose is to support isimple scripting and console program development, not to address every possible use case ever.

## Usage

### `Log.fsx` and `FileLog.fsx`

```fsharp
Log.info "Hello world!"

Log.fail "I'm meltinggggggg"
```

### `Http.fsx`

```fsharp
Http.get "https://www.google.com" []
|> Http.respondBody
|> Result.map (printfn "%s")
|> Result.mapError (printfn "%A)
```

### `Smtp.fsx`

```fsharp
let client = new SmtpClient(host = "smtp.somedomain.com", port = 25)

Smtp.sendMessage client {
    From = MailAddress("noreply@somedomain.com", "Your Name")
    Subject = "An email subject"
    Body = "<p>Hello world</p>"
    Recipients = [ "someone@somedomain.com" ]
    Attachments = [] }
```

### `StringParser.fsx`

```fsharp
open StringParser

match parseInt "87" with
| Some i -> printfn "%i"
| None -> printfn "Invalid #"
```