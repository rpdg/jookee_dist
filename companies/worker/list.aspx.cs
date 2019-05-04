using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;

namespace qk_front.companies.worker
{
	
	public partial class list : System.Web.UI.Page
	{
		public Site site ;
		public long contractor_id;
		public List<Worker> workers;


        public List<SeoBll.Seo> tdks;

		public List<Contractor> contractorsList4global;

		public void Page_Load(object sender, EventArgs args)
		{
			site = SiteBll.GetSessionSite();

			contractor_id = Request["cid"].TryToLong();
			
			workers = WorkerBll.GetWorkersByContractorId(contractor_id);

            tdks = SeoBll.GetTDKbyPage("zxgsxq-sgd.aspx", Request["cid"]).Table.Populate<SeoBll.Seo>();
		
			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
		}

	}
}
