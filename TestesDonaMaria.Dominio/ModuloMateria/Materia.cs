using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string nome;
        public Disciplina disciplina;

        public Materia(string nome, Disciplina disciplina)
        {
            this.nome = nome;
            this.disciplina = disciplina;
        }

        public Materia(int id, string nome, Disciplina disciplina)
        {
            this.id = id;
            this.nome = nome;
            this.disciplina = disciplina;
        }

        public override void AtualizarInformacoes(Materia entidade)
        {
            this.id = entidade.id;
            this.nome = entidade.nome;
            this.disciplina = entidade.disciplina;
        }
        public override string ToString()
        {
            return nome;
        }
        public override bool Equals(object obj)
        {
            return obj is Materia materia &&
                   id == materia.id;
        }

    }
}
