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
    public class VeicoloManager
    {
        public VeicoloManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }


        public bool InsertVeicolo(VeicoloModel veicoloModel)
        {
            bool isInserito = false;

            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO [dbo].[MDVeicoli] (");
            sb.AppendLine("[dbo].[MDVeicoli].[IdMarca]");
            sb.AppendLine(",[dbo].[MDVeicoli].[Modello]");
            sb.AppendLine(",[dbo].[MDVeicoli].[Targa]");
            sb.AppendLine(",[dbo].[MDVeicoli].[DataImmatricolazione]");
            sb.AppendLine(",[dbo].[MDVeicoli].[IdAlimentazione]");
            sb.AppendLine(",[dbo].[MDVeicoli].[IsNoleggiato]");
            sb.AppendLine(",[dbo].[MDVeicoli].[Note]");
            sb.AppendLine(",[dbo].[MDVeicoli].[IdTipoStatus]");
            sb.AppendLine(") VALUES (");
            sb.AppendLine("@IdMarca");
            sb.AppendLine(",@Modello");
            sb.AppendLine(",@Targa");
            sb.AppendLine(",@DataImmatricolazione");
            sb.AppendLine(",@IdAlimentazione");
            sb.AppendLine(",@IsNoleggiato");
            sb.AppendLine(",@Note");
            sb.AppendLine(",@IdTipoStatus");
            sb.AppendLine(")");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {

                    if (!(int.TryParse(veicoloModel.IdMarca.ToString(), out int idMarcaInt) && idMarcaInt > 0))
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", veicoloModel.IdMarca);
                    }


                    if (string.IsNullOrEmpty(veicoloModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", veicoloModel.Modello);
                    }


                    if (string.IsNullOrEmpty(veicoloModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", veicoloModel.Targa);
                    }


                    if (!veicoloModel.DataImmatricolazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", veicoloModel.DataImmatricolazione);
                    }


                    if (!(int.TryParse(veicoloModel.IdAlimentazione.ToString(), out int idAlimentazioneInt) && idAlimentazioneInt > 0))
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoloModel.IdAlimentazione);
                    }


                    if (!bool.TryParse(veicoloModel.IsNoleggiato.ToString(), out bool isNoleggiatoBool))
                    {
                        sqlCommand.Parameters.AddWithValue("@IsNoleggiato", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IsNoleggiato", veicoloModel.IsNoleggiato);
                    }

                    if (string.IsNullOrEmpty(veicoloModel.Note))
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", veicoloModel.Note);
                    }

                    if (veicoloModel.IdTipoStatus != 12 && veicoloModel.IdTipoStatus != 13)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdTipoStatus", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdTipoStatus", veicoloModel.IdTipoStatus);
                    }

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();

                    isInserito = true;
                }
            }
            return isInserito;
        }

        public List<VeicoloModelView> RicercaVeicoli(RicercaVeicolo ricercaVeicolo)
        {
            var veicoloViewList = new List<VeicoloModelView>();

            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("v.[Id]");
            sb.AppendLine(",m.[Descrizione]");
            sb.AppendLine(",v.[Modello]");
            sb.AppendLine(",v.[Targa]");
            sb.AppendLine(",v.[DataImmatricolazione]");
            sb.AppendLine(",v.[IsNoleggiato]");
            sb.AppendLine(",v.[IdTipoStatus]");
            sb.AppendLine("FROM [dbo].[MDVeicoli] v ");
            sb.AppendLine("LEFT JOIN [dbo].[MDMarca] m ");
            sb.AppendLine("ON v.[IdMarca] = m.[Id]");
            sb.AppendLine("WHERE v.[IdTipoStatus]=13 ");

            if (int.TryParse(ricercaVeicolo.IdMarca.ToString(), out int idMarcaInt) && idMarcaInt > 0)
            {
                sb.AppendLine("AND v.[IdMarca] = @IdMarca ");
            }

            if (!string.IsNullOrEmpty(ricercaVeicolo.Modello))
            {
                sb.AppendLine("AND v.[Modello] LIKE '%'+@Modello+'%' ");
            }

            if (!string.IsNullOrEmpty(ricercaVeicolo.Targa))
            {
                sb.AppendLine("AND v.[Targa] LIKE '%'+@Targa+'%' ");
            }

            if (ricercaVeicolo.DataImmatricolazioneInizio.HasValue && ricercaVeicolo.DataImmatricolazioneFine.HasValue && DateTime.TryParse(ricercaVeicolo.DataImmatricolazioneInizio.ToString(), out DateTime dataImmatricolazioneInizioDateTime) && DateTime.TryParse(ricercaVeicolo.DataImmatricolazioneFine.ToString(), out DateTime dataImmatricolazioneFineDateTime))
            {
                sb.AppendLine("AND v.[DataImmatricolazione] >= @DataImmatricolazioneInizio ");
                sb.AppendLine("AND v.[DataImmatricolazione] <= @DataImmatricolazioneFine ");
            }

            else if (ricercaVeicolo.DataImmatricolazioneInizio.HasValue && DateTime.TryParse(ricercaVeicolo.DataImmatricolazioneInizio.ToString(), out DateTime dataImmatricolazioneDateTime))
            {
                sb.AppendLine("AND v.[DataImmatricolazione] = @DataImmatricolazioneInizio ");
            }

            if (ricercaVeicolo.IsNoleggiato != null && bool.TryParse(ricercaVeicolo.IsNoleggiato.ToString(), out bool isNoleggiatoBool))
            {
                sb.AppendLine("AND v.[IsNoleggiato] = @IsNoleggiato ");
            }

            using (var cmd = new SqlCommand(sb.ToString()))
            {
                if (int.TryParse(ricercaVeicolo.IdMarca.ToString(), out int idMarcaInt2) && idMarcaInt > 0)
                {
                    cmd.Parameters.AddWithValue("@IdMarca", ricercaVeicolo.IdMarca);
                }

                if (!string.IsNullOrEmpty(ricercaVeicolo.Modello))
                {
                    cmd.Parameters.AddWithValue("@Modello", ricercaVeicolo.Modello);
                }

                if (!string.IsNullOrEmpty(ricercaVeicolo.Targa))
                {
                    cmd.Parameters.AddWithValue("@Targa", ricercaVeicolo.Targa);
                }

                if (ricercaVeicolo.DataImmatricolazioneInizio.HasValue && ricercaVeicolo.DataImmatricolazioneFine.HasValue && DateTime.TryParse(ricercaVeicolo.DataImmatricolazioneInizio.ToString(), out DateTime dataImmatricolazioneInizioDateTime2) && DateTime.TryParse(ricercaVeicolo.DataImmatricolazioneFine.ToString(), out DateTime dataImmatricolazioneFineDateTime2))
                {
                    cmd.Parameters.AddWithValue("@DataImmatricolazioneInizio", ricercaVeicolo.DataImmatricolazioneInizio);
                    cmd.Parameters.AddWithValue("@DataImmatricolazioneFine", ricercaVeicolo.DataImmatricolazioneFine);
                }

                else if (ricercaVeicolo.DataImmatricolazioneInizio.HasValue && DateTime.TryParse(ricercaVeicolo.DataImmatricolazioneInizio.ToString(), out DateTime dataImmatricolazioneDateTime2))
                {
                    cmd.Parameters.AddWithValue("@DataImmatricolazioneInizio", ricercaVeicolo.DataImmatricolazioneInizio);
                }

                if (ricercaVeicolo.IsNoleggiato != null && bool.TryParse(ricercaVeicolo.IsNoleggiato.ToString(), out bool isNoleggiatoBool2))
                {
                    cmd.Parameters.AddWithValue("@IsNoleggiato", ricercaVeicolo.IsNoleggiato);
                }

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
                if (ds.Tables.Count <= 0) return new List<VeicoloModelView>();
                var dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count <= 0) return new List<VeicoloModelView>();
                foreach (DataRow dataRow in dt.Rows)
                {
                    var veicoloModelView = new VeicoloModelView();

                    veicoloModelView.Id = dataRow.Field<int>("Id");
                    veicoloModelView.Marca = dataRow.Field<string>("Descrizione");
                    veicoloModelView.Modello = dataRow.Field<string>("Modello");
                    veicoloModelView.Targa = dataRow.Field<string>("Targa");
                    veicoloModelView.DataImmatricolazione = dataRow.Field<DateTime?>("DataImmatricolazione");
                    veicoloModelView.IsNoleggiato = dataRow.Field<bool>("IsNoleggiato");
                    veicoloModelView.IdTipoStatus = dataRow.Field<int>("IdTipoStatus");
                    veicoloViewList.Add(veicoloModelView);
                }
            }

            return veicoloViewList;
        }

        public class RicercaVeicolo
        {
            public int IdMarca { get; set; }
            public string Modello { get; set; }
            public string Targa { get; set; }
            public DateTime? DataImmatricolazioneInizio { get; set; }
            public DateTime? DataImmatricolazioneFine { get; set; }
            public bool? IsNoleggiato { get; set; }

        }

        public VeicoloModel GetVeicoloById(int id)
        {
            var veicoloModel = new VeicoloModel();

            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("[dbo].[MDVeicoli].[Id]");
            sb.AppendLine(",[dbo].[MDVeicoli].[IdMarca]");
            sb.AppendLine(",[dbo].[MDVeicoli].[Modello]");
            sb.AppendLine(",[dbo].[MDVeicoli].[Targa]");
            sb.AppendLine(",[dbo].[MDVeicoli].[DataImmatricolazione]");
            sb.AppendLine(",[dbo].[MDVeicoli].[IdAlimentazione]");
            sb.AppendLine(",[dbo].[MDVeicoli].[IsNoleggiato]");
            sb.AppendLine(",[dbo].[MDVeicoli].[Note]");
            sb.AppendLine(",[dbo].[MDVeicoli].[IdTipoStatus]");
            sb.AppendLine("FROM [dbo].[MDVeicoli]");
            sb.AppendLine($"WHERE [dbo].[MDVeicoli].[IdTipoStatus]=13 ");
            sb.AppendLine($"AND Id=@Id");

            using (var cmd = new SqlCommand(sb.ToString()))
            {
                var ds = new DataSet();
                cmd.Parameters.AddWithValue("@Id", id);
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

                if (ds.Tables.Count <= 0) return new VeicoloModel();
                var dataTable = ds.Tables[0];
                if (dataTable == null || dataTable.Rows.Count <= 0) return new VeicoloModel();

                DataRow dataRow = dataTable.Rows[0];

                veicoloModel.Id = dataRow.Field<int>("Id");
                veicoloModel.IdMarca = dataRow.Field<int>("IdMarca");
                veicoloModel.Modello = dataRow.Field<string>("Modello");
                veicoloModel.Targa = dataRow.Field<string>("Targa");
                veicoloModel.DataImmatricolazione = dataRow.Field<DateTime?>("DataImmatricolazione");
                veicoloModel.IdAlimentazione = dataRow.Field<int>("IdAlimentazione");
                veicoloModel.IsNoleggiato = dataRow.Field<bool>("IsNoleggiato");
                veicoloModel.Note = dataRow.Field<string>("Note");
                veicoloModel.IdTipoStatus = dataRow.Field<int>("IdTipoStatus");

            }

            return veicoloModel;
        }

        public bool UpdateVeicolo(VeicoloModel veicoloModel)
        {
            bool isInserito = false;

            var sb = new StringBuilder();

            sb.AppendLine("UPDATE ");
            sb.AppendLine("[dbo].[MDVeicoli] ");
            sb.AppendLine("SET ");
            sb.AppendLine($"[IdMarca]=@IdMarca");
            sb.AppendLine($",[Modello]=@Modello");
            sb.AppendLine($",[Targa]=@Targa");
            sb.AppendLine($",[DataImmatricolazione]=@DataImmatricolazione");
            sb.AppendLine($",[IdAlimentazione]=@IdAlimentazione");
            sb.AppendLine($",[Note]=@Note");
            sb.AppendLine($"WHERE Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", veicoloModel.Id);

                    if (veicoloModel.IdMarca <= 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", veicoloModel.IdMarca);
                    }


                    if (string.IsNullOrEmpty(veicoloModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", veicoloModel.Modello);
                    }


                    if (string.IsNullOrEmpty(veicoloModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", veicoloModel.Targa);
                    }


                    if (!veicoloModel.DataImmatricolazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@DataImmatricolazione", veicoloModel.DataImmatricolazione);
                    }


                    if (veicoloModel.IdAlimentazione <= 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoloModel.IdAlimentazione);
                    }


                    if (string.IsNullOrEmpty(veicoloModel.Note))
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", veicoloModel.Note);
                    }

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();

                    isInserito = true;
                }
            }
            return isInserito;
        }

        public bool EliminaVeicolo(int id)
        {
            bool isEliminato = false;

            var sb = new StringBuilder();

            sb.AppendLine("UPDATE ");
            sb.AppendLine("[dbo].[MDVeicoli] ");
            sb.AppendLine("SET ");
            sb.AppendLine($"[IdTipoStatus]=12");
            sb.AppendLine($"WHERE Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();

                    isEliminato = true;
                }
            }
            return isEliminato;

        }

        public bool UpdateVeicoloANoleggiato(int id)
        {
            bool isModificato = false;

            var sb = new StringBuilder();

            sb.AppendLine("UPDATE ");
            sb.AppendLine("[dbo].[MDVeicoli] ");
            sb.AppendLine("SET ");
            sb.AppendLine($"[IsNoleggiato]=@IsNoleggiato");
            sb.AppendLine($"WHERE Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlCommand.Parameters.AddWithValue("@IsNoleggiato", 1);

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();

                    isModificato = true;
                }
            }
            return isModificato;
        }



    }
}
