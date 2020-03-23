// Learn more about F# at http://fsharp.org
module fsharpworker.App

open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let host =
        Host.CreateDefaultBuilder(argv)
            .ConfigureServices(fun hostContext services -> 
                services.AddHostedService<fsharpworker.Workers.Worker>() |> ignore
            ).Build().Run()
    
    0 // return an integer exit code
