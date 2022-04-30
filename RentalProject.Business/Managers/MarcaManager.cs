using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalProject.Business.Models;

namespace RentalProject.Business.Managers
{
    public class MarcaManager
    {
        public MarcaManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }


        public List<MarcaModel> GetMarcaList()
        {
            var marcaList = new List<MarcaModel>();

            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Id]");
            sb.AppendLine("\t,[Descrizione]");
            sb.AppendLine("FROM [dbo].[MDMarca]");
            sb.AppendLine("ORDER BY [Descrizione]");

            using (var cmd = new SqlCommand(sb.ToString()))
            {
                var ds = new DataSet();
                using (var conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (var adp = new SqlDataAdapter(cmd))
                    {
                        adp.SelectCommand = cmd;
                        adp.SelectCommand.Connection = conn;
                        adp.Fill(ds);
                    }
                }
                if (ds.Tables.Count <= 0) return new List<MarcaModel>();
                var dataTable = ds.Tables[0];
                if (dataTable == null || dataTable.Rows.Count <= 0) return new List<MarcaModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var marcaModel = new MarcaModel();

                    marcaModel.Id = dataRow.Field<int>("Id");
                    marcaModel.Descrizione = dataRow.Field<string>("Descrizione");
                    marcaList.Add(marcaModel);
                }
            }
            return marcaList;
        }



    }
}
