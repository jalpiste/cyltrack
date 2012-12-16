using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Account
{
    public partial class frmconsultarcliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            divInfoCliente.Visible = true;
        }


    }
}