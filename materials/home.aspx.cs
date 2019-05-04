using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using QK;
using Lyu;
using Lyu.Json;


namespace qk_front.materials
{
    public partial class home : System.Web.UI.Page
    {
        
		public Supplier supplier;
		public List<Material> materials;


        public Site site;

        public List<SeoBll.Seo> tdks;

        public List<Contractor> contractorsList4global;

        public void Page_Load(object sender, EventArgs args)
        {
            site = SiteBll.GetSessionSite();

			supplier = SupplierBll.GetDetailById(Request["supplier_id"].TryToLong());

			var dp_case = MaterialsBll.GetMaterialsBySupplierId(supplier.supplier_id);
			materials = dp_case.Table.Populate<Material>();

            tdks = SeoBll.GetTDKbyPage("sjxq.aspx", Request["supplier_id"]).Table.Populate<SeoBll.Seo>();
			contractorsList4global = ContractorBll.GetAllContractors (0, 500).Table.Populate<Contractor> ();
        }
    }
}
