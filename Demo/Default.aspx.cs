using System;
using System.Web.UI;
using RG;

namespace Demo
{
    public partial class Default : Page
    {
        protected void Run_Clicked(object sender, EventArgs e)
        {
            BooScriptRunner scriptRunner = new BooScriptRunner();
            scriptRunner.Run(ScriptText.Text);
            Output.Text = scriptRunner.Errors;
        }
    }
}