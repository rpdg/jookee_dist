using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;


namespace qk_front.materials
{
    public partial class index : System.Web.UI.Page
    {
        public Site site;
        public List<Material> mts;
        public int cur_page;
        public int pages;

        public List<SeoBll.Seo> tdks;

        public List<Contractor> contractorsList4global;
        public void Page_Load(object sender, EventArgs args)
        {
            site = SiteBll.GetSessionSite();

            var pageIndex = Request["pg"].TryToInt();
            cur_page = pageIndex + 1;

            var frontDp = MaterialsBll.GetMaterialsForFront(20, pageIndex);
            mts = frontDp.Table.Populate<Material>();
            pages = frontDp.Page.pageCount;


            tdks = SeoBll.GetTDKbyPage("thjc_list.aspx", "").Table.Populate<SeoBll.Seo>();

            contractorsList4global = ContractorBll.GetAllContractors(0, 500).Table.Populate<Contractor>();
        }
    }
}
