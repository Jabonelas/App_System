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
        long fmv_nfeTipoAmb;
        public long mv_nfeTipoAmb
        {
            get { return fmv_nfeTipoAmb; }
            set { SetPropertyValue<long>(nameof(mv_nfeTipoAmb), ref fmv_nfeTipoAmb, value); }
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
        long fmv_canc;
        public long mv_canc
        {
            get { return fmv_canc; }
            set { SetPropertyValue<long>(nameof(mv_canc), ref fmv_canc, value); }
        }
        long fmv_conc;
        public long mv_conc
        {
            get { return fmv_conc; }
            set { SetPropertyValue<long>(nameof(mv_conc), ref fmv_conc, value); }
        }
        long fmv_quit;
        public long mv_quit
        {
            get { return fmv_quit; }
            set { SetPropertyValue<long>(nameof(mv_quit), ref fmv_quit, value); }
        }
        long fmv_movTipo;
        public long mv_movTipo
        {
            get { return fmv_movTipo; }
            set { SetPropertyValue<long>(nameof(mv_movTipo), ref fmv_movTipo, value); }
        }
        long fmv_codSeqAbertFechCx;
        public long mv_codSeqAbertFechCx
        {
            get { return fmv_codSeqAbertFechCx; }
            set { SetPropertyValue<long>(nameof(mv_codSeqAbertFechCx), ref fmv_codSeqAbertFechCx, value); }
        }
        string fmv_movAbertCx;
        [Size(SizeAttribute.Unlimited)]
        public string mv_movAbertCx
        {
            get { return fmv_movAbertCx; }
            set { SetPropertyValue<string>(nameof(mv_movAbertCx), ref fmv_movAbertCx, value); }
        }
        long fmv_cxAberto;
        public long mv_cxAberto
        {
            get { return fmv_cxAberto; }
            set { SetPropertyValue<long>(nameof(mv_cxAberto), ref fmv_cxAberto, value); }
        }
        long fmv_nfeEnfilGer;
        public long mv_nfeEnfilGer
        {
            get { return fmv_nfeEnfilGer; }
            set { SetPropertyValue<long>(nameof(mv_nfeEnfilGer), ref fmv_nfeEnfilGer, value); }
        }
        string fmv_nfeNatOp;
        [Size(SizeAttribute.Unlimited)]
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
        [Size(SizeAttribute.Unlimited)]
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
        long fmv_nfeIdentLocDestOp;
        public long mv_nfeIdentLocDestOp
        {
            get { return fmv_nfeIdentLocDestOp; }
            set { SetPropertyValue<long>(nameof(mv_nfeIdentLocDestOp), ref fmv_nfeIdentLocDestOp, value); }
        }
        long fmv_nfeMod;
        public long mv_nfeMod
        {
            get { return fmv_nfeMod; }
            set { SetPropertyValue<long>(nameof(mv_nfeMod), ref fmv_nfeMod, value); }
        }
        long fmv_nfeIndOpConsumFin;
        public long mv_nfeIndOpConsumFin
        {
            get { return fmv_nfeIndOpConsumFin; }
            set { SetPropertyValue<long>(nameof(mv_nfeIndOpConsumFin), ref fmv_nfeIndOpConsumFin, value); }
        }
        long fmv_nfeFinEmis;
        public long mv_nfeFinEmis
        {
            get { return fmv_nfeFinEmis; }
            set { SetPropertyValue<long>(nameof(mv_nfeFinEmis), ref fmv_nfeFinEmis, value); }
        }
        long fmv_nfeIndInterm;
        public long mv_nfeIndInterm
        {
            get { return fmv_nfeIndInterm; }
            set { SetPropertyValue<long>(nameof(mv_nfeIndInterm), ref fmv_nfeIndInterm, value); }
        }
        long fmv_nfeIndPresCompEstMomOp;
        public long mv_nfeIndPresCompEstMomOp
        {
            get { return fmv_nfeIndPresCompEstMomOp; }
            set { SetPropertyValue<long>(nameof(mv_nfeIndPresCompEstMomOp), ref fmv_nfeIndPresCompEstMomOp, value); }
        }
        long fmv_nfeTipo;
        public long mv_nfeTipo
        {
            get { return fmv_nfeTipo; }
            set { SetPropertyValue<long>(nameof(mv_nfeTipo), ref fmv_nfeTipo, value); }
        }
        long fmv_nfeTipoImpDanfe;
        public long mv_nfeTipoImpDanfe
        {
            get { return fmv_nfeTipoImpDanfe; }
            set { SetPropertyValue<long>(nameof(mv_nfeTipoImpDanfe), ref fmv_nfeTipoImpDanfe, value); }
        }
        string fmv_nfeCfop;
        [Size(SizeAttribute.Unlimited)]
        public string mv_nfeCfop
        {
            get { return fmv_nfeCfop; }
            set { SetPropertyValue<string>(nameof(mv_nfeCfop), ref fmv_nfeCfop, value); }
        }
        long fmv_nfeProcEmis;
        public long mv_nfeProcEmis
        {
            get { return fmv_nfeProcEmis; }
            set { SetPropertyValue<long>(nameof(mv_nfeProcEmis), ref fmv_nfeProcEmis, value); }
        }
        string fmv_nfeVerProcEmis;
        [Size(SizeAttribute.Unlimited)]
        public string mv_nfeVerProcEmis
        {
            get { return fmv_nfeVerProcEmis; }
            set { SetPropertyValue<string>(nameof(mv_nfeVerProcEmis), ref fmv_nfeVerProcEmis, value); }
        }
        long fmv_nfeModFrete;
        public long mv_nfeModFrete
        {
            get { return fmv_nfeModFrete; }
            set { SetPropertyValue<long>(nameof(mv_nfeModFrete), ref fmv_nfeModFrete, value); }
        }
        string fmv_nfeDtEmis;
        [Size(SizeAttribute.Unlimited)]
        public string mv_nfeDtEmis
        {
            get { return fmv_nfeDtEmis; }
            set { SetPropertyValue<string>(nameof(mv_nfeDtEmis), ref fmv_nfeDtEmis, value); }
        }
        long fmv_nfeTipoEmis;
        public long mv_nfeTipoEmis
        {
            get { return fmv_nfeTipoEmis; }
            set { SetPropertyValue<long>(nameof(mv_nfeTipoEmis), ref fmv_nfeTipoEmis, value); }
        }
        long fmv_nfeTipoDfe;
        public long mv_nfeTipoDfe
        {
            get { return fmv_nfeTipoDfe; }
            set { SetPropertyValue<long>(nameof(mv_nfeTipoDfe), ref fmv_nfeTipoDfe, value); }
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
        [Size(SizeAttribute.Unlimited)]
        public string mv_cpf_tmp
        {
            get { return fmv_cpf_tmp; }
            set { SetPropertyValue<string>(nameof(mv_cpf_tmp), ref fmv_cpf_tmp, value); }
        }
        long ffk_tb_ClasCont2;
        public long fk_tb_ClasCont2
        {
            get { return ffk_tb_ClasCont2; }
            set { SetPropertyValue<long>(nameof(fk_tb_ClasCont2), ref ffk_tb_ClasCont2, value); }
        }
        long ffk_tb_jornada;
        public long fk_tb_jornada
        {
            get { return ffk_tb_jornada; }
            set { SetPropertyValue<long>(nameof(fk_tb_jornada), ref ffk_tb_jornada, value); }
        }
        tb_ator ffk_tb_ator_atend;
        [Association(@"tb_movimentacaoReferencestb_ator2")]
        public tb_ator fk_tb_ator_atend
        {
            get { return ffk_tb_ator_atend; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator_atend), ref ffk_tb_ator_atend, value); }
        }
        tb_ator ffk_tb_ator_emit;
        [Association(@"tb_movimentacaoReferencestb_ator1")]
        public tb_ator fk_tb_ator_emit
        {
            get { return ffk_tb_ator_emit; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator_emit), ref ffk_tb_ator_emit, value); }
        }
        tb_ator ffk_tb_ator_dest;
        [Association(@"tb_movimentacaoReferencestb_ator")]
        public tb_ator fk_tb_ator_dest
        {
            get { return ffk_tb_ator_dest; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator_dest), ref ffk_tb_ator_dest, value); }
        }
        [Association(@"tb_nfeReferencestb_movimentacao")]
        public XPCollection<tb_nfe> tb_nfes { get { return GetCollection<tb_nfe>(nameof(tb_nfes)); } }
    }

}
