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
