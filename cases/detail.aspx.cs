using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;

namespace qk_front.cases
{
	
	public partial class detial : Page
	{
		public Site site ;

		public long contractor_id ;
		
		public List<Case> cases;

		public Case the_case ;		
		public string[] imgs ;
		public Contractor contractor ;

        public List<SeoBll.Seo> tdks;

		
		public List<Contractor> contractorsList4global;

		public void Page_Load(object sender, EventArgs args)
		{
			site = SiteBll.GetSessionSite();

			the_case = CaseBll.GetCaseByCaseId(Request["case_id"].TryToLong() ) ;
			imgs = the_case.imgs.Split('?') ;

			contractor_id = the_case.contractor_id ;
			
			contractor = ContractorBll.GetContractorByContractorId(contractor_id) ;
			
			var dp_case = CaseBll.GetCasesByContractorId(contractor_id, 0, 20);
			cases = dp_case.Table.Populate<Case>();

            tdks = SeoBll.GetTDKbyPage("zxgsxq-jdal-xq.aspx", Request["case_id"]).Table.Populate<SeoBll.Seo>();

			
			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
		}

	}
}
