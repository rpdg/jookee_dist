using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;

namespace qk_front.materials
{
	
	public partial class detail : System.Web.UI.Page
	{
		public Site site ;
		public Material material; 
		public string[] imgs;
		public bool isLogin ;
		public bool canExchange ;
		public User me;

        public List<SeoBll.Seo> tdks;

		public List<Contractor> contractorsList4global;

		public void Page_Load(object sender, EventArgs args)
		{
			site = SiteBll.GetSessionSite();


			material = MaterialsBll.GetDetailById(Request["meterial_id"].TryToLong());

			if (material == null)
				material = new Material();

			imgs = string.IsNullOrEmpty(material.imgs) ? null : material.imgs.Split('?');

			me = UserBll.GetSessionUser();
			if (me != null) {
				var myId = me.user_id;
				me = UserBll.GetUserById(myId);
				isLogin = true;
				canExchange = me.bonuses >= material.bonus;
			} else {
				me = new User();
				isLogin = false;
				canExchange = false;
			}

            tdks = SeoBll.GetTDKbyPage("thjc_xq.aspx", Request["meterial_id"]).Table.Populate<SeoBll.Seo>();

			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
		}
	}
}

