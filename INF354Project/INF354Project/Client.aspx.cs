using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INF354Project
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            var db = new Model1();

            var deleteClient = from client in db.tblClients where client.id == id select client;          

            if (deleteClient.Any())
            {
                tblClient client = deleteClient.First();
                db.tblClients.Remove(client);
                db.SaveChanges();
                Client.DataBind();
            }
            else
                lblError.Text = "Title not deleted";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string name = txtName.Text;
            string ln = txtLastname.Text;
            int title = Convert.ToInt32(ddTitle.SelectedItem.Value);

            var db = new Model1();

            var clientEmailquerry = from client in db.tblClients where client.email == email select client.email;


            if (clientEmailquerry.Any())
                lblError.Text = "Client already exsiists";
            else
            {
                tblClient cl = new tblClient();
                cl.Name = name;
                cl.email = email;
                cl.Lastname = ln;
                cl.titleID = title;

                db.tblClients.Add(cl); // basically the query and where it souuld execute
                db.SaveChanges(); // execute the query on the table           

                 // execute the query on the table
                Client.DataBind(); // to refresh table
            }           
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string email = txtEmailEd.Text;
            string name = txtNameEd.Text;
            string ln = txtLnEd.Text;
            int title = Convert.ToInt32(ddTitleEd.SelectedItem.Value);

            var db = new Model1();

            var clientUpdatequerry = from client in db.tblClients where client.email.Contains(txtOldEmail.Text) select client;


            if (!clientUpdatequerry.Any())
                lblError.Text = "Client does not exsists";
            else
            {
                tblClient cl = clientUpdatequerry.First();

                cl.Name = name;
                cl.email = email;
                cl.Lastname = ln;
                cl.titleID = title;              

                db.SaveChanges(); // execute the query on the table
                Client.DataBind(); // to refresh table
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtNameSearch.Text;
            var db = new Model1();
            var obj = (from client in db.tblClients where (client.Name.Contains(search)) orderby client.Name ascending select client).ToList();

            if (!obj.Any())
                lblError.Text = "Furniture does not exsists";
            else
            {
                Client.DataSourceID = null;
                Client.DataSource = obj;
                Client.DataBind();
            }

        }

        protected void btnRevert_Click(object sender, EventArgs e)
        {
            Client.DataSourceID = null;
            Client.DataSource = addclient;
            Client.DataBind();
        }
    }
}