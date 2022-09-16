# F# Bricks
Reusable "bricks" of F# code for scripting and command development. All of the modules are self-contained, so you can load it into any FSI session and starting using it right away.

The philosophy behind this project is to keep it simple and restrict each "brick" to a single file. Its purpose is to support isimple scripting and console program development, not to address every possible use case ever.

## Usage

### `Log.fsx` && `FileLog.fsx`

```fsharp
Log.info "Hello world!"

Log.fail "I'm meltinggggggg"
```