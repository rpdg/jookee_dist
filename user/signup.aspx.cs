using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;
namespace qk_front.user
{

	public partial class signup : System.Web.UI.Page
	{
		public Site site ;
		public List<Site> sites;

        public List<SeoBll.Seo> tdks;
		public List<Contractor> contractorsList4global;

		public void Page_Load(object sender, EventArgs args)
		{
			site = SiteBll.GetSessionSite();
			sites = SiteBll.GetAll();

            tdks = SeoBll.GetTDKbyPage("signup.aspx", "").Table.Populate<SeoBll.Seo>();

			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
		}

	}
}