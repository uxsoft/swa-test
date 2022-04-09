module PlanningPoker.Server.Program

open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

[<EntryPoint>]
let main argv =
    let host =
        HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(fun s -> ())
//                s.AddSingleton<IHttpResponderService, DefaultHttpResponderService>())
            .Build()

    host.Run()
    0