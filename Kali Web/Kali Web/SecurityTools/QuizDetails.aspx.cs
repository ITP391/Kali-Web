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

        protected void Page_Load(object sender, EventArgs e)
        {
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            cell1.Text = "blah blah blah";
            row.Cells.Add(cell1);
            quizTable.Rows.Add(row);
        }
    }
}