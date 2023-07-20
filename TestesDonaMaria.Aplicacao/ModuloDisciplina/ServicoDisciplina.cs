using System.ComponentModel.DataAnnotations;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloDisciplina;

namespace TestesDonaMaria.Aplicacao.ModuloDisciplina
{
    public class ServicoDisciplina : ServicoBase <Disciplina, RepositorioSQLDisciplina, ValidadorDisciplina>
    {
        protected override string MsgErro => "Esta Disciplina está relacionada a uma Materia e não pode ser excluída";
        public ServicoDisciplina() : base()
        {
        }
    }
}
