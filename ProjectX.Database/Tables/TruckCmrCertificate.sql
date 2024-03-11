CREATE TABLE [dbo].[TruckCmrCertificate]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL,
    [ExpiryDate]                         DATETIME                NOT NULL,
    [IsExpired]                          BIT                     NOT NULL,
    [TruckId]                            INT                     NOT NULL,
    CONSTRAINT [PK_TruckCmrCertificate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Truck_TruckCmrCertificate] FOREIGN KEY ([TruckId]) REFERENCES [dbo].[Truck] ([Id])
)