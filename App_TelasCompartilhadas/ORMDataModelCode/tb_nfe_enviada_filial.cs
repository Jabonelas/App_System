﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace App_TelasCompartilhadas.bancoSQLite
{
    public partial class tb_nfe_enviada_filial
    {
        public tb_nfe_enviada_filial(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        { base.AfterConstruction(); }
    }
}