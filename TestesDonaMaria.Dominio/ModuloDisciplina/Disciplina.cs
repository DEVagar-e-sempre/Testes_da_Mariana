namespace TestesDonaMaria.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string nome;
        public Disciplina(string nome)
        {
            this.nome = nome;
        }

        public Disciplina(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }


        public override void AtualizarInformacoes(Disciplina entidade)
        {
            this.nome = entidade.nome;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            if (string.IsNullOrEmpty(nome))
            {
                erros.Add("O campo Nome é obrigatório!");
            }
            if (nome.Length < 5)
            {
                erros.Add("O nome da Disciplina deve ter no mínimo 5 caracteres!");
            }
            return erros.ToArray();
        }
        public override string ToString()
        {
            return nome;
        }
        public override bool Equals(object obj)
        {
            return obj is Disciplina disciplina &&
                   id == disciplina.id;
        }
    }
}
