Import-Module "$($PSScriptRoot)\Certificate-Module";
$certificateNamePrefix = "Hans Kindberg - Docker Compose Lab - ";
$clientCertificateName = "$($certificateNamePrefix)Client";
$rootCertificateName = "$($certificateNamePrefix)Root CA";
$sslCertificateName = "$($certificateNamePrefix)SSL";

New-RootCertificate `
	-Name $rootCertificateName;

New-ClientCertificate `
	-Name $clientCertificateName `
	-SignerName $rootCertificateName;

New-SslCertificate `
	-DnsName "*.azurewebsites.net", "*.company.com", "*.company.net", "*.example.com", "*.example.net", "*.hanskindberg.net", "*.local.net", "localhost", "::1", "127.0.0.1", "127.0.0.2", "127.0.0.3", "127.0.0.4", "127.0.0.5", "127.0.0.6", "127.0.0.7", "127.0.0.8", "127.0.0.9" `
	-Name $sslCertificateName `
	-SignerName $rootCertificateName;

Write-Host;
Write-Host "Press enter to exit";
Read-Host;