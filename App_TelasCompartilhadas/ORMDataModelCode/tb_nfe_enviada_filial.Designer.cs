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

    public partial class tb_nfe_enviada_filial : XPLiteObject
    {
        long fid_nfe_enviada_filial;
        [Key(AutoGenerate = true)]
        public long id_nfe_enviada_filial
        {
            get { return fid_nfe_enviada_filial; }
            set { SetPropertyValue<long>(nameof(id_nfe_enviada_filial), ref fid_nfe_enviada_filial, value); }
        }
        DateTime fnef_dtCri;
        public DateTime nef_dtCri
        {
            get { return fnef_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(nef_dtCri), ref fnef_dtCri, value); }
        }
        DateTime fnef_dtAlt;
        public DateTime nef_dtAlt
        {
            get { return fnef_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(nef_dtAlt), ref fnef_dtAlt, value); }
        }
        DateTime fnef_dtAcs;
        public DateTime nef_dtAcs
        {
            get { return fnef_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(nef_dtAcs), ref fnef_dtAcs, value); }
        }
        decimal fnef_desat;
        public decimal nef_desat
        {
            get { return fnef_desat; }
            set { SetPropertyValue<decimal>(nameof(nef_desat), ref fnef_desat, value); }
        }
        tb_pdv ffk_tb_pdv;
        [Association(@"tb_nfe_enviada_filialReferencestb_pdv")]
        public tb_pdv fk_tb_pdv
        {
            get { return ffk_tb_pdv; }
            set { SetPropertyValue<tb_pdv>(nameof(fk_tb_pdv), ref ffk_tb_pdv, value); }
        }
        tb_nfe ffk_tb_nfe;
        [Association(@"tb_nfe_enviada_filialReferencestb_nfe")]
        public tb_nfe fk_tb_nfe
        {
            get { return ffk_tb_nfe; }
            set { SetPropertyValue<tb_nfe>(nameof(fk_tb_nfe), ref ffk_tb_nfe, value); }
        }
    }

}
