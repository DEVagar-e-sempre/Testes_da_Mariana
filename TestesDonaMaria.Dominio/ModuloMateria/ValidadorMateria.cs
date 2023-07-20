using FluentValidation;

namespace TestesDonaMaria.Dominio.ModuloMateria
{
    public class ValidadorMateria : ValidadorBase<Materia>
    {
        public ValidadorMateria() 
        {
            Validador();
        }

        public override void Validador()
        {
            RuleFor(x => x.nome).NotEmpty().NotNull().MinimumLength(5);
        }
    }
}
