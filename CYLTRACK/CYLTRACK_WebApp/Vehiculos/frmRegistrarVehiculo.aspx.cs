﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CYLTRACK_WebApp.Rutas
{
    public partial class frmRegistrarVehículo : System.Web.UI.Page
    {

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void txtCedula1_TextChanged(object sender, EventArgs e)
        {
            lblImprimirCedula.Text = txtCedula1.Text;
            txtCedula1.Text = "";
            DivAsignacionConductor.Visible = true;
        }


    }
}