﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace App_TelasCompartilhadas.bancoSQLite
{
    public partial class tb_movimentacao
    {
        public tb_movimentacao(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        { base.AfterConstruction(); }
    }
}