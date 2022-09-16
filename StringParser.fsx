module StringParser =
    open System
    open System.Globalization

    let parseWith (tryParseFunc: string -> bool * _) =
        tryParseFunc >> function
        | true, v    -> Some v
        | false, _   -> None

    let parseInt16WithCulture          cul = parseWith (fun str -> Int16.TryParse(str, NumberStyles.Currency, cul))
    let parseInt32WithCulture          cul = parseWith (fun str -> Int32.TryParse(str, NumberStyles.Currency, cul))
    let parseInt64WithCulture          cul = parseWith (fun str -> Int64.TryParse(str, NumberStyles.Currency, cul))
    let parseIntWithCulture            cul = parseInt32WithCulture cul
    let parseFloatWithCulture          cul = parseWith (fun str -> Double.TryParse(str, NumberStyles.Currency, cul))
    let parseDecimalWithCulture        cul = parseWith (fun str -> Decimal.TryParse(str, NumberStyles.Currency, cul))
    let parseDateTimeWithCulture       cul = parseWith (fun str -> DateTime.TryParse(str, cul, DateTimeStyles.AllowWhiteSpaces ||| DateTimeStyles.RoundtripKind))
    let parseDateTimeOffsetWithCulture cul = parseWith (fun str -> DateTimeOffset.TryParse(str, cul, DateTimeStyles.AllowWhiteSpaces ||| DateTimeStyles.RoundtripKind))
    let parseTimeSpanWithCulture       cul = parseWith (fun str-> TimeSpan.TryParse(str, cul))

    let parseInt16          = parseInt16WithCulture CultureInfo.CurrentUICulture
    let parseInt32          = parseInt32WithCulture CultureInfo.CurrentUICulture
    let parseInt64          = parseInt64WithCulture CultureInfo.CurrentUICulture
    let parseInt            = parseIntWithCulture CultureInfo.CurrentUICulture
    let parseFloat          = parseFloatWithCulture CultureInfo.CurrentUICulture
    let parseDecimal        = parseDecimalWithCulture CultureInfo.CurrentUICulture
    let parseDateTime       = parseDateTimeWithCulture CultureInfo.CurrentUICulture
    let parseDateTimeOffset = parseDateTimeOffsetWithCulture CultureInfo.CurrentUICulture
    let parseTimeSpan       = parseTimeSpanWithCulture CultureInfo.CurrentUICulture
    let parseBoolean        = parseWith Boolean.TryParse
    let parseGuid           = parseWith Guid.TryParse