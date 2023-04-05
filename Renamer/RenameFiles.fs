namespace Renamer

open System.IO
open System

module Files =
    let Rename sequenceOfFiles oldpart newpart = 
        let mutable doneFiles = []
        for oldFile in sequenceOfFiles do
            if not (File.Exists(oldFile)) then
                let warning = $"Can not find {oldFile}" 
                doneFiles <- [warning] |> List.append doneFiles ;
            else
                let newFile = oldFile.Replace(oldpart, newpart, StringComparison.OrdinalIgnoreCase)
                let changed = newFile.CompareTo(oldFile) <> 0
                if changed then
                    System.IO.File.Move(oldFile, newFile)
                    doneFiles <- [newFile] |> List.append doneFiles
                else
                    doneFiles <- [$"Part '{oldpart}' not found in file '{oldFile}'"] |> List.append doneFiles

        doneFiles