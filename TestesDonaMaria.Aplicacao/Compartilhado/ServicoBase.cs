using FluentResults;
using Microsoft.Data.SqlClient;
using Serilog;
using TestesDonaMaria.Dominio.Compartilhado;
using TestesDonaMaria.Infra.Compartilhado;

namespace TestesDonaMaria.Aplicacao.Compartilhado
{
    /* Os controladores terão que ter uma instancia de cada camada de serviço respectiva
     * As instancias da camada de serviço serão passadas por parametro no construtor de cada controlador
     * As configurações de cada validação terão que estar nessa camada
     * Fazer a verificação de repetido aqui
     */
    public abstract class ServicoBase<TEntidade, TRepositorio>
        where TEntidade : EntidadeBase<TEntidade>
        where TRepositorio : IRepositorioBase<TEntidade>, new()
    {
        private TRepositorio repRegistro;
        protected virtual string MsgErro => "";

        public ServicoBase()
        {
            repRegistro = new TRepositorio();
        }

        public virtual Result Inserir(TEntidade registro)
        {
            Log.Debug("Inserindo registro: {@registro}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
            {
                return Result.Fail(erros);
            }
            try
            {
                repRegistro.Inserir(registro);
                return Result.Ok();
            }
            catch (SqlException ex)
            {
                string msgErro = "Falha ao tentar inserir o registro. ";

                Log.Error(ex, msgErro + "{@registro}", registro);

                return Result.Fail(erros);
            }


        }

        public virtual Result Editar(TEntidade registro)
        {
            Log.Debug("Editando registro: {@registro}", registro);

            List<string> erros = ValidarRegistro(registro);

            if (erros.Count() > 0)
                return Result.Fail(erros);
            try
            {
                repRegistro.Editar(registro.id, registro);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                string msgErro = "Falha ao tentar editar o registro. ";

                Log.Error(ex, msgErro + "{@registro}", registro);

                return Result.Fail(erros);
            }
        }

        public virtual Result Excluir(TEntidade registro)
        {
            Log.Debug("Excluindo registro: {@registro}", registro);

            List<string> erros = new List<string>();

            try
            {
                repRegistro.Excluir(registro);

                return Result.Ok();

            }
            catch (SqlException ex)
            {
                erros.Add(MsgErro);

                Log.Warning(ex, MsgErro + "{@registro}", registro);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarRegistro(TEntidade registro)
        {
            List<string> erros = new List<string>(registro.Validar());

            if (NomeDuplicado(registro))
            {
                erros.Add($"Este nome/titulo '{registro}' já está sendo utilizado na aplicação");
            }

            return erros;
        }

        private bool NomeDuplicado(TEntidade registro)
        {
            bool materiaEncontrada = repRegistro.EhRepetido(registro);

            if (materiaEncontrada)
            {
                return true;
            }

            return false;
        }
    }
}
