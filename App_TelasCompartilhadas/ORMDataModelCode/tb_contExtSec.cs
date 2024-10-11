using DevExpress.Xpo;

namespace App_TelasCompartilhadas.bancoSQLite
{
    public partial class tb_contExtSec
    {
        public tb_contExtSec(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        { base.AfterConstruction(); }
    }
}