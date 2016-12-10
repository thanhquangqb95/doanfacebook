using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;
using System.IO;

namespace doanfacebook
{
    public partial class frmDangNhap : Form
    {

        public class TaiKhoan
        {
            public string ten { get; set; }
            public string id { get; set; }
            public string hinh { get; set; }
            public TaiKhoan(string a, string b, string c)
            {
                ten = a;
                id = b;
                hinh = c;
            }
        }
        public frmDangNhap()
        {
            InitializeComponent();
        }
                                                                                      
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            //string OAuthURL = @"https://www.facebook.com/dialog/oauth?client_id=368621536821121
            //                &redirect_uri=https://www.facebook.com/connect/login_success.html
            //                &response_type=token
            //                @scope=use_group,user_status,user_photos,";
            //WebFacebook.Navigate(OAuthURL);
            var access_token = collection["tk"];
            FacebookClient fb = new FacebookClient(access_token);
            dynamic info = fb.Get("me?fields=id,name,picture");
            TaiKhoan taikhoan = new TaiKhoan(info.name, info.id, info.picture.data.url);
            Session["access_token"] = access_token;
            Session["taikhoan"] = taikhoan;
        }
    }
}
