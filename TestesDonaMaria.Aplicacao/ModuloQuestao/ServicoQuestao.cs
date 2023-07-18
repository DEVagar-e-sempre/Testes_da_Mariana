using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloQuestao;

namespace TestesDonaMaria.Aplicacao.ModuloQuestao
{
    public class ServicoQuestao : ServicoBase<Questao, RepositorioSQLQuestao>
    {
        protected override string MsgErro => "Esta Questão está relacionada a um Teste e não pode ser excluída";
        public ServicoQuestao() : base()
        {
            
        }
    }
}
