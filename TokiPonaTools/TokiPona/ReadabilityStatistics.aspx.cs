using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Corpus;
using TpLogic.Readability;

namespace TokiPona
{
    public partial class ReadeabilityStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtInput.Text = SampleText.Giraffe();
                CalculateReability(this, new EventArgs());
            }
        }

        protected void CalculateReability(object sender, EventArgs e)
        {
            string text = HttpUtility.HtmlEncode(txtInput.Text);
            Metrics metrics= MetricsCalculator.Calculate(text);

            txtSentencesWords.Text = metrics.SentenceCount + ", " +metrics.WordCount;
            txtWordsPerSentence.Text = String.Format("{0:0.00}", metrics.WordsPerSentence);

            txtPercentProperModifiers.Text =
                String.Format("{0:0.00}  max expectable ({1:0.00}), ", metrics.ProperModiferPercent
                              ,metrics.ProperModifierMaximum);

            txtComplexNps.Text =
                String.Format("{0:0.00}  max expectable ({1:0.00})", metrics.ComplexNounPhrasePercent,
                              metrics.ComplexNoundPhraseMaximum);

            txtPercentFunctionWords.Text =
                String.Format("{0:0.00}  max expectable ({1:0.00})", metrics.FunctionWordPercent, metrics.FunctionWordMaximum);

            txtCoordinatingWords.Text =
                String.Format("{0:0.00}  max expectable ({1:0.00})", metrics.CoordinatingPercent, metrics.CoordinatingMaximum);
        }
    }
}
