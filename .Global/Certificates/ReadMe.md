# Certificates

I am more used to create certificates with [New-SelfSignedCertificate](https://docs.microsoft.com/en-us/powershell/module/pkiclient/new-selfsignedcertificate/) (PowerShell) than with [mkcert](https://github.com/FiloSottile/mkcert) or [OpenSSL](https://www.openssl.org/).

The PowerShell-script [Create-Certificates.ps1](/.Global/Certificates/Create-Certificates.ps1) including the PowerShell-module [Certificate-Module.psm1](/.Global/Certificates/Certificate-Module.psm1) create certificate-files used in this solution. The files are included in the repository but if we want to create new ones we can run the script.

The script requires:

- [CertUtil](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/certutil/)
- [OpenSSL](https://www.openssl.org/)

To install OpenSSL:

- [OpenSSL for Windows](https://slproweb.com/products/Win32OpenSSL.html)
- [Win64 OpenSSL v1.1.1e](https://slproweb.com/download/Win64OpenSSL-1_1_1e.exe)