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

    public partial class tb_categoria_produto : XPLiteObject
    {
        long fid_categoria_produto;
        [Key(AutoGenerate = true)]
        public long id_categoria_produto
        {
            get { return fid_categoria_produto; }
            set { SetPropertyValue<long>(nameof(id_categoria_produto), ref fid_categoria_produto, value); }
        }
        DateTime fcp_dtCri;
        public DateTime cp_dtCri
        {
            get { return fcp_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(cp_dtCri), ref fcp_dtCri, value); }
        }
        DateTime fcp_dtAlt;
        public DateTime cp_dtAlt
        {
            get { return fcp_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(cp_dtAlt), ref fcp_dtAlt, value); }
        }
        DateTime fcp_dtAcs;
        public DateTime cp_dtAcs
        {
            get { return fcp_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(cp_dtAcs), ref fcp_dtAcs, value); }
        }
        decimal fcp_desat;
        public decimal cp_desat
        {
            get { return fcp_desat; }
            set { SetPropertyValue<decimal>(nameof(cp_desat), ref fcp_desat, value); }
        }
        string fcp_desc;
        [Size(60)]
        public string cp_desc
        {
            get { return fcp_desc; }
            set { SetPropertyValue<string>(nameof(cp_desc), ref fcp_desc, value); }
        }
        tb_secao_produto ffk_tb_secao_produto;
        [Association(@"tb_categoria_produtoReferencestb_secao_produto")]
        public tb_secao_produto fk_tb_secao_produto
        {
            get { return ffk_tb_secao_produto; }
            set { SetPropertyValue<tb_secao_produto>(nameof(fk_tb_secao_produto), ref ffk_tb_secao_produto, value); }
        }
        [Association(@"tb_produtoReferencestb_categoria_produto")]
        public XPCollection<tb_produto> tb_produtos { get { return GetCollection<tb_produto>(nameof(tb_produtos)); } }
        [Association(@"tb_subcategoria_produtoReferencestb_categoria_produto")]
        public XPCollection<tb_subcategoria_produto> tb_subcategoria_produtos { get { return GetCollection<tb_subcategoria_produto>(nameof(tb_subcategoria_produtos)); } }
    }

}
