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

    public partial class tb_unidade_monetaria : XPLiteObject
    {
        long fid_unidade_monetaria;
        [Key(AutoGenerate = true)]
        public long id_unidade_monetaria
        {
            get { return fid_unidade_monetaria; }
            set { SetPropertyValue<long>(nameof(id_unidade_monetaria), ref fid_unidade_monetaria, value); }
        }
        short fun_id;
        public short un_id
        {
            get { return fun_id; }
            set { SetPropertyValue<short>(nameof(un_id), ref fun_id, value); }
        }
        string fun_sigla;
        [Size(3)]
        public string un_sigla
        {
            get { return fun_sigla; }
            set { SetPropertyValue<string>(nameof(un_sigla), ref fun_sigla, value); }
        }
        string fun_nome;
        [Size(256)]
        public string un_nome
        {
            get { return fun_nome; }
            set { SetPropertyValue<string>(nameof(un_nome), ref fun_nome, value); }
        }
        decimal fun_inter;
        public decimal un_inter
        {
            get { return fun_inter; }
            set { SetPropertyValue<decimal>(nameof(un_inter), ref fun_inter, value); }
        }
        decimal fun_cambio;
        public decimal un_cambio
        {
            get { return fun_cambio; }
            set { SetPropertyValue<decimal>(nameof(un_cambio), ref fun_cambio, value); }
        }
        double fun_cambioDt;
        public double un_cambioDt
        {
            get { return fun_cambioDt; }
            set { SetPropertyValue<double>(nameof(un_cambioDt), ref fun_cambioDt, value); }
        }
        decimal fun_canc;
        public decimal un_canc
        {
            get { return fun_canc; }
            set { SetPropertyValue<decimal>(nameof(un_canc), ref fun_canc, value); }
        }
        [Association(@"tb_paisReferencestb_unidade_monetaria")]
        public XPCollection<tb_pais> tb_paiss { get { return GetCollection<tb_pais>(nameof(tb_paiss)); } }
    }

}