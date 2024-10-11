using DevExpress.Xpo;

namespace App_TelasCompartilhadas.bancoSQLite
{
    public partial class tb_unidade_monetaria
    {
        public tb_unidade_monetaria(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        { base.AfterConstruction(); }
    }
}