CREATE TABLE [dbo].[Skill] (
    [Id]         UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [SaveFileId] UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (50)    NOT NULL,
    [Cost]       INT              NULL DEFAULT 2,
    [Damage]     INT              NOT NULL DEFAULT 3,
    [Accuracy]   FLOAT (53)       NULL DEFAULT 1,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Skill_SaveFile] FOREIGN KEY ([SaveFileId]) REFERENCES [dbo].[SaveFile] ([Id])
);

