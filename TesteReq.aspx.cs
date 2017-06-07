using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_TesteReq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void ddlEscolha_SelectedIndexChanged(object sender, EventArgs e)
    {

            //if (ddlEscolha.SelectedIndex == 1)
            //{
            //    mlvEscolha.ActiveViewIndex=2;
            //}
            //else if (ddlEscolha.SelectedIndex == 2)
            //{
            //    mlvEscolha.SetActiveView(view2);
            //}
            //else
            //{
            //    mlvEscolha.SetActiveView(view0);
            //}
            //  mlvEscolha.SetActiveView(view2);
        mlvEscolha.ActiveViewIndex = 1;

        
    }
}