open System.Diagnostics
open System.IO

[<Literal>]
let Constant = "compile-time string"

// this is a line comment
let rec getAllFilesWithin baseFolder =
  seq {
    yield! Directory.GetFiles baseFolder
    for subDir in Directory.GetDirectories baseFolder do
      yield! getAllFilesWithin subDir
  }

let exec program args =
  let startInfo =
    ProcessStartInfo(
      FileName = program,
      Arguments = args,
      UseShellExecute = true)

  let proc = Process.Start startInfo
  proc.WaitForExit()
