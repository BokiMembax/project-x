CREATE TABLE [dbo].[TrailerYellowCertificate]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL,
    [ExpiryDate]                         DATETIME                NOT NULL,
    [IsExpired]                          BIT                     NOT NULL,
    [TrailerId]                          INT                     NOT NULL,
    CONSTRAINT [PK_TrailerYellowCertificate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Trailer_TrailerYellowCertificate] FOREIGN KEY ([TrailerId]) REFERENCES [dbo].[Trailer] ([Id])
)