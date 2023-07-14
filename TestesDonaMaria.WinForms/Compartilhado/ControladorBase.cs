namespace TestesDonaMaria.WinForms.Compartilhado
{
    public abstract class ControladorBase
    {
        public virtual string ToolTipInserir => $"Inserir novo {ObterTipo}";

        public virtual string ToolTipEditar => $"Editar um {ObterTipo}";

        public virtual string ToolTipExcluir => $"Excluir um {ObterTipo}";

        public virtual string ToolTipFiltrar => $"Filtrar {ObterTipo}s";
        public virtual string ToolTipListar => $"Listar Itens do {ObterTipo}";


        public abstract string ObterTipo { get; }
        public virtual bool InserirHabilitado => true;
        public virtual bool EditarHabilitado => true;
        public virtual bool ExcluirHabilitado => true;
        public virtual bool FiltrarHabilitado => false;
        public virtual bool ListarHabilitado => false;

        public virtual bool GerarPDFHabilitado => false;

        public abstract void Inserir();
        public abstract void Editar();

        public abstract void Excluir();

        public virtual void Filtrar() { }

        public virtual void Listar() { }

        public virtual void GerarPDF() { }

        public abstract UserControl ObterListagem();
    }
}
