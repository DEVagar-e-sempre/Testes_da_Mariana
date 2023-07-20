using FluentResults;
using Serilog;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Dominio.ModuloTeste;
using TestesDonaMaria.Infra.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloTeste;

namespace TestesDonaMaria.Aplicacao.ModuloTeste
{
    public class ServicoTeste : ServicoBase<Teste, RepositorioSQLTeste, ValidadorTeste>
    {
        protected override string MsgErro => "Falha ao tentar remover o teste selecionado...";
        private RepositorioSQLQuestao repQuestao;
        public ServicoTeste(RepositorioSQLQuestao repQuestao) : base()
        {
            this.repQuestao = repQuestao;
        }

        public override Result Inserir(Teste registro)
        {
            Result resultado = base.Inserir(registro);

            if(resultado.IsFailed)
            {
                return resultado;
            }

            foreach (Questao questao in registro.listaQuestoes)
            {
                repQuestao.Editar(questao.id, questao);
            }

            return resultado;
        }

        public override Result Excluir(Teste registro)
        {
            Result resultado = base.Excluir(registro);

            if (resultado.IsFailed)
            {
                return resultado;
            }

            foreach (Questao questao in registro.listaQuestoes)
            {
                repQuestao.Editar(questao.id, questao);
            }

            return resultado;
        }


    }
}
