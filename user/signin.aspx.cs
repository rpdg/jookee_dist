using System;
using System.Web;
using System.Web.UI;
using QK;
using Lyu;
namespace qk_front.user
{
	
	public partial class signin: System.Web.UI.Page
	{
		public void Page_Load (object sender, EventArgs args)
		{
			if (IsPostBack) {
				string name = Request ["name"].TryToString();
				string pwd = Request ["pwd"].TryToString();
				if (!(string.IsNullOrEmpty (name) || string.IsNullOrEmpty (pwd))) {
					if (UserBll.Login (Request ["name"], Request ["pwd"]) == 1) {
                        if (Request["returnURL"] != null)
                        {
                            string result = string.Empty;
                            result = SysLogBll.AddSysLog(BonusAction.Login, "");
                            Response.Redirect("../" + System.Web.HttpUtility.UrlDecode(Request["returnURL"].ToString()));
                        }
                        else
                        {
                            string result = string.Empty;
                            result = SysLogBll.AddSysLog(BonusAction.Login, "");
                            Response.Redirect("admin.aspx");
                        }
					}
				}
			}
		}
	}
}

