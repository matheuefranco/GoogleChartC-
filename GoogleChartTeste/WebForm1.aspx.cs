using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;

namespace GoogleChartTeste
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public class Data
        {
            public string ColumnName = "";
            public int Value = 0;

            public Data(string columnName, int value)
            {
                ColumnName = columnName;
                Value = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            DataSet ds = con.listaProdutos();
            //lblmsg.Text = con.mensagem;
        }
        [WebMethod]
        public static List<Data> TesteData()
        {
            List<Data> dataList = new List<Data>();

            dataList.Add(new Data("Column 1", 100));
            dataList.Add(new Data("Column 2", 200));
            dataList.Add(new Data("Column 3", 300));
            dataList.Add(new Data("Column 4", 400));

            return dataList;
        }
    [WebMethod]
        public static List<Produto> GetData()
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