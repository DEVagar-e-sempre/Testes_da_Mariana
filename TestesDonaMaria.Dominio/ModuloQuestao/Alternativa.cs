namespace TestesDonaMaria.Dominio.ModuloQuestao
{
    public class Alternativa : EntidadeBase<Alternativa>
    {
        public string alternativa;
        public bool correta;
        public int questaoId;
        
        public Alternativa(string alternativa, bool correta, int questaoId)
        {
            this.alternativa = alternativa;
            this.correta = correta;
            this.questaoId = questaoId;
        }
        public Alternativa(int id,string alternativa, bool correta, int questaoId)
        {
            this.id = id;
            this.alternativa = alternativa;
            this.correta = correta;
            this.questaoId = questaoId;
        }

        public override void AtualizarInformacoes(Alternativa entidade)
        {
            this.alternativa = entidade.alternativa;
            this.correta = entidade.correta;
            this.questaoId = entidade.questaoId;
        }

        public override string[] Validar()
        {
            List<String> erros = new();
            if (string.IsNullOrEmpty(alternativa))
            {
                erros.Add("O campo alternativa não pode se vazio");
            }
            if (questaoId == 0)
            {
                erros.Add("A alternativa deve estar associada a uma questão");
            }
            return erros.ToArray();
        }
        public override string ToString()
        {
            return alternativa;
        }
        public override bool Equals(object obj)
        {
            return obj is Alternativa alternativa &&
                   id == alternativa.id;
        }
    }
}
