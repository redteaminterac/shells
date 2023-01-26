import ssl
import socket

context = ssl.create_default_context()
context.check_hostname = False
context.verify_mode = ssl.CERT_NONE

while True:
    cmd = input('$ ')
    if cmd == "exit":
        break
    else:
        s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        ssl_sock = context.wrap_socket(s, server_hostname='127.0.0.1')
        ssl_sock.connect(('127.0.0.1', 4443))
        ssl_sock.send(cmd.encode())
        print(ssl_sock.recv(1024).decode())
        ssl_sock.close()
