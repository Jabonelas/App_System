using System.Collections.Generic;
using App_TelasCompartilhadas.bancoSQLite;

namespace App_TelasCompartilhadas.Classes
{
    public static class VariaveisGlobais
    {
        public static tb_ator UsuarioLogado { get; set; }

        public static tb_matriz MatrizLogada { get; set; }

        public static tb_rede RedeLogada { get; set; }

        public static tb_pdv PDVLogado { get; set; }

        public static tb_ator FilialLogada { get; set; }

        public static bool isUsuarioComPermissao { get; set; }
        public static bool isInicializarSistema { get; set; }

        /// <summary>
        /// Tela que serar exibida
        /// </summary>
        public static string telaExibir { get; set; }

        /// <summary>
        /// operacao que sera realizada ex: Alterar, Incluir ou Excluir
        /// </summary>
        public static string operacao { get; set; }

        /// <summary>
        /// id do registro que sera alterado, excluido ou buscado
        /// </summary>
        public static int id { get; set; }

        /// <summary>
        /// tipo de cadastro que sera realizado ex: 10 (Empresa), 11 (Filial),
        /// </summary>
        public static int tipo { get; set; }
    }
}