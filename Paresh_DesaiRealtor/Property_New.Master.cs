using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Property_cls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace Property
{
    public partial class Property_New : System.Web.UI.MasterPage
    {
        #region Global

        cls_Property clsobj = new cls_Property();

        #endregion Global
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenusList();
                string PgNam = "";
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString.ToString());
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd;
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = conn;
                int pageid = 0;
                if (Session["pageid"] == null)
                    pageid = 17;
                else
                    pageid = Convert.ToInt32(Session["pageid"].ToString());
                cmd.CommandText = "select * from tbl_PageBlogs where id=" + pageid;
                System.Data.SqlClient.SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    HtmlMeta meta = new HtmlMeta();
                    meta.Name = "Meta Tag";
                    meta.Content = dr["MetaTag"].ToString();
                    Page.Header.Controls.Add(meta);
                    HtmlMeta meta1 = new HtmlMeta();
                    meta1.Name = "MetaDiscription";
                    meta1.Content = dr["MetaDiscription"].ToString();
                    Page.Header.Controls.Add(meta1);
                    Page.Title = dr["pagetitle"].ToString();
                    //PgNam = dr["PageTitle"].ToString();
                }
            }  
        }

        private void BindMenusList()
        {
            StringBuilder StrMenu = new StringBuilder();
            DataTable dt = new DataTable();
            DataTable dtSubmenu = new DataTable();
            dt = clsobj.GetMenuList();

            DataTable ExclusiveCommercialDt = new DataTable();
            ExclusiveCommercialDt = clsobj.GetExclusiveListingCommercial();

            DataTable ExclusiveResidentialDt = new DataTable();
            ExclusiveResidentialDt = clsobj.GetExclusiveListing();

            DataTable Pre_ConstructionDt = new DataTable();
            Pre_ConstructionDt = clsobj.GetDreamHouseList();



            if (dt.Rows.Count > 0)
            {
                string PageName = dt.Rows[0]["PageName"].ToString();
                StrMenu.Append("<a class='toggleMenu' href='#'></a>");
                StrMenu.Append("<ul class='nav'>");
                StrMenu.Append("<li class='test'><a href='../Home.aspx' title='Home' class='active'>Home</a></li>");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsobj.PageID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    dtSubmenu = clsobj.GetSubMenuBy_PageID();
                    //check if it has submenu 
                    if (dtSubmenu.Rows.Count > 0)
                    {
                        StrMenu.Append("<li><a href=#>" + dt.Rows[i]["PageName"] + "</a>");//</li>
                        StrMenu.Append("<ul>");
                        for (int j = 0; j < dtSubmenu.Rows.Count; j++)
                        {
                            StrMenu.Append("<li><a href='../StaticPages.aspx?PageID=" + dtSubmenu.Rows[j]["id"] + "' title='" + dtSubmenu.Rows[j]["PageName"] + "'>" + dtSubmenu.Rows[j]["PageName"] + "</a> </li>");
                        }
                        StrMenu.Append("</ul>");
                        StrMenu.Append("</li>");
                    }
                    else
                    {
                        StrMenu.Append("<li><a href='../StaticPages.aspx?PageID=" + dt.Rows[i]["id"] + "' title='" + dt.Rows[i]["PageName"] + "'>" + dt.Rows[i]["PageName"] + "</a>");//</li>
                    }
                }

                StrMenu.Append("<li><a href=#>Pre-Constructions</a>");//</li>
                if (Pre_ConstructionDt.Rows.Count > 0)
                {
                    StrMenu.Append("<ul >");

                    for (int j = 0; j < Pre_ConstructionDt.Rows.Count; j++)
                    {
                        StrMenu.Append("<li><a href='../DreamHouseDetail.aspx?Id=" + Pre_ConstructionDt.Rows[j]["Id"] + "' title='Pre-Constructions'>" + Pre_ConstructionDt.Rows[j]["Title"] + "</a></li>");
                    }
                    StrMenu.Append("</ul>");
                }

                StrMenu.Append("<li><a href=#>Exclusive Commercial</a>");//</li>
                if (ExclusiveCommercialDt.Rows.Count > 0)
                {
                    StrMenu.Append("<ul >");

                    for (int j = 0; j < ExclusiveCommercialDt.Rows.Count; j++)
                    {
                        StrMenu.Append("<li><a href='../ExclusiveCommercial.aspx?Id=" + ExclusiveCommercialDt.Rows[j]["Id"] + "' title='Exclusive Commercial'>" + ExclusiveCommercialDt.Rows[j]["Title"] + "</a></li>");
                    }
                    StrMenu.Append("</ul>");
                }

                StrMenu.Append("<li><a href=#>Exclusive Residential</a>");//</li>
                if (ExclusiveResidentialDt.Rows.Count > 0)
                {
                    StrMenu.Append("<ul >");

                    for (int j = 0; j < ExclusiveResidentialDt.Rows.Count; j++)
                    {
                        StrMenu.Append("<li><a href='../ExclusiveResidential.aspx?Id=" + ExclusiveResidentialDt.Rows[j]["Id"] + "' title='Exclusive Residential'>" + ExclusiveResidentialDt.Rows[j]["Title"] + "</a></li>");
                    }
                    StrMenu.Append("</ul>");
                }



                //StrMenu.Append("<li class='test' style='background:none;'><a href='Admin/Adminlogin.aspx' title='Login'>Login</a></li>");
                //StrMenu.Append("<li style='background:none;'><a href='Home_worth.aspx' title='Home Evaluation'>Free Home Evaluation</a></li>");
                //StrMenu.Append("<li>");
                //StrMenu.Append("<a href='landing_page.aspx' title='Find your Dream Home'>Find your Dream Home</a>");
                //StrMenu.Append("</li>");

                ////StrMenu.Append("<li>");
                ////StrMenu.Append("<a href='../RealEstateNews.aspx' title='Real Estate News'>Real Estate News</a>");
                ////StrMenu.Append("</li>");

                //StrMenu.Append("<li style='background:none;'><a href='VirtualTour.aspx' title='Virtual Tour'>Virtual Tour</a></li>");
                StrMenu.Append("<li class='test' style='background:none;'><a href='ContactUs.aspx' title='Contact Us'>Contact Us</a></li>");
                //StrMenu.Append("<li class='test' style='background:none;'><a href='admin/adminlogin.aspx' title='Login'>Login</a></li>");
                StrMenu.Append("</ul>"); ;


            }


            dynamicmenus.Text = StrMenu.ToString();

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            //Session["username"] = txtname.Text;
            //Session["userphone"] = txtphone.Text;
            //Session["useremail"] = txtemail.Text;
            //myModal.Visible = false;      
        }
    }
}