namespace fsharpworker

module Workers =

    open System
    open System.Threading
    open System.Threading.Tasks
    open Microsoft.Extensions.Configuration
    open Microsoft.Extensions.Hosting
    open Microsoft.Extensions.Logging
    open FSharp.Control.Tasks.ContextInsensitive
    
    type Worker(logger : ILogger<Worker>, configuration : IConfiguration ) =
        inherit BackgroundService()

        override _.ExecuteAsync(stoppingToken : CancellationToken) =
            task {
                while not stoppingToken.IsCancellationRequested do
                    do! Console.Out.WriteLineAsync("HELLO WORLD")
                    do! Task.Delay(1000, stoppingToken)
                    
            } :> Task
