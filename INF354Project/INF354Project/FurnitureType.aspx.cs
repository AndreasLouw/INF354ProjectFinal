using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INF354Project
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            var db = new Model1();

            var deletetype = from type in db.tblFurnitureTypes where type.id == id select type;

            if (deletetype.Any())
            {
                tblFurnitureType furtype = deletetype.First();
                db.tblFurnitureTypes.Remove(furtype);
                db.SaveChanges();
                Type.DataBind();
            }
            else
                lblError.Text = "Type not deleted";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string type = txtType.Text;

            var db = new Model1();

            tblFurnitureType ty = new tblFurnitureType();
            ty.Type = type;

            db.tblFurnitureTypes.Add(ty); // basically the query and where it souuld execute
            db.SaveChanges(); // execute the query on the table           

            Type.DataBind(); // to refresh table
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string newType = txtTypeEd.Text;
            int id = Convert.ToInt32(txtIDEd.Text);

            var db = new Model1();

            var typeUpdatequerry = from ty in db.tblFurnitureTypes where ty.id == id select ty;


            if (!typeUpdatequerry.Any())
                lblError.Text = "Title does not exsists";
            else
            {
                tblFurnitureType til = new tblFurnitureType();

                tblFurnitureType type = typeUpdatequerry.First();

                type.Type = newType;
                db.SaveChanges(); // execute the query on the table
                Type.DataBind(); // to refresh table
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}