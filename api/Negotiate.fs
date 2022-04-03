namespace Api

open System
open System.IO
open Microsoft.AspNetCore.Mvc
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.AspNetCore.Http
open Microsoft.Azure.WebJobs.Extensions.SignalRService
open Newtonsoft.Json
open Microsoft.Extensions.Logging

module Negotiate =
    
    [<FunctionName("Negotiate")>]
    let run 
        ([<HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)>] req: HttpRequest) 
        ([<SignalRConnectionInfo(HubName = "serverless")>] connectionInfo: SignalRConnectionInfo)
        (log: ILogger) =
            connectionInfo