module Giraffe1.HttpActions

open System
open Microsoft.AspNetCore.Http
open Giraffe.HttpHandlers
open Giraffe.HttpContextExtensions
open Giraffe.Tasks
open Domain.Model
open Giraffe1.Models

let postMessage =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let! message = ctx.BindJson<Message>()
            return! text "Message posted!" next ctx
        }

let postWeapon =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let! weapon = ctx.BindJson<Weapon>()
            let message = String.Format("Posted weapon {0}", weapon.Name);
            return! text message next ctx
        }
