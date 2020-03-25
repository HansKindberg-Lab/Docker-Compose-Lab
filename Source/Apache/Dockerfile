FROM httpd
RUN echo "LoadModule socache_shmcb_module modules/mod_socache_shmcb.so" >> /usr/local/apache2/conf/httpd.conf
RUN echo "LoadModule ssl_module modules/mod_ssl.so" >> /usr/local/apache2/conf/httpd.conf
RUN echo "Include conf/extra/httpd-ssl.conf" >> /usr/local/apache2/conf/httpd.conf
RUN echo "Include conf/custom.conf" >> /usr/local/apache2/conf/httpd.conf
COPY Apache/apache.conf /usr/local/apache2/conf/custom.conf
COPY Apache/Certificates/ssl-certificate.crt /usr/local/apache2/conf/server.crt
COPY Apache/Certificates/ssl-certificate.key /usr/local/apache2/conf/server.key