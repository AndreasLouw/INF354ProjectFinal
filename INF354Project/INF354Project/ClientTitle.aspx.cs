using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INF354Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            //var db = new DataClasses1DataContext();

            var db = new Model1();

            var deleteTitle = from title in db.tblTitles where title.id == id select title;

            if (deleteTitle.Any())
            {
                // db.tblTitles.

                // db.tblTitles.DeleteOnSubmit(deleteTitle.First());
                //db.tblTitles.Remove(deleteTitle);

                // db.SubmitChanges();

                tblTitle title = deleteTitle.First();
                db.tblTitles.Remove(title);
                db.SaveChanges();


                GridTitle.DataBind();
            }
            else
                lblError.Text = "Title not deleted";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;

            var db = new Model1();

            tblTitle til = new tblTitle();
            til.Title = title;

            db.tblTitles.Add(til); // basically the query and where it souuld execute
            db.SaveChanges(); // execute the query on the table           

            GridTitle.DataBind(); // to refresh table
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string newTitle = txtTitleEd.Text;
            int id = Convert.ToInt32(txtIDEd.Text);

            var db = new Model1();

            var titleUpdatequerry = from title in db.tblTitles where title.id == id select title;


            if (!titleUpdatequerry.Any())
                lblError.Text = "Title does not exsists";
            else
            {
                tblTitle til = new tblTitle();

                tblTitle title = titleUpdatequerry.First();

                title.Title = newTitle;
                db.SaveChanges(); // execute the query on the table
                GridTitle.DataBind(); // to refresh table
            }
        }
    }
}