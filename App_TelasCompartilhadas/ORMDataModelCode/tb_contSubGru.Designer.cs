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

    public partial class tb_contSubGru : XPLiteObject
    {
        long fid_contSubGru;
        [Key(AutoGenerate = true)]
        public long id_contSubGru
        {
            get { return fid_contSubGru; }
            set { SetPropertyValue<long>(nameof(id_contSubGru), ref fid_contSubGru, value); }
        }
        DateTime fcsg_dtCri;
        public DateTime csg_dtCri
        {
            get { return fcsg_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(csg_dtCri), ref fcsg_dtCri, value); }
        }
        DateTime fcsg_dtAlt;
        public DateTime csg_dtAlt
        {
            get { return fcsg_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(csg_dtAlt), ref fcsg_dtAlt, value); }
        }
        DateTime fcsg_dtAcs;
        public DateTime csg_dtAcs
        {
            get { return fcsg_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(csg_dtAcs), ref fcsg_dtAcs, value); }
        }
        string fcsg_desc;
        [Size(60)]
        public string csg_desc
        {
            get { return fcsg_desc; }
            set { SetPropertyValue<string>(nameof(csg_desc), ref fcsg_desc, value); }
        }
        decimal fcsg_canc;
        public decimal csg_canc
        {
            get { return fcsg_canc; }
            set { SetPropertyValue<decimal>(nameof(csg_canc), ref fcsg_canc, value); }
        }
        decimal fcsg_conc;
        public decimal csg_conc
        {
            get { return fcsg_conc; }
            set { SetPropertyValue<decimal>(nameof(csg_conc), ref fcsg_conc, value); }
        }
        tb_contGru ffk_tb_contGru;
        [Association(@"tb_contSubGruReferencestb_contGru")]
        public tb_contGru fk_tb_contGru
        {
            get { return ffk_tb_contGru; }
            set { SetPropertyValue<tb_contGru>(nameof(fk_tb_contGru), ref ffk_tb_contGru, value); }
        }
        [Association(@"tb_contReferencestb_contSubGru")]
        public XPCollection<tb_cont> tb_conts { get { return GetCollection<tb_cont>(nameof(tb_conts)); } }
        [Association(@"tb_contExtSubGruReferencestb_contSubGru")]
        public XPCollection<tb_contExtSubGru> tb_contExtSubGrus { get { return GetCollection<tb_contExtSubGru>(nameof(tb_contExtSubGrus)); } }
    }

}
