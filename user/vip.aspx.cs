using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;

namespace qk_front
{
	
	public partial class members : System.Web.UI.Page
	{
		public List<Contractor> contractors;
		public Site site;

        public List<SeoBll.Seo> tdks;
		public List<Contractor> contractorsList4global;

		public void Page_Load (object sender, EventArgs args)
		{
			contractors = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
			site = SiteBll.GetSessionSite ();


            tdks = SeoBll.GetTDKbyPage("vip.aspx", "").Table.Populate<SeoBll.Seo>();

			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
		}

	}
}
