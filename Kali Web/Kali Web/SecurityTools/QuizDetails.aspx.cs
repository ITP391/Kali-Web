using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kali_Web.SecurityTools
{
    public partial class QuizDetails : System.Web.UI.Page
    {
        int correct;
        int totalQues;
        double result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (result < 2){
                grade.Text = "test";
            }
        }
    }
}