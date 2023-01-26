To generate the server private key file (server.key):
```openssl genpkey -algorithm RSA -out server.key -aes256```

To generate the server certificate signing request file (server.csr):
```openssl req -new -key server.key -out server.csr```

To generate the server certificate file (server.crt) from the certificate signing request:
```openssl x509 -req -days 365 -in server.csr -signkey server.key -out server.crt```
