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

    public partial class tb_produto : XPLiteObject
    {
        long fid_produto;
        [Key]
        public long id_produto
        {
            get { return fid_produto; }
            set { SetPropertyValue<long>(nameof(id_produto), ref fid_produto, value); }
        }
        DateTime fpd_dtCri;
        public DateTime pd_dtCri
        {
            get { return fpd_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(pd_dtCri), ref fpd_dtCri, value); }
        }
        DateTime fpd_dtAlt;
        public DateTime pd_dtAlt
        {
            get { return fpd_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(pd_dtAlt), ref fpd_dtAlt, value); }
        }
        decimal fpd_desat;
        public decimal pd_desat
        {
            get { return fpd_desat; }
            set { SetPropertyValue<decimal>(nameof(pd_desat), ref fpd_desat, value); }
        }
        byte fpd_genero;
        public byte pd_genero
        {
            get { return fpd_genero; }
            set { SetPropertyValue<byte>(nameof(pd_genero), ref fpd_genero, value); }
        }
        byte fpd_unMedCom;
        public byte pd_unMedCom
        {
            get { return fpd_unMedCom; }
            set { SetPropertyValue<byte>(nameof(pd_unMedCom), ref fpd_unMedCom, value); }
        }
        long fpd_codRef;
        public long pd_codRef
        {
            get { return fpd_codRef; }
            set { SetPropertyValue<long>(nameof(pd_codRef), ref fpd_codRef, value); }
        }
        string fpd_codRefStr;
        [Size(20)]
        public string pd_codRefStr
        {
            get { return fpd_codRefStr; }
            set { SetPropertyValue<string>(nameof(pd_codRefStr), ref fpd_codRefStr, value); }
        }
        string fpd_barras;
        [Size(512)]
        public string pd_barras
        {
            get { return fpd_barras; }
            set { SetPropertyValue<string>(nameof(pd_barras), ref fpd_barras, value); }
        }
        string fpd_impRef;
        [Size(60)]
        public string pd_impRef
        {
            get { return fpd_impRef; }
            set { SetPropertyValue<string>(nameof(pd_impRef), ref fpd_impRef, value); }
        }
        byte fpd_proTipo;
        public byte pd_proTipo
        {
            get { return fpd_proTipo; }
            set { SetPropertyValue<byte>(nameof(pd_proTipo), ref fpd_proTipo, value); }
        }
        byte fpd_especie;
        public byte pd_especie
        {
            get { return fpd_especie; }
            set { SetPropertyValue<byte>(nameof(pd_especie), ref fpd_especie, value); }
        }
        decimal fpd_estTot;
        public decimal pd_estTot
        {
            get { return fpd_estTot; }
            set { SetPropertyValue<decimal>(nameof(pd_estTot), ref fpd_estTot, value); }
        }
        decimal fpd_invend;
        public decimal pd_invend
        {
            get { return fpd_invend; }
            set { SetPropertyValue<decimal>(nameof(pd_invend), ref fpd_invend, value); }
        }
        string fpd_descCurta;
        [Size(25)]
        public string pd_descCurta
        {
            get { return fpd_descCurta; }
            set { SetPropertyValue<string>(nameof(pd_descCurta), ref fpd_descCurta, value); }
        }
        string fpd_desc;
        [Size(120)]
        public string pd_desc
        {
            get { return fpd_desc; }
            set { SetPropertyValue<string>(nameof(pd_desc), ref fpd_desc, value); }
        }
        byte fpd_fxEta;
        public byte pd_fxEta
        {
            get { return fpd_fxEta; }
            set { SetPropertyValue<byte>(nameof(pd_fxEta), ref fpd_fxEta, value); }
        }
        decimal fpd_vlrUnComBase;
        public decimal pd_vlrUnComBase
        {
            get { return fpd_vlrUnComBase; }
            set { SetPropertyValue<decimal>(nameof(pd_vlrUnComBase), ref fpd_vlrUnComBase, value); }
        }
        decimal fpd_cstUnComBase;
        public decimal pd_cstUnComBase
        {
            get { return fpd_cstUnComBase; }
            set { SetPropertyValue<decimal>(nameof(pd_cstUnComBase), ref fpd_cstUnComBase, value); }
        }
        decimal fpd_estMinBase;
        public decimal pd_estMinBase
        {
            get { return fpd_estMinBase; }
            set { SetPropertyValue<decimal>(nameof(pd_estMinBase), ref fpd_estMinBase, value); }
        }
        decimal fpd_estMaxBase;
        public decimal pd_estMaxBase
        {
            get { return fpd_estMaxBase; }
            set { SetPropertyValue<decimal>(nameof(pd_estMaxBase), ref fpd_estMaxBase, value); }
        }
        byte fpd_nfeProdOrigem;
        public byte pd_nfeProdOrigem
        {
            get { return fpd_nfeProdOrigem; }
            set { SetPropertyValue<byte>(nameof(pd_nfeProdOrigem), ref fpd_nfeProdOrigem, value); }
        }
        short fpd_nfeCsosn;
        public short pd_nfeCsosn
        {
            get { return fpd_nfeCsosn; }
            set { SetPropertyValue<short>(nameof(pd_nfeCsosn), ref fpd_nfeCsosn, value); }
        }
        decimal fpd_vend;
        public decimal pd_vend
        {
            get { return fpd_vend; }
            set { SetPropertyValue<decimal>(nameof(pd_vend), ref fpd_vend, value); }
        }
        string fpd_tmpStr;
        [Size(SizeAttribute.Unlimited)]
        public string pd_tmpStr
        {
            get { return fpd_tmpStr; }
            set { SetPropertyValue<string>(nameof(pd_tmpStr), ref fpd_tmpStr, value); }
        }
        decimal fpd_ativo;
        public decimal pd_ativo
        {
            get { return fpd_ativo; }
            set { SetPropertyValue<decimal>(nameof(pd_ativo), ref fpd_ativo, value); }
        }
        tb_est ffk_tb_est;
        [Association(@"tb_produtoReferencestb_est")]
        public tb_est fk_tb_est
        {
            get { return ffk_tb_est; }
            set { SetPropertyValue<tb_est>(nameof(fk_tb_est), ref ffk_tb_est, value); }
        }
        tb_rede ffk_tb_rede;
        [Association(@"tb_produtoReferencestb_rede")]
        public tb_rede fk_tb_rede
        {
            get { return ffk_tb_rede; }
            set { SetPropertyValue<tb_rede>(nameof(fk_tb_rede), ref ffk_tb_rede, value); }
        }
        tb_ncm ffk_tb_ncm;
        [Association(@"tb_produtoReferencestb_ncm")]
        public tb_ncm fk_tb_ncm
        {
            get { return ffk_tb_ncm; }
            set { SetPropertyValue<tb_ncm>(nameof(fk_tb_ncm), ref ffk_tb_ncm, value); }
        }
        tb_ator ffk_tb_ator;
        [Association(@"tb_produtoReferencestb_ator")]
        public tb_ator fk_tb_ator
        {
            get { return ffk_tb_ator; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator), ref ffk_tb_ator, value); }
        }
        tb_relacao_produto_cadastro_XML ffk_tb_relacao_produto_cadastro_XML;
        [Association(@"tb_produtoReferencestb_relacao_produto_cadastro_XML")]
        public tb_relacao_produto_cadastro_XML fk_tb_relacao_produto_cadastro_XML
        {
            get { return ffk_tb_relacao_produto_cadastro_XML; }
            set { SetPropertyValue<tb_relacao_produto_cadastro_XML>(nameof(fk_tb_relacao_produto_cadastro_XML), ref ffk_tb_relacao_produto_cadastro_XML, value); }
        }
        tb_marca_produto ffk_tb_marca_produto;
        [Association(@"tb_produtoReferencestb_marca_produto")]
        public tb_marca_produto fk_tb_marca_produto
        {
            get { return ffk_tb_marca_produto; }
            set { SetPropertyValue<tb_marca_produto>(nameof(fk_tb_marca_produto), ref ffk_tb_marca_produto, value); }
        }
        tb_subcategoria_produto ffk_tb_subcategoria_produto;
        [Association(@"tb_produtoReferencestb_subcategoria_produto")]
        public tb_subcategoria_produto fk_tb_subcategoria_produto
        {
            get { return ffk_tb_subcategoria_produto; }
            set { SetPropertyValue<tb_subcategoria_produto>(nameof(fk_tb_subcategoria_produto), ref ffk_tb_subcategoria_produto, value); }
        }
        tb_categoria_produto ffk_tb_categoria_produto;
        [Association(@"tb_produtoReferencestb_categoria_produto")]
        public tb_categoria_produto fk_tb_categoria_produto
        {
            get { return ffk_tb_categoria_produto; }
            set { SetPropertyValue<tb_categoria_produto>(nameof(fk_tb_categoria_produto), ref ffk_tb_categoria_produto, value); }
        }
        [Association(@"tb_codigo_produtoReferencestb_produto")]
        public XPCollection<tb_codigo_produto> tb_codigo_produtos { get { return GetCollection<tb_codigo_produto>(nameof(tb_codigo_produtos)); } }
        [Association(@"tb_movimentacao_produtoReferencestb_produto")]
        public XPCollection<tb_movimentacao_produto> tb_movimentacao_produtos { get { return GetCollection<tb_movimentacao_produto>(nameof(tb_movimentacao_produtos)); } }
        [Association(@"tb_produto_filialReferencestb_produto")]
        public XPCollection<tb_produto_filial> tb_produto_filials { get { return GetCollection<tb_produto_filial>(nameof(tb_produto_filials)); } }
        [Association(@"tb_relacao_produto_cadastro_XMLReferencestb_produto")]
        public XPCollection<tb_relacao_produto_cadastro_XML> tb_relacao_produto_cadastro_XMLs { get { return GetCollection<tb_relacao_produto_cadastro_XML>(nameof(tb_relacao_produto_cadastro_XMLs)); } }
    }

}
