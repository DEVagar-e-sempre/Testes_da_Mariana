using FluentAssertions;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TesteDonaMaria.TestesUnitarios.ModuloDisciplina
{
    [TestClass]
    public class TesteUnitarioDisciplina
    {
        Disciplina disciplina;
        public TesteUnitarioDisciplina()
        {
            disciplina = new Disciplina("Matematica");
        }

        [TestMethod]
        public void Deve_Permitir_Cadastrar_Materia_Em_Disciplina()
        {
            disciplina.Should().NotBeNull();
        }
    }
}