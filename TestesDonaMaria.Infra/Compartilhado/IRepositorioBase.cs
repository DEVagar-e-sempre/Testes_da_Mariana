using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMaria.Dominio.Compartilhado;

namespace TestesDonaMaria.Infra.Compartilhado
{
    public interface IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase<TEntidade>
    {
        public void Inserir(TEntidade registro);
        public void Editar(int id, TEntidade registroAtualizado);
        public void Excluir(TEntidade registroSelecionado);
        public TEntidade SelecionarPorId(int id);
        public List<TEntidade> SelecionarTodos();
        public int ObterProximoID();
        public bool EhRepetido(TEntidade registro);
    }
}
