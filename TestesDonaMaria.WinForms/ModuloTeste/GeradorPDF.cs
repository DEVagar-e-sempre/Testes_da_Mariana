using iTextSharp.text;
using iTextSharp.text.pdf;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Dominio.ModuloTeste;

namespace TestesDonaMaria.WinForms.ModuloTeste
{
    public class GeradorPDF
    {
        private Chunk chunk;
        private string caminho = "C:\\Users\\Usuario\\Documents\\GitHub\\Testes_da_Mariana";
        private Document documento;
        private FileStream arquivo;

        public GeradorPDF()
        {
            documento = new Document();
            arquivo = new FileStream(caminho, FileMode.Create);
        }

        public void GerarPDF(Teste teste, bool ehGabarito = false)
        {
            Paragraph paragrafo;
            PdfWriter escritor = PdfWriter.GetInstance(documento, arquivo);

            string tituloTeste = teste.titulo;
            chunk = new Chunk(tituloTeste, FontFactory.GetFont(FontFactory.HELVETICA_BOLD));
            paragrafo = new Paragraph();
            paragrafo.Add(chunk);

            string materiaTeste = teste.materia.nome;
            chunk = new Chunk(materiaTeste, FontFactory.GetFont(FontFactory.HELVETICA_BOLD));
            paragrafo = new Paragraph();
            paragrafo.Add(chunk);

            string serieTeste = teste.serie.ToString();
            chunk = new Chunk(serieTeste, FontFactory.GetFont(FontFactory.HELVETICA_BOLD));
            paragrafo = new Paragraph();
            paragrafo.Add(chunk);

            foreach (Questao q in teste.listaQuestoes)
            {

                string enunciado = q.enunciado;
                chunk = new Chunk(enunciado, FontFactory.GetFont(FontFactory.HELVETICA));
                paragrafo = new Paragraph();
                paragrafo.Add(chunk);

                foreach (Alternativa alternativas in q.alternativas)
                {
                    string enunciadoAlt = alternativas.alternativa;
                    chunk = new Chunk(enunciadoAlt, FontFactory.GetFont(FontFactory.HELVETICA));
                    paragrafo = new Paragraph();
                    paragrafo.Add(chunk);
                }

                if(ehGabarito == true)
                {
                    Alternativa alt = q.alternativas.Find(x => x.correta == true);
                    chunk = new Chunk("Resposta: " + alt.alternativa, FontFactory.GetFont(FontFactory.HELVETICA));
                    paragrafo = new Paragraph();
                    paragrafo.Add(chunk);
                }
            }

            documento.Add(paragrafo);
            documento.Close();
            arquivo.Close();
        }
                
    }
}
