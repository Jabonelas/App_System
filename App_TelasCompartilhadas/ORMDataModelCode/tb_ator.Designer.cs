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

    public partial class tb_ator : XPLiteObject
    {
        long fid_ator;
        [Key]
        public long id_ator
        {
            get { return fid_ator; }
            set { SetPropertyValue<long>(nameof(id_ator), ref fid_ator, value); }
        }
        string fat_inscEstSubst;
        [Size(20)]
        public string at_inscEstSubst
        {
            get { return fat_inscEstSubst; }
            set { SetPropertyValue<string>(nameof(at_inscEstSubst), ref fat_inscEstSubst, value); }
        }
        byte fat_persTim;
        public byte at_persTim
        {
            get { return fat_persTim; }
            set { SetPropertyValue<byte>(nameof(at_persTim), ref fat_persTim, value); }
        }
        byte fat_dirRede;
        public byte at_dirRede
        {
            get { return fat_dirRede; }
            set { SetPropertyValue<byte>(nameof(at_dirRede), ref fat_dirRede, value); }
        }
        byte fat_dirMov;
        public byte at_dirMov
        {
            get { return fat_dirMov; }
            set { SetPropertyValue<byte>(nameof(at_dirMov), ref fat_dirMov, value); }
        }
        DateTime fat_dtCri;
        public DateTime at_dtCri
        {
            get { return fat_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(at_dtCri), ref fat_dtCri, value); }
        }
        DateTime fat_dtAlt;
        public DateTime at_dtAlt
        {
            get { return fat_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(at_dtAlt), ref fat_dtAlt, value); }
        }
        DateTime fat_dtAcs;
        public DateTime at_dtAcs
        {
            get { return fat_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(at_dtAcs), ref fat_dtAcs, value); }
        }
        decimal fat_desat;
        public decimal at_desat
        {
            get { return fat_desat; }
            set { SetPropertyValue<decimal>(nameof(at_desat), ref fat_desat, value); }
        }
        byte fat_genero;
        public byte at_genero
        {
            get { return fat_genero; }
            set { SetPropertyValue<byte>(nameof(at_genero), ref fat_genero, value); }
        }
        byte fat_nfeIndInscEst;
        public byte at_nfeIndInscEst
        {
            get { return fat_nfeIndInscEst; }
            set { SetPropertyValue<byte>(nameof(at_nfeIndInscEst), ref fat_nfeIndInscEst, value); }
        }
        byte fat_nfeCodRegTrib;
        public byte at_nfeCodRegTrib
        {
            get { return fat_nfeCodRegTrib; }
            set { SetPropertyValue<byte>(nameof(at_nfeCodRegTrib), ref fat_nfeCodRegTrib, value); }
        }
        byte fat_atorTipo;
        public byte at_atorTipo
        {
            get { return fat_atorTipo; }
            set { SetPropertyValue<byte>(nameof(at_atorTipo), ref fat_atorTipo, value); }
        }
        string fat_cnpj;
        [Size(18)]
        public string at_cnpj
        {
            get { return fat_cnpj; }
            set { SetPropertyValue<string>(nameof(at_cnpj), ref fat_cnpj, value); }
        }
        string fat_cpf;
        [Size(14)]
        public string at_cpf
        {
            get { return fat_cpf; }
            set { SetPropertyValue<string>(nameof(at_cpf), ref fat_cpf, value); }
        }
        string fat_rgRne;
        [Size(20)]
        public string at_rgRne
        {
            get { return fat_rgRne; }
            set { SetPropertyValue<string>(nameof(at_rgRne), ref fat_rgRne, value); }
        }
        string fat_idMl;
        [Size(60)]
        public string at_idMl
        {
            get { return fat_idMl; }
            set { SetPropertyValue<string>(nameof(at_idMl), ref fat_idMl, value); }
        }
        string fat_razSoc;
        [Size(60)]
        public string at_razSoc
        {
            get { return fat_razSoc; }
            set { SetPropertyValue<string>(nameof(at_razSoc), ref fat_razSoc, value); }
        }
        string fat_nomeFant;
        [Size(60)]
        public string at_nomeFant
        {
            get { return fat_nomeFant; }
            set { SetPropertyValue<string>(nameof(at_nomeFant), ref fat_nomeFant, value); }
        }
        string fat_end_Logr;
        [Size(60)]
        public string at_end_Logr
        {
            get { return fat_end_Logr; }
            set { SetPropertyValue<string>(nameof(at_end_Logr), ref fat_end_Logr, value); }
        }
        string fat_end_Num;
        [Size(60)]
        public string at_end_Num
        {
            get { return fat_end_Num; }
            set { SetPropertyValue<string>(nameof(at_end_Num), ref fat_end_Num, value); }
        }
        string fat_end_Compl;
        [Size(60)]
        public string at_end_Compl
        {
            get { return fat_end_Compl; }
            set { SetPropertyValue<string>(nameof(at_end_Compl), ref fat_end_Compl, value); }
        }
        string fat_end_Bairro;
        [Size(60)]
        public string at_end_Bairro
        {
            get { return fat_end_Bairro; }
            set { SetPropertyValue<string>(nameof(at_end_Bairro), ref fat_end_Bairro, value); }
        }
        string fat_end_PontoRef;
        [Size(SizeAttribute.Unlimited)]
        public string at_end_PontoRef
        {
            get { return fat_end_PontoRef; }
            set { SetPropertyValue<string>(nameof(at_end_PontoRef), ref fat_end_PontoRef, value); }
        }
        string fat_end_Cep;
        [Size(9)]
        public string at_end_Cep
        {
            get { return fat_end_Cep; }
            set { SetPropertyValue<string>(nameof(at_end_Cep), ref fat_end_Cep, value); }
        }
        long fat_end_Mun;
        public long at_end_Mun
        {
            get { return fat_end_Mun; }
            set { SetPropertyValue<long>(nameof(at_end_Mun), ref fat_end_Mun, value); }
        }
        string fat_telFixo;
        [Size(20)]
        public string at_telFixo
        {
            get { return fat_telFixo; }
            set { SetPropertyValue<string>(nameof(at_telFixo), ref fat_telFixo, value); }
        }
        string fat_telFixoRamal;
        [Size(10)]
        public string at_telFixoRamal
        {
            get { return fat_telFixoRamal; }
            set { SetPropertyValue<string>(nameof(at_telFixoRamal), ref fat_telFixoRamal, value); }
        }
        string fat_telCel;
        [Size(20)]
        public string at_telCel
        {
            get { return fat_telCel; }
            set { SetPropertyValue<string>(nameof(at_telCel), ref fat_telCel, value); }
        }
        string fat_respon;
        [Size(60)]
        public string at_respon
        {
            get { return fat_respon; }
            set { SetPropertyValue<string>(nameof(at_respon), ref fat_respon, value); }
        }
        string fat_inscEst;
        [Size(20)]
        public string at_inscEst
        {
            get { return fat_inscEst; }
            set { SetPropertyValue<string>(nameof(at_inscEst), ref fat_inscEst, value); }
        }
        string fat_inscMun;
        [Size(20)]
        public string at_inscMun
        {
            get { return fat_inscMun; }
            set { SetPropertyValue<string>(nameof(at_inscMun), ref fat_inscMun, value); }
        }
        string fat_inscSuframa;
        [Size(9)]
        public string at_inscSuframa
        {
            get { return fat_inscSuframa; }
            set { SetPropertyValue<string>(nameof(at_inscSuframa), ref fat_inscSuframa, value); }
        }
        string fat_email;
        [Size(60)]
        public string at_email
        {
            get { return fat_email; }
            set { SetPropertyValue<string>(nameof(at_email), ref fat_email, value); }
        }
        string fat_website;
        [Size(60)]
        public string at_website
        {
            get { return fat_website; }
            set { SetPropertyValue<string>(nameof(at_website), ref fat_website, value); }
        }
        string fat_dtNasc;
        [Size(5)]
        public string at_dtNasc
        {
            get { return fat_dtNasc; }
            set { SetPropertyValue<string>(nameof(at_dtNasc), ref fat_dtNasc, value); }
        }
        string fat_emailCont;
        [Size(60)]
        public string at_emailCont
        {
            get { return fat_emailCont; }
            set { SetPropertyValue<string>(nameof(at_emailCont), ref fat_emailCont, value); }
        }
        string fat_obsCom;
        [Size(SizeAttribute.Unlimited)]
        public string at_obsCom
        {
            get { return fat_obsCom; }
            set { SetPropertyValue<string>(nameof(at_obsCom), ref fat_obsCom, value); }
        }
        string fat_obsFisc;
        [Size(SizeAttribute.Unlimited)]
        public string at_obsFisc
        {
            get { return fat_obsFisc; }
            set { SetPropertyValue<string>(nameof(at_obsFisc), ref fat_obsFisc, value); }
        }
        string fat_cnae;
        [Size(12)]
        public string at_cnae
        {
            get { return fat_cnae; }
            set { SetPropertyValue<string>(nameof(at_cnae), ref fat_cnae, value); }
        }
        decimal fat_prop;
        public decimal at_prop
        {
            get { return fat_prop; }
            set { SetPropertyValue<decimal>(nameof(at_prop), ref fat_prop, value); }
        }
        decimal fat_nfeCredSn;
        public decimal at_nfeCredSn
        {
            get { return fat_nfeCredSn; }
            set { SetPropertyValue<decimal>(nameof(at_nfeCredSn), ref fat_nfeCredSn, value); }
        }
        string fat_nfeCscTokenProd;
        public string at_nfeCscTokenProd
        {
            get { return fat_nfeCscTokenProd; }
            set { SetPropertyValue<string>(nameof(at_nfeCscTokenProd), ref fat_nfeCscTokenProd, value); }
        }
        byte fat_nfeCscIdProd;
        public byte at_nfeCscIdProd
        {
            get { return fat_nfeCscIdProd; }
            set { SetPropertyValue<byte>(nameof(at_nfeCscIdProd), ref fat_nfeCscIdProd, value); }
        }
        string fat_nfeCscTokenHom;
        public string at_nfeCscTokenHom
        {
            get { return fat_nfeCscTokenHom; }
            set { SetPropertyValue<string>(nameof(at_nfeCscTokenHom), ref fat_nfeCscTokenHom, value); }
        }
        byte fat_nfeCscIdHom;
        public byte at_nfeCscIdHom
        {
            get { return fat_nfeCscIdHom; }
            set { SetPropertyValue<byte>(nameof(at_nfeCscIdHom), ref fat_nfeCscIdHom, value); }
        }
        decimal fat_revenda;
        public decimal at_revenda
        {
            get { return fat_revenda; }
            set { SetPropertyValue<decimal>(nameof(at_revenda), ref fat_revenda, value); }
        }
        byte fat_nfeEnqSN;
        public byte at_nfeEnqSN
        {
            get { return fat_nfeEnqSN; }
            set { SetPropertyValue<byte>(nameof(at_nfeEnqSN), ref fat_nfeEnqSN, value); }
        }
        byte fat_nfeRecBrutaEnqSN;
        public byte at_nfeRecBrutaEnqSN
        {
            get { return fat_nfeRecBrutaEnqSN; }
            set { SetPropertyValue<byte>(nameof(at_nfeRecBrutaEnqSN), ref fat_nfeRecBrutaEnqSN, value); }
        }
        decimal fat_receitaBrutaTotal;
        public decimal at_receitaBrutaTotal
        {
            get { return fat_receitaBrutaTotal; }
            set { SetPropertyValue<decimal>(nameof(at_receitaBrutaTotal), ref fat_receitaBrutaTotal, value); }
        }
        decimal fat_receitaBrutaTotal_ImpXml;
        public decimal at_receitaBrutaTotal_ImpXml
        {
            get { return fat_receitaBrutaTotal_ImpXml; }
            set { SetPropertyValue<decimal>(nameof(at_receitaBrutaTotal_ImpXml), ref fat_receitaBrutaTotal_ImpXml, value); }
        }
        byte fat_nfeTipoAmb;
        public byte at_nfeTipoAmb
        {
            get { return fat_nfeTipoAmb; }
            set { SetPropertyValue<byte>(nameof(at_nfeTipoAmb), ref fat_nfeTipoAmb, value); }
        }
        decimal fat_percComisAtend;
        public decimal at_percComisAtend
        {
            get { return fat_percComisAtend; }
            set { SetPropertyValue<decimal>(nameof(at_percComisAtend), ref fat_percComisAtend, value); }
        }
        decimal fat_metaMensal;
        public decimal at_metaMensal
        {
            get { return fat_metaMensal; }
            set { SetPropertyValue<decimal>(nameof(at_metaMensal), ref fat_metaMensal, value); }
        }
        string fat_nomeUsuario;
        [Size(20)]
        public string at_nomeUsuario
        {
            get { return fat_nomeUsuario; }
            set { SetPropertyValue<string>(nameof(at_nomeUsuario), ref fat_nomeUsuario, value); }
        }
        string fat_senhaUsuarioHashCode;
        [Size(60)]
        public string at_senhaUsuarioHashCode
        {
            get { return fat_senhaUsuarioHashCode; }
            set { SetPropertyValue<string>(nameof(at_senhaUsuarioHashCode), ref fat_senhaUsuarioHashCode, value); }
        }
        decimal fat_manutPdv;
        public decimal at_manutPdv
        {
            get { return fat_manutPdv; }
            set { SetPropertyValue<decimal>(nameof(at_manutPdv), ref fat_manutPdv, value); }
        }
        long fat_atorH;
        public long at_atorH
        {
            get { return fat_atorH; }
            set { SetPropertyValue<long>(nameof(at_atorH), ref fat_atorH, value); }
        }
        long fat_estH;
        public long at_estH
        {
            get { return fat_estH; }
            set { SetPropertyValue<long>(nameof(at_estH), ref fat_estH, value); }
        }
        decimal fat_canc;
        public decimal at_canc
        {
            get { return fat_canc; }
            set { SetPropertyValue<decimal>(nameof(at_canc), ref fat_canc, value); }
        }
        tb_municipio ffk_tb_municipio;
        [Association(@"tb_atorReferencestb_municipio")]
        public tb_municipio fk_tb_municipio
        {
            get { return ffk_tb_municipio; }
            set { SetPropertyValue<tb_municipio>(nameof(fk_tb_municipio), ref ffk_tb_municipio, value); }
        }
        tb_estados_br ffk_tb_estados_br;
        [Association(@"tb_atorReferencestb_estados_br")]
        public tb_estados_br fk_tb_estados_br
        {
            get { return ffk_tb_estados_br; }
            set { SetPropertyValue<tb_estados_br>(nameof(fk_tb_estados_br), ref ffk_tb_estados_br, value); }
        }
        tb_certificado_digital ffk_tb_certificado_digital;
        [Association(@"tb_atorReferencestb_certificado_digital")]
        public tb_certificado_digital fk_tb_certificado_digital
        {
            get { return ffk_tb_certificado_digital; }
            set { SetPropertyValue<tb_certificado_digital>(nameof(fk_tb_certificado_digital), ref ffk_tb_certificado_digital, value); }
        }
        tb_matriz ffk_tb_matriz;
        [Association(@"tb_atorReferencestb_matriz")]
        public tb_matriz fk_tb_matriz
        {
            get { return ffk_tb_matriz; }
            set { SetPropertyValue<tb_matriz>(nameof(fk_tb_matriz), ref ffk_tb_matriz, value); }
        }
        [Association(@"tb_certificado_digitalReferencestb_ator")]
        public XPCollection<tb_certificado_digital> tb_certificado_digitals { get { return GetCollection<tb_certificado_digital>(nameof(tb_certificado_digitals)); } }
        [Association(@"tb_contReferencestb_ator")]
        public XPCollection<tb_cont> tb_conts { get { return GetCollection<tb_cont>(nameof(tb_conts)); } }
        [Association(@"tb_historicoReferencestb_ator")]
        public XPCollection<tb_historico> tb_historicos { get { return GetCollection<tb_historico>(nameof(tb_historicos)); } }
        [Association(@"tb_movimentacaoReferencestb_ator")]
        public XPCollection<tb_movimentacao> tb_movimentacaos { get { return GetCollection<tb_movimentacao>(nameof(tb_movimentacaos)); } }
        [Association(@"tb_movimentacaoReferencestb_ator1")]
        public XPCollection<tb_movimentacao> tb_movimentacaos1 { get { return GetCollection<tb_movimentacao>(nameof(tb_movimentacaos1)); } }
        [Association(@"tb_movimentacaoReferencestb_ator2")]
        public XPCollection<tb_movimentacao> tb_movimentacaos2 { get { return GetCollection<tb_movimentacao>(nameof(tb_movimentacaos2)); } }
        [Association(@"tb_movimentacao_produtoReferencestb_ator")]
        public XPCollection<tb_movimentacao_produto> tb_movimentacao_produtos { get { return GetCollection<tb_movimentacao_produto>(nameof(tb_movimentacao_produtos)); } }
        [Association(@"tb_pdvReferencestb_ator")]
        public XPCollection<tb_pdv> tb_pdvs { get { return GetCollection<tb_pdv>(nameof(tb_pdvs)); } }
        [Association(@"tb_produtoReferencestb_ator")]
        public XPCollection<tb_produto> tb_produtos { get { return GetCollection<tb_produto>(nameof(tb_produtos)); } }
        [Association(@"tb_produto_filialReferencestb_ator")]
        public XPCollection<tb_produto_filial> tb_produto_filials { get { return GetCollection<tb_produto_filial>(nameof(tb_produto_filials)); } }
        [Association(@"tb_relacao_produto_cadastro_XMLReferencestb_ator")]
        public XPCollection<tb_relacao_produto_cadastro_XML> tb_relacao_produto_cadastro_XMLs { get { return GetCollection<tb_relacao_produto_cadastro_XML>(nameof(tb_relacao_produto_cadastro_XMLs)); } }
        [Association(@"tb_resEventoNFeReferencestb_ator")]
        public XPCollection<tb_resEventoNFe> tb_resEventoNFes { get { return GetCollection<tb_resEventoNFe>(nameof(tb_resEventoNFes)); } }
        [Association(@"tb_resposta_NFeReferencestb_ator")]
        public XPCollection<tb_resposta_NFe> tb_resposta_NFes { get { return GetCollection<tb_resposta_NFe>(nameof(tb_resposta_NFes)); } }
    }

}