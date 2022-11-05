# Docker-Compose-Lab



## TEMPORARY - BEGIN

docker build . -f Apache/Dockerfile -t apache:latest
docker build . -f Application/Dockerfile -t application:latest

docker-compose -f "Docker-Compose.Azure.yml" up -d






docker run -h localhost --name apache -p 44399:443 apache:latest

docker run -h localhost --name apache -p 443:443 apache:latest

docker run --name apache -p 443:443 apache:latest

docker-compose -f "Docker-Compose.Azure.yml" up -d

docker run -h my.apache.com --name apache -p 8099:80 apache:latest

docker run -h my.httpd.com --name httpd -p 8099:80 httpd:latest

https://localhost:443

http://localhost:8099

## TEMPORARY - END

















This is a docker compose lab with apache and asp.net core. The apache is a proxy for the asp.net core application. I have choosed apache because as I understand you can set up path-specific MTLS with it. Path-specific MTLS is what I would like to accomplish in another project of mine.

The environment and requirements for this project:

- Environment: **Windows 10**
- Requirements: **Docker Desktop**

## 1 Create local registry to push your images to

 - [Deploy a registry server](https://docs.docker.com/registry/deploying/)

Create a registry listening on port 5555:

	docker run -d -p 5555:5000 --restart=always --name registry registry:2

If you want to list the registry:

	curl -X GET http://localhost:5555/v2/_catalog

	curl -X GET http://localhost:5555/v2/application/tags/list

Stop your registry and remove all data

	docker container stop registry && docker container rm -v registry

## 2 Create docker hub registry to push your images to

 - [Docker Hub Quickstart](https://docs.docker.com/docker-hub/)

## 3 Apache image

- [Read more](/Source/Apache/ReadMe.md)

At the command-prompt, change directory to *C:\Data\Projects\HansKindberg-Lab\Docker-Compose-Lab\Source**

	docker build . -f Apache/Dockerfile -t apache:latest -t localhost:5555/apache:latest -t yourdockerusername/apache:latest

	docker push localhost:5555/apache:latest

	docker login yourdockerusername

	docker push yourdockerusername/apache:latest

If you want to run it (the -h parameter is to avoid ServerName warnings)

	docker run -h my.apache.com --name apache -p 8099:80 apache:latest

## 4 Application image

At the command-prompt, change directory to *C:\Data\Projects\HansKindberg-Lab\Docker-Compose-Lab\Source**

	docker build . -f Application/Dockerfile -t application:latest -t localhost:5555/application:latest -t yourdockerusername/application:latest

	docker push localhost:5555/application:latest

	docker login yourdockerusername

	docker push yourdockerusername/application:latest

## 5 Create Swarm

	docker swarm init

## 6 Start with docker-compose

	docker-compose -f "Docker-Compose.Local-Swarm.yml" up -d

## Temporary links

- https://stackoverflow.com/questions/53062504/apache-2-4-37-with-openssl-1-1-1-cannot-perform-post-handshake-authentication
- [Apache HTTP 2.4: How to Build a Docker Image for SSL/TLS Mutual Authentication](https://dzone.com/articles/apache-http-24-how-to-build-a-docker-image-for-ssl)
- [Authenticate proxy with apache](https://docs.docker.com/registry/recipes/apache/)
- https://jennylaw.azurewebsites.net/posts/nginx-in-app-service/
- Google: azure linux container nginx
- https://docs.microsoft.com/en-us/azure/container-instances/container-instances-container-group-ssl
- docker-compose -f Docker-Compose.Nginx-Test.yml up
- https://docs.microsoft.com/en-us/azure/app-service/containers/tutorial-multi-container-app
- https://medium.com/better-programming/about-using-docker-config-e967d4a74b83
- https://www.humankode.com/ssl/create-a-selfsigned-certificate-for-nginx-in-5-minutes