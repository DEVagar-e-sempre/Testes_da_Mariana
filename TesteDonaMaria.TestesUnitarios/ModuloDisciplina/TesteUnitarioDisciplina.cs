using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TesteDonaMaria.TestesUnitarios.ModuloDisciplina
{
    [TestClass]
    public class TesteUnitarioDisciplina
    {
        [TestMethod]
        public void Deve_Permitir_Cadastrar_Materia_Em_Disciplina()
        {
            Disciplina artes = new Disciplina("Artes");

            Materia cores = new Materia("cores primarias", artes);



        }
    }
}