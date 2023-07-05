CREATE TABLE [dbo].[TBAlternativa] (
    [id]    INT          IDENTITY (1, 1) NOT NULL,
    [texto]      VARCHAR (50) NOT NULL,
    [questao_id] INT          NOT NULL,
    CONSTRAINT [FK_TBAlternativa_TBQuestao] FOREIGN KEY ([questao_id]) REFERENCES [dbo].[TBQuestao] ([id]),
    CONSTRAINT [PK_TBAlternativa] PRIMARY KEY CLUSTERED ([id] ASC)
);

