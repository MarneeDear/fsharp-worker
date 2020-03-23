namespace chickadee.giraffeworker

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
                    
            } |> ignore

            // I have to put this WriteLineAsync here or I can't compile due to this error
            //This expression was expected to have type
            //            'Task'    
            //but here has type
            //            'unit'
            Console.Out.WriteLineAsync(String.Empty)
