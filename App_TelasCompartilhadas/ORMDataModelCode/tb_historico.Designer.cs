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

    public partial class tb_historico : XPLiteObject
    {
        long fid_historico;
        [Key]
        public long id_historico
        {
            get { return fid_historico; }
            set { SetPropertyValue<long>(nameof(id_historico), ref fid_historico, value); }
        }
        DateTime fhi_dtCri;
        public DateTime hi_dtCri
        {
            get { return fhi_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(hi_dtCri), ref fhi_dtCri, value); }
        }
        string fhi_sqlTableName;
        public string hi_sqlTableName
        {
            get { return fhi_sqlTableName; }
            set { SetPropertyValue<string>(nameof(hi_sqlTableName), ref fhi_sqlTableName, value); }
        }
        string fhi_sqlColumnName;
        public string hi_sqlColumnName
        {
            get { return fhi_sqlColumnName; }
            set { SetPropertyValue<string>(nameof(hi_sqlColumnName), ref fhi_sqlColumnName, value); }
        }
        string fhi_conteudoAnterior;
        [Size(SizeAttribute.Unlimited)]
        public string hi_conteudoAnterior
        {
            get { return fhi_conteudoAnterior; }
            set { SetPropertyValue<string>(nameof(hi_conteudoAnterior), ref fhi_conteudoAnterior, value); }
        }
        string fhi_conteudoNovo;
        [Size(SizeAttribute.Unlimited)]
        public string hi_conteudoNovo
        {
            get { return fhi_conteudoNovo; }
            set { SetPropertyValue<string>(nameof(hi_conteudoNovo), ref fhi_conteudoNovo, value); }
        }
        tb_est ffk_tb_est;
        [Association(@"tb_historicoReferencestb_est")]
        public tb_est fk_tb_est
        {
            get { return ffk_tb_est; }
            set { SetPropertyValue<tb_est>(nameof(fk_tb_est), ref ffk_tb_est, value); }
        }
        tb_ator ffk_tb_ator;
        [Association(@"tb_historicoReferencestb_ator")]
        public tb_ator fk_tb_ator
        {
            get { return ffk_tb_ator; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator), ref ffk_tb_ator, value); }
        }
    }

}
