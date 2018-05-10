using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INF354Project
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            var db = new Model1();

            var deleteFurniture = from furniture in db.tblFurnitures where furniture.id == id select furniture;

            if (deleteFurniture.Any())
            {
                tblFurniture fur = deleteFurniture.First();
                db.tblFurnitures.Remove(fur);
                db.SaveChanges();
                Furniture.DataBind();
            }
            else
                lblError.Text = "Furniture not deleted";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int type = Convert.ToInt32(ddType.SelectedItem.Value);

            var db = new Model1();

            tblFurniture fur = new tblFurniture();
            fur.Name = name;
            fur.typeID = type;
            db.tblFurnitures.Add(fur); // basically the query and where it souuld execute
            db.SaveChanges(); // execute the query on the table
            Furniture.DataBind(); // to refresh table
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txtNameEd.Text;
            int type = Convert.ToInt32(ddTypeEd.SelectedItem.Value);
            int id = Convert.ToInt32(txtIDEd.Text);

            var db = new Model1();

            var furnitureUpdatequerry = from furniture in db.tblFurnitures where furniture.id == id select furniture;


            if (!furnitureUpdatequerry.Any())
                lblError.Text = "Furniture does not exsists";
            else
            {
                tblFurniture fur = furnitureUpdatequerry.First();
                fur.Name = name;
                fur.typeID = type;

                db.SaveChanges(); // execute the query on the table
                Furniture.DataBind(); // to refresh table
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtNameSearch.Text;
            var db = new Model1();
            var obj = (from furniture in db.tblFurnitures where(furniture.Name.Contains(search)) orderby furniture.Name ascending select furniture).ToList();
            
            if (!obj.Any())
                lblError.Text = "Furniture does not exsists";
            else
            {
                Furniture.DataSourceID = null;
                Furniture.DataSource = obj;
                Furniture.DataBind();
            }
           
        }

        protected void btnRevert_Click(object sender, EventArgs e)
        {
            Furniture.DataSourceID = null;
            Furniture.DataSource = sdsFurniture;
            Furniture.DataBind();
        }
    }
}