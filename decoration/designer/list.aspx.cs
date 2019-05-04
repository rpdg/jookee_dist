using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;

namespace qk_front.companies.decoration
{
	
	public partial class list : System.Web.UI.Page
	{
		public long contractor_id;
		public List<Designer> designers;
		public Site site ;

        public List<SeoBll.Seo> tdks;

		public List<Contractor> contractorsList4global;

		public void Page_Load(object sender, EventArgs args)
		{
			site = SiteBll.GetSessionSite();

			contractor_id = Request["cid"].TryToLong();
			
			designers = DesignerBll.GetDesignersByContractorId(contractor_id, 100);


            tdks = SeoBll.GetTDKbyPage("zxgsxq-sjs.aspx", Request["cid"]).Table.Populate<SeoBll.Seo>();

			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
		}

	}
}
