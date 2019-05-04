using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;
namespace qk_front.companies.decoration
{
	
	public partial class detial : System.Web.UI.Page
	{
		public Site site ;
		public List<Case> cases;
		public Designer designer ;

        public List<SeoBll.Seo> tdks;

		public List<Contractor> contractorsList4global;

		public void Page_Load(object sender, EventArgs args)
		{
			site = SiteBll.GetSessionSite();

			long designer_id = Request["designer_id"].TryToLong();
			if (designer_id > 0) {
				designer = DesignerBll.GetDetailByDesignerId(designer_id);
				cases = CaseBll.GetCasesByAuthorId(designer_id);
			} else {
				designer = new Designer();
				cases = new List<Case>();
			}

            tdks = SeoBll.GetTDKbyPage("zxgsxq_sjs_xq.aspx", Request["designer_id"]).Table.Populate<SeoBll.Seo>();

			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
		}
	}
}

