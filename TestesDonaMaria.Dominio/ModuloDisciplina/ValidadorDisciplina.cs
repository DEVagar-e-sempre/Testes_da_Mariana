using FluentValidation;

namespace TestesDonaMaria.Dominio.ModuloDisciplina
{
    public class ValidadorDisciplina : ValidadorBase<Disciplina>
    {
        public ValidadorDisciplina() 
        {
            Validador();
        }

        public override void Validador()
        {
            RuleFor(x => x.nome).NotEmpty().NotNull().MinimumLength(5);
        }
    }
}
