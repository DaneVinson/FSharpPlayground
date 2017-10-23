module Giraffe1.App

open System
open System.IO
open System.Collections.Generic
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe.HttpContextExtensions
open Giraffe.HttpHandlers
open Giraffe.Middleware
open Giraffe.Razor.HttpHandlers
open Giraffe.Razor.Middleware
open Giraffe.Tasks
open Giraffe1.HttpActions
open Domain.Model
open Giraffe1.Models

// let postMessage =
//     fun (next : HttpFunc) (ctx : HttpContext) ->
//         task {
//             let! message = ctx.BindJson<Message>()
//             return! text "Message posted!" next ctx
//         }

// let postWeapon =
//     fun (next : HttpFunc) (ctx : HttpContext) ->
//         task {
//             let! weapon = ctx.BindJson<Weapon>()
//             let message = String.Format("Posted weapon {0}", weapon.Name);
//             return! text message next ctx
//         }

// Web app
let webApp =
    choose [
        GET >=>
            choose [
                route "/" >=> razorHtmlView "Index" { Text = "Dane's Giraffe" }
                route "/api/message" >=> json { Text = "Something anyway" }
                route "/api/sword" >=> json { Id = 1; Name = "Stormbringer"; Type = "Bastard Sword" } ]
        POST >=>
            choose [ 
                route "/api/weapon" >=> postWeapon
                route "/api/message" >=> postMessage ]
        setStatusCode 404 >=> text "Not Found" ]

// Error handler
let errorHandler (ex : Exception) (logger : ILogger) =
    logger.LogError(EventId(), ex, "An unhandled exception has occurred while executing the request.")
    clearResponse >=> setStatusCode 500 >=> text ex.Message

// Config
let configureApp (app : IApplicationBuilder) =
    app.UseGiraffeErrorHandler errorHandler
    app.UseStaticFiles() |> ignore
    app.UseGiraffe webApp

// Services
let configureServices (services : IServiceCollection) =
    let sp  = services.BuildServiceProvider()
    let env = sp.GetService<IHostingEnvironment>()
    let viewsFolderPath = Path.Combine(env.ContentRootPath, "Views")
    services.AddRazorEngine viewsFolderPath |> ignore

// Logging
let configureLogging (builder : ILoggingBuilder) =
    let filter (l : LogLevel) = l.Equals LogLevel.Error
    builder.AddFilter(filter).AddConsole().AddDebug() |> ignore

[<EntryPoint>]
let main argv =
    let contentRoot = Directory.GetCurrentDirectory()
    let webRoot     = Path.Combine(contentRoot, "WebRoot")
    WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(contentRoot)
        .UseIISIntegration()
        .UseWebRoot(webRoot)
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .ConfigureLogging(configureLogging)
        .Build()
        .Run()
    0