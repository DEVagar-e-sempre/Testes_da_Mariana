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

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
            {
                erros.Add("O campo Nome é obrigatório!");
            }
            if (disciplina == null)
            {
                erros.Add("É obrigatório a seleção da disciplina!");
            }
            if(nome.Length < 5)
            {
                erros.Add("O nome da materia deve ter no mínimo 5 caracteres!");
            }
            return erros.ToArray();
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
