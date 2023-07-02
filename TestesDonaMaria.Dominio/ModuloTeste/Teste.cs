using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo;
        public Disciplina disc;
        public Materia materia;
        public int quantQuestoes;
        public int serie;

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
