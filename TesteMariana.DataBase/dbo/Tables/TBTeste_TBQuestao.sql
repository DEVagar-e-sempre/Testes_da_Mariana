CREATE TABLE [dbo].[TBTeste_TBQuestao] (
    [questao_id] INT NOT NULL,
    [teste_id]   INT NOT NULL,
    CONSTRAINT [FK_TBTeste_Questao_TBQuestao] FOREIGN KEY ([questao_id]) REFERENCES [dbo].[TBQuestao] ([id]),
    CONSTRAINT [FK_TBTeste_Questao_TBTeste] FOREIGN KEY ([teste_id]) REFERENCES [dbo].[TBTeste] ([id])
);

