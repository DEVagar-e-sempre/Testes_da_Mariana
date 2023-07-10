CREATE TABLE [dbo].[TBTeste] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [titulo]        VARCHAR (100) NOT NULL,
    [materia_id]    INT           NOT NULL,
    [quantQuestoes] INT           NOT NULL,
    [serie]         INT           NOT NULL,
    [recuperacao]   BIT           NOT NULL,
    CONSTRAINT [PK_TBTeste] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TBTeste_TBMateria] FOREIGN KEY ([materia_id]) REFERENCES [dbo].[TBMateria] ([id])
);





