using DevExpress.Xpo;

namespace App_TelasCompartilhadas.bancoSQLite
{
    public partial class tb_produto_filial
    {
        public tb_produto_filial(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        { base.AfterConstruction(); }
    }
}