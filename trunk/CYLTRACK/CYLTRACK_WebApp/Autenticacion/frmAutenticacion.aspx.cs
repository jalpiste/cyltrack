﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion
{
    public partial class frmAutenticacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

         }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        
  
        
    }
}