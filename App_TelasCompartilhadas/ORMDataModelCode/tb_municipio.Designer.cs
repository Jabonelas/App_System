﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace App_TelasCompartilhadas.bancoSQLite
{

    public partial class tb_municipio : XPLiteObject
    {
        long fid_municipio;
        [Key]
        public long id_municipio
        {
            get { return fid_municipio; }
            set { SetPropertyValue<long>(nameof(id_municipio), ref fid_municipio, value); }
        }
        decimal fmu_desat;
        public decimal mu_desat
        {
            get { return fmu_desat; }
            set { SetPropertyValue<decimal>(nameof(mu_desat), ref fmu_desat, value); }
        }
        long fmu_id;
        public long mu_id
        {
            get { return fmu_id; }
            set { SetPropertyValue<long>(nameof(mu_id), ref fmu_id, value); }
        }
        string fmu_nome;
        [Size(40)]
        public string mu_nome
        {
            get { return fmu_nome; }
            set { SetPropertyValue<string>(nameof(mu_nome), ref fmu_nome, value); }
        }
        tb_estados_br ffk_tb_estados_br;
        [Association(@"tb_municipioReferencestb_estados_br")]
        public tb_estados_br fk_tb_estados_br
        {
            get { return ffk_tb_estados_br; }
            set { SetPropertyValue<tb_estados_br>(nameof(fk_tb_estados_br), ref ffk_tb_estados_br, value); }
        }
        [Association(@"tb_atorReferencestb_municipio")]
        public XPCollection<tb_ator> tb_ators { get { return GetCollection<tb_ator>(nameof(tb_ators)); } }
    }

}
