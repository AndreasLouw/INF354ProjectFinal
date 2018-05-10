using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INF354Project
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtid.Text);

            var db = new Model1();


            // var deleteClFur = from clfur in db.tblClientFurnitures where clfur.i == id select clfur;

            var deleteClFur = from clfur in db.tblClientFurnitures where clfur.id == id select clfur;

            if (deleteClFur.Any())
            {
                db.tblClientFurnitures.Remove(deleteClFur.First());
                db.SaveChanges();
                ClFur.DataBind();
            }
            else
                lblError.Text = "Record not deleted";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int clientID = Convert.ToInt32(ddCName.SelectedValue);
            int furnID = Convert.ToInt32(ddFName.SelectedValue);

            var db = new Model1();

            tblClientFurniture cf = new tblClientFurniture();
            cf.clientId = clientID;
            cf.furnitureId = furnID;
            cf.date = DateTime.Now;

            db.tblClientFurnitures.Add(cf); // basically the query and where it souuld execute
            db.SaveChanges(); // execute the query on the table
            ClFur.DataBind(); // to refresh table
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int newcID = Convert.ToInt32(ddCINew.SelectedItem.Value);
            int newfID = Convert.ToInt32(ddFidNew.SelectedItem.Value);
            int id = Convert.ToInt32(txtIDed.Text);


            var db = new Model1();

            var clFurUpdatequerry = from cf in db.tblClientFurnitures where cf.id == id select cf;

            if (!clFurUpdatequerry.Any())
                lblError.Text = "ID does not exsist";
            else
            {
                tblClientFurniture cfur = clFurUpdatequerry.First();

                cfur.clientId = newcID;
                cfur.furnitureId = newfID;

                db.SaveChanges(); // execute the query on the table
                ClFur.DataBind(); // to refresh table
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtNameSearch.Text;
            var db = new Model1();           

            var cid = (from cl in db.tblClients where cl.Name == search select cl).First();

            int clientid = cid.id;

            var fid = (from fur in db.tblClientFurnitures where fur.clientId == clientid select fur).First();

            int furnitureid = fid.furnitureId;

            var fname = (from fur in db.tblFurnitures where fur.id == furnitureid select fur).First();

            string furname = fname.Name;
            int furid = fname.typeID;

            var ftname = (from fur in db.tblFurnitureTypes where fur.id == furid select fur).First();

            string furtname = ftname.Type;

            var obj = (from furniture in db.tblFurnitures where (furniture.Name.Contains(search)) orderby furniture.Name ascending select furniture).ToList();

            lblError.Text = "Client " + search + " Rented a " + furname + " " + furtname;


            /*if (!obj.Any())
                lblError.Text = "Furniture does not exsists";
            else
            {
                Furniture.DataSourceID = null;
                Furniture.DataSource = obj;
                Furniture.DataBind();
            }*/
        }

        protected void btnRevert_Click(object sender, EventArgs e)
        {
           /* Furniture.DataSourceID = null;
            Furniture.DataSource = sdsFurniture;
            Furniture.DataBind();*/
        }

        protected void btnSearchSim_Click(object sender, EventArgs e)
        {

        }
    }
}