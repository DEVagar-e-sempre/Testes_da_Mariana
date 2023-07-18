using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Infra.ModuloMateria;

namespace TestesDonaMaria.Aplicacao.ModuloMateria
{
    public class ServicoMateria : ServicoBase <Materia, RepositorioSQLMateria>
    {
        protected override string MsgErro => "Esta Materia está relacionada a uma Questão e não pode ser excluída";
        public ServicoMateria() : base() 
        {
            
        }
    }
}
