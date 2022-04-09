﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api;

public static class Negotiate
{
    [FunctionName("negotiate")]
    public static SignalRConnectionInfo Run(
        [HttpTrigger(AuthorizationLevel.Anonymous)]HttpRequest req,
        [SignalRConnectionInfo(HubName = "chat")]SignalRConnectionInfo connectionInfo)
    {
        return connectionInfo;
    }
}