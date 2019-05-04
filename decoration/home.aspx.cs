using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;
namespace qk_front.decoration
{
	
	public partial class home : System.Web.UI.Page
	{
		public Contractor contractor;
		public List<Case> cases;
		public List<Designer> designers;
		public List<Worker> workers;

        public List<SeoBll.Seo> tdks;

		public List<Contractor> contractorsList4global;

		public Site site ;
		public void Page_Load(object sender, EventArgs args)
		{
			site = SiteBll.GetSessionSite();

			contractor = ContractorBll.GetContractorByContractorId(Request["cid"].TryToLong());

            contractor.address=contractor.address.Replace("\r\n", "<br/>");
			
			var dp_case = CaseBll.GetCasesByContractorId(contractor.contractor_id, 0, 4);
			cases = dp_case.Table.Populate<Case>();


            tdks = SeoBll.GetTDKbyPage("zxgsxq.aspx",Request["cid"]).Table.Populate<SeoBll.Seo>();


			designers = DesignerBll.GetDesignersByContractorId(contractor.contractor_id, 4);
			workers = WorkerBll.GetWorkersByContractorId(contractor.contractor_id, 4);
			
			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
		}

	}
}
