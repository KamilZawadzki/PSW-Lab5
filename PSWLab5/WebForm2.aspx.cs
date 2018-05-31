using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSWLab5
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        public WebForm2()
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            innySrodekTransportu.Visible = false;
        }
    }
}