CREATE TABLE [dbo].[TruckGreenClassCertificate]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL,
    [ExpiryDate]                         DATETIME                NOT NULL,
    [IsExpired]                          BIT                     NOT NULL,
    [EmissionClassId]                    INT                     NOT NULL,
    CONSTRAINT [PK_TruckGreenClassCertificate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmissionClass_TruckGreenClassCertificate] FOREIGN KEY ([EmissionClassId]) REFERENCES [dbo].[EmissionClass] ([Id])
)