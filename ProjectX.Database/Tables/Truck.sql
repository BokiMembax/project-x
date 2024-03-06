CREATE TABLE [dbo].[Truck]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL, 
    [CombinationNumber]                  NVARCHAR (255)          NOT NULL,
    [Vin]                                NVARCHAR (255)          NOT NULL,
    [ManufacturedOn]                     DATETIME                NOT NULL,
    [Registration]                       NVARCHAR (255)          NOT NULL,
    [RegistrationExpiryDate]             DATETIME                NULL,    
    CONSTRAINT [PK_Truck] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UNIQUE_Vin] UNIQUE (Vin)
)