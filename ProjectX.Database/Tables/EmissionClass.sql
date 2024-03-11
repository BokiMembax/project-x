CREATE TABLE [dbo].[EmissionClass]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL,
    [Name]                               NVARCHAR (255)          NOT NULL,
    [Description]                        NVARCHAR (255)          NOT NULL,
    CONSTRAINT [PK_EmissionClass] PRIMARY KEY CLUSTERED ([Id] ASC)
)