# Build image

Just to get certificates and configuration in the image. I would like to handle this with docker-compose config and secret but do not know how to do that for **Azure App Service Docker Compose**.

- https://hub.docker.com/_/httpd

If you want to run apache directly

	docker run -p 8099:80 httpd

Then browse to http://localhost:8099, it works.

Get the default config

	docker run --rm httpd cat /usr/local/apache2/conf/httpd.conf > default-apache.conf