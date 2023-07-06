namespace TestesDonaMaria.WinForms.Compartilhado
{
    public static class InicializadorFormExtension
    {
        public static void ConfigurarTelas(this Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
        }
    }
}
