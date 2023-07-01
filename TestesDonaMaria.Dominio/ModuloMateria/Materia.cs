using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMaria.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string nome;
        public Materia(string nome)
        {
            this.nome = nome;
        }
        public Materia()
        {

        }
        public override void AtualizarInformacoes(Materia entidade)
        {
            nome = entidade.nome;
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
            campo += $"{sufixo}nome{prefixo},";
            return campo;
        }

        public override SqlParameter[] ObterParametroSQL()
        {
            return new SqlParameter[]
            {
                 new SqlParameter("@nome", nome),
            };
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            if (string.IsNullOrEmpty(nome))
            {
                erros.Add("O nome não pode ser vazio");
            }
            return erros.ToArray();
        }

        public override bool VerificarRepeticao(Materia registro)
        {
            return id != registro.id && nome == registro.nome;
        }
    }
}
