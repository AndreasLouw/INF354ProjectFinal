using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INF354Project
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* var db = new Model1();

             var clientid= from clfur in db.tblClientFurnitures select clfur.clientId;
             var idlist = clientid.ToArray();

             var clientTitle = from clt in db.tblTitles select clt.Title;

             var titlelist = clientTitle.ToArray();

             Chart1.data*/

           /* var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Project Name", typeof(string));
            dt.Columns.Add("Project Date", typeof(DateTime));

            for (int i = 0; i < 10; i++)
            {
                var row = dt.NewRow();
                row.ItemArray = new object[] { i, "Title-" + i.ToString(), DateTime.Now.AddDays(i * -1) };
                dt.Rows.Add(row);
            }

            var pp = from p in dt.AsEnumerable()
                     where (int)p["Id"] > 2
                     select p;

            foreach (var row in pp)
            {
                Console.WriteLine(row["Id"] + "\t" + row["Project Name"] + "\t" + row["Project Date"]);
            }

            Console.ReadLine();*/

        }
    }
}