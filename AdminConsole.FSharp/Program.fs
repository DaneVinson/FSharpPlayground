
open System
open Domain.Model

let getArmory (name : string) =
    match name with
        | "fantasy" -> FantasyArmory() :> IArmory
        | _ -> SciFiArmory() :> IArmory

[<EntryPoint>]
let main argv =
    let armory = getArmory "fantasy"
    armory.GetWeapons() |> Seq.iter(fun w -> printfn "%s" (w.ToString()))
    0
