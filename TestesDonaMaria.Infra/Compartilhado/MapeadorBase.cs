using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMaria.Infra.Compartilhado
{
    public abstract class MapeadorBase<TEntidade>
    {
        public abstract void ConfigurarParametros(SqlCommand comando, TEntidade registro);

        public abstract TEntidade ConverterRegistro(SqlDataReader leitorRegistros);
    }
}
