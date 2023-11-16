﻿namespace AvaloniaExample.ViewModels

open System
open Elmish.Avalonia
open Elmish
open App

type CounterViewModel(app: IElmishStore<Model, Msg>) =
    inherit ReactiveViewModel()

    member this.Count = this.Bind(app, _.Count)
    member this.Actions = this.Bind(app, _.Actions)
    member this.Increment() = app.Dispatch Increment
    member this.Decrement() = app.Dispatch Decrement
    member this.Reset() = app.Dispatch ResetCounter
    member this.IsResetEnabled = this.Bind(app, fun m -> m.Count <> 0)

    static member DesignVM = 
        let store = new DesignStore<App.Model, App.Msg>(App.init())
        new CounterViewModel(store)