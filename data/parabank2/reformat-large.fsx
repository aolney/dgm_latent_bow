open System.IO

//parabank2 is distributed as a zip archive; reformat without extracting file
let zipArchive = System.IO.Compression.ZipFile.OpenRead("parabank2.zip")
let entry = zipArchive.GetEntry("parabank2.tsv")

let reader = new StreamReader(entry.Open())
let writer = new StreamWriter("train.txt")
let mutable split = null

while not <| reader.EndOfStream do
    split <- reader.ReadLine().Split('\t')
    for i = 2 to split.Length - 1 do
        writer.WriteLine( split.[1] + "\t" + split.[i] )

writer.Flush()
writer.Close()
reader.Close()
