using TestesDonaMaria.Infra.ModuloDisciplina;

namespace TestesDonaMaria.WinForms.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        public override string ObterTipoCadastro => "Cadastro de Disciplina";

        private RepositorioSQLDisciplina repDisciplina;

        public ControladorDisciplina(RepositorioSQLDisciplina repDisciplina)
        {
            this.repDisciplina = repDisciplina;
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterListagem()
        {
            throw new NotImplementedException();
        }
    }
}
