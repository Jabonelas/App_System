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

        public static bool IsUsuarioComPermissao { get; set; }
        public static bool IsInicializarSistema { get; set; }
    }
}