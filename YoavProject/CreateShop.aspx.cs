using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;


namespace YoavProject
{
    public partial class CreateShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string last_fn = "";
                OleDbConnection Con = new OleDbConnection();
                Con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Project.accdb";
                Con.Open();
                int i = 0;
                string sqlstring1 = "SELECT * FROM Items; ";
                OleDbCommand cmd = new OleDbCommand(sqlstring1, Con);
                OleDbDataReader Dr = cmd.ExecuteReader();
                Dr.Read();
                Response.Write("<div id='orichecker'");
                if (Dr.HasRows)
                {
                    Response.Write("Categories:");
                    Response.Write("<ul>");
                    do
                    {
                        if (Equals(Dr["MyCategory"], last_fn) == false)
                        {
                            Response.Write("</table>");
                             Response.Write("<li > <button class='show-button' onclick='Show("+ i + ")' > " + Dr["MyCategory"].ToString() + " </button> </li>");
                            Response.Write("<hr/>");
                            Response.Write("<table id='ori" + i + "'>");
                            Response.Write("<tr>");
                            Response.Write("<td>  Name </td>");
                            Response.Write("<td>  Level </td>");
                            Response.Write("<td>  Price </td>");
                            Response.Write("<td>  Quantity </td>");
                            Response.Write("<tr/>");
                            last_fn = Dr["MyCategory"].ToString();
                            i++;
                        }


                        else
                        {
                            Response.Write("<tr>");
                            Response.Write("<td>" + Dr["ItemName"].ToString() + "<img class=\"ImageOri\" src=\"...\\HD_Foods \\" + Dr["ItemName"].ToString() + ".png\"><td/>");
                            Response.Write("<td>" + Dr["Food_Level"].ToString() + "<td/>");
                            Response.Write("<td>" + Dr["Price"].ToString() + "<td/>");
                            Response.Write("<td>" + "asp:TextBox runat='server'  ID = 'Quantity" + i + "'type='number' />  <td/> ");
                            Response.Write("<tr/>");
                        }
                    }
                    while (Dr.Read());

                    Con.Close();
                }
                Response.Write("<div/>");
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Project.accdb";
                Con1.Open();
                string sqlstring1 = "SELECT * FROM A WHERE HashID = '#9Z48' ";
                OleDbCommand cmd = new OleDbCommand(sqlstring1, Con1);
                OleDbDataReader Dr = cmd.ExecuteReader();
                Dr.Read();
                if (Dr.HasRows)
                {
                    string a = Dr["FarmLevel"].ToString();
                    string b = Dr["FarmID"].ToString();
                    string c = Dr["HashID"].ToString();
                    string id = ShopId();
                    DateTime currentTime = DateTime.Now;
                    TimeZoneInfo timeZone = TimeZoneInfo.Local;
                    string time = "" + currentTime + timeZone.DisplayName + "";
                    string sqlstring = " INSERT INTO Shops (ShopID,ShopPassword,TimeCreated, Name_IG, FarmID, FarmLevel, TransferOption, Particial) VALUES " + "('" + id + "','" + ShopPassword.Text + "','" + time +  "','" + Name_IG.Text + "','" + b + "','" + a + "','" + TransferOpt.Text + "','" + Particial.Checked + "');";
                    OleDbCommand cmd1 = new OleDbCommand(sqlstring, Con1);
                    int y = 0;
                    y = cmd1.ExecuteNonQuery();
                    Response.Write(y);
                    Con1.Close();
                }
                Con1.Close();
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


        public string ShopId()
        {
            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random rng = new Random();
            string code = "";
            for (int i = 0; i < 6; i++)
            {
                char ch = chars[rng.Next(chars.Length)];
                code += ch;
            }
            return code;
        }

    }
    }







}