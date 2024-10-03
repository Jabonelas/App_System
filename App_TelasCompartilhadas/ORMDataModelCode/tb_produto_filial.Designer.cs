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

    public partial class tb_produto_filial : XPLiteObject
    {
        long fid_produto_filial;
        [Key(AutoGenerate = true)]
        public long id_produto_filial
        {
            get { return fid_produto_filial; }
            set { SetPropertyValue<long>(nameof(id_produto_filial), ref fid_produto_filial, value); }
        }
        long fpf_codRef;
        public long pf_codRef
        {
            get { return fpf_codRef; }
            set { SetPropertyValue<long>(nameof(pf_codRef), ref fpf_codRef, value); }
        }
        string fpf_desc;
        [Size(120)]
        public string pf_desc
        {
            get { return fpf_desc; }
            set { SetPropertyValue<string>(nameof(pf_desc), ref fpf_desc, value); }
        }
        string fpf_descCurta;
        [Size(25)]
        public string pf_descCurta
        {
            get { return fpf_descCurta; }
            set { SetPropertyValue<string>(nameof(pf_descCurta), ref fpf_descCurta, value); }
        }
        byte fpf_proTipo;
        public byte pf_proTipo
        {
            get { return fpf_proTipo; }
            set { SetPropertyValue<byte>(nameof(pf_proTipo), ref fpf_proTipo, value); }
        }
        byte fpf_unMedCom;
        public byte pf_unMedCom
        {
            get { return fpf_unMedCom; }
            set { SetPropertyValue<byte>(nameof(pf_unMedCom), ref fpf_unMedCom, value); }
        }
        DateTime fpf_dtCri;
        public DateTime pf_dtCri
        {
            get { return fpf_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(pf_dtCri), ref fpf_dtCri, value); }
        }
        DateTime fpf_dtAlt;
        public DateTime pf_dtAlt
        {
            get { return fpf_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(pf_dtAlt), ref fpf_dtAlt, value); }
        }
        DateTime fpf_dtAcs;
        public DateTime pf_dtAcs
        {
            get { return fpf_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(pf_dtAcs), ref fpf_dtAcs, value); }
        }
        long fpf_atorFil;
        public long pf_atorFil
        {
            get { return fpf_atorFil; }
            set { SetPropertyValue<long>(nameof(pf_atorFil), ref fpf_atorFil, value); }
        }
        decimal fpf_vlrUnCom;
        public decimal pf_vlrUnCom
        {
            get { return fpf_vlrUnCom; }
            set { SetPropertyValue<decimal>(nameof(pf_vlrUnCom), ref fpf_vlrUnCom, value); }
        }
        decimal fpf_cstUnCom;
        public decimal pf_cstUnCom
        {
            get { return fpf_cstUnCom; }
            set { SetPropertyValue<decimal>(nameof(pf_cstUnCom), ref fpf_cstUnCom, value); }
        }
        decimal fpf_estMin;
        public decimal pf_estMin
        {
            get { return fpf_estMin; }
            set { SetPropertyValue<decimal>(nameof(pf_estMin), ref fpf_estMin, value); }
        }
        decimal fpf_est;
        public decimal pf_est
        {
            get { return fpf_est; }
            set { SetPropertyValue<decimal>(nameof(pf_est), ref fpf_est, value); }
        }
        decimal fpf_desat;
        public decimal pf_desat
        {
            get { return fpf_desat; }
            set { SetPropertyValue<decimal>(nameof(pf_desat), ref fpf_desat, value); }
        }
        decimal fpf_canc;
        public decimal pf_canc
        {
            get { return fpf_canc; }
            set { SetPropertyValue<decimal>(nameof(pf_canc), ref fpf_canc, value); }
        }
        tb_produto ffk_tb_produto;
        [Association(@"tb_produto_filialReferencestb_produto")]
        public tb_produto fk_tb_produto
        {
            get { return ffk_tb_produto; }
            set { SetPropertyValue<tb_produto>(nameof(fk_tb_produto), ref ffk_tb_produto, value); }
        }
        tb_ator ffk_tb_ator;
        [Association(@"tb_produto_filialReferencestb_ator")]
        public tb_ator fk_tb_ator
        {
            get { return ffk_tb_ator; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator), ref ffk_tb_ator, value); }
        }
        [Association(@"tb_relacao_produto_cadastro_XMLReferencestb_produto_filial")]
        public XPCollection<tb_relacao_produto_cadastro_XML> tb_relacao_produto_cadastro_XMLs { get { return GetCollection<tb_relacao_produto_cadastro_XML>(nameof(tb_relacao_produto_cadastro_XMLs)); } }
    }

}
