CREATE TABLE [dbo].[TruckGreenCardCertificate]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL,
    [ExpiryDate]                         DATETIME                NOT NULL,
    [IsExpired]                          BIT                     NOT NULL,
    [TruckId]                            INT                     NOT NULL,
    CONSTRAINT [PK_TruckGreenCardCertificate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Truck_TruckGreenCardCertificate] FOREIGN KEY ([TruckId]) REFERENCES [dbo].[Truck] ([Id])
)