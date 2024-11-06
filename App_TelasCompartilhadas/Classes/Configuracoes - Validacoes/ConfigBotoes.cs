using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.Utils.Svg;

namespace App_TelasCompartilhadas.Classes
{
    public class ConfigBotoes
    {
        private frmImagensGeralSistema frmImagensGeralSistema = new frmImagensGeralSistema();

        //Posicao das imagens no vetor
        //alterar[0]
        //exportar excel[1]
        //enviar email[2]
        //deletar[3]
        //buscar[4]
        //voltar[5]
        //finalizar venda[6]
        //selecionar produto[7]
        //visualizar[8]
        //imprimir[9]
        //pagar[10]
        //salvar[11]
        //novo[12]
        //adicionar carrinho[13]

        public void BotaoSalvar(SimpleButton button)
        {
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[11];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
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
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[5];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
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
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[12];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
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
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[8];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Visualizar informações do registro selecionado.";
            button.ToolTipTitle = "Visualizar:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoExcluir(SimpleButton button)
        {
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[3];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
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
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[6];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
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
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[10];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para realizar o pagamento.";
            button.ToolTipTitle = "Pagamento:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoAdicionarPagamento(SimpleButton button)
        {
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[7];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique aqui para adicionar o pagamento.";
            button.ToolTipTitle = "Adicionar pagamento:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoImprimir(SimpleButton button)
        {
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[9];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
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
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[2];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
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
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[0];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
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
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[4];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
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
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[1];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique para exportar para Excel.";
            button.ToolTipTitle = "Expotar Excel:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }

        public void BotaoAdicionarCarrinho(SimpleButton button)
        {
            var imagem = frmImagensGeralSistema.colecaoImagensBotoesSVG[13];

            DevExpress.Utils.Svg.SvgImage svgImage = imagem;

            Image image = svgImage.Render(null);

            button.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            button.ImageOptions.Image = image;
            button.ImageOptions.ImageToTextAlignment = ImageAlignToText.BottomCenter;
            button.ImageOptions.SvgImageSize = new Size(40, 40);
            button.Text = "";
            button.ToolTip = "Clique aqui para selecionar e adicionar ao seu carrinho.";
            button.ToolTipTitle = "Adicionar:";
            button.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
        }
    }
}