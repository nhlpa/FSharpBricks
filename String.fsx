[<RequireQualifiedAccess>]
module String =
    open System
    open System.Globalization
    open System.Text

    let private textInfo = CultureInfo.InvariantCulture.TextInfo

    let equals (s1 : string, s2 : string) =
        s1.Equals(s2, StringComparison.OrdinalIgnoreCase)

    let isEmpty (x : string) =
        String.IsNullOrWhiteSpace(x)

    let isNotEmpty (x : string) =
        not(isEmpty x)

    let replace (find : string, replace : string) (x : string) =
        x.Replace(find, replace)

    let replacePattern (pattern, replace) (x : string) =
        RegularExpressions.Regex.Replace(input = x, pattern = pattern, replacement = replace)

    let substring (startIndex, length) (x : string) =
        x.Substring(startIndex, length)

    let substringFrom startIndex (x : string) =
        x.Substring(startIndex)

    let chop length (x : string) =
        if x.Length <= length then x
        else
            x
            |> substring (0, length)
            |> fun x -> String.Concat [x; "..."]

    let toTitleCase (x : string) =
        textInfo.ToTitleCase x

    let toLower (x : string) =
        textInfo.ToLower x

    let toUpper (x : string) =
        textInfo.ToUpper x

    let trim (x : string) =
        x.Trim()