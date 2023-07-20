using FluentValidation;

namespace TestesDonaMaria.Dominio.Compartilhado
{
    public abstract class ValidadorBase<T> : AbstractValidator<T>
    {
        public abstract void Validador();
    }
}
