CREATE TABLE [dbo].[TBQuestao] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [titulo]         VARCHAR (100) NOT NULL,
    [questaoCorreta] VARCHAR (100) NOT NULL,
    [materia_id]     INT           NOT NULL,
    CONSTRAINT [PK_TBQuestao] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TBQuestao_TBMateria] FOREIGN KEY ([materia_id]) REFERENCES [dbo].[TBMateria] ([id])
);

