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

    public partial class tb_planCont : XPLiteObject
    {
        long fid_planCont;
        [Key]
        public long id_planCont
        {
            get { return fid_planCont; }
            set { SetPropertyValue<long>(nameof(id_planCont), ref fid_planCont, value); }
        }
        string fpc_desc;
        [Size(60)]
        public string pc_desc
        {
            get { return fpc_desc; }
            set { SetPropertyValue<string>(nameof(pc_desc), ref fpc_desc, value); }
        }
        DateTime fpc_dtCri;
        public DateTime pc_dtCri
        {
            get { return fpc_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(pc_dtCri), ref fpc_dtCri, value); }
        }
        DateTime fpc_dtAlt;
        public DateTime pc_dtAlt
        {
            get { return fpc_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(pc_dtAlt), ref fpc_dtAlt, value); }
        }
        DateTime fpc_dtAcs;
        public DateTime pc_dtAcs
        {
            get { return fpc_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(pc_dtAcs), ref fpc_dtAcs, value); }
        }
        decimal fpc_desat;
        public decimal pc_desat
        {
            get { return fpc_desat; }
            set { SetPropertyValue<decimal>(nameof(pc_desat), ref fpc_desat, value); }
        }
        decimal fpc_canc;
        public decimal pc_canc
        {
            get { return fpc_canc; }
            set { SetPropertyValue<decimal>(nameof(pc_canc), ref fpc_canc, value); }
        }
    }

}