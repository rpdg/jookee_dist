using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;
namespace qk_front.cases
{
	
	public partial class index : System.Web.UI.Page
	{
		public Site site ;
		public List<Case> cases;
		public int cur_page ;
		public int pages ;
		public int count ;

		protected List<RoomStyle> styles;
        protected List<HouseType> htypes;
		protected List<PlantDict> types;

        public List<SeoBll.Seo> tdks;

		public List<Contractor> contractorsList4global;

		public void Page_Load(object sender, EventArgs args)
		{
			var pageIndex = Request["pg"].TryToInt();
			if (pageIndex < 0)
				pageIndex = 0;

			cur_page = pageIndex + 1;

			var frontDp = CaseBll.SearchCasesForFront(Request["building_kw"], Request["rs"], Request["dst"] ,Request["ht"], 20 , pageIndex) ;
			cases = frontDp.Table.Populate<Case>();
			pages = frontDp.Page.pageCount;
			count = frontDp.Page.rowCount;

			site = SiteBll.GetSessionSite();

            htypes = DictBll.GetHouseTypes();
			styles = DictBll.GetRoomStyles();
			types = DictBll.GetDecorationStyles();

            tdks = SeoBll.GetTDKbyPage("search.aspx", "").Table.Populate<SeoBll.Seo>();

			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
		}
	}
}

