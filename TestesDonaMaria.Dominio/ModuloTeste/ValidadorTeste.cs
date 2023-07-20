using FluentValidation;

namespace TestesDonaMaria.Dominio.ModuloTeste
{
    public class ValidadorTeste : ValidadorBase<Teste>
    {
        public ValidadorTeste()
        {
            Validador();
        }

        public override void Validador()
        {
            RuleFor(x => x.titulo).NotEmpty().NotNull().MinimumLength(5);
        }
    }
}
