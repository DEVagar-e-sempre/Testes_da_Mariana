namespace TestesDonaMaria.WinForms.Compartilhado
{
    public abstract class ControladorBase
    {
        public virtual string ToolTipInserir => $"Inserir novo {ObterTipoCadastro}";

        public virtual string ToolTipEditar => $"Editar um {ObterTipoCadastro}";

        public virtual string ToolTipExcluir => $"Excluir um {ObterTipoCadastro}";

        public virtual string ToolTipFiltrar => $"Filtrar {ObterTipoCadastro}s";

        public virtual string ToolTipAdd => $"Adicionar Itens dos Temas";

        public virtual string ToolTipListar => $"Listar Itens do {ObterTipoCadastro}";


        public abstract string ObterTipoCadastro { get; }
        public virtual bool InserirHabilitado => true;
        public virtual bool EditarHabilitado => true;
        public virtual bool ExcluirHabilitado => true;
        public virtual bool FiltrarHabilitado => false;
        public virtual bool AddItemHabilitado => false;
        public virtual bool ListarHabilitado => false;

        public abstract void Inserir();
        public abstract void Editar();

        public abstract void Excluir();

        public virtual void AddItem() { }

        public virtual void Filtrar() { }

        public virtual void Listar() { }

        public virtual void Adicionar() { }

        public virtual void ConcluirItens() { }

        public abstract UserControl ObterListagem();
    }
}
