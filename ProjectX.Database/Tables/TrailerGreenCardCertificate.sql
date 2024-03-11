CREATE TABLE [dbo].[TrailerGreenCardCertificate]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL,
    [ExpiryDate]                         DATETIME                NOT NULL,
    [IsExpired]                          BIT                     NOT NULL,
    [TrailerId]                          INT                     NOT NULL,
    CONSTRAINT [PK_TrailerGreenCardCertificate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Trailer_TrailerGreenCardCertificate] FOREIGN KEY ([TrailerId]) REFERENCES [dbo].[Trailer] ([Id])
)