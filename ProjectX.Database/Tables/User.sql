CREATE TABLE [dbo].[User]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL,
    [CompanyId]                          INT                     NOT NULL,
    [TruckId]                            INT                     NULL,
    [TrailerId]                          INT                     NULL,
    [Embg]                               NVARCHAR (255)          NOT NULL,
    [FirstName]                          NVARCHAR (255)          NOT NULL,
    [LastName]                           NVARCHAR (255)          NOT NULL,
    [Email]                              NVARCHAR (255)          NOT NULL,
    [PasswordHash]                       NVARCHAR (255)          NOT NULL,
    [PhoneNumber]                        NVARCHAR (255)          NOT NULL,
    [DateOfEmployment]                   DATETIME                NULL,    
    [DriversCertificateSerialNumber]     NVARCHAR (255)          NULL,
    [DriversCertificateIssueDate]        DATETIME                NULL,
    [DriversCertificateExpiryDate]       DATETIME                NULL,    
    [DrivingLicenseSerialNumber]         NVARCHAR (255)          NULL,
    [DrivingLicenseIssueDate]            DATETIME                NULL,
    [DrivingLicenseExpiryDate]           DATETIME                NULL,    
    [PassportSerialNumber]               NVARCHAR (255)          NULL,
    [PassportIssueDate]                  DATETIME                NULL,
    [PassportExpiryDate]                 DATETIME                NULL,    
    [IdentityCardSerialNumber]           NVARCHAR (255)          NULL,
    [IdentityCardIssueDate]              DATETIME                NULL,
    [IdentityCardExpiryDate]             DATETIME                NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Company_User] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]),
    CONSTRAINT [FK_Truck_User] FOREIGN KEY ([TruckId]) REFERENCES [dbo].[Truck] ([Id]),
    CONSTRAINT [FK_Trailer_User] FOREIGN KEY ([TrailerId]) REFERENCES [dbo].[Trailer] ([Id]),
)

GO
CREATE UNIQUE NONCLUSTERED INDEX uniqueDriversCertificateSerialNumber
ON [dbo].[User] (DriversCertificateSerialNumber)
WHERE DriversCertificateSerialNumber IS NOT NULL;

GO
CREATE UNIQUE NONCLUSTERED INDEX uniqueDrivingLicenseSerialNumber
ON [dbo].[User] (DrivingLicenseSerialNumber)
WHERE DrivingLicenseSerialNumber IS NOT NULL;

GO
CREATE UNIQUE NONCLUSTERED INDEX uniquePassportSerialNumber
ON [dbo].[User] (PassportSerialNumber)
WHERE PassportSerialNumber IS NOT NULL;

GO
CREATE UNIQUE NONCLUSTERED INDEX uniqueIdentityCardSerialNumber
ON [dbo].[User] (IdentityCardSerialNumber)
WHERE IdentityCardSerialNumber IS NOT NULL;

GO
CREATE UNIQUE NONCLUSTERED INDEX uniqueEmbg
ON [dbo].[User] (Embg);

GO
CREATE UNIQUE NONCLUSTERED INDEX uniqueEmail
ON [dbo].[User] (Email);

GO
CREATE UNIQUE NONCLUSTERED INDEX uniquePhoneNumber
ON [dbo].[User] (PhoneNumber);
