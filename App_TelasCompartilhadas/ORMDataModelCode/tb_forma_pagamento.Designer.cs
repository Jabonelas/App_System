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

    public partial class tb_forma_pagamento : XPLiteObject
    {
        long fid_forma_pagamento;
        [Key]
        public long id_forma_pagamento
        {
            get { return fid_forma_pagamento; }
            set { SetPropertyValue<long>(nameof(id_forma_pagamento), ref fid_forma_pagamento, value); }
        }
        DateTime ffp_dtCri;
        public DateTime fp_dtCri
        {
            get { return ffp_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(fp_dtCri), ref ffp_dtCri, value); }
        }
        DateTime ffp_dtAlt;
        public DateTime fp_dtAlt
        {
            get { return ffp_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(fp_dtAlt), ref ffp_dtAlt, value); }
        }
        DateTime ffp_dtAcs;
        public DateTime fp_dtAcs
        {
            get { return ffp_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(fp_dtAcs), ref ffp_dtAcs, value); }
        }
        decimal ffp_desat;
        public decimal fp_desat
        {
            get { return ffp_desat; }
            set { SetPropertyValue<decimal>(nameof(fp_desat), ref ffp_desat, value); }
        }
        string ffp_desc;
        [Size(60)]
        public string fp_desc
        {
            get { return ffp_desc; }
            set { SetPropertyValue<string>(nameof(fp_desc), ref ffp_desc, value); }
        }
        short ffp_ordExib;
        public short fp_ordExib
        {
            get { return ffp_ordExib; }
            set { SetPropertyValue<short>(nameof(fp_ordExib), ref ffp_ordExib, value); }
        }
        char ffp_atalhoTecl;
        public char fp_atalhoTecl
        {
            get { return ffp_atalhoTecl; }
            set { SetPropertyValue<char>(nameof(fp_atalhoTecl), ref ffp_atalhoTecl, value); }
        }
        string ffp_taxaDesc;
        [Size(60)]
        public string fp_taxaDesc
        {
            get { return ffp_taxaDesc; }
            set { SetPropertyValue<string>(nameof(fp_taxaDesc), ref ffp_taxaDesc, value); }
        }
        DateTime ffp_taxaData;
        public DateTime fp_taxaData
        {
            get { return ffp_taxaData; }
            set { SetPropertyValue<DateTime>(nameof(fp_taxaData), ref ffp_taxaData, value); }
        }
        decimal ffp_taxa0;
        public decimal fp_taxa0
        {
            get { return ffp_taxa0; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa0), ref ffp_taxa0, value); }
        }
        decimal ffp_taxa1;
        public decimal fp_taxa1
        {
            get { return ffp_taxa1; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa1), ref ffp_taxa1, value); }
        }
        decimal ffp_taxa2;
        public decimal fp_taxa2
        {
            get { return ffp_taxa2; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa2), ref ffp_taxa2, value); }
        }
        decimal ffp_taxa3;
        public decimal fp_taxa3
        {
            get { return ffp_taxa3; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa3), ref ffp_taxa3, value); }
        }
        decimal ffp_taxa4;
        public decimal fp_taxa4
        {
            get { return ffp_taxa4; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa4), ref ffp_taxa4, value); }
        }
        decimal ffp_taxa5;
        public decimal fp_taxa5
        {
            get { return ffp_taxa5; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa5), ref ffp_taxa5, value); }
        }
        decimal ffp_taxa6;
        public decimal fp_taxa6
        {
            get { return ffp_taxa6; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa6), ref ffp_taxa6, value); }
        }
        decimal ffp_taxa7;
        public decimal fp_taxa7
        {
            get { return ffp_taxa7; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa7), ref ffp_taxa7, value); }
        }
        decimal ffp_taxa8;
        public decimal fp_taxa8
        {
            get { return ffp_taxa8; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa8), ref ffp_taxa8, value); }
        }
        decimal ffp_taxa9;
        public decimal fp_taxa9
        {
            get { return ffp_taxa9; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa9), ref ffp_taxa9, value); }
        }
        decimal ffp_taxa10;
        public decimal fp_taxa10
        {
            get { return ffp_taxa10; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa10), ref ffp_taxa10, value); }
        }
        decimal ffp_taxa11;
        public decimal fp_taxa11
        {
            get { return ffp_taxa11; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa11), ref ffp_taxa11, value); }
        }
        decimal ffp_taxa12;
        public decimal fp_taxa12
        {
            get { return ffp_taxa12; }
            set { SetPropertyValue<decimal>(nameof(fp_taxa12), ref ffp_taxa12, value); }
        }
        decimal ffp_vlrMin;
        public decimal fp_vlrMin
        {
            get { return ffp_vlrMin; }
            set { SetPropertyValue<decimal>(nameof(fp_vlrMin), ref ffp_vlrMin, value); }
        }
        decimal ffp_vlrMax;
        public decimal fp_vlrMax
        {
            get { return ffp_vlrMax; }
            set { SetPropertyValue<decimal>(nameof(fp_vlrMax), ref ffp_vlrMax, value); }
        }
        short ffp_parcMin;
        public short fp_parcMin
        {
            get { return ffp_parcMin; }
            set { SetPropertyValue<short>(nameof(fp_parcMin), ref ffp_parcMin, value); }
        }
        short ffp_parcMax;
        public short fp_parcMax
        {
            get { return ffp_parcMax; }
            set { SetPropertyValue<short>(nameof(fp_parcMax), ref ffp_parcMax, value); }
        }
        short ffp_intParcBase;
        public short fp_intParcBase
        {
            get { return ffp_intParcBase; }
            set { SetPropertyValue<short>(nameof(fp_intParcBase), ref ffp_intParcBase, value); }
        }
        long ffp_nfeIndPag;
        public long fp_nfeIndPag
        {
            get { return ffp_nfeIndPag; }
            set { SetPropertyValue<long>(nameof(fp_nfeIndPag), ref ffp_nfeIndPag, value); }
        }
        long ffp_nfeTipoPag;
        public long fp_nfeTipoPag
        {
            get { return ffp_nfeTipoPag; }
            set { SetPropertyValue<long>(nameof(fp_nfeTipoPag), ref ffp_nfeTipoPag, value); }
        }
        byte ffp_nfeTipoIntegr;
        public byte fp_nfeTipoIntegr
        {
            get { return ffp_nfeTipoIntegr; }
            set { SetPropertyValue<byte>(nameof(fp_nfeTipoIntegr), ref ffp_nfeTipoIntegr, value); }
        }
        decimal ffp_canc;
        public decimal fp_canc
        {
            get { return ffp_canc; }
            set { SetPropertyValue<decimal>(nameof(fp_canc), ref ffp_canc, value); }
        }
        tb_rede ffk_tb_rede;
        [Association(@"tb_forma_pagamentoReferencestb_rede")]
        public tb_rede fk_tb_rede
        {
            get { return ffk_tb_rede; }
            set { SetPropertyValue<tb_rede>(nameof(fk_tb_rede), ref ffk_tb_rede, value); }
        }
        [Association(@"tb_sub_forma_pagamentoReferencestb_forma_pagamento")]
        public XPCollection<tb_sub_forma_pagamento> tb_sub_forma_pagamentos { get { return GetCollection<tb_sub_forma_pagamento>(nameof(tb_sub_forma_pagamentos)); } }
    }

}
