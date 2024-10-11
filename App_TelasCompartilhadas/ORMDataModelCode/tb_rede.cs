using DevExpress.Xpo;

namespace App_TelasCompartilhadas.bancoSQLite
{
    public partial class tb_rede
    {
        public tb_rede(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        { base.AfterConstruction(); }
    }
}