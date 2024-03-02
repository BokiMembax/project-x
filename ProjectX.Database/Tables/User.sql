CREATE TABLE [dbo].[User]
(
	[Id]                                 INT                     IDENTITY (1, 1) NOT NULL,
    [Uid]                                UNIQUEIDENTIFIER        NOT NULL,
    [CreatedOn]                          DATETIME                NOT NULL,
    [DeletedOn]                          DATETIME                NULL,  
    [Embg]                               NVARCHAR (255)          NOT NULL,
    [FirstName]                          NVARCHAR (255)          NOT NULL,
    [LastName]                           NVARCHAR (255)          NOT NULL,
    [Email]                              NVARCHAR (255)          NOT NULL,
    [Password]                           NVARCHAR (255)          NOT NULL,
    [PhoneNumber]                        NVARCHAR (255)          NOT NULL,
    [CompanyId]                          INT                     NOT NULL
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Company_User] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]),
    CONSTRAINT [UNIQUE_Embg] UNIQUE (Embg),
    CONSTRAINT [UNIQUE_UserEmail] UNIQUE (Email),
    CONSTRAINT [UNIQUE_UserPhoneNumber] UNIQUE (PhoneNumber)
)