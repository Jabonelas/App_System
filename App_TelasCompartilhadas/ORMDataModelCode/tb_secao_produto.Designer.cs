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

    public partial class tb_secao_produto : XPLiteObject
    {
        long fid_secao_produto;
        [Key(AutoGenerate = true)]
        public long id_secao_produto
        {
            get { return fid_secao_produto; }
            set { SetPropertyValue<long>(nameof(id_secao_produto), ref fid_secao_produto, value); }
        }
        DateTime fsp_dtCri;
        public DateTime sp_dtCri
        {
            get { return fsp_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(sp_dtCri), ref fsp_dtCri, value); }
        }
        DateTime fsp_dtAlt;
        public DateTime sp_dtAlt
        {
            get { return fsp_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(sp_dtAlt), ref fsp_dtAlt, value); }
        }
        DateTime fsp_dtAcs;
        public DateTime sp_dtAcs
        {
            get { return fsp_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(sp_dtAcs), ref fsp_dtAcs, value); }
        }
        decimal fsp_desat;
        public decimal sp_desat
        {
            get { return fsp_desat; }
            set { SetPropertyValue<decimal>(nameof(sp_desat), ref fsp_desat, value); }
        }
        string fsp_desc;
        [Size(48)]
        public string sp_desc
        {
            get { return fsp_desc; }
            set { SetPropertyValue<string>(nameof(sp_desc), ref fsp_desc, value); }
        }
        tb_rede ffk_tb_rede;
        [Association(@"tb_secao_produtoReferencestb_rede")]
        public tb_rede fk_tb_rede
        {
            get { return ffk_tb_rede; }
            set { SetPropertyValue<tb_rede>(nameof(fk_tb_rede), ref ffk_tb_rede, value); }
        }
        [Association(@"tb_categoria_produtoReferencestb_secao_produto")]
        public XPCollection<tb_categoria_produto> tb_categoria_produtos { get { return GetCollection<tb_categoria_produto>(nameof(tb_categoria_produtos)); } }
    }

}
