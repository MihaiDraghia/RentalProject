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
    public class NoleggioManager
    {
        public NoleggioManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }


        public bool InsertNoleggio(NoleggioModel noleggioModel)
        {
            bool isInserito = false;

            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO [dbo].[MDNoleggi] (");
            sb.AppendLine("\t[IdVeicolo]");
            sb.AppendLine("\t,[IdCliente]");
            sb.AppendLine("\t,[Note]");
            sb.AppendLine("\t,[DataInizioNoleggio]");
            sb.AppendLine("\t,[DataFineNoleggio]");
            sb.AppendLine("\t,[IsAttivo]");
            sb.AppendLine(")VALUES(");
            sb.AppendLine("\t@IdVeicolo");
            sb.AppendLine("\t,@IdCliente");
            sb.AppendLine("\t,@Note");
            sb.AppendLine("\t,@DataInizioNoleggio");
            sb.AppendLine("\t,@DataFineNoleggio");
            sb.AppendLine("\t,@IsAttivo");
            sb.AppendLine(")");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {

                    if (noleggioModel.IdVeicolo > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdVeicolo", noleggioModel.IdVeicolo);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdVeicolo", DBNull.Value);
                    }


                    if (noleggioModel.IdCliente > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdCliente", noleggioModel.IdCliente);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdCliente", DBNull.Value);
                    }


                    if (!string.IsNullOrWhiteSpace(noleggioModel.Note))
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", noleggioModel.Note);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
                    }

                    sqlCommand.Parameters.AddWithValue("@DataInizioNoleggio", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@DataFineNoleggio", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@IsAttivo", 1);

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();

                    isInserito = true;
                }
            }
            return isInserito;
        }

        public bool UpdateFineNoleggio(int idNoleggio)
        {
            bool isModificato = false;

            var sb = new StringBuilder();

            sb.AppendLine("UPDATE ");
            sb.AppendLine("[dbo].[MDNoleggi] ");
            sb.AppendLine("SET ");
            sb.AppendLine($"\t[DataFineNoleggio]=@DataFineNoleggio");
            sb.AppendLine($"\t,[IsAttivo]=@IsAttivo");
            sb.AppendLine($"WHERE Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", idNoleggio);
                    sqlCommand.Parameters.AddWithValue("@DataFineNoleggio", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@IsAttivo", 0);

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();

                    isModificato = true;
                }
            }
            return isModificato;
        }

        public DatiNoleggiato GetDatiNoleggiato(int idVeicolo)
        {
            var datiNoleggiato = new DatiNoleggiato();

            var sb = new StringBuilder();

            sb.AppendLine("SELECT ");
            sb.AppendLine("\t n.[Id] AS IdNoleggio ");
            sb.AppendLine("\t,n.[DataInizioNoleggio] ");
            sb.AppendLine("\t,m.[Descrizione] AS Marca");
            sb.AppendLine("\t,v.[Modello] ");
            sb.AppendLine("\t,v.[Targa] ");
            sb.AppendLine("\t,c.[Nome] ");
            sb.AppendLine("\t,c.[Cognome] ");
            sb.AppendLine("\t,c.[CodiceFiscale] ");
            sb.AppendLine("\t,c.[Email] ");
            sb.AppendLine("\t,c.[Telefono] ");
            sb.AppendLine("FROM [dbo].[MDNoleggi] n ");
            sb.AppendLine("LEFT JOIN [dbo].[MDVeicoli] v ");
            sb.AppendLine("ON n.[IdVeicolo] = v.[Id]");
            sb.AppendLine("LEFT JOIN [dbo].[MDClienti] c ");
            sb.AppendLine("ON n.[IdCliente] = c.[Id]");
            sb.AppendLine("LEFT JOIN [dbo].[MDMarca] m ");
            sb.AppendLine("ON v.[IdMarca] = m.[Id]");
            sb.AppendLine($"WHERE n.[IdVeicolo]=@IdVeicolo ");
            sb.AppendLine($"AND n.[IsAttivo]=@IsAttivo");

            using (var cmd = new SqlCommand(sb.ToString()))
            {
                var ds = new DataSet();

                cmd.Parameters.AddWithValue("@IdVeicolo", idVeicolo);
                cmd.Parameters.AddWithValue("@IsAttivo", 1);

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

                if (ds.Tables.Count <= 0) return new DatiNoleggiato();
                var dataTable = ds.Tables[0];
                if (dataTable == null || dataTable.Rows.Count <= 0) return new DatiNoleggiato();

                DataRow dataRow = dataTable.Rows[0];

                datiNoleggiato.IdNoleggio = dataRow.Field<int>("IdNoleggio");
                datiNoleggiato.DataInizioNoleggio = dataRow.Field<DateTime?>("DataInizioNoleggio");
                datiNoleggiato.Marca = dataRow.Field<string>("Marca");
                datiNoleggiato.Modello = dataRow.Field<string>("Modello");
                datiNoleggiato.Targa = dataRow.Field<string>("Targa");
                datiNoleggiato.Nome = dataRow.Field<string>("Nome");
                datiNoleggiato.Cognome = dataRow.Field<string>("Cognome");
                datiNoleggiato.CodiceFiscale = dataRow.Field<string>("CodiceFiscale");
                datiNoleggiato.Email = dataRow.Field<string>("Email");
                datiNoleggiato.Telefono = dataRow.Field<string>("Telefono");

            }

            return datiNoleggiato;

        }

        public DatiNonNoleggiato GetDatiNonNoleggiato(int idVeicolo)
        {
            var datiVeicolo = new DatiNonNoleggiato();

            var sb = new StringBuilder();

            sb.AppendLine("SELECT ");
            sb.AppendLine("v.[Id] ");
            sb.AppendLine(",m.[Descrizione] as [Marca]");
            sb.AppendLine(",v.[Modello]");
            sb.AppendLine(",v.[Targa]");
            sb.AppendLine("FROM [dbo].[MDVeicoli] v ");
            sb.AppendLine("LEFT JOIN [dbo].[MDMarca] m ");
            sb.AppendLine("ON v.[IdMarca] = m.[Id]");
            sb.AppendLine($"WHERE v.[IdTipoStatus]=13 ");
            sb.AppendLine($"AND v.[Id]=@Id");

            using (var cmd = new SqlCommand(sb.ToString()))
            {
                var ds = new DataSet();
                cmd.Parameters.AddWithValue("@Id", idVeicolo);
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

                if (ds.Tables.Count <= 0) return new DatiNonNoleggiato();
                var dataTable = ds.Tables[0];
                if (dataTable == null || dataTable.Rows.Count <= 0) return new DatiNonNoleggiato();

                DataRow dataRow = dataTable.Rows[0];

                datiVeicolo.Id = dataRow.Field<int>("Id");
                datiVeicolo.Marca = dataRow.Field<string>("Marca");
                datiVeicolo.Modello = dataRow.Field<string>("Modello");
                datiVeicolo.Targa = dataRow.Field<string>("Targa");

            }

            return datiVeicolo;

        }

        public bool TransactionNoleggioNewCliente(ClienteModel clienteModel, int idVeicolo)
        {
            bool isRiuscito = false;

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction("SampleTransaction");

                command.Connection = connection;
                command.Transaction = transaction;

                var noleggioManager = new NoleggioManager(this.ConnectionString);
                var veicoloManager = new VeicoloManager(this.ConnectionString);
                var clienteManager = new ClienteManager(this.ConnectionString);

                try
                {
                    int? idCliente = clienteManager.InsertClienteGetId(clienteModel);

                    var noleggioModel = new NoleggioModel();

                    noleggioModel.IdCliente = int.Parse(idCliente.ToString());
                    noleggioModel.IdVeicolo = idVeicolo;

                    noleggioManager.InsertNoleggio(noleggioModel);

                    veicoloManager.UpdateVeicoloANoleggiato(idVeicolo);


                    transaction.Commit();

                    isRiuscito = true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {

                    }

                }
            }

            return isRiuscito;
        }

        public bool TransactionNoleggioClienteEsistente(int idCliente, int idVeicolo)
        {
            bool isRiuscito = false;

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction("SampleTransaction");

                command.Connection = connection;
                command.Transaction = transaction;

                var noleggioManager = new NoleggioManager(this.ConnectionString);
                var veicoloManager = new VeicoloManager(this.ConnectionString);

                var noleggioModel = new NoleggioModel();

                noleggioModel.IdCliente = idCliente;
                noleggioModel.IdVeicolo = idVeicolo;

                try
                {
                    noleggioManager.InsertNoleggio(noleggioModel);

                    veicoloManager.UpdateVeicoloANoleggiato(idVeicolo);


                    transaction.Commit();

                    isRiuscito = true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {

                    }

                }
            }

            return isRiuscito;
        }

        public bool TransactionFineNoleggio(int idNoleggio, int idVeicolo)
        {
            bool isRiuscito = false;

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction("SampleTransaction");

                command.Connection = connection;
                command.Transaction = transaction;

                var noleggioManager = new NoleggioManager(this.ConnectionString);
                var veicoloManager = new VeicoloManager(this.ConnectionString);

                try
                {
                    noleggioManager.UpdateFineNoleggio(idNoleggio);

                    veicoloManager.UpdateVeicoloANonNoleggiato(idVeicolo);


                    transaction.Commit();

                    isRiuscito = true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {

                    }

                }
            }

            return isRiuscito;
        }



    }
}
