using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMaria.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public string titulo;
        public int questaoCorretaID;

        public override void AtualizarInformacoes(Questao entidade)
        {
            this.titulo = entidade.titulo;
            this.questaoCorretaID = entidade.questaoCorretaID;
        }

        public override string ObterCampoSQL(bool ehParametro = false)
        {
            string sufixo = "[";
            string prefixo = "]";
            string campo = "";

            if (ehParametro)
            {
                sufixo = "@";
                prefixo = "";
            }
            campo += $"{sufixo}titulo{prefixo},";
            campo += $"{sufixo}questaoCorreta{prefixo},";
            return campo;
        }

        public override SqlParameter[] ObterParametroSQL()
        {
            return new SqlParameter[]
           {
                 new SqlParameter("@titulo", titulo),
                 new SqlParameter("@questaoCorreta", questaoCorretaID)
           };
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            if (string.IsNullOrEmpty(titulo))
            {
                erros.Add("O titulo não pode ser vazio.");
            }
            if(questaoCorretaID < 1)
            {
                erros.Add("É necessario definir uma questão correta.");
            }
            return erros.ToArray();
        }

        public override bool VerificarRepeticao(Questao registro)
        {
            return id != registro.id && titulo == registro.titulo;
        }
    }
}
