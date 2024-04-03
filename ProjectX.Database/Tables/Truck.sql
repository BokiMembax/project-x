CREATE TABLE [dbo].[Truck]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL, 
    [CombinationNumber]                  NVARCHAR (255)          NOT NULL,
    [Vin]                                NVARCHAR (255)          NOT NULL,
    [ManufacturedOn]                     DATETIME                NOT NULL,
    [Registration]                       NVARCHAR (255)          NULL,
    [RegistrationExpiryDate]             DATETIME                NULL,
    [CompanyId]                          INT                     NOT NULL,
    [GreenClassCertificateId]            INT                     NULL,
    CONSTRAINT [PK_Truck] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Company_Truck] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]),
    CONSTRAINT [FK_TruckGreenClassCertificate_Truck] FOREIGN KEY ([GreenClassCertificateId]) REFERENCES [dbo].[TruckGreenClassCertificate] ([Id]),
    CONSTRAINT [UNIQUE_TruckVin] UNIQUE (Vin),
    CONSTRAINT [UNIQUE_TruckRegistration] UNIQUE (Registration)
)