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

    public partial class tb_resposta_NFe : XPLiteObject
    {
        long fid_resposta_NFe;
        [Key(AutoGenerate = true)]
        public long id_resposta_NFe
        {
            get { return fid_resposta_NFe; }
            set { SetPropertyValue<long>(nameof(id_resposta_NFe), ref fid_resposta_NFe, value); }
        }
        string frnfe_cnpj;
        [Size(18)]
        public string rnfe_cnpj
        {
            get { return frnfe_cnpj; }
            set { SetPropertyValue<string>(nameof(rnfe_cnpj), ref frnfe_cnpj, value); }
        }
        string frnfe_cpf;
        [Size(14)]
        public string rnfe_cpf
        {
            get { return frnfe_cpf; }
            set { SetPropertyValue<string>(nameof(rnfe_cpf), ref frnfe_cpf, value); }
        }
        string frnfe_inscEst;
        [Size(20)]
        public string rnfe_inscEst
        {
            get { return frnfe_inscEst; }
            set { SetPropertyValue<string>(nameof(rnfe_inscEst), ref frnfe_inscEst, value); }
        }
        string frnfe_nfeChave;
        [Size(50)]
        public string rnfe_nfeChave
        {
            get { return frnfe_nfeChave; }
            set { SetPropertyValue<string>(nameof(rnfe_nfeChave), ref frnfe_nfeChave, value); }
        }
        DateTime frnfe_nfeDtAut;
        public DateTime rnfe_nfeDtAut
        {
            get { return frnfe_nfeDtAut; }
            set { SetPropertyValue<DateTime>(nameof(rnfe_nfeDtAut), ref frnfe_nfeDtAut, value); }
        }
        DateTime frnfe_nfeDtEmis;
        public DateTime rnfe_nfeDtEmis
        {
            get { return frnfe_nfeDtEmis; }
            set { SetPropertyValue<DateTime>(nameof(rnfe_nfeDtEmis), ref frnfe_nfeDtEmis, value); }
        }
        string frnfe_nfeNumProtAut;
        [Size(15)]
        public string rnfe_nfeNumProtAut
        {
            get { return frnfe_nfeNumProtAut; }
            set { SetPropertyValue<string>(nameof(rnfe_nfeNumProtAut), ref frnfe_nfeNumProtAut, value); }
        }
        byte frnfe_nfeSit;
        public byte rnfe_nfeSit
        {
            get { return frnfe_nfeSit; }
            set { SetPropertyValue<byte>(nameof(rnfe_nfeSit), ref frnfe_nfeSit, value); }
        }
        byte frnfe_nfeTipo;
        public byte rnfe_nfeTipo
        {
            get { return frnfe_nfeTipo; }
            set { SetPropertyValue<byte>(nameof(rnfe_nfeTipo), ref frnfe_nfeTipo, value); }
        }
        decimal frnfe_nfeVersao;
        public decimal rnfe_nfeVersao
        {
            get { return frnfe_nfeVersao; }
            set { SetPropertyValue<decimal>(nameof(rnfe_nfeVersao), ref frnfe_nfeVersao, value); }
        }
        decimal frnfe_nfeVlrTotNF;
        public decimal rnfe_nfeVlrTotNF
        {
            get { return frnfe_nfeVlrTotNF; }
            set { SetPropertyValue<decimal>(nameof(rnfe_nfeVlrTotNF), ref frnfe_nfeVlrTotNF, value); }
        }
        string frnfe_razSoc;
        [Size(60)]
        public string rnfe_razSoc
        {
            get { return frnfe_razSoc; }
            set { SetPropertyValue<string>(nameof(rnfe_razSoc), ref frnfe_razSoc, value); }
        }
        DateTime frnfe_dtCri;
        public DateTime rnfe_dtCri
        {
            get { return frnfe_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(rnfe_dtCri), ref frnfe_dtCri, value); }
        }
        DateTime frnfe_dtAlt;
        public DateTime rnfe_dtAlt
        {
            get { return frnfe_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(rnfe_dtAlt), ref frnfe_dtAlt, value); }
        }
        DateTime frnfe_dtAcs;
        public DateTime rnfe_dtAcs
        {
            get { return frnfe_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(rnfe_dtAcs), ref frnfe_dtAcs, value); }
        }
        long frnfe_nsu;
        public long rnfe_nsu
        {
            get { return frnfe_nsu; }
            set { SetPropertyValue<long>(nameof(rnfe_nsu), ref frnfe_nsu, value); }
        }
        long frnfe_ultNsu;
        public long rnfe_ultNsu
        {
            get { return frnfe_ultNsu; }
            set { SetPropertyValue<long>(nameof(rnfe_ultNsu), ref frnfe_ultNsu, value); }
        }
        long frnfe_maxNsu;
        public long rnfe_maxNsu
        {
            get { return frnfe_maxNsu; }
            set { SetPropertyValue<long>(nameof(rnfe_maxNsu), ref frnfe_maxNsu, value); }
        }
        tb_ator ffk_tb_ator;
        [Association(@"tb_resposta_NFeReferencestb_ator")]
        public tb_ator fk_tb_ator
        {
            get { return ffk_tb_ator; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator), ref ffk_tb_ator, value); }
        }
    }

}
