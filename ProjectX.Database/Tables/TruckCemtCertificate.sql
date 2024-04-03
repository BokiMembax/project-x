CREATE TABLE [dbo].[TruckCemtCertificate]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL,
    [ExpiryDate]                         DATETIME                NOT NULL,
    [IsExpired]                          BIT                     NOT NULL,
    [TruckId]                            INT                     NOT NULL,
    CONSTRAINT [PK_TruckCemtCertificate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Truck_TruckCemtCertificate] FOREIGN KEY ([TruckId]) REFERENCES [dbo].[Truck] ([Id])
)