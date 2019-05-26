CREATE TABLE [dbo].[Heroes] (
    [Id]         UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [SaveFileId] UNIQUEIDENTIFIER NOT NULL,
    [Name]		 NVARCHAR (50)    NOT NULL ,
    [Health]     INT              NOT NULL DEFAULT 10,
    [Mana]       INT              NOT NULL DEFAULT 5,
    [Skill1]     UNIQUEIDENTIFIER NULL,
    [Skill2]     UNIQUEIDENTIFIER NULL,
    [Skill3]     UNIQUEIDENTIFIER NULL,
    [Skill4]     UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Heroes_SaveFile] FOREIGN KEY ([SaveFileId]) REFERENCES [dbo].[SaveFile] ([Id]), 
    CONSTRAINT [FK_Heroes_Skill1] FOREIGN KEY ([Skill1]) REFERENCES [Skill]([Id]),
	CONSTRAINT [FK_Heroes_Skill2] FOREIGN KEY ([Skill2]) REFERENCES [Skill]([Id]),
	CONSTRAINT [FK_Heroes_Skill3] FOREIGN KEY ([Skill3]) REFERENCES [Skill]([Id]),
	CONSTRAINT [FK_Heroes_Skill4] FOREIGN KEY ([Skill4]) REFERENCES [Skill]([Id]),
);

