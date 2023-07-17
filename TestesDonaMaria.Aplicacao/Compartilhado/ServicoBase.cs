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
        where TRepositorio : IRepositorioBase<TEntidade>
    {
    }
}
