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
    public class AlimentazioneManager
    {
        public AlimentazioneManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }


        public List<AlimentazioneModel> GetAlimentazioneList()
        {
            var alimentazioneList = new List<AlimentazioneModel>();

            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Id]");
            sb.AppendLine("\t,[Descrizione]");
            sb.AppendLine("FROM [dbo].[MDAlimentazione]");
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
                if (ds.Tables.Count <= 0) return new List<AlimentazioneModel>();
                var dataTable = ds.Tables[0];
                if (dataTable == null || dataTable.Rows.Count <= 0) return new List<AlimentazioneModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var alimentazioneModel = new AlimentazioneModel();

                    alimentazioneModel.Id = dataRow.Field<int>("Id");
                    alimentazioneModel.Descrizione = dataRow.Field<string>("Descrizione");
                    alimentazioneList.Add(alimentazioneModel);
                }
            }
            return alimentazioneList;
        }



    }
}
