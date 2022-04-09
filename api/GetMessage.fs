namespace Company.Function

open System
open System.IO
open System.Net
open System.Text.Json
open System.Text.Json.Serialization
open Microsoft.Azure.Functions.Worker
open Microsoft.Azure.Functions.Worker.Http
open Microsoft.Extensions.Logging

module GetMessage =
    // Define a nullable container to deserialize into.
    [<AllowNullLiteral>]
    type NameContainer() =
        member val Name = "" with get, set

    // For convenience, it's better to have a central place for the literal.
    [<Literal>]
    let Name = "name"

    [<Function("GetMessage")>]
    let run
        ([<HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)>] req: HttpRequestData)
        (context: FunctionContext)
        =
        async {
            use stream = new StreamReader(req.Body)
            let! reqBody = stream.ReadToEndAsync() |> Async.AwaitTask

            
            let data =
                JsonSerializer.Deserialize<NameContainer>(reqBody)

            let name = req.Url.Query

            let responseMessage =
                if (String.IsNullOrWhiteSpace(name)) then
                    "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                else
                    "Hello, "
                    + name
                    + ". This HTTP triggered function executed successfully."

            let response = req.CreateResponse(HttpStatusCode.OK)
            response.Headers.Add("Date", "Mon, 18 Jul 2016 16:06:00 GMT");
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            
            response.WriteString(responseMessage);
                
            
            return response
        }
        |> Async.StartAsTask
