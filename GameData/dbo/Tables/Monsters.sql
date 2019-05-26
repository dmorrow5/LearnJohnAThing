CREATE TABLE [dbo].[Monsters] (
    [Id]          UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [Name] NVARCHAR (50)    NOT NULL,
    [Health]      INT              NOT NULL DEFAULT 10,
    [Skill1]      UNIQUEIDENTIFIER NULL,
    [Skill2]      UNIQUEIDENTIFIER NULL,
    [Skill3]      UNIQUEIDENTIFIER NULL,
    [Skill4]      UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Monsters_Skill1] FOREIGN KEY ([Skill1]) REFERENCES [Skill]([Id]),
	CONSTRAINT [FK_Monsters_Skill2] FOREIGN KEY ([Skill2]) REFERENCES [Skill]([Id]),
	CONSTRAINT [FK_Monsters_Skill3] FOREIGN KEY ([Skill3]) REFERENCES [Skill]([Id]),
	CONSTRAINT [FK_Monsters_Skill4] FOREIGN KEY ([Skill4]) REFERENCES [Skill]([Id]),
);

