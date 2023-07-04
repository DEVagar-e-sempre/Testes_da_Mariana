﻿using Microsoft.Data.SqlClient;

namespace TestesDonaMaria.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string nome;
        public Disciplina(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            if (string.IsNullOrEmpty(nome))
            {
                erros.Add("O nome não pode ser vazio");
            }
            if (nome.Length > 5)
            {
                erros.Add("O nome deve ter mais de 5 caracteres");
            }
            return erros.ToArray();
        }

        public override void AtualizarInformacoes(Disciplina entidade)
        {
            this.id = entidade.id;
            nome = entidade.nome;
        }
    }
}
