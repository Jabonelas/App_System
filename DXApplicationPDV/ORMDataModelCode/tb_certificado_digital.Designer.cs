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

    public partial class tb_certificado_digital : XPLiteObject
    {
        long fid_certificado_digital;
        [Key(AutoGenerate = true)]
        public long id_certificado_digital
        {
            get { return fid_certificado_digital; }
            set { SetPropertyValue<long>(nameof(id_certificado_digital), ref fid_certificado_digital, value); }
        }
        DateTime fcd_dtCri;
        public DateTime cd_dtCri
        {
            get { return fcd_dtCri; }
            set { SetPropertyValue<DateTime>(nameof(cd_dtCri), ref fcd_dtCri, value); }
        }
        DateTime fcd_dtAlt;
        public DateTime cd_dtAlt
        {
            get { return fcd_dtAlt; }
            set { SetPropertyValue<DateTime>(nameof(cd_dtAlt), ref fcd_dtAlt, value); }
        }
        DateTime fcd_dtAcs;
        public DateTime cd_dtAcs
        {
            get { return fcd_dtAcs; }
            set { SetPropertyValue<DateTime>(nameof(cd_dtAcs), ref fcd_dtAcs, value); }
        }
        string fcd_cnpj;
        [Size(18)]
        public string cd_cnpj
        {
            get { return fcd_cnpj; }
            set { SetPropertyValue<string>(nameof(cd_cnpj), ref fcd_cnpj, value); }
        }
        string fcd_razSoc;
        [Size(60)]
        public string cd_razSoc
        {
            get { return fcd_razSoc; }
            set { SetPropertyValue<string>(nameof(cd_razSoc), ref fcd_razSoc, value); }
        }
        byte[] fcd_rawData;
        [Size(SizeAttribute.Unlimited)]
        [MemberDesignTimeVisibility(true)]
        public byte[] cd_rawData
        {
            get { return fcd_rawData; }
            set { SetPropertyValue<byte[]>(nameof(cd_rawData), ref fcd_rawData, value); }
        }
        string fcd_pwd;
        [Size(64)]
        public string cd_pwd
        {
            get { return fcd_pwd; }
            set { SetPropertyValue<string>(nameof(cd_pwd), ref fcd_pwd, value); }
        }
        string fcd_serial;
        [Size(128)]
        public string cd_serial
        {
            get { return fcd_serial; }
            set { SetPropertyValue<string>(nameof(cd_serial), ref fcd_serial, value); }
        }
        DateTime fcd_dtPub;
        public DateTime cd_dtPub
        {
            get { return fcd_dtPub; }
            set { SetPropertyValue<DateTime>(nameof(cd_dtPub), ref fcd_dtPub, value); }
        }
        DateTime fcd_dtExp;
        public DateTime cd_dtExp
        {
            get { return fcd_dtExp; }
            set { SetPropertyValue<DateTime>(nameof(cd_dtExp), ref fcd_dtExp, value); }
        }
        long fcd_ativo;
        public long cd_ativo
        {
            get { return fcd_ativo; }
            set { SetPropertyValue<long>(nameof(cd_ativo), ref fcd_ativo, value); }
        }
        string fcd_tipo;
        [Size(50)]
        public string cd_tipo
        {
            get { return fcd_tipo; }
            set { SetPropertyValue<string>(nameof(cd_tipo), ref fcd_tipo, value); }
        }
        string fcd_modoEmissao;
        [Size(50)]
        public string cd_modoEmissao
        {
            get { return fcd_modoEmissao; }
            set { SetPropertyValue<string>(nameof(cd_modoEmissao), ref fcd_modoEmissao, value); }
        }
        long fcd_x509Version;
        public long cd_x509Version
        {
            get { return fcd_x509Version; }
            set { SetPropertyValue<long>(nameof(cd_x509Version), ref fcd_x509Version, value); }
        }
        string fcd_sHA1String;
        [Size(128)]
        public string cd_sHA1String
        {
            get { return fcd_sHA1String; }
            set { SetPropertyValue<string>(nameof(cd_sHA1String), ref fcd_sHA1String, value); }
        }
        long fcd_canc;
        public long cd_canc
        {
            get { return fcd_canc; }
            set { SetPropertyValue<long>(nameof(cd_canc), ref fcd_canc, value); }
        }
        tb_ator ffk_tb_ator;
        [Association(@"tb_certificado_digitalReferencestb_ator")]
        public tb_ator fk_tb_ator
        {
            get { return ffk_tb_ator; }
            set { SetPropertyValue<tb_ator>(nameof(fk_tb_ator), ref ffk_tb_ator, value); }
        }
        [Association(@"tb_atorReferencestb_certificado_digital")]
        public XPCollection<tb_ator> tb_ators { get { return GetCollection<tb_ator>(nameof(tb_ators)); } }
    }

}
