using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using DevExpress.XtraBars.Alerter;

namespace App_ERP.Cadastro.PDV
{
    public partial class uc_CadPDV : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private long idPDV = 0;

        private string operacao = string.Empty;

        public uc_CadPDV(frmTelaInicialERP _form, string _operacao, int _idPDV)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = _form;

            idPDV = _idPDV;

            operacao = _operacao;

            PreencherFilial();

            if (idPDV != 0)
            {
                PreencherCampos();
            }
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);

            uc_TituloTelas1.lblTituloTela.Text = "Cadastrar PDV (Ponto de venda)";
        }

        private void PreencherFilial()
        {
            try
            {
                using (Session session = new Session())
                {
                    var filial = session.Query<tb_ator>()
                        .Where(x => x.at_desat == 0 && x.at_atorTipo == 11)
                        .Select(x => new
                        {
                            x.id_ator,
                            x.at_nomeFant,
                            x.at_cnpj
                        })
                        .ToList();

                    cmbFilial.Properties.DataSource = filial;
                    cmbFilial.Properties.DisplayMember = "at_nomeFant";
                    cmbFilial.Properties.ValueMember = "id_ator";
                    cmbFilial.Properties.NullText = "Selecione a Filial";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher filial: {ex.Message}");
            }
        }

        private void PreencherCampos()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var query = (from pdv in uow.Query<tb_pdv>()
                                 join filial in uow.Query<tb_ator>()
                                     on pdv.fk_tb_ator.id_ator equals filial.id_ator
                                 where pdv.id_pdv == idPDV
                                 select new
                                 {
                                     filial.id_ator,
                                     filial.at_cnpj,
                                     filial.at_nomeFant,
                                     pdv.pdv_pdvNum
                                 }).FirstOrDefault();

                    cmbFilial.EditValue = query.id_ator;
                    txtPDVNum.Text = query.pdv_pdvNum.ToString();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preenhcer campos da tela de cadastro de PDV: {ex.Message}");
            }
        }

        private void uc_CadPDV_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private bool IsCamposPreenchidos()
        {
            if (string.IsNullOrEmpty(cmbFilial.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Filial.");
                cmbFilial.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPDVNum.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo numero de PDV.");
                txtPDVNum.Focus();
                return false;
            }

            return true;
        }

        private void CadastrarPDV()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator ator = uow.GetObjectByKey<tb_ator>(Convert.ToInt64(cmbFilial.EditValue));

                    short numeroPDV = short.Parse(txtPDVNum.Text);

                    tb_pdv pdv = new tb_pdv(uow);

                    pdv.pdv_desat = 0;
                    pdv.pdv_pdvNum = numeroPDV;
                    pdv.pdv_nfeHomSerie = 0;
                    pdv.pdv_nfeHomNum = 0;
                    pdv.pdv_nfeProdSerie = 0;
                    pdv.pdv_nfeProdNum = 0;
                    pdv.pdv_dskIndex = 0;
                    pdv.pdv_dskSignature = 0;
                    pdv.pdv_dskSize = 0;
                    pdv.pdv_nicAdapterTypeID = 0;
                    pdv.pdv_nicInterfaceIndex = 0;
                    pdv.pdv_nicNetEnabled = 0;
                    pdv.pdv_nicSpeed = 0;
                    pdv.pdv_nicCfgDHCPEnabled = 0;
                    pdv.pdv_nicCfgIPConnectionMetric = 0;
                    pdv.pdv_nicCfgIPEnabled = 0;
                    pdv.pdv_pcPgFlAllocatedBaseSize = 0;
                    pdv.pdv_pcPgFlCurrentUsage = 0;
                    pdv.pdv_pcPgFlPeakUsage = 0;
                    pdv.pdv_pcLdCompressed = 0;
                    pdv.pdv_pcLdConfigManagerErrorCode = 0;
                    pdv.pdv_pcLdDriveType = 0;
                    pdv.pdv_pcLdFreeSpace = 0;
                    pdv.pdv_pcLdLastErrorCode = 0;
                    pdv.pdv_pcLdSize = 0;
                    pdv.pdv_pcLdVolumeDirty = 0;
                    pdv.pdv_pcAutomaticManagedPagefile = 0;
                    pdv.pdv_pcAutomaticResetBootOption = 0;
                    pdv.pdv_pcAutomaticResetCapability = 0;
                    pdv.pdv_pcBootROMSupported = 0;
                    pdv.pdv_pcCurrentTimeZone = 0;
                    pdv.pdv_pcDaylightInEffect = 0;
                    pdv.pdv_pcDomainRole = 0;
                    pdv.pdv_pcEnableDaylightSavingsTime = 0;
                    pdv.pdv_pcHypervisorPresent = 0;
                    pdv.pdv_pcNetworkServerModeEnabled = 0;
                    pdv.pdv_pcNumberOfLogicalProcessors = 0;
                    pdv.pdv_pcNumberOfProcessors = 0;
                    pdv.pdv_pcPCSystemType = 0;
                    pdv.pdv_pcTotalPhysicalMemory = 0;
                    pdv.pdv_pcWakeUpType = 0;
                    pdv.pdv_pcOsCurrentTimeZone = 0;
                    pdv.pdv_pcOsFreePhysicalMemory = 0;
                    pdv.pdv_pcOsFreeSpaceInPagingFiles = 0;
                    pdv.pdv_pcOsFreeVirtualMemory = 0;
                    pdv.pdv_pcOsNumberOfProcesses = 0;
                    pdv.pdv_pcOsNumberOfUsers = 0;
                    pdv.pdv_pcOsOperatingSystemSKU = 0;
                    pdv.pdv_pcOSLanguage = 0;
                    pdv.pdv_pcOSProductSuite = 0;
                    pdv.pdv_pcOsPortableOperatingSystem = 0;
                    pdv.pdv_pcOsPrimary = 0;
                    pdv.pdv_pcOsProductType = 0;
                    pdv.pdv_pcOsServicePackMajorVersion = 0;
                    pdv.pdv_pcOsServicePackMinorVersion = 0;
                    pdv.pdv_pcOsSizeStoredInPagingFiles = 0;
                    pdv.pdv_pcOsSuiteMask = 0;
                    pdv.pdv_pcOsTotalSwapSpaceSize = 0;
                    pdv.pdv_pcOsTotalVirtualMemorySize = 0;
                    pdv.pdv_pcOsTotalVisibleMemorySize = 0;
                    pdv.pdv_procHandleCount = 0;
                    pdv.pdv_procKernelModeTime = 0;
                    pdv.pdv_procOtherOperationCount = 0;
                    pdv.pdv_procOtherTransferCount = 0;
                    pdv.pdv_procPageFaults = 0;
                    pdv.pdv_procPageFileUsage = 0;
                    pdv.pdv_procPeakPageFileUsage = 0;
                    pdv.pdv_procPeakVirtualSize = 0;
                    pdv.pdv_procPeakWorkingSetSize = 0;
                    pdv.pdv_procPriority = 0;
                    pdv.pdv_procPrivatePageCount = 0;
                    pdv.pdv_procProcessId = 0;
                    pdv.pdv_procReadOperationCount = 0;
                    pdv.pdv_procReadTransferCount = 0;
                    pdv.pdv_procThreadCount = 0;
                    pdv.pdv_procUserModeTime = 0;
                    pdv.pdv_procVirtualSize = 0;
                    pdv.pdv_procWorkingSetSize = 0;
                    pdv.pdv_procWriteOperationCount = 0;
                    pdv.pdv_procWriteTransferCount = 0;
                    pdv.pdv_pcPrcAddressWidth = 0;
                    pdv.pdv_pcPrcArchitecture = 0;
                    pdv.pdv_pcPrcAvailability = 0;
                    pdv.pdv_pcPrcCharacteristics = 0;
                    pdv.pdv_pcPrcConfigManagerErrorCode = 0;
                    pdv.pdv_pcPrcConfigManagerUserConfig = 0;
                    pdv.pdv_pcPrcCpuStatus = 0;
                    pdv.pdv_pcPrcCurrentClockSpeed = 0;
                    pdv.pdv_pcPrcCurrentVoltage = 0;
                    pdv.pdv_pcPrcDataWidth = 0;
                    pdv.pdv_pcPrcExtClock = 0;
                    pdv.pdv_pcPrcFamily = 0;
                    pdv.pdv_pcPrcL2CacheSize = 0;
                    pdv.pdv_pcPrcL2CacheSpeed = 0;
                    pdv.pdv_pcPrcL3CacheSize = 0;
                    pdv.pdv_pcPrcL3CacheSpeed = 0;
                    pdv.pdv_pcPrcLevel = 0;
                    pdv.pdv_pcPrcLoadPercentage = 0;
                    pdv.pdv_pcPrcMaxClockSpeed = 0;
                    pdv.pdv_pcPrcNumberOfCores = 0;
                    pdv.pdv_pcPrcNumberOfEnabledCore = 0;
                    pdv.pdv_pcPrcNumberOfLogicalProcessors = 0;
                    pdv.pdv_pcPrcPowerManagementSupported = 0;
                    pdv.pdv_pcPrcProcessorType = 0;
                    pdv.pdv_pcPrcRevision = 0;
                    pdv.pdv_pcPrcSecondLevelAddressTranslationExtensions = 0;
                    pdv.pdv_pcPrcStatusInfo = 0;
                    pdv.pdv_pcPrcThreadCount = 0;
                    pdv.pdv_gpuAdapterRAM = 0;
                    pdv.pdv_gpuAvailability = 0;
                    pdv.pdv_gpuConfigManagerErrorCode = 0;
                    pdv.pdv_gpuCurrentBitsPerPixel = 0;
                    pdv.pdv_gpuCurrentHorizontalResolution = 0;
                    pdv.pdv_gpuCurrentNumberOfColors = 0;
                    pdv.pdv_gpuCurrentRefreshRate = 0;
                    pdv.pdv_gpuCurrentScanMode = 0;
                    pdv.pdv_gpuCurrentVerticalResolution = 0;
                    pdv.pdv_gpuDitherType = 0;
                    pdv.pdv_persTim = 0;
                    pdv.pdv_pdvUpdReady = 0;

                    //--------------------------------------------
                    pdv.pdv_dtCri = DateTime.Now;
                    pdv.pdv_dtAlt = DateTime.Now;
                    pdv.pdv_desat = 0;
                    pdv.fk_tb_ator = ator;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar PDV: {ex.Message}");
            }
        }

        private void AlterarPDV()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator ator = uow.GetObjectByKey<tb_ator>(Convert.ToInt64(cmbFilial.EditValue));

                    tb_pdv pdv = uow.GetObjectByKey<tb_pdv>(idPDV);

                    pdv.pdv_pdvNum = Convert.ToInt16(txtPDVNum.Text);
                    pdv.pdv_dtAlt = DateTime.Now;
                    pdv.fk_tb_ator = ator;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar PDV: {ex.Message}");
            }
        }

        private bool IsNumPDVExiste()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    long numPDV = Convert.ToInt64(txtPDVNum.Text);

                    var isNumPDVExist = uow.Query<tb_pdv>()
                        .Any(x => x.pdv_pdvNum == numPDV && x.fk_tb_ator == cmbFilial.EditValue);

                    return isNumPDVExist;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar numero PDV: {ex.Message}");

                return false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar" && IsNumPDVExiste())
            {
                MensagensDoSistema.MensagemAtencaoOk("Um PDV com esse número já cadastrado.");

                return;
            }

            if (operacao == "cadastrar")
            {
                CadastrarPDV();
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    AlterarPDV();

                    AlertaConfirmacaoCantoInferiorDireito();
                }
            }

            _frmTelaInicial.TelaPDV();
        }

        private void AlertaConfirmacaoCantoInferiorDireito()
        {
            // Obtém o FluentDesignForm ao qual o FluentDesignFormContainer pertence
            Form parentForm = _frmTelaInicial.FindForm();

            // Verifica se o parentForm não é nulo
            if (parentForm != null)
            {
                // Cria a mensagem e exibe o AlertControl
                AlertInfo info = new AlertInfo("", "");
                alcConfirmacao.Show(parentForm, info);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaPDV();
        }

        private void alcConfirmacao_HtmlElementMouseClick(object sender, DevExpress.XtraBars.Alerter.AlertHtmlElementMouseEventArgs e)
        {
            // Verifica qual elemento foi clicado pelo 'id'
            if (e.ElementId == "dialogresult-ok")
            {
                alcConfirmacao.Dispose();
            }
            else if (e.ElementId == "close")
            {
                alcConfirmacao.Dispose();
            }
        }
    }
}