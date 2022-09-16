module Http =
    open System
    open System.Net
    open System.Net.Http

    type RequestFailure =
        { Url : Uri
          StatusCode : HttpStatusCode option
          Message : string }

    let private client =
        let handler = new HttpClientHandler()
        handler.AutomaticDecompression <- DecompressionMethods.GZip ||| DecompressionMethods.Deflate
        new HttpClient(handler)

    let newRequest method url headers body =
        let req = new HttpRequestMessage()
        req.Method <- method
        req.RequestUri <- Uri(url, UriKind.Absolute)

        for k, v in headers do
            req.Headers.Add(name = k, value = v)

        match body with
        | None -> ()
        | Some body ->
            req.Content <- new StringContent (body)
            headers
            |> List.tryFind (fun (name, _) -> String.Equals(name,"Content-Type", StringComparison.OrdinalIgnoreCase))
            |> Option.iter (fun (_, contentType) -> req.Content.Headers.ContentType.MediaType <- contentType)

        req

    let sendRequest req =
        try
            let resp = client.Send(req)

            if resp.StatusCode = HttpStatusCode.OK then
                Ok resp
            else
                Error {
                    Url = req.RequestUri
                    StatusCode = Some resp.StatusCode
                    Message = string resp.StatusCode }

        with
        | :? HttpRequestException as e ->
            Error {
                Url = req.RequestUri
                StatusCode = Option.ofNullable e.StatusCode
                Message = e.Message }

    let responseBody (resp : HttpResponseMessage) =
        resp.Content.ReadAsStringAsync().RunSynchronously

    let get url headers =
        newRequest HttpMethod.Get url headers None
        |> sendRequest

    let post url headers body =
        newRequest HttpMethod.Post url headers (Some body)
        |> sendRequest