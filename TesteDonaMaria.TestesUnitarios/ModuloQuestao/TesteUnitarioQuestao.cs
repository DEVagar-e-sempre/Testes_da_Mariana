using FluentAssertions;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Dominio.ModuloQuestao;

namespace TesteDonaMaria.TestesUnitarios.ModuloQuestao
{
    [TestClass]
    public class TesteUnitarioQuestao
    {
        Disciplina disciplina;
        Questao questao;
        Alternativa alt;
        Materia adicaoUnidades;
        public TesteUnitarioQuestao()
        {
            disciplina = new Disciplina("Matematica");
            adicaoUnidades = new Materia("Adicao de Unidades", disciplina);
            questao = new Questao("aaaaaaaaaaaaa", 2, adicaoUnidades);
            alt = new Alternativa("A", true, questao.id);
        }

        [TestMethod]
        public void Alternativas_Nao_Podem_Ser_Null()
        {
            questao.alternativas.Should().NotBeNull();
        }
    }
}
