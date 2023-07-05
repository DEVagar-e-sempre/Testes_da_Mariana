CREATE TABLE [dbo].[TBAlternativa] (
    [id]                  INT          IDENTITY (1, 1) NOT NULL,
    [alternativa]         VARCHAR (50) NOT NULL,
    [questao_id]          INT          NOT NULL,
    [alternativa_correta] BIT          CONSTRAINT [DF_TBAlternativa_ehCorreta] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TBAlternativa] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TBAlternativa_TBQuestao] FOREIGN KEY ([questao_id]) REFERENCES [dbo].[TBQuestao] ([id])
);



