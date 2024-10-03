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

    public partial class tb_matriz : XPLiteObject
    {
        long fid_matriz;
        [Key(AutoGenerate = true)]
        public long id_matriz
        {
            get { return fid_matriz; }
            set { SetPropertyValue<long>(nameof(id_matriz), ref fid_matriz, value); }
        }
        string fmt_cnpj;
        [Size(18)]
        public string mt_cnpj
        {
            get { return fmt_cnpj; }
            set { SetPropertyValue<string>(nameof(mt_cnpj), ref fmt_cnpj, value); }
        }
        string fmt_nomeFant;
        [Size(60)]
        public string mt_nomeFant
        {
            get { return fmt_nomeFant; }
            set { SetPropertyValue<string>(nameof(mt_nomeFant), ref fmt_nomeFant, value); }
        }
        string fmt_razSoc;
        [Size(60)]
        public string mt_razSoc
        {
            get { return fmt_razSoc; }
            set { SetPropertyValue<string>(nameof(mt_razSoc), ref fmt_razSoc, value); }
        }
        DateTime fmt_dtCri;
        public DateTime mt_dtCri
        {
            get { return fmt_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(mt_dtCri), ref fmt_dtCri, value); }
        }
        DateTime fmt_dtAlt;
        public DateTime mt_dtAlt
        {
            get { return fmt_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(mt_dtAlt), ref fmt_dtAlt, value); }
        }
        DateTime fmt_dtAcs;
        public DateTime mt_dtAcs
        {
            get { return fmt_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(mt_dtAcs), ref fmt_dtAcs, value); }
        }
        short fmt_hrAbertLj;
        public short mt_hrAbertLj
        {
            get { return fmt_hrAbertLj; }
            set { SetPropertyValue<short>(nameof(mt_hrAbertLj), ref fmt_hrAbertLj, value); }
        }
        short fmt_hrFchLj;
        public short mt_hrFchLj
        {
            get { return fmt_hrFchLj; }
            set { SetPropertyValue<short>(nameof(mt_hrFchLj), ref fmt_hrFchLj, value); }
        }
        decimal fmt_efetuaTestesEletro;
        public decimal mt_efetuaTestesEletro
        {
            get { return fmt_efetuaTestesEletro; }
            set { SetPropertyValue<decimal>(nameof(mt_efetuaTestesEletro), ref fmt_efetuaTestesEletro, value); }
        }
        decimal fmt_desat;
        public decimal mt_desat
        {
            get { return fmt_desat; }
            set { SetPropertyValue<decimal>(nameof(mt_desat), ref fmt_desat, value); }
        }
        byte fmt_persTim;
        public byte mt_persTim
        {
            get { return fmt_persTim; }
            set { SetPropertyValue<byte>(nameof(mt_persTim), ref fmt_persTim, value); }
        }
        tb_rede ffk_tb_rede;
        [Association(@"tb_matrizReferencestb_rede")]
        public tb_rede fk_tb_rede
        {
            get { return ffk_tb_rede; }
            set { SetPropertyValue<tb_rede>(nameof(fk_tb_rede), ref ffk_tb_rede, value); }
        }
        [Association(@"tb_atorReferencestb_matriz")]
        public XPCollection<tb_ator> tb_ators { get { return GetCollection<tb_ator>(nameof(tb_ators)); } }
    }

}
