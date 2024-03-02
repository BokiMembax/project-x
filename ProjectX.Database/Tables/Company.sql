CREATE TABLE [dbo].[Company]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL, 
    [Embs]                               NVARCHAR (255)          NOT NULL,
    [Name]                               NVARCHAR (255)          NOT NULL,
    [Address]                            NVARCHAR (255)          NOT NULL,
    [Email]                              NVARCHAR (255)          NOT NULL,
    [PhoneNumber]                        NVARCHAR (255)          NOT NULL,    
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UNIQUE_Embs] UNIQUE (Embs),
    CONSTRAINT [UNIQUE_CompanyEmail] UNIQUE (Email),
)