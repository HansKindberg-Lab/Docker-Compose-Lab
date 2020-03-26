# Build image

Just to get certificates and configuration in the image. I would like to handle this with docker-compose config and secret but do not know how to do that for **Azure App Service Docker Compose**.

- https://hub.docker.com/_/httpd

If you want to run apache directly

	docker run -p 8099:80 httpd

Then browse to http://localhost:8099, it works.

Get the default config

	docker run --rm httpd cat /usr/local/apache2/conf/httpd.conf > default-apache.conf

## apache.conf

This is just a reminder how I came up with the apache.conf file as a "newbie". I like manually merged these two:

- https://cwiki.apache.org/confluence/display/HTTPD/Minimal+Config
- the default httpd.conf when starting a container from the https://hub.docker.com/_/httpd image

If you run the following command you start a container with the https://hub.docker.com/_/httpd image:

	docker run -h my.httpd.com --name httpd -p 8099:80 httpd:latest

When the container is started you have the default /usr/local/apache2/conf/httpd.conf.

Then I have googled for setting upp ssl, proxy and mtls.

## Certificates

- [Read more](/Source/Apache/Certificates/ReadMe.md)