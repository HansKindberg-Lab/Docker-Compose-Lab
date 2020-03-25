# Create SSL certificate

Using [**mkcert**](https://github.com/FiloSottile/mkcert)

	choco install mkcert

Create

	mkcert -cert-file ssl-certificate.crt -key-file ssl-certificate.key localhost 127.0.0.1 ::1