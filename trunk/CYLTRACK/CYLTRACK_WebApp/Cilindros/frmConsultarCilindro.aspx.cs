﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Account
{
    public partial class frmConsultarCilindro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


    protected void txtCodigoCilindro_TextChanged(object sender, EventArgs e)
    {
        DivDatosCilindro.Visible = true;  
    }

          

        
    }
}