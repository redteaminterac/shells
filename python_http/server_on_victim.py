import socket
import subprocess

HOST = '127.0.0.1'
PORT = 1234

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((HOST, PORT))
s.listen(1)
print('[*] Listening on {}:{}'.format(HOST, PORT))
conn, addr = s.accept()
print('[*] Connection from: {}'.format(addr))

while True:
    cmd = conn.recv(1024).decode()
    if cmd == 'exit':
        conn.close()
        break
    else:
        output = subprocess.getoutput(cmd)
        conn.send(output.encode())
