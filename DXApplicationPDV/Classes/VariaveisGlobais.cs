using DXApplicationPDV.bancoSQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationPDV.Classes
{
    internal class VariaveisGlobais
    {
        public static tb_ator UsuarioLogado { get; set; }

        public static tb_matriz MatrizLogada { get; set; }

        public static tb_rede RedeLogada { get; set; }

        public static tb_pdv PDVLogado { get; set; }
    }
}