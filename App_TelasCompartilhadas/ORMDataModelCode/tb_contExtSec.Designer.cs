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

    public partial class tb_contExtSec : XPLiteObject
    {
        long fid_contExtSec;
        [Key(AutoGenerate = true)]
        public long id_contExtSec
        {
            get { return fid_contExtSec; }
            set { SetPropertyValue<long>(nameof(id_contExtSec), ref fid_contExtSec, value); }
        }
        decimal fces_deb;
        public decimal ces_deb
        {
            get { return fces_deb; }
            set { SetPropertyValue<decimal>(nameof(ces_deb), ref fces_deb, value); }
        }
        decimal fces_cred;
        public decimal ces_cred
        {
            get { return fces_cred; }
            set { SetPropertyValue<decimal>(nameof(ces_cred), ref fces_cred, value); }
        }
        DateTime fces_dtCri;
        public DateTime ces_dtCri
        {
            get { return fces_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(ces_dtCri), ref fces_dtCri, value); }
        }
        DateTime fces_dtAlt;
        public DateTime ces_dtAlt
        {
            get { return fces_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(ces_dtAlt), ref fces_dtAlt, value); }
        }
        DateTime fces_dtAcs;
        public DateTime ces_dtAcs
        {
            get { return fces_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(ces_dtAcs), ref fces_dtAcs, value); }
        }
        decimal fces_canc;
        public decimal ces_canc
        {
            get { return fces_canc; }
            set { SetPropertyValue<decimal>(nameof(ces_canc), ref fces_canc, value); }
        }
        decimal fces_conc;
        public decimal ces_conc
        {
            get { return fces_conc; }
            set { SetPropertyValue<decimal>(nameof(ces_conc), ref fces_conc, value); }
        }
        tb_contSec ffk_tb_contSec;
        [Association(@"tb_contExtSecReferencestb_contSec")]
        public tb_contSec fk_tb_contSec
        {
            get { return ffk_tb_contSec; }
            set { SetPropertyValue<tb_contSec>(nameof(fk_tb_contSec), ref ffk_tb_contSec, value); }
        }
    }

}
