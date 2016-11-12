namespace Ionide.VSCode.FSharp

open Fable.Core
open Fable.Import.vscode
open Ionide.VSCode.Helpers

module Formatting =
    let private createProvider () =
        { new DocumentFormattingEditProvider
          with
            member this.provideDocumentFormattingEdits (doc, opts, _) =
                debugger () |> ignore
                promise {
                    return ResizeArray<TextEdit>() 
                } |> Case2
        }
        // -> U2<ResizeArray<TextEdit>, Promise<ResizeArray<TextEdit>>>
    ()

    let activate selector (disposables: Disposable[]) =
        languages.registerDocumentFormattingEditProvider (selector, createProvider())
        |> ignore
        ()
