using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;
namespace qk_front
{

    public partial class index : System.Web.UI.Page
    {
        public Site site;
        //public User me ;
        public List<Case> cases;
        public List<Article> articles1;
        public List<Article> articles2;
        public List<Article> articles3;
        public List<Article> articles4;
        public List<Material> materials;

        public List<SeoBll.Seo> tdks;

        public List<Contractor> contractors;
        public List<Supplier> suppliers;


        protected List<District> dists;

        public List<Contractor> contractorsList4global;

        public void Page_Load(object sender, EventArgs args)
        {
            //me = UserBll.GetSessionUser();
            var t_site_id = Request["site"].TryToShort();
            if (t_site_id > 0)
            {
                site = SiteBll.GetById(t_site_id);
                SiteBll.SetSessionSite(site);
            }

            site = SiteBll.GetSessionSite();

            //cases = CaseBll.GetCasesForFront(6, 0).Table.Populate<Case>() ;
            cases = CaseBll.GetCasesForFrontOnlyDesigner(6, 0, 0, 0).Populate<Case>();

            articles1 = ArticleBll.GetArticleForFront("热点新闻").Table.Populate<Article>();
            articles2 = ArticleBll.GetArticleForFront("居家布置").Table.Populate<Article>();
            articles3 = ArticleBll.GetArticleForFront("装修常识").Table.Populate<Article>();
            articles4 = ArticleBll.GetArticleForFront("装修手册").Table.Populate<Article>();

            materials = MaterialsBll.GetMaterialsForFront().Table.Populate<Material>();

            tdks = SeoBll.GetTDKbyPage("index.aspx", "").Table.Populate<SeoBll.Seo>();

            contractors = ContractorBll.GetAllContractors(0, 50).Table.Populate<Contractor>();
            suppliers = SupplierBll.GetAll(0, 50).Table.Populate<Supplier>();


            dists = DistrictBll.GetAll();

            contractorsList4global = ContractorBll.GetAllContractors(0, 500).Table.Populate<Contractor>();
        }

    }
}
