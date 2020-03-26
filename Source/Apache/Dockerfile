FROM httpd
COPY Apache/apache.conf /usr/local/apache2/conf/httpd.conf
COPY Apache/Certificates/ssl-certificate.crt /usr/local/apache2/conf/server.crt
COPY Apache/Certificates/ssl-certificate.key /usr/local/apache2/conf/server.key
# The following environment variables are used in apache.conf.
ENV APACHE_SERVER_ADMIN firstname.lastname@localhost
#ENV APACHE_SERVER_NAME my.apache.com
ENV APACHE_SERVER_NAME localhost