using TestesDonaMaria.Dominio.Compartilhado;

namespace TestesDonaMaria.Infra.Compartilhado
{
    public interface IRepositorio<TEntidade>
        where TEntidade : EntidadeBase<TEntidade>
    {
        public bool Inserir(TEntidade registro);

        public bool Editar(int id, TEntidade registroAtualizado);

        public void Excluir(TEntidade registroSelecionado);

        public TEntidade SelecionarPorId(int id);

        public List<TEntidade> SelecionarTodos();

        public void AdicionarRegistroEContador(List<TEntidade> listaRegistros, int contador);

        public bool EhRepetido(TEntidade entidade);
    }
}