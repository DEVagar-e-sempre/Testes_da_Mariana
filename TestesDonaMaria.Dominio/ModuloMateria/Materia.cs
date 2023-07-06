using Microsoft.Data.SqlClient;
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
                erros.Add("O campo do Nome é obrigatório!");
            }
            else if (disciplina == null)
            {
                erros.Add("É obrigatório a seleção da disciplina!");
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
    }
}
