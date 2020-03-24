namespace fsharpworker

module Workers =

    open System
    open System.Threading
    open System.Threading.Tasks
    open Microsoft.Extensions.Configuration
    open Microsoft.Extensions.Hosting
    open Microsoft.Extensions.Logging
    open FSharp.Control.Tasks.ContextInsensitive

    let settings (config:IConfiguration) : Settings.MySettingsSection =
        let cnf = config.GetSection("MySettingsSection")
        {
            SettingA = cnf.GetValue("SettingA")
            SettingB = cnf.GetValue("SettingB")
        }
    
    type Worker(logger : ILogger<Worker>, configuration : IConfiguration ) =
        inherit BackgroundService()

        override _.ExecuteAsync(stoppingToken : CancellationToken) =
            let set = settings configuration
            task {
                logger.LogInformation("Starting FSharp Worker")
                logger.LogInformation(sprintf "Setting A %s " set.SettingA)
                logger.LogInformation(sprintf "Setting B %i" set.SettingB)
                while not stoppingToken.IsCancellationRequested do
                    do! Console.Out.WriteLineAsync("HELLO WORLD")
                    do! Task.Delay(1000, stoppingToken)
                    
            } :> Task
