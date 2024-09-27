using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using DevExpress.XtraEditors;
using Svg;
using DevExpress.Utils.Svg;
using System.Web.UI.WebControls.WebParts;

namespace DXApplicationPDV.Classes
{
    public class ConfigBotoes
    {
        private string localImagem = @"C:\Users\israe\source\repos\DXApplicationPDV\DXApplicationPDV\bin\Debug\icones\Navegacao\Nova pasta\"; // Caminho da imagem

        public void BotaoSalvar(SimpleButton button)
        {
            string nomeImagem = "save.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para salvar as alterações.";
            button.ToolTipTitle = "Salvar:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoVoltar(SimpleButton button)
        {
            string nomeImagem = "Back.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para retornar à tela anterior.";
            button.ToolTipTitle = "Voltar:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoNovoRegistro(SimpleButton button)
        {
            string nomeImagem = "Action_New.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique aqui para adicionar um novo registro.";
            button.ToolTipTitle = "Novo Registro:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoVisualizar(SimpleButton button)
        {
            string nomeImagem = "Preview.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Visualizar informações do registro selecionado.";
            button.ToolTipTitle = "Visualizar Venda:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoExcluir(SimpleButton button)
        {
            string nomeImagem = "Actions_Trash.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para remover o registro selecionado.";
            button.ToolTipTitle = "Excluir:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoFinalizarVenda(SimpleButton button)
        {
            string nomeImagem = "BO_Sale_Item.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique aqui para concluir a sua compra e finalizar o processo de venda.";
            button.ToolTipTitle = "Finalizar Venda:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoPagamento(SimpleButton button)
        {
            string nomeImagem = "ProductQuickShippments.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para realizar o pagamento.";
            button.ToolTipTitle = "Pagamento:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoSelecionarProduto(SimpleButton button)
        {
            string nomeImagem = "BO_Security_Permission_Type.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique aqui para selecionar o produto e adicionar à sua venda.";
            button.ToolTipTitle = "Adicionar:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoImprimir(SimpleButton button)
        {
            string nomeImagem = "PrintLayoutView.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para imprimir.";
            button.ToolTipTitle = "Imprimir:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoEnviarEmail(SimpleButton button)
        {
            string nomeImagem = "Actions_Send.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para enviar por e-mail.";
            button.ToolTipTitle = "Enviar por E-mail:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoAlterar(SimpleButton button)
        {
            string nomeImagem = "Action_Edit.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para modificar o registro selecionado.";
            button.ToolTipTitle = "Alterar:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoBuscar(SimpleButton button)
        {
            string nomeImagem = "Actions_Zoom.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para realizar a pesquisa.";
            button.ToolTipTitle = "Buscar:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoExcel(SimpleButton button)
        {
            string nomeImagem = "Action_Export_ToXls.svg";

            // Usar o SvgImage do DevExpress
            DevExpress.Utils.Svg.SvgImage svgImage = DevExpress.Utils.Svg.SvgImage.FromFile(localImagem + nomeImagem);

            // Converter para Image (não precisa ser Bitmap, pode ser Image)
            Image image = svgImage.Render(null);

            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para exportar para Excel.";
            button.ToolTipTitle = "Expotar Excel:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }
    }
}