using DevExpress.Xpo;

namespace App_TelasCompartilhadas.bancoSQLite
{
    public partial class tb_certificado_digital
    {
        public tb_certificado_digital(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        { base.AfterConstruction(); }
    }
}