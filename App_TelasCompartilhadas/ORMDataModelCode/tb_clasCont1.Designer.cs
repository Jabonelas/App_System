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

    public partial class tb_clasCont1 : XPLiteObject
    {
        long fid_clasCont1;
        [Key(AutoGenerate = true)]
        public long id_clasCont1
        {
            get { return fid_clasCont1; }
            set { SetPropertyValue<long>(nameof(id_clasCont1), ref fid_clasCont1, value); }
        }
        DateTime fcc1_dtCri;
        public DateTime cc1_dtCri
        {
            get { return fcc1_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(cc1_dtCri), ref fcc1_dtCri, value); }
        }
        DateTime fcc1_dtAlt;
        public DateTime cc1_dtAlt
        {
            get { return fcc1_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(cc1_dtAlt), ref fcc1_dtAlt, value); }
        }
        DateTime fcc1_dtAcs;
        public DateTime cc1_dtAcs
        {
            get { return fcc1_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(cc1_dtAcs), ref fcc1_dtAcs, value); }
        }
        decimal fcc1_desat;
        public decimal cc1_desat
        {
            get { return fcc1_desat; }
            set { SetPropertyValue<decimal>(nameof(cc1_desat), ref fcc1_desat, value); }
        }
        string fcc1_desc;
        [Size(48)]
        public string cc1_desc
        {
            get { return fcc1_desc; }
            set { SetPropertyValue<string>(nameof(cc1_desc), ref fcc1_desc, value); }
        }
        decimal fcc1_saida;
        public decimal cc1_saida
        {
            get { return fcc1_saida; }
            set { SetPropertyValue<decimal>(nameof(cc1_saida), ref fcc1_saida, value); }
        }
        tb_rede ffk_tb_rede;
        [Association(@"tb_clasCont1Referencestb_rede")]
        public tb_rede fk_tb_rede
        {
            get { return ffk_tb_rede; }
            set { SetPropertyValue<tb_rede>(nameof(fk_tb_rede), ref ffk_tb_rede, value); }
        }
    }

}
