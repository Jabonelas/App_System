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

    public partial class tb_contExtGru : XPLiteObject
    {
        long fid_contExtGru;
        [Key(AutoGenerate = true)]
        public long id_contExtGru
        {
            get { return fid_contExtGru; }
            set { SetPropertyValue<long>(nameof(id_contExtGru), ref fid_contExtGru, value); }
        }
        decimal fceg_deb;
        public decimal ceg_deb
        {
            get { return fceg_deb; }
            set { SetPropertyValue<decimal>(nameof(ceg_deb), ref fceg_deb, value); }
        }
        decimal fceg_cred;
        public decimal ceg_cred
        {
            get { return fceg_cred; }
            set { SetPropertyValue<decimal>(nameof(ceg_cred), ref fceg_cred, value); }
        }
        DateTime fceg_dtCri;
        public DateTime ceg_dtCri
        {
            get { return fceg_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(ceg_dtCri), ref fceg_dtCri, value); }
        }
        DateTime fceg_dtAlt;
        public DateTime ceg_dtAlt
        {
            get { return fceg_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(ceg_dtAlt), ref fceg_dtAlt, value); }
        }
        DateTime fceg_dtAcs;
        public DateTime ceg_dtAcs
        {
            get { return fceg_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(ceg_dtAcs), ref fceg_dtAcs, value); }
        }
        decimal fceg_canc;
        public decimal ceg_canc
        {
            get { return fceg_canc; }
            set { SetPropertyValue<decimal>(nameof(ceg_canc), ref fceg_canc, value); }
        }
        decimal fceg_conc;
        public decimal ceg_conc
        {
            get { return fceg_conc; }
            set { SetPropertyValue<decimal>(nameof(ceg_conc), ref fceg_conc, value); }
        }
        tb_contGru ffk_tb_contGru;
        [Association(@"tb_contExtGruReferencestb_contGru")]
        public tb_contGru fk_tb_contGru
        {
            get { return ffk_tb_contGru; }
            set { SetPropertyValue<tb_contGru>(nameof(fk_tb_contGru), ref ffk_tb_contGru, value); }
        }
    }

}
