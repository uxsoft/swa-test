namespace Api

open Microsoft.Azure.Functions.Worker
open Microsoft.Extensions.Logging

//module Negotiate =
    
//    [<Function("Negotiate")>]
//    let run 
//        ([<HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)>] req: HttpRequest) 
//        ([<SignalRConnectionInfo(HubName = "serverless")>] connectionInfo: SignalRConnectionInfo)
//        (log: ILogger) =
//            connectionInfo