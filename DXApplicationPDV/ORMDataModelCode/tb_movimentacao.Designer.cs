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

    public partial class tb_movimentacao : XPLiteObject
    {
        long fid_movimentacao;
        [Key(AutoGenerate = true)]
        public long id_movimentacao
        {
            get { return fid_movimentacao; }
            set { SetPropertyValue<long>(nameof(id_movimentacao), ref fid_movimentacao, value); }
        }
        byte fmv_nfeTipoAmb;
        public byte mv_nfeTipoAmb
        {
            get { return fmv_nfeTipoAmb; }
            set { SetPropertyValue<byte>(nameof(mv_nfeTipoAmb), ref fmv_nfeTipoAmb, value); }
        }
        DateTime fmv_dtCri;
        public DateTime mv_dtCri
        {
            get { return fmv_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(mv_dtCri), ref fmv_dtCri, value); }
        }
        DateTime fmv_dtAlt;
        public DateTime mv_dtAlt
        {
            get { return fmv_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(mv_dtAlt), ref fmv_dtAlt, value); }
        }
        DateTime fmv_dtAcs;
        public DateTime mv_dtAcs
        {
            get { return fmv_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(mv_dtAcs), ref fmv_dtAcs, value); }
        }
        long fmv_qtdItens;
        public long mv_qtdItens
        {
            get { return fmv_qtdItens; }
            set { SetPropertyValue<long>(nameof(mv_qtdItens), ref fmv_qtdItens, value); }
        }
        long fmv_numSeq;
        public long mv_numSeq
        {
            get { return fmv_numSeq; }
            set { SetPropertyValue<long>(nameof(mv_numSeq), ref fmv_numSeq, value); }
        }
        decimal fmv_canc;
        public decimal mv_canc
        {
            get { return fmv_canc; }
            set { SetPropertyValue<decimal>(nameof(mv_canc), ref fmv_canc, value); }
        }
        decimal fmv_conc;
        public decimal mv_conc
        {
            get { return fmv_conc; }
            set { SetPropertyValue<decimal>(nameof(mv_conc), ref fmv_conc, value); }
        }
        decimal fmv_quit;
        public decimal mv_quit
        {
            get { return fmv_quit; }
            set { SetPropertyValue<decimal>(nameof(mv_quit), ref fmv_quit, value); }
        }
        short fmv_movTipo;
        public short mv_movTipo
        {
            get { return fmv_movTipo; }
            set { SetPropertyValue<short>(nameof(mv_movTipo), ref fmv_movTipo, value); }
        }
        long fmv_codSeqAbertFechCx;
        public long mv_codSeqAbertFechCx
        {
            get { return fmv_codSeqAbertFechCx; }
            set { SetPropertyValue<long>(nameof(mv_codSeqAbertFechCx), ref fmv_codSeqAbertFechCx, value); }
        }
        long fmv_movAbertCx;
        public long mv_movAbertCx
        {
            get { return fmv_movAbertCx; }
            set { SetPropertyValue<long>(nameof(mv_movAbertCx), ref fmv_movAbertCx, value); }
        }
        decimal fmv_cxAberto;
        public decimal mv_cxAberto
        {
            get { return fmv_cxAberto; }
            set { SetPropertyValue<decimal>(nameof(mv_cxAberto), ref fmv_cxAberto, value); }
        }
        decimal fmv_nfeEnfilGer;
        public decimal mv_nfeEnfilGer
        {
            get { return fmv_nfeEnfilGer; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeEnfilGer), ref fmv_nfeEnfilGer, value); }
        }
        string fmv_nfeNatOp;
        [Size(60)]
        public string mv_nfeNatOp
        {
            get { return fmv_nfeNatOp; }
            set { SetPropertyValue<string>(nameof(mv_nfeNatOp), ref fmv_nfeNatOp, value); }
        }
        decimal fmv_nfeVlrTotProd;
        public decimal mv_nfeVlrTotProd
        {
            get { return fmv_nfeVlrTotProd; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotProd), ref fmv_nfeVlrTotProd, value); }
        }
        decimal fmv_nfeVlrTotNF;
        public decimal mv_nfeVlrTotNF
        {
            get { return fmv_nfeVlrTotNF; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotNF), ref fmv_nfeVlrTotNF, value); }
        }
        decimal fmv_nfeVlrTotDesc;
        public decimal mv_nfeVlrTotDesc
        {
            get { return fmv_nfeVlrTotDesc; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotDesc), ref fmv_nfeVlrTotDesc, value); }
        }
        decimal fmv_nfeVlrIcmsDeson;
        public decimal mv_nfeVlrIcmsDeson
        {
            get { return fmv_nfeVlrIcmsDeson; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrIcmsDeson), ref fmv_nfeVlrIcmsDeson, value); }
        }
        decimal fmv_nfeVlrTotIcmsSt;
        public decimal mv_nfeVlrTotIcmsSt
        {
            get { return fmv_nfeVlrTotIcmsSt; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotIcmsSt), ref fmv_nfeVlrTotIcmsSt, value); }
        }
        decimal fmv_nfeVlrTotFcpRetSt;
        public decimal mv_nfeVlrTotFcpRetSt
        {
            get { return fmv_nfeVlrTotFcpRetSt; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotFcpRetSt), ref fmv_nfeVlrTotFcpRetSt, value); }
        }
        decimal fmv_nfeVlrTotFrete;
        public decimal mv_nfeVlrTotFrete
        {
            get { return fmv_nfeVlrTotFrete; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotFrete), ref fmv_nfeVlrTotFrete, value); }
        }
        decimal fmv_nfeVlrTotSeg;
        public decimal mv_nfeVlrTotSeg
        {
            get { return fmv_nfeVlrTotSeg; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotSeg), ref fmv_nfeVlrTotSeg, value); }
        }
        decimal fmv_nfeVlrTotOutro;
        public decimal mv_nfeVlrTotOutro
        {
            get { return fmv_nfeVlrTotOutro; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotOutro), ref fmv_nfeVlrTotOutro, value); }
        }
        decimal fmv_nfeVlrTotImpImp;
        public decimal mv_nfeVlrTotImpImp
        {
            get { return fmv_nfeVlrTotImpImp; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotImpImp), ref fmv_nfeVlrTotImpImp, value); }
        }
        decimal fmv_nfeVlrTotIpi;
        public decimal mv_nfeVlrTotIpi
        {
            get { return fmv_nfeVlrTotIpi; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotIpi), ref fmv_nfeVlrTotIpi, value); }
        }
        decimal fmv_nfeVlrTotIpiDevol;
        public decimal mv_nfeVlrTotIpiDevol
        {
            get { return fmv_nfeVlrTotIpiDevol; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotIpiDevol), ref fmv_nfeVlrTotIpiDevol, value); }
        }
        decimal fmv_nfeVlrTroco;
        public decimal mv_nfeVlrTroco
        {
            get { return fmv_nfeVlrTroco; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTroco), ref fmv_nfeVlrTroco, value); }
        }
        decimal fmv_nfeBcIcms;
        public decimal mv_nfeBcIcms
        {
            get { return fmv_nfeBcIcms; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeBcIcms), ref fmv_nfeBcIcms, value); }
        }
        decimal fmv_nfeVlrBcIcmsSt;
        public decimal mv_nfeVlrBcIcmsSt
        {
            get { return fmv_nfeVlrBcIcmsSt; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrBcIcmsSt), ref fmv_nfeVlrBcIcmsSt, value); }
        }
        decimal fmv_nfeVlrTotTrib;
        public decimal mv_nfeVlrTotTrib
        {
            get { return fmv_nfeVlrTotTrib; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotTrib), ref fmv_nfeVlrTotTrib, value); }
        }
        string fmv_nfeChave;
        [Size(50)]
        public string mv_nfeChave
        {
            get { return fmv_nfeChave; }
            set { SetPropertyValue<string>(nameof(mv_nfeChave), ref fmv_nfeChave, value); }
        }
        decimal fmv_nfeVlrTotCofins;
        public decimal mv_nfeVlrTotCofins
        {
            get { return fmv_nfeVlrTotCofins; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotCofins), ref fmv_nfeVlrTotCofins, value); }
        }
        decimal fmv_nfeVlrTotFcp;
        public decimal mv_nfeVlrTotFcp
        {
            get { return fmv_nfeVlrTotFcp; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotFcp), ref fmv_nfeVlrTotFcp, value); }
        }
        decimal fmv_nfeVlrTotFcpSt;
        public decimal mv_nfeVlrTotFcpSt
        {
            get { return fmv_nfeVlrTotFcpSt; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotFcpSt), ref fmv_nfeVlrTotFcpSt, value); }
        }
        decimal fmv_nfeVlrTotIcms;
        public decimal mv_nfeVlrTotIcms
        {
            get { return fmv_nfeVlrTotIcms; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotIcms), ref fmv_nfeVlrTotIcms, value); }
        }
        decimal fmv_nfeVlrTotPis;
        public decimal mv_nfeVlrTotPis
        {
            get { return fmv_nfeVlrTotPis; }
            set { SetPropertyValue<decimal>(nameof(mv_nfeVlrTotPis), ref fmv_nfeVlrTotPis, value); }
        }
        byte fmv_nfeIdentLocDestOp;
        public byte mv_nfeIdentLocDestOp
        {
            get { return fmv_nfeIdentLocDestOp; }
            set { SetPropertyValue<byte>(nameof(mv_nfeIdentLocDestOp), ref fmv_nfeIdentLocDestOp, value); }
        }
        byte fmv_nfeMod;
        public byte mv_nfeMod
        {
            get { return fmv_nfeMod; }
            set { SetPropertyValue<byte>(nameof(mv_nfeMod), ref fmv_nfeMod, value); }
        }
        byte fmv_nfeIndOpConsumFin;
        public byte mv_nfeIndOpConsumFin
        {
            get { return fmv_nfeIndOpConsumFin; }
            set { SetPropertyValue<byte>(nameof(mv_nfeIndOpConsumFin), ref fmv_nfeIndOpConsumFin, value); }
        }
        byte fmv_nfeFinEmis;
        public byte mv_nfeFinEmis
        {
            get { return fmv_nfeFinEmis; }
            set { SetPropertyValue<byte>(nameof(mv_nfeFinEmis), ref fmv_nfeFinEmis, value); }
        }
        long fmv_nfeIndInterm;
        public long mv_nfeIndInterm
        {
            get { return fmv_nfeIndInterm; }
            set { SetPropertyValue<long>(nameof(mv_nfeIndInterm), ref fmv_nfeIndInterm, value); }
        }
        byte fmv_nfeIndPresCompEstMomOp;
        public byte mv_nfeIndPresCompEstMomOp
        {
            get { return fmv_nfeIndPresCompEstMomOp; }
            set { SetPropertyValue<byte>(nameof(mv_nfeIndPresCompEstMomOp), ref fmv_nfeIndPresCompEstMomOp, value); }
        }
        byte fmv_nfeTipo;
        public byte mv_nfeTipo
        {
            get { return fmv_nfeTipo; }
            set { SetPropertyValue<byte>(nameof(mv_nfeTipo), ref fmv_nfeTipo, value); }
        }
        byte fmv_nfeTipoImpDanfe;
        public byte mv_nfeTipoImpDanfe
        {
            get { return fmv_nfeTipoImpDanfe; }
            set { SetPropertyValue<byte>(nameof(mv_nfeTipoImpDanfe), ref fmv_nfeTipoImpDanfe, value); }
        }
        string fmv_nfeCfop;
        [Size(3)]
        public string mv_nfeCfop
        {
            get { return fmv_nfeCfop; }
            set { SetPropertyValue<string>(nameof(mv_nfeCfop), ref fmv_nfeCfop, value); }
        }
        byte fmv_nfeProcEmis;
        public byte mv_nfeProcEmis
        {
            get { return fmv_nfeProcEmis; }
            set { SetPropertyValue<byte>(nameof(mv_nfeProcEmis), ref fmv_nfeProcEmis, value); }
        }
        string fmv_nfeVerProcEmis;
        [Size(20)]
        public string mv_nfeVerProcEmis
        {
            get { return fmv_nfeVerProcEmis; }
            set { SetPropertyValue<string>(nameof(mv_nfeVerProcEmis), ref fmv_nfeVerProcEmis, value); }
        }
        byte fmv_nfeModFrete;
        public byte mv_nfeModFrete
        {
            get { return fmv_nfeModFrete; }
            set { SetPropertyValue<byte>(nameof(mv_nfeModFrete), ref fmv_nfeModFrete, value); }
        }
        DateTime fmv_nfeDtEmis;
        public DateTime mv_nfeDtEmis
        {
            get { return fmv_nfeDtEmis; }
            set { SetPropertyValue<DateTime>(nameof(mv_nfeDtEmis), ref fmv_nfeDtEmis, value); }
        }
        byte fmv_nfeTipoEmis;
        public byte mv_nfeTipoEmis
        {
            get { return fmv_nfeTipoEmis; }
            set { SetPropertyValue<byte>(nameof(mv_nfeTipoEmis), ref fmv_nfeTipoEmis, value); }
        }
        byte fmv_nfeTipoDfe;
        public byte mv_nfeTipoDfe
        {
            get { return fmv_nfeTipoDfe; }
            set { SetPropertyValue<byte>(nameof(mv_nfeTipoDfe), ref fmv_nfeTipoDfe, value); }
        }
        string fmv_nfeXmlProcRes;
        [Size(SizeAttribute.Unlimited)]
        public string mv_nfeXmlProcRes
        {
            get { return fmv_nfeXmlProcRes; }
            set { SetPropertyValue<string>(nameof(mv_nfeXmlProcRes), ref fmv_nfeXmlProcRes, value); }
        }
        decimal fmv_vlrTotPag;
        public decimal mv_vlrTotPag
        {
            get { return fmv_vlrTotPag; }
            set { SetPropertyValue<decimal>(nameof(mv_vlrTotPag), ref fmv_vlrTotPag, value); }
        }
        string fmv_cpf_tmp;
        [Size(11)]
        public string mv_cpf_tmp
        {
            get { return fmv_cpf_tmp; }
            set { SetPropertyValue<string>(nameof(mv_cpf_tmp), ref fmv_cpf_tmp, value); }
        }
        tb_clasCont2 ffk_tb_clasCont2;
        [Association(@"tb_movimentacaoReferencestb_clasCont2")]
        public tb_clasCont2 fk_tb_clasCont2
        {
            get { return ffk_tb_clasCont2; }
            set { SetPropertyValue<tb_clasCont2>(nameof(fk_tb_clasCont2), ref ffk_tb_clasCont2, value); }
        }
        tb_jornada ffk_tb_jornada;
        [Association(@"tb_movimentacaoReferencestb_jornada")]
        public tb_jornada fk_tb_jornada
        {
            get { return ffk_tb_jornada; }
            set { SetPropertyValue<tb_jornada>(nameof(fk_tb_jornada), ref ffk_tb_jornada, value); }
        }
        tb_ator ffk_tb_ator_atend;
        [Association(@"tb_movimentacaoReferencestb_ator2")]
        public tb_ator fk_tb_ator_atend
        {
            get { return ffk_tb_ator_atend; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator_atend), ref ffk_tb_ator_atend, value); }
        }
        tb_ator ffk_tb_ator_dest;
        [Association(@"tb_movimentacaoReferencestb_ator1")]
        public tb_ator fk_tb_ator_dest
        {
            get { return ffk_tb_ator_dest; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator_dest), ref ffk_tb_ator_dest, value); }
        }
        tb_ator ffk_tb_ator_emit;
        [Association(@"tb_movimentacaoReferencestb_ator")]
        public tb_ator fk_tb_ator_emit
        {
            get { return ffk_tb_ator_emit; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator_emit), ref ffk_tb_ator_emit, value); }
        }
        [Association(@"tb_movimentacao_caixaReferencestb_movimentacao")]
        public XPCollection<tb_movimentacao_caixa> tb_movimentacao_caixas { get { return GetCollection<tb_movimentacao_caixa>(nameof(tb_movimentacao_caixas)); } }
        [Association(@"tb_movimentacao_impressaoReferencestb_movimentacao")]
        public XPCollection<tb_movimentacao_impressao> tb_movimentacao_impressaos { get { return GetCollection<tb_movimentacao_impressao>(nameof(tb_movimentacao_impressaos)); } }
        [Association(@"tb_movimentacao_pagamentoReferencestb_movimentacao")]
        public XPCollection<tb_movimentacao_pagamento> tb_movimentacao_pagamentos { get { return GetCollection<tb_movimentacao_pagamento>(nameof(tb_movimentacao_pagamentos)); } }
        [Association(@"tb_movimentacao_produtoReferencestb_movimentacao")]
        public XPCollection<tb_movimentacao_produto> tb_movimentacao_produtos { get { return GetCollection<tb_movimentacao_produto>(nameof(tb_movimentacao_produtos)); } }
        [Association(@"tb_nfeReferencestb_movimentacao")]
        public XPCollection<tb_nfe> tb_nfes { get { return GetCollection<tb_nfe>(nameof(tb_nfes)); } }
    }

}
