using System;
using System.IO;
using iText.Kernel.Font;
using iTextSharp.text;
using iTextSharp.text.pdf;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Dominio.ModuloTeste;
using Font = System.Drawing.Font;

namespace TestesDonaMaria.WinForms.ModuloTeste
{
    public class GeradorPDF
    {
        private Chunk chunk;
        private Document documento;
        private FileStream arquivo;
        private String pastaTesteMariana;

        public GeradorPDF()
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.pastaTesteMariana = Path.Combine(documentosPath, "TestesMariana");
            if (!Directory.Exists(pastaTesteMariana))
            {
                Directory.CreateDirectory(pastaTesteMariana);
            }
            
        }

        public void GerarPDF(Teste teste, bool ehGabarito = false)
        {
            documento = new Document();

            string nomeArquivo = teste.titulo + " - " + teste.materia.nome + " - " + teste.serie + "º ano";
            if (ehGabarito)
            {
                nomeArquivo = nomeArquivo + " - Gabarito";
            }

            arquivo = new FileStream(Path.Combine(pastaTesteMariana, nomeArquivo + ".pdf"), FileMode.Create);

            Paragraph paragrafo;
            PdfWriter escritor = PdfWriter.GetInstance(documento, arquivo);
            documento.Open();

           


            var fonteNegritoHelvetica = FontFactory.GetFont(FontFactory.HELVETICA_BOLD);

            string escola = "Escola: _________________________________________________________";
            paragrafo = new Paragraph(escola, fonteNegritoHelvetica);
            documento.Add(paragrafo);

            string disciplina = "Disciplina: " + teste.materia.disciplina.nome;
            paragrafo = new Paragraph(disciplina, fonteNegritoHelvetica);
            documento.Add(paragrafo);

            string professor = "Professor(a): __________________________________________________";
            paragrafo = new Paragraph(professor, fonteNegritoHelvetica);
            documento.Add(paragrafo);

            string aluno = "Aluno(a): ________________________________________________________";
            paragrafo = new Paragraph(aluno, fonteNegritoHelvetica);

            string data = "Data: __/__/20__";
            paragrafo = new Paragraph(data, fonteNegritoHelvetica);
            documento.Add(paragrafo);

            string tituloTeste = teste.titulo + " - " + teste.materia.nome + " - " + teste.serie + "º ano";
            paragrafo = new Paragraph(tituloTeste, fonteNegritoHelvetica);
            paragrafo.Alignment = Element.ALIGN_CENTER;
            documento.Add(paragrafo);

            var fonteNormalHelvetica = FontFactory.GetFont(FontFactory.HELVETICA);

            int numeroQuestao = 1;
            char letra;
            foreach (Questao q in teste.listaQuestoes)
            {

                string enunciado = numeroQuestao + ") " + q.enunciado;
                paragrafo = new Paragraph(enunciado, fonteNegritoHelvetica);
                documento.Add(paragrafo);
                letra = 'A';
                string correta = "";
                numeroQuestao++;
                foreach (Alternativa alternativa in q.alternativas)
                {
                    string enunciadoAlt = "     (" + letra + ") " + alternativa.alternativa;
                    paragrafo = new Paragraph(enunciadoAlt, fonteNormalHelvetica);
                    documento.Add(paragrafo);
                    if (alternativa.correta == true)
                    {
                        correta = letra.ToString();
                    }
                    letra++;
                }

                if(ehGabarito == true)
                {
                    paragrafo = new Paragraph("Resposta: " + correta, fonteNegritoHelvetica);
                    documento.Add(paragrafo);
                }
            }
            documento.Close();
            arquivo.Close();
        }
                
    }
}
