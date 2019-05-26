CREATE TABLE [dbo].[SaveFile] (
    [Id]          UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [LastSavedOn] DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

