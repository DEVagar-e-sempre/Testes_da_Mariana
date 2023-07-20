using FluentValidation;

namespace TestesDonaMaria.Dominio.ModuloQuestao
{
    public class ValidadorQuestao : ValidadorBase<Questao>
    {
        public ValidadorQuestao()
        {
            Validador();
        }

        public override void Validador()
        {
            RuleFor(x => x.enunciado).NotNull().NotEmpty();
        }
    }
}
