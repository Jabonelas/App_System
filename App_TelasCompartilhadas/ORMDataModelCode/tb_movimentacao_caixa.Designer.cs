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

    public partial class tb_movimentacao_caixa : XPLiteObject
    {
        long fid_movimentacao_caixa;
        [Key(AutoGenerate = true)]
        public long id_movimentacao_caixa
        {
            get { return fid_movimentacao_caixa; }
            set { SetPropertyValue<long>(nameof(id_movimentacao_caixa), ref fid_movimentacao_caixa, value); }
        }
        decimal fmc_canc;
        public decimal mc_canc
        {
            get { return fmc_canc; }
            set { SetPropertyValue<decimal>(nameof(mc_canc), ref fmc_canc, value); }
        }
        tb_movimentacao ffk_tb_movimentacao;
        [Association(@"tb_movimentacao_caixaReferencestb_movimentacao")]
        public tb_movimentacao fk_tb_movimentacao
        {
            get { return ffk_tb_movimentacao; }
            set { SetPropertyValue<tb_movimentacao>(nameof(fk_tb_movimentacao), ref ffk_tb_movimentacao, value); }
        }
    }

}
