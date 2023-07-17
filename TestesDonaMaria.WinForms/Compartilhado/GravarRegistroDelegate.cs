using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMaria.Dominio.Compartilhado;

namespace TestesDonaMaria.WinForms.Compartilhado
{
    public delegate Result GravarRegistroDelegate<T>(T registro) where T : EntidadeBase<T>;
}
