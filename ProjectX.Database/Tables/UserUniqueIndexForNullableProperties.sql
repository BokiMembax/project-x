CREATE UNIQUE INDEX uniqueDriversCertificateSerialNumber
ON [dbo].[User] (DriversCertificateSerialNumber)
WHERE DriversCertificateSerialNumber IS NOT NULL;
GO

CREATE UNIQUE INDEX uniqueDrivingLicenseSerialNumber
ON [dbo].[User] (DrivingLicenseSerialNumber)
WHERE DrivingLicenseSerialNumber IS NOT NULL;
GO

CREATE UNIQUE INDEX uniquePassportSerialNumber
ON [dbo].[User] (PassportSerialNumber)
WHERE PassportSerialNumber IS NOT NULL;
GO

CREATE UNIQUE INDEX uniqueIdentityCardSerialNumber
ON [dbo].[User] (IdentityCardSerialNumber)
WHERE IdentityCardSerialNumber IS NOT NULL;
GO