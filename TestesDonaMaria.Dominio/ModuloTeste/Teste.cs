using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Dominio.ModuloQuestao;

namespace TestesDonaMaria.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo;
        public Disciplina disciplina;
        public Materia materia;
        public int quantQuestoes;
        public int serie;
        public List<Questao> listaQuestoes;

        public Teste(string titulo, Disciplina disciplina, Materia materia, int quantQuestoes, int serie)
        {
            this.titulo = titulo;
            this.disciplina = disciplina;
            this.materia = materia;
            this.quantQuestoes = quantQuestoes;
            this.serie = serie;
            this.listaQuestoes = new List<Questao>();

        }
        public override void AtualizarInformacoes(Teste entidade)
        {
            throw new NotImplementedException();
        }

        public override string ObterCampoSQL(bool ehParametro = false)
        {
            throw new NotImplementedException();
        }

        public override SqlParameter[] ObterParametroSQL()
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }

        public override bool VerificarRepeticao(Teste registro)
        {
            throw new NotImplementedException();
        }
    }
}
