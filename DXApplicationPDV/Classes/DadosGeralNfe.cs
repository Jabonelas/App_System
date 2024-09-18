using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DXApplicationPDV.Classes
{
    internal class DadosGeralNfe
    {
        public const string S_LBL_CAMPO_OBRIGATORIO = "Campo obrigatório!";
        public const string S_LBL_DESC_NAO_DEFINIDO = "Não definido";
        public const string S_LBL_FORMATO_INVALIDO = "Formato inválido!";
        public const string S_LBL_GERAL = "GERAL";
        public const string S_LBL_NAME_NAO_DEFINIDO = "n/d";
        public const string S_LBL_REGEX_FORMATO_INCORRETO = "Formato incorreto!";
        public const string S_LBL_SHORTNAME_NAO_DEFINIDO = "n/d";
        public const string S_LBL_TAMANHO_INVALIDO = "Tamanho inválido!\r\nTecle ESC para cancelar";
        public const string SFormatStrDateTime = @"{0:dd/MM/yy HH:mm}";
        public const string SFormatStrMoney = @"R$ {0:N2}";
        public const string SFormatStrNumberNoDecimal = @"{0:N0}";
        public const string SFormatStrTaxa = @"{0:N3}";
        public const string SFormatStrWeight = @"{0:N3}";
        public const string SNullDateTimeStr = @"01/01/0001 00:00:00";

        public const int SRangeByte = 99;
        public const int SRangeInt = 999999999;
        public const long SRangeLong = 999999999999999999;
        public const double SRangeMoney = 999999999.99d;
        public const double SRangeQtd = 999999999.99d;
        public const int SRangeShort = 9999;
        public const double SRangeTaxa = 999.999d;
        public const int SRangeTresNumeros = 999;
        public const string SRegDtNasc = @"(\d{2}\/\d{2})";
        public const string SRegExAnything = @".*";
        public const string SRegExByte = @"(\d{1,2})";
        public const string SRegExCep = @"(\d{5}\-\d{3})";
        public const string SRegExCnae = @"(\d{2}\.\d{2}\-\d{1}\-\d{2})";
        public const string SRegExCnpj = @"(\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2})";
        public const string SRegExCodBarras = @"(\d{0,14})";
        public const string SRegExCpf = @"(\d{3}\.\d{3}\.\d{3}\-\d{2})";
        public const string SRegExEan = @"(\d{7,14})";
        public const string SRegExEmail = @"((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+";
        public const string SRegExHostOrWebDomain = @"(([a-z0-9]+(-[a-z0-9]+)*\.?)+([a-z]){0,})";
        public const string SRegExInscEst = @"(\d{2,14})";
        public const string SRegExInscSuframa = @"(\d{8,9})";
        public const string SRegExInt = @"(\d{1,9})";
        public const string SRegExIntlPhoneNumberCelular = @"((\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1))?\d{11,14})"; // https://stackoverflow.com/questions/2113908/what-regular-expression-will-match-valid-international-phone-numbers
        public const string SRegExIntlPhoneNumberFixo = @"((\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1))?\d{10,14})"; // https://stackoverflow.com/questions/2113908/what-regular-expression-will-match-valid-international-phone-numbers
        public const string SRegExLong = @"(\d{1,18})";
        public const string SRegExMoney = @"([0-9]{1,11}([.,][0-9]{1,3})?)";
        public const string SRegExNome = @"([A-Z0-9;,.&/\-\(\) ]+)";
        public const string SRegExNumericVersion = @"(\d{1,3}(\,\d{4})?)";
        public const string SRegExOneWord = @"(\w{1})";
        public const string SRegExQtd = @"(\d{1,11}(\,\d{3})?)";
        public const string SRegExRgRne = @"([0-9A-Za-z\:\.\+\-\/\(\)])";   // {0,20}
        public const string SRegExShort = @"(\d{1,4})";
        public const string SRegExTelRamal = @"\d";
        public const string SRegExTresNumeros = @"(\d{1,3})";
        public const string SRegExWebSite = @"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}([-a-zA-Z0-9@:%_\+.~#?&//=]*)";

        public static readonly int[] SNfeCStatNfeAutorizada =
    {
        100, // Autorizado o uso da NF-e
        150, // Autorizado o uso da NF-e, autorização fora de prazo
    };

        public static readonly int[] SNfeCStatQueOcupaNumeracaoNfe =
        {
        100, // Autorizado o uso da NF-e
        150, // Autorizado o uso da NF-e, autorização fora de prazo
        110, // Uso Denegado
        //204, //Rejeição por duplicação de nnf
        205, // NF-e está denegada na base de dados da SEFAZ [nRec:999999999999999]
        301, // Uso Denegado: Irregularidade fiscal do emitente
        302, // Uso Denegado: Irregularidade fiscal do destinatário
        303, // Uso Denegado: Destinatário não habilitado a operar na UF
    };

        public static DateTime SNullDateTime = DateTime.Parse(SNullDateTimeStr);

        public static bool SIsNullDateTime(DateTime dt)
        { return dt == DateTime.Parse(SNullDateTimeStr); }

        //public static Exception SxSqlConnect(in SqlConnection sqlCon)
        //{
        //    Exception _ = null;
        //    int retryCount = 50;
        //    while (sqlCon.State != ConnectionState.Open && retryCount > 0)
        //    {
        //        retryCount--;
        //        Thread.Sleep(300);
        //        _ = null;
        //        try { sqlCon.Open(); }
        //        catch (Exception ex) { _ = ex; }
        //    }
        //    return _ == null ? _ : SxConsole.SxConsoleWriteDebug(_);
        //}

        //public static int SxSqlDbCount(in SqlConnection sqlCon, string dbName) => sqlCon.ExecuteScalar<int>($"SELECT COUNT(*) FROM sysdatabases WHERE name = '{dbName}'");

        #region SEnNfePisCofinsReg

        /// <summary>
        /// Regime Tributário do PIS e COFINS
        /// </summary>
        public enum SEnNfePisCofinsReg : byte // //byte=tinyint short=smallint int32=int
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "N/D", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - RegCumulativo

            /// <summary>
            /// Alíquota Regime Cumulativo
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "1 - Alíquota Regime Cumulativo", Description = "Alíquota Regime Cumulativo",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RegCumulativo1 = 1,

            #endregion 1 - RegCumulativo

            #region 2 - RegNaoCumulativo

            /// <summary>
            /// Alíquota Regime Não Cumulativo
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "2 - Alíquota Regime Não Cumulativo", Description = "Alíquota Regime Não Cumulativo",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RegNaoCumulativo2 = 2,

            #endregion 2 - RegNaoCumulativo

            #region 3 - RegMonofasico

            /// <summary>
            /// Alíquota Regime Monofásico
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "3 - Alíquota Regime Monofásico", Description = "Alíquota Regime Monofásico",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RegMonofasico3 = 3,

            #endregion 3 - RegMonofasico

            #region 4 - RegST

            /// <summary>
            /// Alíquota Regime Substituição Tributária
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "4 - Alíquota Regime Substituição Tributária", Description = "Alíquota Regime Substituição Tributária",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("4")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RegST4 = 4,

            #endregion 4 - RegST

            #region 5 - RegSN

            /// <summary>
            /// Alíquota Regime Simples Nacional
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "5 - Alíquota Regime Simples Nacional", Description = "Alíquota Regime Simples Nacional",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RegSN5 = 5,

            #endregion 5 - RegSN
        }

        #endregion SEnNfePisCofinsReg

        #region SEnNfeRecBrutaEnqSN

        /// <summary>
        /// Tabela Simples Nacional por Receita Bruta
        /// </summary>
        public enum SEnNfeRecBrutaEnqSN : byte // //byte=tinyint short=smallint int32=int
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "N/D", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - PrimeiraFaixa

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "1 - Até 180.000,00", Description = "Até 180.000,00",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            PrimeiraFaixa1 = 1,

            #endregion 1 - PrimeiraFaixa

            #region 2 - SegundaFaixa

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "2 - De 180.000,01 a 360.000,00", Description = "De 180.000,01 a 360.000,00",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SegundaFaixa2 = 2,

            #endregion 2 - SegundaFaixa

            #region 3 - TerceiraFaixa

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "3 - De 360.000,01 a 720.000,00", Description = "De 360.000,01 a 720.000,00",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TerceiraFaixa3 = 3,

            #endregion 3 - TerceiraFaixa

            #region 4 - QuartaFaixa

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "4 - De 720.000,01 a 1.800.000,00", Description = "De 720.000,01 a 1.800.000,00",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("4")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            QuartaFaixa4 = 4,

            #endregion 4 - QuartaFaixa

            #region 5 - QuintaFaixa

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "5 - De 1.800.000,01 a 3.600.000,00", Description = "De 1.800.000,01 a 3.600.000,00",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            QuintaFaixa5 = 5,

            #endregion 5 - QuintaFaixa

            #region 6 - SextaFaixa

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "6 - De 3.600.000,01 a 4.800.000,00", Description = "De 3.600.000,01 a 4.800.000,00",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("6")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SextaFaixa6 = 6,

            #endregion 6 - SextaFaixa
        }

        #endregion SEnNfeRecBrutaEnqSN

        #region SEnNfeEnqSN

        /// <summary>
        /// Tabela de Enquadramento dos Anexos do Simples Nacional
        /// </summary>
        public enum SEnNfeEnqSN : byte // //byte=tinyint short=smallint int32=int
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "N/D", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - Comercio

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "1 - Anexo I – Participantes: empresas de comércio (lojas em geral)", Description = "Anexo I – Participantes: empresas de comércio (lojas em geral)",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Comercio1 = 1,

            #endregion 1 - Comercio

            #region 2 - Industria

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "2 - Anexo II – Participantes: fábricas/indústrias e empresas industriais", Description = "Anexo II – Participantes: fábricas/indústrias e empresas industriais",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Industria2 = 2,

            #endregion 2 - Industria

            #region 3 - ServInstReparManuten

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "3 - Anexo III – Participantes: empresas que oferecem serviços de instalação, de reparos e de manutenção", Description = "Anexo III – Participantes: empresas que oferecem serviços de instalação, de reparos e de manutenção",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ServInstReparManuten3 = 3,

            #endregion 3 - ServInstReparManuten

            #region 4 - ServLimpVigObrAdv

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "4 - Anexo IV – Participantes: empresas que fornecem serviço de limpeza, vigilância, obras, construção de imóveis, serviços advocatícios", Description = "Anexo IV – Participantes: empresas que fornecem serviço de limpeza, vigilância, obras, construção de imóveis, serviços advocatícios",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("4")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ServLimpVigObrAdv4 = 4,

            #endregion 4 - ServLimpVigObrAdv

            #region 5 - ServAudTecPubEngOutr

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "5 - Anexo V – Participantes: empresas que fornecem serviço de auditoria, jornalismo, tecnologia, publicidade, engenharia, entre outros", Description = "Anexo V – Participantes: empresas que fornecem serviço de auditoria, jornalismo, tecnologia, publicidade, engenharia, entre outros",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ServAudTecPubEngOutr5 = 5,

            #endregion 5 - ServAudTecPubEngOutr
        }

        #endregion SEnNfeEnqSN

        #region SEnNfePisCofinsCst

        /// <summary>
        /// Código de Situação Tributária do PIS/COFINS
        /// </summary>
        public enum SEnNfePisCofinsCst : byte // //byte=tinyint short=smallint int32=int
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "N/D", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 01 - OpTribAliqNormal

            /// <summary>
            /// Operação Tributável (base de cálculo = valor da operação alíquota normal(cumulativo / não cumulativo))
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "01 Operação Tributável (base de cálculo = valor da operação alíquota normal(cumulativo / não cumulativo))", Description = "Operação Tributável (base de cálculo = valor da operação alíquota normal(cumulativo / não cumulativo))",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("01")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpTribAliqNormal01 = 01,

            #endregion 01 - OpTribAliqNormal

            #region 02 - OpTribAliqDiferenciada

            /// <summary>
            /// Operação Tributável (base de cálculo = valor da operação(alíquota diferenciada))
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "02 Operação Tributável (base de cálculo = valor da operação(alíquota diferenciada))", Description = "Operação Tributável (base de cálculo = valor da operação(alíquota diferenciada))",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("02")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpTribAliqDiferenciada02 = 02,

            #endregion 02 - OpTribAliqDiferenciada

            #region 03 - OpTribPorQuantidade

            /// <summary>
            /// Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "03 Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)", Description = "Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto)",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("03")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpTribPorQuantidade03 = 03,

            #endregion 03 - OpTribPorQuantidade

            #region 04 - OpTribMonoAliqZero

            /// <summary>
            /// Operação Tributável (tributação monofásica (alíquota zero))
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "04 Operação Tributável (tributação monofásica (alíquota zero))", Description = "Operação Tributável (tributação monofásica (alíquota zero))",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("04")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpTribMonoAliqZero04 = 04,

            #endregion 04 - OpTribMonoAliqZero

            #region 05 - OpTribST

            /// <summary>
            /// Operação Tributável (Substituição Tributária)
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "05 Operação Tributável (Substituição Tributária)", Description = "Operação Tributável (Substituição Tributária)",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("05")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpTribST05 = 05,

            #endregion 05 - OpTribST

            #region 06 - OpTribAliqZero

            /// <summary>
            /// Operação Tributável (alíquota zero)
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "06 Operação Tributável (alíquota zero)", Description = "Operação Tributável (alíquota zero)",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("06")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpTribAliqZero06 = 06,

            #endregion 06 - OpTribAliqZero

            #region 07 - OpIsenta

            /// <summary>
            /// Operação Isenta da Contribuição
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "07 Operação Isenta da Contribuição", Description = "Operação Isenta da Contribuição",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("07")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpIsenta07 = 07,

            #endregion 07 - OpIsenta

            #region 08 - OpSemIncidencia

            /// <summary>
            /// Operação Sem Incidência da Contribuição
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "08 Operação Sem Incidência da Contribuição", Description = "Operação Sem Incidência da Contribuição",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("08")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpSemIncidencia08 = 08,

            #endregion 08 - OpSemIncidencia

            #region 09 - OpSuspensa

            /// <summary>
            /// Operação com Suspensão da Contribuição
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "09 Operação com Suspensão da Contribuição", Description = "Operação com Suspensão da Contribuição",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("09")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpSuspensa09 = 09,

            #endregion 09 - OpSuspensa

            #region 49 - OutrOpSaida

            /// <summary>
            /// Outras Operações de Saída
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "49 Outras Operações de Saída", Description = "Outras Operações de Saída",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("49")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OutrOpSaida49 = 49,

            #endregion 49 - OutrOpSaida

            #region 50 - OpCredVincExcRecTribMerInter

            /// <summary>
            /// Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "50 Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno", Description = "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("50")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpCredVincExcRecTribMerInter50 = 50,

            #endregion 50 - OpCredVincExcRecTribMerInter

            #region 51 - OpCredVincExcRecNaoTribMerInter

            /// <summary>
            /// Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "51 Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno", Description = "Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("51")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpCredVincExcRecNaoTribMerInter51 = 51,

            #endregion 51 - OpCredVincExcRecNaoTribMerInter

            #region 52 - OpCredVincExcRecExp

            /// <summary>
            /// Operação com Direito a Crédito – Vinculada Exclusivamente a Receita de Exportação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "52 Operação com Direito a Crédito – Vinculada Exclusivamente a Receita de Exportação", Description = "Operação com Direito a Crédito – Vinculada Exclusivamente a Receita de Exportação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("52")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpCredVincExcRecExp52 = 52,

            #endregion 52 - OpCredVincExcRecExp

            #region 53 - OpCredVincRecTribENaoTribMerInter

            /// <summary>
            /// Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "53 Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno", Description = "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("53")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpCredVincRecTribENaoTribMerInter53 = 53,

            #endregion 53 - OpCredVincRecTribENaoTribMerInter

            #region 54 - OpCredVincRecTribMerInternEExp

            /// <summary>
            /// Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "54 Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", Description = "Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("54")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpCredVincRecTribMerInternEExp54 = 54,

            #endregion 54 - OpCredVincRecTribMerInternEExp

            #region 55 - OpCredVincRecNaoTribMerInternEExp

            /// <summary>
            /// Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "55 Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação", Description = "Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("55")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpCredVincRecNaoTribMerInternEExp55 = 55,

            #endregion 55 - OpCredVincRecNaoTribMerInternEExp

            #region 56 - OpCredVincRecTribENaoTribMerInternEExp

            /// <summary>
            /// Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "56 Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno,e de Exportação", Description = "Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("56")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpCredVincRecTribENaoTribMerInternEExp56 = 56,

            #endregion 56 - OpCredVincRecTribENaoTribMerInternEExp

            #region 60 - CredPresOpAqVincExcRecTribMerInter

            /// <summary>
            /// Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "60 Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno", Description = "Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("60")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CredPresOpAqVincExcRecTribMerInter60 = 60,

            #endregion 60 - CredPresOpAqVincExcRecTribMerInter

            #region 61 - CredPresOpAqVincExcRecNaoTribMerInter

            /// <summary>
            /// Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "61 Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno", Description = "Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("61")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CredPresOpAqVincExcRecNaoTribMerInter61 = 61,

            #endregion 61 - CredPresOpAqVincExcRecNaoTribMerInter

            #region 62 - CredPresOpAqVincExcRecExp

            /// <summary>
            /// Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "62 Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação", Description = "Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("62")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CredPresOpAqVincExcRecExp62 = 62,

            #endregion 62 - CredPresOpAqVincExcRecExp

            #region 63 - CredPresOpAqVincRecTribENaoTribMerInter

            /// <summary>
            /// Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "63 Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno", Description = "Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("63")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CredPresOpAquiVincRecTribENaoTribMerInter63 = 63,

            #endregion 63 - CredPresOpAqVincRecTribENaoTribMerInter

            #region 64 - CredPresOpAqVincRecTribMerInterEExp

            /// <summary>
            /// Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "64 Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação", Description = "Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("64")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CredPresOpAquiVincRecTribMerInterEExp64 = 64,

            #endregion 64 - CredPresOpAqVincRecTribMerInterEExp

            #region 65 - CredPresOpAqVincRecNaoTribMerInterEExp

            /// <summary>
            /// Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "65 Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação", Description = "Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("65")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CredPresOpAqVincRecNaoTribMerInterEExp65 = 65,

            #endregion 65 - CredPresOpAqVincRecNaoTribMerInterEExp

            #region 66 - CredPresOpAqVincRecTribENaoTribMerInterEExp

            /// <summary>
            /// Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno,e de Exportação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "66 Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno,e de Exportação", Description = "Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno,e de Exportação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("66")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CredPresOpAqVincRecTribENaoTribMerInterEExp66 = 66,

            #endregion 66 - CredPresOpAqVincRecTribENaoTribMerInterEExp

            #region 67 - CredPresOutrOp

            /// <summary>
            /// Crédito Presumido - Outras Operações
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "67 Crédito Presumido - Outras Operações", Description = "Crédito Presumido - Outras Operações",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("67")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CredPresOutrOp67 = 67,

            #endregion 67 - CredPresOutrOp

            #region 70 - OpAqSemCred

            /// <summary>
            /// Operação de Aquisição sem Direito a Crédito
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "70 Operação de Aquisição sem Direito a Crédito", Description = "Operação de Aquisição sem Direito a Crédito",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("70")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpAqSemCred70 = 70,

            #endregion 70 - OpAqSemCred

            #region 71 - OpAqIsencao

            /// <summary>
            /// Operação de Aquisição com Isenção
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "71 Operação de Aquisição com Isenção", Description = "Operação de Aquisição com Isenção",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("71")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpAqIsencao71 = 71,

            #endregion 71 - OpAqIsencao

            #region 72 - OpAqSuspensao

            /// <summary>
            /// Operação de Aquisição com Suspensão
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "72 Operação de Aquisição com Suspensão", Description = "Operação de Aquisição com Suspensão",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("72")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpAqSuspensao72 = 72,

            #endregion 72 - OpAqSuspensao

            #region 73 - OpAqAliqZero

            /// <summary>
            /// Operação de Aquisição a Alíquota Zero
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "73 Operação de Aquisição a Alíquota Zero", Description = "Operação de Aquisição a Alíquota Zero",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("73")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpAqAliqZero73 = 73,

            #endregion 73 - OpAqAliqZero

            #region 74 - OpAqSemIncidContrib

            /// <summary>
            /// Operação de Aquisição; sem Incidência da Contribuição
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "74 Operação de Aquisição; sem Incidência da Contribuição", Description = "Operação de Aquisição; sem Incidência da Contribuição",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("74")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpAqSemIncidContrib74 = 74,

            #endregion 74 - OpAqSemIncidContrib

            #region 75 - OpAqST

            /// <summary>
            /// Operação de Aquisição por Substituição Tributária
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "75 Operação de Aquisição por Substituição Tributária", Description = "Operação de Aquisição por Substituição Tributária",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("75")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OpAqST75 = 75,

            #endregion 75 - OpAqST

            #region 98 - OutrOpEntrada

            /// <summary>
            /// Outras Operações de Entrada
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "98 Outras Operações de Entrada", Description = "Outras Operações de Entrada",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("98")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OutrOpEntrada98 = 98,

            #endregion 98 - OutrOpEntrada

            #region 99 - OutrOp

            /// <summary>
            /// Outras Operações de Entrada
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "99 Outras Operações", Description = "Outras Operações",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("99")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OutrOp99 = 99,

            #endregion 99 - OutrOp
        }

        #endregion SEnNfePisCofinsCst

        #region SEnNfeIpiCst

        /// <summary>
        /// Código da situação tributária do IPI
        /// </summary>
        public enum SEnNfeIpiCst : byte // //byte=tinyint short=smallint int32=int
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "N/D", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 00 - EntrRecupCred

            /// <summary>
            /// Entrada com recuperação de crédito
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "00 Entrada com recuperação de crédito", Description = "Entrada com recuperação de crédito",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("00")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            EntrRecupCred00 = 00,

            #endregion 00 - EntrRecupCred

            #region 01 - EntrTribAliqZero

            /// <summary>
            /// Entrada tributada com alíquota zero
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "01 Entrada tributada com alíquota zero", Description = "Entrada tributada com alíquota zero",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("01")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            EntrTribAliqZero01 = 01,

            #endregion 01 - EntrTribAliqZero

            #region 02 - EntradaIsenta

            /// <summary>
            /// Entrada isenta
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "02 Entrada isenta", Description = "Entrada isenta",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("02")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            EntradaIsenta02 = 02,

            #endregion 02 - EntradaIsenta

            #region 03 - EntradaNaoTrib

            /// <summary>
            /// Entrada não-tributada
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "03 Entrada não-tributada", Description = "Entrada não-tributada",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("03")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            EntradaNaoTrib03 = 03,

            #endregion 03 - EntradaNaoTrib

            #region 04 - EntradaImune

            /// <summary>
            /// Entrada imune
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "04 Entrada imune", Description = "Entrada imune",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("04")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            EntradaImune04 = 04,

            #endregion 04 - EntradaImune

            #region 05 - EntradaSuspensa

            /// <summary>
            /// Entrada suspensa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "05 Entrada suspensa", Description = "Entrada suspensa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("05")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            EntradaSuspensa05 = 05,

            #endregion 05 - EntradaSuspensa

            #region 49 - OutrasEntr

            /// <summary>
            /// Outras entradas
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "49 Outras entradas", Description = "Outras entradas",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("49")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OutrasEntr49 = 49,

            #endregion 49 - OutrasEntr

            #region 50 - SaidasTrib

            /// <summary>
            /// Saída tributada
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "50 Saída tributada", Description = "Saída tributada",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("50")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SaidasTrib50 = 50,

            #endregion 50 - SaidasTrib

            #region 51 - SaidaTribAliqZero

            /// <summary>
            /// Saída tributada com alíquota zero
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "51 Saída tributada com alíquota zero", Description = "Saída tributada com alíquota zero",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("51")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SaidaTribAliqZero51 = 51,

            #endregion 51 - SaidaTribAliqZero

            #region 52 - SaidaIsenta

            /// <summary>
            /// Saída isenta
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "52 Saída isenta", Description = "Saída isenta",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("52")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SaidaIsenta52 = 52,

            #endregion 52 - SaidaIsenta

            #region 53 - SaidaNaoTrib

            /// <summary>
            /// Saída não-tributada
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "53 Saída não-tributada", Description = "Saída não-tributada",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("53")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SaidaNaoTrib53 = 53,

            #endregion 53 - SaidaNaoTrib

            #region 54 - SaidaImune

            /// <summary>
            /// Saída imune
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "54 Saída imune", Description = "Saída imune",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("54")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SaidaImune54 = 54,

            #endregion 54 - SaidaImune

            #region 55 - SaidaSuspensa

            /// <summary>
            /// Saída com suspensão
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "55 Saída com suspensão", Description = "Saída com suspensão",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("55")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SaidaSuspensa55 = 55,

            #endregion 55 - SaidaSuspensa

            #region 99 - OutrasSaidas

            /// <summary>
            /// Outras saídas
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "99 Outras saídas", Description = "Outras saídas",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("99")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            OutrasSaidas99 = 99,

            #endregion 99 - OutrasSaidas
        }

        #endregion SEnNfeIpiCst

        #region SEnNfeSit

        /// <summary>
        /// Situação da NF-e
        /// </summary>
        public enum SEnNfeSit : byte // //byte=tinyint short=smallint int32=int
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "N/D", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - UsoAutorizado

            /// <summary>
            /// Uso autorizado da NF-e
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "UsoAutorizado", Name = "1 UsoAutorizado", Description = "Uso autorizado da NF-e",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            UsoAutorizado1 = 1,

            #endregion 1 - UsoAutorizado

            #region 2 - UsoDenegado

            /// <summary>
            /// Uso denegado da NF-e
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "UsoDenegado", Name = "2 UsoDenegado", Description = "Uso denegado da NF-e",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            UsoDenegado2 = 2,

            #endregion 2 - UsoDenegado

            #region 3 - NfeCancelada

            /// <summary>
            /// NF-e cancelada
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "NfeCancelada", Name = "3 NfeCancelada", Description = "NF-e cancelada",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            NfeCancelada3 = 3,

            #endregion 3 - NfeCancelada
        }

        #endregion SEnNfeSit

        public enum SEnNfeTpEvt : int // //byte=tinyint short=smallint int32=int
        {
            //
            // Summary:
            //     Evento desconhecido
            [XmlEnum("0")]
            Desconhecido = 0,

            //
            // Summary:
            //     Carta de correção eletrônica (110110)
            [XmlEnum("110110")]
            CartaCorrecao = 110110,

            //
            // Summary:
            //     Cancelamento NFe (110111)
            [XmlEnum("110111")]
            Cancelamento = 110111,

            //
            // Summary:
            //     Cancelamento da NFCe sendo substituída por outra NFCe (110112)
            [XmlEnum("110112")]
            CancelamentoPorSubstituicao = 110112,

            //
            // Summary:
            //     Comprovante de Entrega da NF-e
            [XmlEnum("110130")]
            ComprovanteEntregaNFe = 110130,

            //
            // Summary:
            //     Cancelamento do Comprovante de Entrega da NF-e
            [XmlEnum("110131")]
            CancelamentoComprovanteEntregaNFe = 110131,

            //
            // Summary:
            //     EPEC - Evento Prévio de Emissão em Contingência (110140)
            [XmlEnum("110140")]
            EPEC = 110140,

            //
            // Summary:
            //     Pedido de prorrogação do prazo de ICMS no caso de remessa para industrialização
            //     (111500) - 1o Prazo
            [XmlEnum("111500")]
            PedidoProrrogacaoPrazo1 = 111500,

            //
            // Summary:
            //     Pedido de prorrogação do prazo de ICMS no caso de remessa para industrialização
            //     (111501) - 2o Prazo
            [XmlEnum("111501")]
            PedidoProrrogacaoPrazo2 = 111501,

            //
            // Summary:
            //     Cancelamento do pedido de prorrogação do prazo de ICMS no caso de remessa para
            //     industrialização (111502) - 1o Prazo
            [XmlEnum("111502")]
            CancelamentoPedidoProrrogacaoPrazo1 = 111502,

            //
            // Summary:
            //     Cancelamento do pedido de prorrogação do prazo de ICMS no caso de remessa para
            //     industrialização (111503) - 2o Prazo
            [XmlEnum("111503")]
            CancelamentoPedidoProrrogacaoPrazo2 = 111503,

            //
            // Summary:
            //     Manifestação do Destinatário - Confirmação da Operação (210200)
            [XmlEnum("210200")]
            ManifestacaoConfirmacaoOperacao = 210200,

            //
            // Summary:
            //     Manifestação do Destinatário - Ciência da Operação (210210)
            [XmlEnum("210210")]
            ManifestacaoCienciaOperacao = 210210,

            //
            // Summary:
            //     Manifestação do Destinatário - Desconhecimento da Operação (210220)
            [XmlEnum("210220")]
            ManifestacaoDesconhecimentoOperacao = 210220,

            //
            // Summary:
            //     Manifestação do Destinatário - Operação não realizada (210240)
            [XmlEnum("210240")]
            ManifestacaoOperacaoNaoRealizada = 210240,

            //
            // Summary:
            //     SEFAZ do emitente declara que NF-e é um "Documento Fiscal Inidôneo". (400200)
            [XmlEnum("400200")]
            DocumentoFiscalInidoneo = 400200,

            //
            // Summary:
            //     Cancelamento do evento 400200 (400201)
            [XmlEnum("400201")]
            CancelamentoEventoFisco400200 = 400201,

            //
            // Summary:
            //     Possibilita que a SEFAZ marque uma NF-e emitida em função de uma situação específica
            //     prevista em legislação, ex.: transferência de crédito, ressarcimento. (400300)
            [XmlEnum("400300")]
            VistoEletronicoDoFisco = 400300,

            //
            // Summary:
            //     O evento da Nota Fiscal Referenciada é gerado sempre que uma nova NF-e referenciar
            //     uma ou mais outras Notas Fiscais Eletrônicas. Não serão gerados eventos de "NF-e
            //     Referenciada" para os documentos diferentes do Modelo 55. (410300)
            [XmlEnum("410300")]
            NFeReferenciada = 410300,

            //
            // Summary:
            //     Resposta ao pedido de prorrogação do prazo de ICMS no caso de remessa para industrialização
            //     (411500) - 1o Prazo (Evento exclusivo do fisco)
            [XmlEnum("411500")]
            RespostaPedidoProrrogacaoPrazo1 = 411500,

            //
            // Summary:
            //     Resposta ao pedido de prorrogação do prazo de ICMS no caso de remessa para industrialização
            //     (411501) - 2o Prazo (Evento exclusivo do fisco)
            [XmlEnum("411501")]
            RespostaPedidoProrrogacaoPrazo2 = 411501,

            //
            // Summary:
            //     Resposta ao cancelamento do pedido de prorrogação do prazo de ICMS no caso de
            //     remessa para industrialização (411502) - 1o Prazo (Evento exclusivo do fisco)
            [XmlEnum("411502")]
            RespostaCancelamentoPedidoProrrogacaoPrazo1 = 411502,

            //
            // Summary:
            //     Resposta ao cancelamento do pedido de prorrogação do prazo de ICMS no caso de
            //     remessa para industrialização (411503) - 2o Prazo (Evento exclusivo do fisco)
            [XmlEnum("411503")]
            RespostaCancelamentoPedidoProrrogacaoPrazo2 = 411503,

            //
            // Summary:
            //     Registro de Passagem da NF-e no Posto Fiscal (610500)
            [XmlEnum("610500")]
            RegistroPassagemNFe = 610500,

            //
            // Summary:
            //     Cancelamento do evento 610500 (610501)
            [XmlEnum("610501")]
            CancelamentoRegistroPassagemNFe = 610501,

            //
            // Summary:
            //     Registro de Passagem do MDF-e no Posto Fiscal, propagado pelo Sistema MDF-e.
            //     (610510)
            [XmlEnum("610510")]
            RegistroDePassagemMDFe = 610510,

            //
            // Summary:
            //     Cancelamento do evento 610511 (610511)
            [XmlEnum("610511")]
            CancelamentoRegistroDePassagemMDFe = 610511,

            //
            // Summary:
            //     Registro de Passagem do MDF-e no Posto Fiscal, propagado pelo Ambiente Nacional.
            //     Nota: A Chave de Acesso da NF-e está vinculada a um CT-e citado no MDF-e. (610514)
            [XmlEnum("610514")]
            RegistroDePassagemMDFeComCTe = 610514,

            //
            // Summary:
            //     Cancelamento do evento 610514. (610515)
            [XmlEnum("610515")]
            CancelamentoRegistroDePassagemMDFeComCTe = 610515,

            //
            // Summary:
            //     Registro de Passagem do MDF-e, capturado por antenas do Projeto Brasil ID. Evento
            //     eliminado (BT 2017.002), substituído pelo Registro de Passagem Automático MDF-e.
            //     (610550)
            [XmlEnum("610550")]
            RegistroPassagemNFeBRId = 610550,

            //
            // Summary:
            //     Registro de Passagem do MDF-e capturado de forma automática (antena, leitura
            //     de placa por OCR, etc.), propagado pelo Sistema MDFe. Nota: A Chave de Acesso
            //     da NF-e está citada no MDF-e. (610552)
            [XmlEnum("610552")]
            RegistroDePassagemAutomaticoMDFe = 610552,

            //
            // Summary:
            //     Cancelamento do evento 610552 (610554)
            [XmlEnum("610554")]
            RegistroDePassagemAutomaticoMDFeComCTe = 610554,

            //
            // Summary:
            //     Documenta na NF-e a ocorrência de CT-e autorizado, no momento do compartilhamento
            //     do CT-e com o Ambiente Nacional. Nota: A Chave de Acesso da NF-e está citada
            //     no CTe. (610600)
            [XmlEnum("610600")]
            CTeAutorizado = 610600,

            //
            // Summary:
            //     Documenta na NF-e a ocorrência de cancelamento de CT-e autorizado, no momento
            //     do compartilhamento do evento com o Ambiente Nacional. Nota: A Chave de Acesso
            //     da NF-e está citada no CT-e. (610601)
            [XmlEnum("610601")]
            CTeCancelado = 610601,

            //
            // Summary:
            //     Evento que documenta na NF-e a ocorrência de MDF-e autorizado.Nota: A Chave de
            //     Acesso da NF-e está citada no MDF-e. (610610)
            [XmlEnum("610610")]
            MDFeAutorizado = 610610,

            //
            // Summary:
            //     Cancelamento do MDF-e (610611)
            [XmlEnum("610611")]
            MDFeCancelado = 610611,

            //
            // Summary:
            //     Evento que documenta na NF-e a ocorrência de MDF-e autorizado. Nota: A Chave
            //     de Acesso da NF-e está vinculada a um CT-e citado no MDF-e. (610614)
            [XmlEnum("610614")]
            MDFeAutorizadoComCTe = 610614,

            //
            // Summary:
            //     Cancelamento do evento 610614. (610615)
            [XmlEnum("610615")]
            CancelamentoDoMDFeAutorizadoComCTe = 610615,

            //
            // Summary:
            //     Evento que indica a quantidade de mercadoria na unidade tributável que foi efetivamente
            //     embarcada para o exterior referente a um certo item de uma NF-e. Gerado e enviado
            //     pelo sistema Portal Único do Comércio Exterior (PUCOMEX) Receita Federal do Brasil
            //     (RFB) para o Ambiente Nacional da NF-e (790700)
            [XmlEnum("790700")]
            AverbacaoDeExportacao = 790700,

            //
            // Summary:
            //     Registro da ocorrência da Vistoria do processo de internalização de produtos
            //     industrializados de origem nacional com isenção de ICMS nas áreas sob controle
            //     da SUFRAMA. (990900)
            [XmlEnum("990900")]
            VistoriaSUFRAMA = 990900,

            //
            // Summary:
            //     Confirmação da internalização de produtos industrializados de origem nacional
            //     com isenção de ICMS nas áreas sob controle da SUFRAMA. (990910)
            [XmlEnum("990910")]
            InternalizacaoSUFRAMA = 990910
        }

        #region SEnPdvOp

        /// <summary>
        /// Operação de Ponto de Venda
        /// </summary>
        public enum SEnMovTipo : short // verificar map. SOp_DbType
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1-99 Operações de caixa

            #region 01 - AbertCx

            /// <summary>
            /// Abertura de caixa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "1 Abertura de caixa", Description = "Abertura de caixa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            //[ImageName(dx_SvgImages_Ponto_de_Venda_5_abertura)]
            AbertCx1 = 1,

            #endregion 01 - AbertCx

            #region 02 - FechCx

            /// <summary>
            /// Fechamento de caixa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "2 Fechamento de caixa", Description = "Fechamento de caixa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Saida2)]
            //[ImageName(dx_SvgImages_Ponto_de_Venda_6_fechamento)]
            FechCx2 = 2,

            #endregion 02 - FechCx

            #region 03 - SaidaCx

            /// <summary>
            /// Saida de Estoque
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "3 Saida de estoque", Description = "Saida de estoque",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Saida2)]
            //[ImageName(dx_SvgImages_Ponto_de_Veda_4_retirada)]
            SaidaCx3 = 3,

            #endregion 03 - SaidaCx

            #region 11 - Entrada

            /// <summary>
            /// Entrada de caixa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "3 Entrada de caixa", Description = "Entrada de caixa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("11")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            //[ImageName(dx_SvgImages_Ponto_de_Venda_3_reforco)]
            Reforco11 = 11,

            #endregion 11 - Entrada

            #region 12 - Saída

            /// <summary>
            /// Saída de caixa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "4 Saída de caixa", Description = "Saída de caixa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("12")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Saida2)]
            //[ImageName(dx_SvgImages_Ponto_de_Venda_4_retirada)]
            Retirada12 = 12,

            #endregion 12 - Saída

            #region 13 - Receita

            /// <summary>
            /// Receita de caixa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5 Receita de caixa", Description = "Receita de caixa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("13")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Business_DollarCircled")]
            Receita13 = 13,

            #endregion 13 - Receita

            #region 14 - Despesa

            /// <summary>
            /// Despesa de caixa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "6 Despesa de caixa", Description = "Despesa de caixa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("14")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Saida2)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Business_DollarCircled")]
            Despesa14 = 14,

            #endregion 14 - Despesa

            #region 14 - Despesa

            /// <summary>
            /// Recarga de celular
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "99 Recarga de celular", Description = "Recarga de celular",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("99")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            //[ImageName(dx_SvgImages_Ponto_de_Venda_3_reforco)]
            Recarga99 = 99,

            #endregion 14 - Despesa

            #endregion 1-99 Operações de caixa

            #region 100-149 Pedidos, comandas de vendas

            #region 100 - Pedido

            /// <summary>
            /// Pedido de venda
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "100 Pedido de venda", Description = "Pedido de venda",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("100")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            PedidoDeVenda100 = 100,

            #endregion 100 - Pedido

            #endregion 100-149 Pedidos, comandas de vendas

            #region 150-199 Vendas

            #region 150 - Venda NFC-e

            /// <summary>
            /// Venda
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "150 Venda NFC-e", Description = "Venda NFC-e",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("150")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            VendaNfce150 = 150,

            #endregion 150 - Venda NFC-e

            #region 151 - Venda NF-e

            /// <summary>
            /// Venda
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "151 Venda NF-e", Description = "Venda NF-e",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("151")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            VendaNfe151 = 151,

            #endregion 151 - Venda NF-e

            #endregion 150-199 Vendas

            #region 200-249 Servicos

            #region 200 - Serviço NFS-e

            /// <summary>
            /// Venda
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "200 Serviço NFS-e", Description = "Serviço NFS-e",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("200")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ServicoNFSe200 = 200,

            #endregion 200 - Serviço NFS-e

            #region 201 - Serviço sem NFS-e

            /// <summary>
            /// Venda
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "201 Serviço s/NFS-e", Description = "Serviço s/NFS-e",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("201")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ServicoSemNFSe201 = 201,

            #endregion 201 - Serviço sem NFS-e

            #endregion 200-249 Servicos

            #region 250-299 Compras

            #region 250 - Compra

            /// <summary>
            /// Pedido de venda
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "250 Compra", Description = "Compra",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("250")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Saida2)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            Compra250 = 250,

            #endregion 250 - Compra

            #endregion 250-299 Compras

            #region 300-349 Transferencias

            #region 300 - Transferencia NF-e

            /// <summary>
            /// Transferencia
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "300 Transferencia NF-e", Description = "Transferencia NF-e",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("300")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TransfNfe300 = 300,

            #endregion 300 - Transferencia NF-e

            #endregion 300-349 Transferencias

            #region 350-399 Remessas

            #region 350 - Remessa em bonificação

            /// <summary>
            /// Remessa em bonificação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "350 Remessa em bonificação", Description = "Remessa em bonificação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("350")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RemessaEmBonificacao350 = 350,

            #endregion 350 - Remessa em bonificação

            #region 351 - Remessa para conserto

            /// <summary>
            /// Remessa para conserto
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "351 Remessa para conserto", Description = "Remessa para conserto",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("351")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RemessaParaConserto351 = 351,

            #endregion 351 - Remessa para conserto

            #endregion 350-399 Remessas

            #region 400-449 Devoluções e trocas

            #region 400 - Devolução

            /// <summary>
            /// Devolução
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "400 Devolução", Description = "Devolução",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("400")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Sale_Item")]
            Devolucao400 = 400,

            #endregion 400 - Devolução

            #region 420 - Troca

            /// <summary>
            /// Troca
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "420 Troca", Description = "Troca",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("420")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Entrada1)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Sale_Item")]
            Troca420 = 420,

            #endregion 420 - Troca

            #endregion 400-449 Devoluções e trocas

            #region 900-999 Outros

            #region 900 - Saldo de vendas

            /// <summary>
            /// Saldo de vendas
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "900 Saldo de vendas", Description = "Saldo de vendas",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("900")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Neutro3)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Invoice")]
            SaldoVendas900 = 900,

            #endregion 900 - Saldo de vendas

            #region 901 - Saldo de pedidos

            /// <summary>
            /// Saldo de pedidos
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "901 Saldo de pedidos", Description = "Saldo de pedidos",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("901")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Neutro3)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SaldoPedidos901 = 901,

            #endregion 901 - Saldo de pedidos

            #region 902 - Projeção de vendas

            /// <summary>
            /// Projeção de vendas
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "902 Projeção de vendas", Description = "Projeção de vendas",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("902")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Neutro3)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Invoice")]
            SaldoProjecao902 = 902,

            #endregion 902 - Projeção de vendas

            #region 903 - Auditoria de estoque

            /// <summary>
            /// Auditoria de estoque
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "903 Auditoria", Description = "Auditoria de estoque",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("903")]
            //[ToolTip(null)]
            [SDirFin(SEnDirFin.Neutro3)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            AuditoriaDeEst903 = 903,

            #endregion 903 - Auditoria de estoque

            #endregion 900-999 Outros
        }

        #endregion SEnPdvOp

        #region SEnNfeTipoDfe

        public enum SEnNfeTipoDfe : byte
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("255")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd255 = 255,

            #endregion nd

            #region 0 - NFe

            /// <summary>
            /// NFe
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "NFe", Name = "0 NFe", Description = "NFe",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            NFe0 = 0,

            #endregion 0 - NFe

            #region 1 - NFCe

            /// <summary>
            /// NFCe
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "NFCe", Name = "1 NFCe", Description = "NFCe",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            NFCe1 = 1,

            #endregion 1 - NFCe

            #region 2 - CTe

            /// <summary>
            /// CTe
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "CTe", Name = "2 CTe", Description = "CTe",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CTe2 = 2,

            #endregion 2 - CTe

            #region 3 - CTeOS

            /// <summary>
            /// CTeOS
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "CTeOS", Name = "3 CTeOS", Description = "CTeOS",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CTeOS3 = 3,

            #endregion 3 - CTeOS

            #region 4 - MDFe

            /// <summary>
            /// MDFe
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "MDFe", Name = "4 MDFe", Description = "MDFe",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("4")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            MDFe4 = 4,

            #endregion 4 - MDFe

            #region 5 - NFSe

            /// <summary>
            /// NFSe
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "NFSe", Name = "5 NFSe", Description = "NFSe",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            NFSe5 = 5,

            #endregion 5 - NFSe

            #region 6 - SAT

            /// <summary>
            /// SAT
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "SAT", Name = "6 SAT", Description = "SAT",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("6")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SAT6 = 6,

            #endregion 6 - SAT

            #region 7 - CFe

            /// <summary>
            /// Cupom fiscal eletrônico
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "CFe", Name = "7 CFe", Description = "Cupom fiscal eletrônico",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("7")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CFe7 = 7,

            #endregion 7 - CFe

            #region 8 - GNRE

            /// <summary>
            /// Guia Nacional de Recolhimento de Tributos Estaduais
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "GNRE", Name = "8 GNRE", Description = "Guia Nacional de Recolhimento de Tributos Estaduais",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("8")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            GNRE8 = 8,

            #endregion 8 - GNRE

            #region 9 - SNCM

            /// <summary>
            /// Sistema Nacional de Controle de Medicamentos
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "SNCM", Name = "9 SNCM", Description = "Sistema Nacional de Controle de Medicamentos",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("9")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SNCM9 = 9,

            #endregion 9 - SNCM

            #region 10 - CCG

            /// <summary>
            /// Consulta Centralizada de GTIN
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "CCG", Name = "10 CCG", Description = "Consulta Centralizada de GTIN",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("10")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CCG10 = 10,

            #endregion 10 - CCG
        }

        #endregion SEnNfeTipoDfe

        #region SEnDirFin

        /// <summary>
        /// Direção financeira
        /// </summary>
        public enum SEnDirFin : byte // //byte=tinyint short=smallint int32=int
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "N/D", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - Entrada

            /// <summary>
            /// Entrada de valores
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Entrada", Name = "1 Entrada", Description = "Entrada de valores",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Entrada1 = 1,

            #endregion 1 - Entrada

            #region 2 - Saida

            /// <summary>
            /// Saída de valores
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Saida", Name = "2 Saida", Description = "Saída de valores",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Saida2 = 2,

            #endregion 2 - Saida

            #region 3 - Neutro

            /// <summary>
            /// Desc
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Neutro", Name = "3 Neutro", Description = "Desc",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Neutro3 = 3,

            #endregion 3 - Neutro
        }

        #endregion SEnDirFin

        #region SEnGenero

        /// <summary>
        /// Desc
        /// </summary>
        public enum SEnGenero : byte // //byte=tinyint short=smallint int32=int
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "N/D", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - Unissex

            /// <summary>
            /// Unissex
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Unissex", Name = "1 Unissex", Description = "Unissex",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Unissex1 = 1,

            #endregion 1 - Unissex

            #region 10 - Feminino

            /// <summary>
            /// Feminino
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Feminino", Name = "10 Feminino", Description = "Feminino",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("10")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Feminino10 = 10,

            #endregion 10 - Feminino

            #region 20 - Masculino

            /// <summary>
            /// Masculino
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Masculino", Name = "20 Masculino", Description = "Masculino",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("20")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Masculino20 = 20,

            #endregion 20 - Masculino
        }

        #endregion SEnGenero

        #region SEnNfePagTipoIntegr

        public enum SEnNfePagTipoIntegr : byte // verificar map. SNfeTipoIntegr_DbType
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - PagamentoIntegrado

            /// <summary>
            /// Pagamento integrado com o sistema de automação da empresa (Ex.: equipamento TEF, Comércio Eletrônico)
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "PagamentoIntegrado", Name = "1 PagamentoIntegrado", Description = "Pagamento integrado com o sistema de automação da empresa (Ex.: equipamento TEF, Comércio Eletrônico)",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            PagamentoIntegrado1 = 1,

            #endregion 1 - PagamentoIntegrado

            #region 2 - PagamentoNaoIntegrado

            /// <summary>
            /// Pagamento não integrado com o sistema de automação da empresa (Ex.: equipamento POS);
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "PagamentoNaoIntegrado", Name = "2 PagamentoNaoIntegrado", Description = "Pagamento não integrado com o sistema de automação da empresa (Ex.: equipamento POS);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            PagamentoNaoIntegrado2 = 2,

            #endregion 2 - PagamentoNaoIntegrado
        }

        #endregion SEnNfePagTipoIntegr

        #region SEnNfeModFrete

        /// <summary>
        /// Modalidade de frete
        /// </summary>
        public enum SEnNfeModFrete : byte
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "n/d", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("255")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd255 = 255,

            #endregion nd

            #region 0 - ContrFreteContaRemCIF

            /// <summary>
            /// Contratação do Frete por conta do Remetente (CIF);
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContrFreteContaRemCIF", Name = "1 ContrFreteContaRemCIF", Description = "Contratação do Frete por conta do Remetente (CIF);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContrFreteContaRemCIF0 = 0,

            #endregion 0 - ContrFreteContaRemCIF

            #region 1 - ContrFreteContaDestFOB

            /// <summary>
            /// Contratação do Frete por conta do Destinatário (FOB);
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContrFreteContaDestFOB", Name = "1 ContrFreteContaDestFOB", Description = "Contratação do Frete por conta do Destinatário (FOB);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContrFreteContaDestFOB1 = 1,

            #endregion 1 - ContrFreteContaDestFOB

            #region 2 - ContrFreteContaTerc

            /// <summary>
            /// Contratação do Frete por conta de Terceiros;
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContrFreteContaTerc", Name = "2 ContrFreteContaTerc", Description = "Contratação do Frete por conta de Terceiros;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContrFreteContaTerc2 = 2,

            #endregion 2 - ContrFreteContaTerc

            #region 3 - TranspPropContaRem

            /// <summary>
            /// Transporte Próprio por conta do Remetente;
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "TranspPropContaRem", Name = "3 TranspPropContaRem", Description = "Transporte Próprio por conta do Remetente;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TranspPropContaRem3 = 3,

            #endregion 3 - TranspPropContaRem

            #region 4 - TranspPropContaDest

            /// <summary>
            /// Transporte Próprio por conta do Destinatário;
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "TranspPropContaDest", Name = "4 TranspPropContaDest", Description = "Transporte Próprio por conta do Destinatário;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("4")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TranspPropContaDest4 = 4,

            #endregion 4 - TranspPropContaDest

            #region 9 - SemFrete

            /// <summary>
            /// Sem Ocorrência de Transporte.
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "SemFrete", Name = "9 SemFrete", Description = "Sem Ocorrência de Transporte.",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("9")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SemFrete9 = 9,

            #endregion 9 - SemFrete
        }

        #endregion SEnNfeModFrete

        #region SEnUnMed

        /// <summary>
        /// Unidade de medida
        /// O nome do member da enum (duas letras) será usado na emissão da NF-e
        /// </summary>
        public enum SEnUnMed : byte
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - UN

            /// <summary>
            /// Unidade
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "UN", Description = "Unidade",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            UN1 = 1,

            #endregion 1 - UN

            #region 2 - PC

            /// <summary>
            /// Peça
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "PC", Description = "Peça",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            PC2 = 2,

            #endregion 2 - PC

            #region 3 - PT

            /// <summary>
            /// Pacote
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "PT", Description = "Pacote",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            PT3 = 3,

            #endregion 3 - PT

            #region 4 - RL

            /// <summary>
            /// Rolo
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "RL", Description = "Rolo",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("4")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RL4 = 4,

            #endregion 4 - RL

            #region 5 - BN

            /// <summary>
            /// Bobina
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "BN", Description = "Bobina",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            BN5 = 5,

            #endregion 5 - BN

            #region 6 - BL

            /// <summary>
            /// Bloco
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "BL", Description = "Bloco",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("6")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            BL6 = 6,

            #endregion 6 - BL

            #region 7 - CO

            /// <summary>
            /// Copo
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "7", Description = "Copo",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("7")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CO7 = 7,

            #endregion 7 - CO

            #region 10 - KG

            /// <summary>
            /// Kilograma
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "KG", Description = "Kilograma",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("10")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            KG10 = 10,

            #endregion 10 - KG

            #region 11 - KT

            /// <summary>
            /// Kilo-ton
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "11", Description = "Kilo-ton",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("11")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            KT11 = 11,

            #endregion 11 - KT

            #region 20 - MT

            /// <summary>
            /// Metro linear
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "MT", Description = "Metro linear",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("20")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            MT20 = 20,

            #endregion 20 - MT

            #region 21 - M2

            /// <summary>
            /// Metro quadrado
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "M2", Description = "Metro quadrado",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("21")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            M2_21 = 21,

            #endregion 21 - M2

            #region 22 - M3

            /// <summary>
            /// Metro cúbico
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "M3", Description = "Metro cúbico",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("22")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            M3_22 = 22,

            #endregion 22 - M3

            #region 30 - LT

            /// <summary>
            /// Litro
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "LT", Description = "Litro",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("30")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            LT30 = 30,

            #endregion 30 - LT

            #region 31 - ML

            /// <summary>
            /// Mili-litro
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "31", Description = "Mili-litro",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("31")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ML31 = 31,

            #endregion 31 - ML

            #region 32 - FL

            /// <summary>
            /// Fentolitro
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "FL", Description = "Fentolitro",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("32")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            FL32 = 32,

            #endregion 32 - FL

            #region 42 - MW

            /// <summary>
            /// Megawatt
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "MW", Description = "Megawatt",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("42")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            MW42 = 42,

            #endregion 42 - MW

            #region 50 - PR

            /// <summary>
            /// Par
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "PR", Description = "Desc",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("50")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            PR50 = 50,

            #endregion 50 - PR

            #region 51 - DZ

            /// <summary>
            /// Dúzia
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "DZ", Description = "Dúzia",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("51")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            DZ51 = 51,

            #endregion 51 - DZ

            #region 52 - CJ

            /// <summary>
            /// Conjunto
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "CJ", Description = "Conjunto",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("52")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CJ52 = 52,

            #endregion 52 - CJ

            #region 53 - CX

            /// <summary>
            /// Caixa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "CX", Description = "Caixa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("53")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CX53 = 53,

            #endregion 53 - CX

            #region 54 - FD

            /// <summary>
            /// Fardo
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "FD", Description = "Fardo",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("54")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            FD54 = 54,

            #endregion 54 - FD

            #region 55 - SC

            /// <summary>
            /// Saco
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "SC", Description = "Saco",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("55")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            SC55 = 55,

            #endregion 55 - SC

            #region 56 - JG

            /// <summary>
            /// Jogo
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "JG", Description = "Jogo",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("56")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            JG56 = 56,

            #endregion 56 - JG

            #region 57 - FR

            /// <summary>
            /// Frasco
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "FR", Description = "Frasco",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("57")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            FR57 = 57,

            #endregion 57 - FR

            #region 58 - TB

            /// <summary>
            /// Tubo
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "TB", Description = "Tubo",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("58")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TB58 = 58,

            #endregion 58 - TB

            #region 59 - BD

            /// <summary>
            /// Balde
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "BD", Description = "Balde",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("59")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            BD59 = 59,

            #endregion 59 - BD

            #region 60 - FC

            /// <summary>
            /// Flaconete
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "FC", Description = "Flaconete",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("60")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            FC60 = 60,

            #endregion 60 - FC

            #region 61 - TU

            /// <summary>
            /// Tubete
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "TU", Description = "Tubete",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("61")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TU61 = 61,

            #endregion 61 - TU

            #region 62 - GL

            /// <summary>
            /// Galão
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "GL", Description = "Galão",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("62")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            GL62 = 62,

            #endregion 62 - GL

            #region 63 - LA

            /// <summary>
            /// Lata
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "LA", Description = "Lata",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("63")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            LA63 = 63,

            #endregion 63 - LA

            #region 64 - MI

            /// <summary>
            /// Mil passos
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "MI", Description = "Mil passos",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("64")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            MI64 = 64,

            #endregion 64 - MI
        }

        #endregion SEnUnMed

        #region SEnNfeCsosn

        /// <summary>
        /// Código de Situação da Operação do Simples Nacional
        /// </summary>
        public enum SEnNfeCsosn : short
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 101 - TribSnPermCred

            /// <summary>
            /// Tributada pelo Simples Nacional com permissão de crédito
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "101 Trib.p/S.N.c/Perm.Créd.", Description = "Tributada pelo Simples Nacional com permissão de crédito",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("101")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TribSnPermCred101 = 101,

            #endregion 101 - TribSnPermCred

            #region 102 - TribSnSemPermCred

            /// <summary>
            /// Tributada pelo Simples Nacional sem permissão de crédito
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "102 Trib.p/S.N.s/Perm.Cred.", Description = "Tributada pelo Simples Nacional sem permissão de crédito",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("102")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TribSnSemPermCred102 = 102,

            #endregion 102 - TribSnSemPermCred

            #region 103 - IsencaoIcmsSnFxRecBru

            /// <summary>
            /// Isenção do ICMS no Simples Nacional para faixa de receita bruta
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "103 Isenção S.N.p/fx.rec.bru", Description = "Isenção do ICMS no Simples Nacional para faixa de receita bruta",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("103")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            IsencaoIcmsSnFxRecBru103 = 103,

            #endregion 103 - IsencaoIcmsSnFxRecBru

            #region 201 - TribSnComPermCredCobSt

            /// <summary>
            /// Tributada pelo Simples Nacional com permissão de crédito e com cobrança do ICMS por Substituição Tributária
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "201 Trib.p/S.N.c/perm.créd.cobr.ICMS.p/S.T.", Description = "Tributada pelo Simples Nacional com permissão de crédito e com cobrança do ICMS por Substituição Tributária",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("201")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TribSnComPermCredCobSt201 = 201,

            #endregion 201 - TribSnComPermCredCobSt

            #region 202 - TribSnSemPermCredCobIcmsSt

            /// <summary>
            /// Tributada pelo Simples Nacional sem permissão de crédito e com cobrança do ICMS por Substituição Tributária;
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "202 Trib.p/S.N.s/perm.créd.cobr.ICMS.p/S.T.", Description = "Tributada pelo Simples Nacional sem permissão de crédito e com cobrança do ICMS por Substituição Tributária;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("202")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TribSnSemPermCredCobIcmsSt202 = 202,

            #endregion 202 - TribSnSemPermCredCobIcmsSt

            #region 203 - IsencaoIcmsSnParaFxRecBruCobrIcmsSt

            /// <summary>
            /// Isenção do ICMS nos Simples Nacional para faixa de receita bruta e com cobrança do ICMS por Substituição Tributária
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "203 Isenção ICMS S.N.p/fx.rec.bru.cobr.S.T.", Description = "Isenção do ICMS nos Simples Nacional para faixa de receita bruta e com cobrança do ICMS por Substituição Tributária",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("203")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            IsencaoIcmsSnParaFxRecBruCobrIcmsSt203 = 203,

            #endregion 203 - IsencaoIcmsSnParaFxRecBruCobrIcmsSt

            #region 300 - Imune

            /// <summary>
            /// Imune
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "300 Imune", Description = "Imune",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("300")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Imune300 = 300,

            #endregion 300 - Imune

            #region 400 - NaoTribSn

            /// <summary>
            /// Não tributada pelo Simples Nacional
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "400 N.trib.p/S.N.", Description = "Não tributada pelo Simples Nacional",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("400")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            NaoTribSn400 = 400,

            #endregion 400 - NaoTribSn

            #region 500 - IcmsCobrAntPorStOuAnt

            /// <summary>
            /// ICMS cobrado anteriormente por substituição tributária (substituído) ou por antecipação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "500 ICMS cobr.ant.p/S.T. ou ant.", Description = "ICMS cobrado anteriormente por substituição tributária (substituído) ou por antecipação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("500")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            IcmsCobrAntPorStOuAnt500 = 500,

            #endregion 500 - IcmsCobrAntPorStOuAnt

            #region 900 - Outros

            /// <summary>
            /// Outros
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "900 Outros", Description = "Outros",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("900")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Outros900 = 900,

            #endregion 900 - Outros
        }

        #endregion SEnNfeCsosn

        #region SEnNfeMotDesonIcms

        /// <summary>
        /// Motivo da desoneração do ICMS
        /// </summary>
        public enum SEnNfeMotDesonIcms : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Agropecuária", Description = "Uso na agropecuária",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Agro3 = 3,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Outro", Description = "Outros",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Outro9 = 9,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Fomento", Description = "Órgão de fomento e desenvolvimento agropecuário",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Fomento12 = 12,
        }

        #endregion SEnNfeMotDesonIcms

        #region SEnNfeModBcSt

        /// <summary>
        /// Modalidade de determinação da B.C. do ICMS
        /// </summary>
        public enum SEnNfeModBcSt : int
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Prç.tab.máx.", Description = "Preço tabelado ou máximo sugerido",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            PrcTabeladoMax0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Lista neg.", Description = "Lista Negativa (valor)",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ListaNegativa1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Lista pos.", Description = "Lista Positiva (valor);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ListaPositiva2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Lista neu.", Description = "Lista Neutra (valor)",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ListaNeutra3 = 3,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "M.V.A.", Description = "Margem Valor Agregado (%)",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            MVA4 = 4,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Pauta", Description = "Pauta (valor)",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Pauta5 = 5,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Val.op.", Description = "Valor da operação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ValorOperacao6 = 6,
        }

        #endregion SEnNfeModBcSt

        #region SEnNfeModBc

        /// <summary>
        /// Modalidade de determinação da B.C. do ICMS
        /// </summary>
        public enum SEnNfeModBc : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "M.V.A.", Description = "Margem Valor Agregado (%);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            MVA0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Pauta(valor)", Description = "Pauta (Valor);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            PautaValor1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Prç.tab.máx.", Description = "Preço Tabelado Máx. (valor);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            PrcTabeladoMax2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Val.op.", Description = "Valor da operação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ValorOperacao3 = 3,
        }

        #endregion SEnNfeModBc

        #region SEnNfeCst

        /// <summary>
        /// Código de situação tributária
        /// </summary>D:\nfe\xml\cfop-4.00\5102-SAÍDA-VENDAS-Venda de mercadoria adquirida ou recebida de terceiros\
        public enum SEnNfeCst : short
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "n/d", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd32767 = 32767,

            #endregion nd

            #region 00 - TribInt

            /// <summary>
            /// Tributada integralmente
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "00 Tributada integralmente", Description = "Tributada integralmente",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("00")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TribInt00 = 00,

            #endregion 00 - TribInt

            #region 10 - TribCobrIcmsSubstTrib

            /// <summary>
            /// Tributada e com cobrança do ICMS por substituição tributária
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "10 Tributada e com cobrança do ICMS por substituição tributária", Description = "Tributada e com cobrança do ICMS por substituição tributária",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("10")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            TribCobrIcmsSubstTrib10 = 10,

            #endregion 10 - TribCobrIcmsSubstTrib

            #region 20 - RedBC

            /// <summary>
            /// Com redução de base de cálculo
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "20 Com redução de base de cálculo", Description = "Com redução de base de cálculo",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("20")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RedBC20 = 20,

            #endregion 20 - RedBC

            #region 30 - IsentaOuNaoTrib

            /// <summary>
            /// Isenta ou não tributada e com cobrança do ICMS por substituição tributária
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "30 Isenta ou não tributada e com cobrança do ICMS por substituição tributária", Description = "Isenta ou não tributada e com cobrança do ICMS por substituição tributária",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("30")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            IsentaOuNaoTrib30 = 30,

            #endregion 30 - IsentaOuNaoTrib

            #region 40 - Isenta

            /// <summary>
            /// Isenta
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "40 Isenta", Description = "Isenta",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("40")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Isenta40 = 40,

            #endregion 40 - Isenta

            #region 41 - NaoTrib

            /// <summary>
            /// Não tributada
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "41 Não tributada", Description = "Não tributada",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("41")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            NaoTrib41 = 41,

            #endregion 41 - NaoTrib

            #region 50 - Suspensao

            /// <summary>
            /// Suspensão
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "50 Suspensão", Description = "Suspensão",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("50")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Suspensao50 = 50,

            #endregion 50 - Suspensao

            #region 51 - Diferimento

            /// <summary>
            /// Diferimento
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "51 Diferimento", Description = "Diferimento",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("51")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Diferimento51 = 51,

            #endregion 51 - Diferimento

            #region 60 - CobrAntSubsTrib

            /// <summary>
            /// ICMS cobrado anteriormente por substituição tributária
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "60 ICMS cobrado anteriormente por substituição tributária", Description = "ICMS cobrado anteriormente por substituição tributária",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("60")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            CobrAntSubsTrib60 = 60,

            #endregion 60 - CobrAntSubsTrib

            #region 70 - RedBcCobrIcmsST

            /// <summary>
            /// Com redução de base de cálculo e cobrança do ICMS por substituição tributária
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "70 RedBcCobrIcmsST", Description = "Com redução de base de cálculo e cobrança do ICMS por substituição tributária",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("70")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RedBcCobrIcmsST70 = 70,

            #endregion 70 - RedBcCobrIcmsST

            #region 90 - Outros

            /// <summary>
            /// Outros
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "90 Outros", Description = "Outros",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("90")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Outros90 = 90,

            #endregion 90 - Outros
        }

        #endregion SEnNfeCst

        #region SEnNfeTipoEmiss

        /// <summary>
        /// Tipo de Emissão da NF-e
        /// </summary>
        public enum SEnNfeTipoEmis : byte
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ND", Name = "n/d", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            nd0 = 0,

            #endregion nd

            #region 1 - Normal

            /// <summary>
            /// Normal
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Normal", Name = "1 Normal", Description = "Normal",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Normal1 = 1,

            #endregion 1 - Normal

            #region 2 - ContigenciaFSIAImpFormSeg

            /// <summary>
            /// Contingência FS-IA, com impressão do DANFE em Formulário de Segurança - Impressor Autônomo;
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContigenciaFSIAImpFormSeg", Name = "2 ContigenciaFSIAImpFormSeg", Description = "Contingência FS-IA, com impressão do DANFE em Formulário de Segurança - Impressor Autônomo;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("2")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContigenciaFSIAImpFormSeg2 = 2,

            #endregion 2 - ContigenciaFSIAImpFormSeg

            #region 3 - ContigenciaSCAN

            /// <summary>
            /// Contingência SCAN (Sistema de Contingência do Ambiente Nacional); *Desativado * NT 2015/002
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContigenciaSCAN", Name = "3 ContigenciaSCAN", Description = "Contingência SCAN (Sistema de Contingência do Ambiente Nacional); *Desativado * NT 2015/002",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("3")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContigenciaSCAN3 = 3,

            #endregion 3 - ContigenciaSCAN

            #region 4 - ContigenciaEPEC

            /// <summary>
            /// Contingência EPEC (Evento Prévio da Emissão em Contingência);
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContigenciaEPEC", Name = "4 ContigenciaEPEC", Description = "Contingência EPEC (Evento Prévio da Emissão em Contingência);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("4")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContigenciaEPEC4 = 4,

            #endregion 4 - ContigenciaEPEC

            #region 5 - ContigenciaFSDAImpDanfeFormSeg

            /// <summary>
            /// Contingência FS-DA, com impressão do DANFE em Formulário de Segurança - Documento Auxiliar;
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContigenciaFSDAImpDanfeFormSeg", Name = "5 ContigenciaFSDAImpDanfeFormSeg", Description = "Contingência FS-DA, com impressão do DANFE em Formulário de Segurança - Documento Auxiliar;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContigenciaFSDAImpDanfeFormSeg5 = 5,

            #endregion 5 - ContigenciaFSDAImpDanfeFormSeg

            #region 6 - ContigenciaSVCAN

            /// <summary>
            /// Contingência SVC-RS (SEFAZ Virtual de Contingência do RS);
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContigenciaSVCAN", Name = "6 ContigenciaSVCAN", Description = "Contingência SVC-RS (SEFAZ Virtual de Contingência do RS);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("6")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContigenciaSVCAN6 = 6,

            #endregion 6 - ContigenciaSVCAN

            #region 7 - ContigenciaSVCRS

            /// <summary>
            /// Contingência SVC-RS (SEFAZ Virtual de Contingência do RS);
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContigenciaSVCRS", Name = "7 ContigenciaSVCRS", Description = "Contingência SVC-RS (SEFAZ Virtual de Contingência do RS);",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("7")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContigenciaSVCRS7 = 7,

            #endregion 7 - ContigenciaSVCRS

            #region 9 - ContigenciaOfflineNfce

            /// <summary>
            /// Contingência off-line da NFC-e;
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "ContigenciaOfflineNfce", Name = "9 ContigenciaOfflineNfce", Description = "Contingência off-line da NFC-e;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("9")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            ContigenciaOfflineNfce9 = 9,

            #endregion 9 - ContigenciaOfflineNfce
        }

        #endregion SEnNfeTipoEmiss

        #region SEnNfeProdOrigem

        /// <summary>
        /// Origem da mercadoria
        /// </summary>
        public enum SEnNfeProdOrigem : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Nac.", Description = "Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Nacional0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Estr.", Description = "Estrangeira - Importação direta, exceto a indicada no código 6;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Estrangeira1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Estr.adq.merc.int.", Description = "Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            EstrAdqMercInt2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Nac.cont.imp.40-70%", Description = "Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% e inferior ou igual a 70%;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Nacional70_3 = 3,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Nacional", Description = "Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as legislações citadas nos Ajustes;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NacionalConf4 = 4,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Nac.cont.imp.inf.40%", Description = "Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Nacional40_5 = 5,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Estr.imp.dir.s/sim.nac.", Description = "Estrangeira - Importação direta, sem similar nacional, constante em lista da CAMEX e gás natural;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            EstrangeiraDireta6 = 6,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Estr.adq.merc.int.s/sim.nac.", Description = "Estrangeira - Adquirida no mercado interno, sem similar nacional, constante lista CAMEX e gás natural.",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            EstrangeiraInterna7 = 7,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Nac.cont.imp.sup.70%", Description = "Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70%;",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NacionalCont70p_8 = 8,
        }

        #endregion SEnNfeProdOrigem

        #region SEnNfeCfop

        /// <summary>
        /// CFOP
        /// </summary>
        public enum SEnNfeCfop : int
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "n/d", Description = S_LBL_NAME_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("0")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region *** 1000 * Entradas e/ou aquisições de serviços do Estado ***

            #region 1102 - CompraPComercializacao

            /// <summary>
            /// Compra para comercialização
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "1102 Compra para comercialização", Description = "Compra para comercialização",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1102")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.XAF.ModelEditor_ModelMerge")]
            CompraPComercializacao1102 = 1102,

            #endregion 1102 - CompraPComercializacao

            #region 1152 - TransfPComercializacao

            /// <summary>
            /// Transferência para comercialização
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "1152 Transferência para comercialização", Description = "Transferência para comercialização",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1152")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.XAF.Action_StateMachine")]
            TransfPComercializacao1152 = 1152,

            #endregion 1152 - TransfPComercializacao

            #region 1202 - Devolução de venda de mercadoria adquirida ou recebida de terceiros

            /// <summary>
            /// Devolução de venda de mercadoria adquirida ou recebida de terceiros
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "1202 Devolução de venda de mercadoria adquirida ou recebida de terceiros", Description = "Devolução de venda de mercadoria adquirida ou recebida de terceiros",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Entrada0)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Sale_Item")]
            DevolMercAdqTerc1202 = 1202,

            #endregion 1202 - Devolução de venda de mercadoria adquirida ou recebida de terceiros

            #endregion *** 1000 * Entradas e/ou aquisições de serviços do Estado ***

            #region *** 5000 * Saídas ou prestações de serviços dentro do Estado ***

            #region 5101: Venda de produção do estabelecimento

            /// <summary>
            /// Venda de produção do estabelecimento dentro do Estado
            /// Venda de produto industrializado ou produzido pelo estabelecimento, bem como a de mercadoria por estabelecimento industrial ou produtor rural de cooperativa destinada a seus cooperados ou a estabelecimento de outra cooperativa.
            /// (NR Ajuste SINIEF 05/2005) (Dec.28.868/2006 - Efeitos a partir de 01/01/2006, ficando facultada ao contribuinte a sua adoção para fatos geradores ocorridos no período de 01 de novembro a 31 de dezembro de 2005)
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5101 Venda de produção do estabelecimento dentro do Estado", Description = "Venda de mercadoria adquirida ou recebida de terceiros",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            VendaProdEstabDE5101 = 5101,

            #endregion 5101: Venda de produção do estabelecimento

            #region 5102: Venda de mercadoria adquirida ou recebida de terceiros.

            /// <summary>
            /// Venda de mercadoria adquirida ou recebida de terceiros dentro do Estado
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5102 Venda de mercadoria adquirida ou recebida de terceiros dentro do Estado", Description = "Venda de mercadoria adquirida ou recebida de terceiros",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            VendaMercAdqTercDE5102 = 5102,

            #endregion 5102: Venda de mercadoria adquirida ou recebida de terceiros.

            #region 5109 - VendProdEstbDestZfmOuAlc

            /// <summary>
            /// Venda de produção do estabelecimento destinada à ZFM ou ALC
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5109 Venda de produção do estabelecimento destinada à ZFM ou ALC", Description = "Venda de produção do estabelecimento destinada à ZFM ou ALC",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5109")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            VendProdEstbDestZfmOuAlc5109 = 5109,

            #endregion 5109 - VendProdEstbDestZfmOuAlc

            #region 5124 - IndEfetOutraEmpr

            /// <summary>
            /// Industrialização efetuada por outra empresa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5124 Industrialização efetuada por outra empresa", Description = "Industrialização efetuada por outra empresa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5124")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            IndEfetOutraEmpr5124 = 5124,

            #endregion 5124 - IndEfetOutraEmpr

            #region 5152: Transferência de mercadoria adquirida ou recebida de terceiros.

            /// <summary>
            /// Transferência de mercadoria adquirida ou recebida de terceiros dentro do Estado
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "5152 Transferência de mercadoria adquirida ou recebida de terceiros dentro do Estado", Description = "Transferência de mercadoria adquirida ou recebida de terceiros dentro do Estado",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.XAF.Action_StateMachine")]
            TransfMercAdqTercDE5152 = 5152,

            #endregion 5152: Transferência de mercadoria adquirida ou recebida de terceiros.

            #region 5201: Devolução de compra p/ industrialização ou produção rural dentro do Estado

            /// <summary>
            /// Devolução de compra p/ industrialização ou produção rural dentro do Estado
            /// Devolução de mercadoria adquirida para ser utilizada em processo de industrialização ou produção rural, cuja entrada tenha sido classificada como "1.101 - Compra para industrialização ou produção rural".
            /// (NR Ajuste SINIEF 05/2005) (Dec.28.868/2006 - Efeitos a partir de 01/01/2006, ficando facultada ao contribuinte a sua adoção para fatos geradores ocorridos no período de 01 de novembro a 31 de dezembro de 2005)
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "5201 Devolução de compra p/ industrialização ou produção rural dentro do Estado", Description = "Devolução de compra p/ industrialização ou produção rural dentro do Estado",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.XAF.Action_StateMachine")]
            DevolComprIndProdRuralDE5201 = 5201,

            #endregion 5201: Devolução de compra p/ industrialização ou produção rural dentro do Estado

            #region 5403 - VendMercAdqRecTercSujStCondContrSubst

            /// <summary>
            /// Venda de mercadoria, adquirida ou recebida de terceiros, sujeita a ST, na condição de contribuinte-substituto
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "VendMercAdqRecTercSujStCondContrSubst", Name = "5403 VendMercAdqRecTercSujStCondContrSubst", Description = "Venda de mercadoria, adquirida ou recebida de terceiros, sujeita a ST, na condição de contribuinte-substituto",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5403")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            VendMercAdqRecTercSujStCondContrSubst5403 = 5403,

            #endregion 5403 - VendMercAdqRecTercSujStCondContrSubst

            #region 5405: Venda de mercadoria, adquirida ou recebida de terceiros, sujeita a ST, na condição de contribuinte-substituído

            /// <summary>
            /// Venda de mercadoria, adquirida ou recebida de terceiros, sujeita a ST, na condição de contribuinte-substituído dentro do Estado
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5405 Venda de mercadoria, adquirida ou recebida de terceiros, sujeita a ST, na condição de contribuinte-substituído dentro do Estado", Description = "Venda de mercadoria, adquirida ou recebida de terceiros, sujeita a ST, na condição de contribuinte-substituído",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.XAF.Action_StateMachine")]
            VendaMercAdqTercSTContrSubsDE5405 = 5405,

            #endregion 5405: Venda de mercadoria, adquirida ou recebida de terceiros, sujeita a ST, na condição de contribuinte-substituído

            #region 5910: Remessa em bonificação, doação ou brinde

            /// <summary>
            /// Outra saída de mercadoria ou prestação de serviço não especificado
            /// Classificam-se neste código as outras saídas de mercadorias ou prestações de serviços que não tenham sido especificados nos códigos anteriores.
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "5910 Remessa em bonificação, doação ou brinde", Description = "Remessa em bonificação, doação ou brinde",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            RemessaEmBonificacaoDoacaoOuBrinde5910 = 5910,

            #endregion 5910: Remessa em bonificação, doação ou brinde

            #region 5915: Remessa para conserto

            /// <summary>
            /// Outra saída de mercadoria ou prestação de serviço não especificado
            /// Classificam-se neste código as outras saídas de mercadorias ou prestações de serviços que não tenham sido especificados nos códigos anteriores.
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "5915 Remessa para conserto", Description = "Remessa para conserto",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            RemessaParaConserto5915 = 5915,

            #endregion 5915: Remessa para conserto

            #region 5924 - RemPIndContaOrdArqMercQuandoNTransitarPeloEstabAdquir

            /// <summary>
            /// Remessa para industrialização por conta e ordem do adquirente da mercadoria, quando esta não transitar pelo estabelecimento do adquirente
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5924 Remessa para industrialização por conta e ordem do adquirente da mercadoria, quando esta não transitar pelo estabelecimento do adquirente", Description = "Remessa para industrialização por conta e ordem do adquirente da mercadoria, quando esta não transitar pelo estabelecimento do adquirente",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5924")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RemPIndContaOrdArqMercQuandoNTransitarPeloEstabAdquir5924 = 5924,

            #endregion 5924 - RemPIndContaOrdArqMercQuandoNTransitarPeloEstabAdquir

            #region 5926 - Lançamento efetuado a título de reclassificação de mercadoria decorrente de formação de kit ou de sua desagregação

            /// <summary>
            /// Lançamento efetuado a título de reclassificação de mercadoria decorrente de formação de kit ou de sua desagregação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5926 Lançamento efetuado a título de reclassificação de mercadoria decorrente de formação de kit ou de sua desagregação", Description = "Lançamento efetuado a título de reclassificação de mercadoria decorrente de formação de kit ou de sua desagregação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5926")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            LancEfetTitReclassifMercDecKitOuDesagr5926 = 5926,

            #endregion 5926 - Lançamento efetuado a título de reclassificação de mercadoria decorrente de formação de kit ou de sua desagregação

            #region 5927 - LancEfetTitBaixaEstoqDecPerdaRouboOuDeter

            /// <summary>
            /// Lançamento efetuado a título de baixa de estoque decorrente de perda, roubo ou deterioração
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5927 Lançamento efetuado a título de baixa de estoque decorrente de perda, roubo ou deterioração", Description = "Lançamento efetuado a título de baixa de estoque decorrente de perda, roubo ou deterioração",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5927")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            LancEfetTitBaixaEstoqDecPerdaRouboOuDeter5927 = 5927,

            #endregion 5927 - LancEfetTitBaixaEstoqDecPerdaRouboOuDeter

            #region 5929 - Lançamento efetuado em decorrência de emissão de documento fiscal relativo a operação ou prestação também acobertada por documento fiscal do varejo

            /// <summary>
            /// Lançamento efetuado em decorrência de emissão de documento fiscal relativo a operação ou prestação também acobertada por documento fiscal do varejo
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "5929 Lançamento efetuado em decorrência de emissão de documento fiscal relativo a operação ou prestação também acobertada por documento fiscal do varejo", Description = "Lançamento efetuado em decorrência de emissão de documento fiscal relativo a operação ou prestação também acobertada por documento fiscal do varejo",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("5929")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            LancEfetDecorrEmisDocFiscRelatOpAcobDocFiscVar5929 = 5929,

            #endregion 5929 - Lançamento efetuado em decorrência de emissão de documento fiscal relativo a operação ou prestação também acobertada por documento fiscal do varejo

            #region 5949: Outra saída de mercadoria ou prestação de serviço não especificado dentro do Estado

            /// <summary>
            /// Outra saída de mercadoria ou prestação de serviço não especificado
            /// Classificam-se neste código as outras saídas de mercadorias ou prestações de serviços que não tenham sido especificados nos códigos anteriores.
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "5949 Outra saída de mercadoria ou prestação de serviço não especificado", Description = "Outra saída de mercadoria ou prestação de serviço não especificado",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            OutraSaidaMercPrestServNEspecDE5949 = 5949,

            #endregion 5949: Outra saída de mercadoria ou prestação de serviço não especificado dentro do Estado

            #endregion *** 5000 * Saídas ou prestações de serviços dentro do Estado ***

            #region *** 6000 * Saídas ou prestações de serviços fora do Estado ***

            #region 6101: Venda de produção do estabelecimento

            /// <summary>
            /// Venda de produção do estabelecimento fora do Estado
            /// Venda de produto industrializado ou produzido pelo estabelecimento, bem como a de mercadoria por estabelecimento industrial ou produtor rural de cooperativa destinada a seus cooperados ou a estabelecimento de outra cooperativa.
            /// (NR Ajuste SINIEF 05/2005) (Dec.28.868/2006 - Efeitos a partir de 01/01/2006, ficando facultada ao contribuinte a sua adoção para fatos geradores ocorridos no período de 01 de novembro a 31 de dezembro de 2005)
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Description = "6101 Venda de produção do estabelecimento fora do Estado",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            VendaProdEstabFE6101 = 6101,

            #endregion 6101: Venda de produção do estabelecimento

            #region 6102 - VendMercAdqRecTercForaDoEstado

            /// <summary>
            /// Venda de mercadoria adquirida ou recebida de terceiros
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "VendMercAdqRecTercForaDoEstado", Name = "6102 Venda de mercadoria adquirida ou recebida de terceiros", Description = "Venda de mercadoria adquirida ou recebida de terceiros",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("6102")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            VendMercAdqRecTercForaDoEstado6102 = 6102,

            #endregion 6102 - VendMercAdqRecTercForaDoEstado

            #region 6108 - VendMercAdqTerDestNaoContrib

            /// <summary>
            /// Venda de mercadoria adquirida ou recebida de terceiros, destinada a não contribuinte
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "6108 VendMercAdqTerDestNaoContrib", Description = "Venda de mercadoria adquirida ou recebida de terceiros, destinada a não contribuinte",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("6108")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            VendMercAdqTerDestNaoContrib6108 = 6108,

            #endregion 6108 - VendMercAdqTerDestNaoContrib

            #region 6403 - VendaMercAdqTercOpMercSujStContrSubst

            /// <summary>
            /// Venda de mercadoria adquirida ou recebida de terceiros em operação com mercadoria sujeita a ST, na condição de contribuinte substituto
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "6403 Venda de mercadoria adquirida ou recebida de terceiros em operação com mercadoria sujeita a ST, na condição de contribuinte substituto", Description = "Venda de mercadoria adquirida ou recebida de terceiros em operação com mercadoria sujeita a ST, na condição de contribuinte substituto",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("6403")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            VendaMercAdqTercOpMercSujStContrSubst6403 = 6403,

            #endregion 6403 - VendaMercAdqTercOpMercSujStContrSubst

            #region 6404 - VendaProdStRetido

            /// <summary>
            /// Venda de mercadoria sujeita a ST, cujo imposto já tenha sido retido anteriormente
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "6404 Venda de mercadoria sujeita a ST, cujo imposto já tenha sido retido anteriormente", Description = "Venda de mercadoria sujeita a ST, cujo imposto já tenha sido retido anteriormente",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("6404")]
            //[ToolTip(null)]
            VendaProdStRetido6404 = 6404,

            #endregion 6404 - VendaProdStRetido

            #region 6902 - RetMercUtilIndPorEnc

            /// <summary>
            /// Retorno de mercadoria utilizada na industrialização por encomenda
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "6902 Retorno de mercadoria utilizada na industrialização por encomenda", Description = "Retorno de mercadoria utilizada na industrialização por encomenda",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("6902")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            RetMercUtilIndPorEnc6902 = 6902,

            #endregion 6902 - RetMercUtilIndPorEnc

            #region 6910: Remessa em bonificação, doação ou brinde

            /// <summary>
            /// Outra saída de mercadoria ou prestação de serviço não especificado
            /// Classificam-se neste código as outras saídas de mercadorias ou prestações de serviços que não tenham sido especificados nos códigos anteriores.
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "6910 Remessa em bonificação, doação ou brinde", Description = "Remessa em bonificação, doação ou brinde",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            RemessaEmBonificacaoDoacaoOuBrinde6910 = 6910,

            #endregion 6910: Remessa em bonificação, doação ou brinde

            #region 6949: Outra saída de mercadoria ou prestação de serviço não especificado fora do Estado

            /// <summary>
            /// Outra saída de mercadoria ou prestação de serviço não especificado
            /// Classificam-se neste código as outras saídas de mercadorias ou prestações de serviços que não tenham sido especificados nos códigos anteriores.
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "6949 Outra saída de mercadoria ou prestação de serviço não especificado", Description = "Outra saída de mercadoria ou prestação de serviço não especificado fora do Estado",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            [SNfeTipo(SEnNfeTipo.Saida1)]
            [SDivisa(SEnDivisa.Estadual)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Order_Item")]
            OutraSaidaMercPrestServNEspecFE6949 = 6949,

            #endregion 6949: Outra saída de mercadoria ou prestação de serviço não especificado fora do Estado

            #endregion *** 6000 * Saídas ou prestações de serviços fora do Estado ***

            #region 9000 - Usado para outras situações pelo Simtec

            #region 9999 - Balanço

            /// <summary>
            /// Balanço de estoque
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "9999 Balanço", Description = "Balanço de estoque",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("9999")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            Balanço9999 = 9999,

            #endregion 9999 - Balanço

            #endregion 9000 - Usado para outras situações pelo Simtec
        }

        #endregion SEnNfeCfop

        #region SEnNfeTipoBand

        /// <summary>
        /// Tipo da bandeira
        /// </summary>
        public enum SEnNfeTipoBand : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Visa", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Visa1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Mastercard", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Mastercard2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "American Express", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Amex3 = 3,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Sorocred", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Sorocred4 = 4,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "DinersClub", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            DinersClub5 = 5,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Elo6 = 6,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Hipercard", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Hipercard7 = 7,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Aura", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Aura8 = 8,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Cabal", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Cabal9 = 9,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Outro", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Outro99 = 99,
        }

        #endregion SEnNfeTipoBand

        #region SEnNfeIndPag

        /// <summary>
        /// Indicador da Forma de Pagamento
        /// </summary>
        public enum SEnNfeIndPag : int
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Pagamento à vista", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            AVista0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Pagamento à prazo", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            APrazo1 = 1,
        }

        #endregion SEnNfeIndPag

        #region SEnNfeTipoPag

        /// <summary>
        /// Meio de pagamento
        /// </summary>
        public enum SEnNfeTipoPag : int
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Dinheiro", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Dinheiro1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Cheque", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Cheque2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Cartão de crédito", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            CartaoCredito3 = 3,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Cartão de débito", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            CartaoDebito4 = 4,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Crédito da loja", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            CreditoLoja5 = 5,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Vale alimentação", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ValeAlimentacao10 = 10,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Vale refeição", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ValeRefeicao11 = 11,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Vale presente", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ValePresente12 = 12,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Vale combustível", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ValeCombustivel13 = 13,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Duplicata mercantil", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            DuplicataMercantil14 = 14,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Boleto bancário", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            BoletoBancario15 = 15,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Depósito bancário", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            DepositoBancario16 = 16,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Pagto. instantâneo Pix", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            PagamentoInstantaneoPix17 = 17,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Transferência bancária", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            TransfBancariaCartDigital18 = 18,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Programa de fidelidade, cashback ou crédito virtual", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ProgFidelCashbackCredVirtual19 = 19,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Sem pagamento", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            SemPagamento90 = 90,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Outro pagamento", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Outros99 = 99,
        }

        #endregion SEnNfeTipoPag

        #region SEnNfeIndValProdTotNfe

        /// <summary>
        /// Indica se valor do Item (vProd) entra no valor total da NF-e (vProd
        /// </summary>
        public enum SEnNfeIndValProdTotNfe : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Valor do item (vProd) não compõe o valor total da NF-e", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NaoCompoeTot0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Valor do item (vProd) compõe o valor total da NF-e (vProd) (v2.0)", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            CompoeTot1 = 1,
        }

        #endregion SEnNfeIndValProdTotNfe

        #region SEnNfeCodRegTrib

        /// <summary>
        /// Código de regime tributário
        /// </summary>
        public enum SEnNfeCodRegTrib : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
         Name = "Simples nacional", Description = S_LBL_DESC_NAO_DEFINIDO,
        AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            SimplesNacional1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Simples nacional exc. sub. rec. bru.", Description = "Simples nacional, excesso sublimite de receita bruta",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            SimplesNacionalExcSublimRecBru2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Regime normal", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            RegimeNormal3 = 3,
        }

        #endregion SEnNfeCodRegTrib

        #region SEnNfeProcEmis

        /// <summary>
        /// Processo de emissão da NF-e
        /// </summary>
        public enum SEnNfeProcEmis : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            AplicativoContribuinte0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Fisco1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ContribuitePeloSiteFisco2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ContribuintePeloAppFisco3 = 3,
        }

        #endregion SEnNfeProcEmis

        #region SEnNfeIndInterm

        /// <summary>
        /// Indicador de intermediador/marketplace
        /// </summary>
        public enum SEnNfeIndInterm : int
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Sem intermediador", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            SemIntermediador0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Operação em site ou plataforma de terceiros", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            SiteOuMarketplace1 = 1,
        }

        #endregion SEnNfeIndInterm

        #region SEnNfeIndPresCompEstMomOp

        /// <summary>
        /// Indicador de presença do comprador no estabelecimento comercial no momento da operação
        /// </summary>
        public enum SEnNfeIndPresCompEstMomOp : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Não se aplica", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NaoSeAplica0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Operação presencial", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Presencial1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Operação não presencial, pela Internet", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NaoPresencial2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Operação não presencial, Teleatendimento", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NaoPresencialTeleatendimento3 = 3,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "NFC-e em operação com entrega a domicílio", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NFCeOpEntrDomicilio4 = 4,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Operação presencial, fora do estabelecimento", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            OpPresencForaEstab5 = 5,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Operação não presencial, outros", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            OpNaoPresencOutros = 9,
        }

        #endregion SEnNfeIndPresCompEstMomOp

        #region SEnNfeIndOpConsumFin

        /// <summary>
        /// Indica operação com Consumidor final
        /// </summary>
        public enum SEnNfeIndOpConsumFin : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Normal", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Consumidor final", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Final1 = 1,
        }

        #endregion SEnNfeIndOpConsumFin

        #region SEnNfeFinEmis

        /// <summary>
        /// Finalidade de emissão da NF-e
        /// </summary>
        public enum SEnNfeFinEmis : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "NF-e normal", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Normal1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "NF-e complementar", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Complementar2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "NF-e de ajuste", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Ajuste3 = 3,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Devolução de mercadoria", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Devolucao4 = 4,
        }

        #endregion SEnNfeFinEmis

        #region SEnNfeTipoAmb

        /// <summary>
        /// Tipo de ambiente da NF-e
        /// </summary>
        public enum SEnNfeTipoAmb : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Produção", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Prod1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Homologação", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Hom2 = 2,
        }

        #endregion SEnNfeTipoAmb

        #region TmpDanfe

        /// <summary>
        /// Formato de Impressão do DANFE
        /// </summary>
        public enum SEnNfeTipoImpDanfe : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            SemGeracao0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NormalRetrato1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NormalPaisagem2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Simplificado3 = 3,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NFCe4 = 4,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            MensagemEletronica5 = 5,
        }

        #endregion TmpDanfe

        #region SEnNfeIdentLocDestOp

        /// <summary>
        /// Identificador do local de destino da operação
        /// </summary>
        public enum SEnNfeIdentLocDestOp : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Operação interna", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            OperacaoInterna1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Operação interestadual", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            OperacaoInterestadual2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Operação com exterior", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            OperacaoComExterior3 = 3,
        }

        #endregion SEnNfeIdentLocDestOp

        #region SEnNfeTipo

        /// <summary>
        /// Tipo de NF-e: Entrada/Saída
        /// </summary>
        public enum SEnNfeTipo : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = "n/d",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd255 = 255,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Entrada", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Business_Objects_BO_Audit_ChangeHistory)]
            Entrada0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "Saída", Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Business_Objects_BO_Audit_ChangeHistory)]
            Saida1 = 1,
        }

        #endregion SEnNfeTipo

        #region SEnNfeServico

        public enum SEnNfeServico : int // verificar map. SNfeServico_DbType
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = S_LBL_SHORTNAME_NAO_DEFINIDO, Name = S_LBL_NAME_NAO_DEFINIDO, Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            //[ImageName(SVG_DX_QUESTAO)]
            nd0 = 0,

            #endregion nd

            ConsCad10 = 10,
            ConsReciNFe20 = 20,
            ConsSitNFe30 = 30,
            ConsStatServ40 = 40,
            DistDFeInt50 = 50,
            EnvEvento60 = 60,
            EnviNFe70 = 70,
            InutNFe80 = 80,
            NfeProc90 = 90,
            ProcEventoNFe100 = 100,
            ProcInutNFe110 = 110,
            ProtNFe12 = 120,
            ResEvento130 = 130,
            ResNFe140 = 140,
            RetConsCad150 = 150,
            RetConsReciNFe160 = 160,
            RetConsSitNFe170 = 170,
            RetConsStatServ180 = 180,
            RetDistDFeInt190 = 190,
            RetEnvEvento200 = 200,
            RetEnviNFe210 = 210,
            RetInutNFe220 = 220,
        }

        #endregion SEnNfeServico

        #region SEnNfeMod

        public enum SEnNfeMod : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "NF-e", Description = "Nota Fiscal Eletrônica",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NFe55 = 55,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "NFC-e", Description = "Nota Fiscal Consumidor Eletrônica",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            NFCe65 = 65,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
            Name = "CT-e", Description = "Conhecimento de Transporte Eletrônico",
            AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            CTe57 = 57,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "MDF-e", Description = "Manifesto de Documentos Fiscal Eletrônico",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            MDFe58 = 58,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Name = "CTe-OS", Description = "Conhecimento de Transporte Eletrônico Especial",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            CTeOS67 = 67,
        }

        #endregion SEnNfeMod

        #region SEnNfeIndInscEst

        /// <summary>
        /// Indicador da inscrição estadual
        /// </summary>
        public enum SEnNfeIndInscEst : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd0 = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Contribuinte do ICMS", Description = null,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip("Contribuinte do I.C.M.S.")]
            Contribuinte1 = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Contribuinte isento", Description = null,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip("Contribuinte ISENTO de inscrição estadual")]
            Isento2 = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Name = "Não contribuinte", Description = null,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip("Não contribuinte do I.C.M.S., que pode ou não possuir inscrição estadual")]
            NaoContribuinte3 = 9,
        }

        #endregion SEnNfeIndInscEst

        #region STipo

        public enum SEnAtorTipo : byte // verificar map. STipo_DbType
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Outlook_Inspired.Customers")]
            nd0 = 0,

            #endregion nd

            #region 1 - Consumidor

            /// <summary>
            /// Consumidor
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Consumidor", Name = "1 Consumidor", Description = "Consumidor",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Cadastros_6_consumidor_cpf)]
            Consumidor1 = 1,

            #endregion 1 - Consumidor

            #region 10 - Empresa

            /// <summary>
            /// Empresa
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Empresa", Name = "10 Empresa", Description = "Empresa",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("10")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Cadastros_7_consumidor_cnpj)]
            Empresa10 = 10,

            #endregion 10 - Empresa

            #region 11 - Filial

            /// <summary>
            /// Filial
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Filial", Name = "10 Filial", Description = "Filial",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("11")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Cadastros_13_filial)]
            Filial11 = 11,

            #endregion 11 - Filial

            #region 20 - Fornecedor

            /// <summary>
            /// Fornecedor
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Fornecedor", Name = "20 Fornecedor", Description = "Fornecedor",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("20")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Cadastros_8_fornecedores)]
            Fornecedor20 = 20,

            #endregion 20 - Fornecedor

            #region 30 - Transportadora

            /// <summary>
            /// Transportadora
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Transportadora", Name = "30 Transportadora", Description = "Transportadora",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("30")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Cadastros_9_transportadoras)]
            Transportadora30 = 30,

            #endregion 30 - Transportadora

            #region 40 - Intermediador

            /// <summary>
            /// Intermediador
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Intermediador", Name = "40 Intermediador", Description = "Intermediador",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("40")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Outlook_Inspired_ProductQuickShippments)]
            Intermediador40 = 40,

            #endregion 40 - Intermediador

            #region 100 - Funcionario

            /// <summary>
            /// Funcionário
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Funcionario", Name = "100 Funcionario", Description = "Funcionário",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("100")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Cadastros_10_colaboradores)]
            Funcionario100 = 100,

            #endregion 100 - Funcionario

            #region 101 - Vendedor

            /// <summary>
            /// Vendedor
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Vendedor", Name = "101 Vendedor", Description = "Funcionário",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("101")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Icon_Builder_Actions_Question)]
            Vendedor101 = 101,

            #endregion 101 - Vendedor

            #region 102 - Gerente

            /// <summary>
            /// Gerente
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Gerente", Name = "102 Gerente", Description = "Funcionário",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("102")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Icon_Builder_Actions_Question)]
            Gerente102 = 102,

            #endregion 102 - Gerente
        }

        #endregion STipo

        public enum SEnMovPersPlanoTim : byte // verificar map. STipo_DbType
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - Migração

            /// <summary>
            /// Migração
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Migração", Name = "1 Migração", Description = "Migração",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Business_Objects.BO_Price_Item")]
            Migracao1 = 1,

            #endregion 1 - Migração

            #region 10 - Ativação

            /// <summary>
            /// Ativação
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Ativação", Name = "10 Ativação", Description = "Ativação",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("10")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.HybridDemoIcons.Tiles.HybridDemo_Commission")]
            Ativacao10 = 10,

            #endregion 10 - Ativação

            #region 20 - Portabilidade

            /// <summary>
            /// Serviço
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Portabilidade", Name = "10 Portabilidade", Description = "Portabilidade",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("20")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.HybridDemoIcons.Tiles.HybridDemo_Commission")]
            Portabilidade20 = 20,

            #endregion 20 - Portabilidade
        }

        public enum SEnProTipo : byte // verificar map. STipo_DbType
        {
            #region nd

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.Icon_Builder.Actions_Question")]
            nd0 = 0,

            #endregion nd

            #region 1 - Produto

            /// <summary>
            /// Produto
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Produto", Name = "1 Produto", Description = "Produto",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("1")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Cadastros_1_produtos)]
            Produto1 = 1,

            #endregion 1 - Produto

            #region 10 - Servico

            /// <summary>
            /// Serviço
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Servico", Name = "10 Servico", Description = "Serviço",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("10")]
            //[ToolTip(null)]
            //[ImageName(dx_SvgImages_Cadastros_2_serviços)]
            Servico10 = 10,

            #endregion 10 - Servico

            #region 99 - ServicoSemNfse

            /// <summary>
            /// Serviço s/ NFS-e
            /// </summary>
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                ShortName = "Serviço s/NFS-e", Name = "99 Serviço s/NFS-e", Description = "Serviço s/NFS-e",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            [XmlEnum("99")]
            //[ToolTip(null)]
            ////[ImageName("dx.SvgImages.HybridDemoIcons.Tiles.HybridDemo_Commission")]
            ServicoSemNfse99 = 99,

            #endregion 99 - ServicoSemNfse
        }

        [Flags]
        public enum SEnDireitoAcesso : byte
        {
            NotSpecified0 = 0,
            Allow1 = 1 << 0,
            Deny2 = 1 << 1,
        }

        #region Attributes

        #region StDivisaAttribute

        /// <summary>
        /// Evasão de divisa na movimentação de mercadoria
        /// </summary>
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Interface, Inherited = false)]
        public class SDivisaAttribute : Attribute
        {
            private SEnDivisa _Divisa;

            [Description("Evasão de divisa na movimentação de mercadoria")]
            public SEnDivisa SDivisa { get => _Divisa; set => _Divisa = value; }

            public SDivisaAttribute(SEnDivisa Divisa) => _Divisa = Divisa;
        }

        #endregion StDivisaAttribute

        public enum SEnDivisa : byte
        {
            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                Description = S_LBL_DESC_NAO_DEFINIDO,
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            nd = 0,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Description = "Estadual",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Estadual = 1,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Description = "Interestadual",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Interestadual = 2,

            [System.ComponentModel.DataAnnotations.Display(Order = 0,
                 Description = "Exterior",
                AutoGenerateField = true, AutoGenerateFilter = true, Prompt = "prompt")]
            //[ToolTip(null)]
            Exterior = 3,
        }

        #region SNfeTipoAttribute

        /// <summary>
        /// Define entrada ou saída na movimentação de mercadorias
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Interface, Inherited = false)]
        public class SNfeTipoAttribute : Attribute
        {
            private SEnNfeTipo _NfeTipo;

            [Description("Define entrada ou saída na movimentação de mercadorias")]
            public SEnNfeTipo NfeTipo { get => _NfeTipo; set => _NfeTipo = value; }

            public SNfeTipoAttribute(SEnNfeTipo entradaSaida) => _NfeTipo = entradaSaida;
        }

        #endregion SNfeTipoAttribute

        #region SDirFinAttribute

        /// <summary>
        /// Direção financeira
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Interface, Inherited = false)]
        public class SDirFinAttribute : Attribute
        {
            private SEnDirFin _DirFin;

            [Description("Direção financeira")]
            public SEnDirFin SDirFin { get => _DirFin; set => _DirFin = value; }

            public SDirFinAttribute(SEnDirFin DirFin) => _DirFin = DirFin;
        }

        #endregion SDirFinAttribute

        #region SxSvgImageAttribute

        /// <summary>
        /// Direção financeira
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Interface, Inherited = false)]
        public class SxSvgImageAttribute : Attribute
        {
            private string _Svg;

            [Description("SVG Image string")]
            public SxSvgImageAttribute(string DirFin) => _Svg = DirFin;
        }

        #endregion SxSvgImageAttribute

        #endregion Attributes
    }
}