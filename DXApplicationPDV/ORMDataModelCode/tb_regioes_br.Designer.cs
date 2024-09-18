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
namespace DXApplicationPDV.bancoSQLite
{

    public partial class tb_regioes_br : XPLiteObject
    {
        long fid_regioes_br;
        [Key(AutoGenerate = true)]
        public long id_regioes_br
        {
            get { return fid_regioes_br; }
            set { SetPropertyValue<long>(nameof(id_regioes_br), ref fid_regioes_br, value); }
        }
        decimal frb_desat;
        public decimal rb_desat
        {
            get { return frb_desat; }
            set { SetPropertyValue<decimal>(nameof(rb_desat), ref frb_desat, value); }
        }
        byte frb_id;
        public byte rb_id
        {
            get { return frb_id; }
            set { SetPropertyValue<byte>(nameof(rb_id), ref frb_id, value); }
        }
        string frb_sigla;
        [Size(2)]
        public string rb_sigla
        {
            get { return frb_sigla; }
            set { SetPropertyValue<string>(nameof(rb_sigla), ref frb_sigla, value); }
        }
        string frb_nome;
        [Size(12)]
        public string rb_nome
        {
            get { return frb_nome; }
            set { SetPropertyValue<string>(nameof(rb_nome), ref frb_nome, value); }
        }
        tb_pais ffk_tb_pais;
        [Association(@"tb_regioes_brReferencestb_pais")]
        public tb_pais fk_tb_pais
        {
            get { return ffk_tb_pais; }
            set { SetPropertyValue<tb_pais>(nameof(fk_tb_pais), ref ffk_tb_pais, value); }
        }
        [Association(@"tb_estados_brReferencestb_regioes_br")]
        public XPCollection<tb_estados_br> tb_estados_brs { get { return GetCollection<tb_estados_br>(nameof(tb_estados_brs)); } }
    }

}
