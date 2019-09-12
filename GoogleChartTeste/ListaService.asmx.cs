using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Web.Script.Serialization;

namespace GoogleChartTeste
{
    /// <summary>
    /// Summary description for ListaService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ListaService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void buscaDados()
        {
            List<Produto> produtos = new List<Produto>();
            ConectaBanco con = new ConectaBanco();
            DataSet ds = con.listaProdutos();
            DataTable dt = new DataTable();

            dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                Produto prod = new Produto();
                prod.descricao = dr[1].ToString();
                prod.densidade = Convert.ToDouble(dr[3].ToString());
                produtos.Add(prod);
            }
            //return chartData;
            var js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(produtos));
        }
        [WebMethod]
        public  List<Produto> GetData()
        {
            List<Produto> produtos = new List<Produto>();
            ConectaBanco con = new ConectaBanco();
            DataSet ds = con.listaProdutos();
            DataTable dt = new DataTable();

            dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                Produto prod = new Produto();
                prod.iD = Convert.ToInt32(dr[0].ToString());
                prod.descricao = dr[1].ToString();
                prod.densidade = Convert.ToDouble(dr[3].ToString());
                produtos.Add(prod);
            }
            return produtos;
     
        }
    }
}
