﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace DXApplicationPDV.bancoSQLite
{
    public partial class tb_contSec
    {
        public tb_contSec(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        { base.AfterConstruction(); }
    }
}