CREATE TABLE [dbo].[Trailer]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL, 
    [Vin]                                NVARCHAR (255)          NOT NULL,
    [ManufacturedOn]                     DATETIME                NOT NULL,
    [Registration]                       NVARCHAR (255)          NULL,
    [RegistrationExpiryDate]             DATETIME                NULL,
    [CompanyId]                          INT                     NOT NULL,
    [TruckId]                            INT                     NULL,
    CONSTRAINT [PK_Trailer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Company_Trailer] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]),
    CONSTRAINT [FK_Truck_Trailer] FOREIGN KEY ([TruckId]) REFERENCES [dbo].[Truck] ([Id]),
    CONSTRAINT [UNIQUE_TrailerVin] UNIQUE (Vin),
    CONSTRAINT [UNIQUE_TrailerRegistration] UNIQUE (Registration)
)