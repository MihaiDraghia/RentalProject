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
    public class ClienteManager
    {
        public ClienteManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }


        public List<ClienteModel> RicercaClienti(RicercaCliente ricercaCliente)
        {
            var clienteModelList = new List<ClienteModel>();

            var sb = new StringBuilder();

            sb.AppendLine("SELECT ");
            sb.AppendLine("\t[Id]");
            sb.AppendLine("\t,[Nome]");
            sb.AppendLine("\t,[Cognome]");
            sb.AppendLine("\t,[CodiceFiscale]");
            sb.AppendLine("\t,[DataNascita]");
            sb.AppendLine("\t,[Sesso]");
            sb.AppendLine("\t,[Indirizzo]");
            sb.AppendLine("\t,[Citta]");
            sb.AppendLine("\t,[Cap]");
            sb.AppendLine("\t,[Email]");
            sb.AppendLine("\t,[Telefono]");
            sb.AppendLine("\t,[IdTipoStatus]");
            sb.AppendLine("\t,[DataInserimento]");
            sb.AppendLine("\t,[DataModifica]");
            sb.AppendLine("FROM [dbo].[MDClienti] ");
            sb.AppendLine("WHERE [IdTipoStatus]=@IdTipoStatus ");


            if (!string.IsNullOrEmpty(ricercaCliente.Nome))
            {
                sb.AppendLine("AND [Nome] LIKE '%'+@Nome+'%' ");
            }

            if (!string.IsNullOrEmpty(ricercaCliente.Cognome))
            {
                sb.AppendLine("AND [Cognome] LIKE '%'+@Cognome+'%' ");
            }

            if (!string.IsNullOrEmpty(ricercaCliente.CodiceFiscale))
            {
                sb.AppendLine("AND [CodiceFiscale] LIKE '%'+@CodiceFiscale+'%' ");
            }

            if (!string.IsNullOrEmpty(ricercaCliente.Email))
            {
                sb.AppendLine("AND [Email] LIKE '%'+@Email+'%' ");
            }

            if (!string.IsNullOrEmpty(ricercaCliente.Telefono))
            {
                sb.AppendLine("AND [Telefono] LIKE '%'+@Telefono+'%' ");
            }

            using (var cmd = new SqlCommand(sb.ToString()))
            {

                if (!string.IsNullOrEmpty(ricercaCliente.Nome))
                {
                    cmd.Parameters.AddWithValue("@Nome", ricercaCliente.Nome);
                }

                if (!string.IsNullOrEmpty(ricercaCliente.Cognome))
                {
                    cmd.Parameters.AddWithValue("@Cognome", ricercaCliente.Cognome);
                }

                if (!string.IsNullOrEmpty(ricercaCliente.CodiceFiscale))
                {
                    cmd.Parameters.AddWithValue("@CodiceFiscale", ricercaCliente.CodiceFiscale);
                }

                if (!string.IsNullOrEmpty(ricercaCliente.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", ricercaCliente.Email);
                }

                if (!string.IsNullOrEmpty(ricercaCliente.Telefono))
                {
                    cmd.Parameters.AddWithValue("@Telefono", ricercaCliente.Telefono);
                }

                cmd.Parameters.AddWithValue("@IdTipoStatus", 13);

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
                if (ds.Tables.Count <= 0) return new List<ClienteModel>();
                var dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count <= 0) return new List<ClienteModel>();
                foreach (DataRow dataRow in dt.Rows)
                {
                    var clienteModel = new ClienteModel();

                    clienteModel.Id = dataRow.Field<int>("Id");
                    clienteModel.Nome = dataRow.Field<string>("Nome");
                    clienteModel.Cognome = dataRow.Field<string>("Cognome");
                    clienteModel.CodiceFiscale = dataRow.Field<string>("CodiceFiscale");
                    clienteModel.DataNascita = dataRow.Field<DateTime?>("DataNascita");
                    clienteModel.Sesso = dataRow.Field<string>("Sesso");
                    clienteModel.Indirizzo = dataRow.Field<string>("Indirizzo");
                    clienteModel.Citta = dataRow.Field<string>("Citta");
                    clienteModel.Cap = dataRow.Field<string>("Cap");
                    clienteModel.Email = dataRow.Field<string>("Email");
                    clienteModel.Telefono = dataRow.Field<string>("Telefono");
                    clienteModel.IdTipoStatus = dataRow.Field<int>("IdTipoStatus");
                    clienteModel.DataInserimento = dataRow.Field<DateTime?>("DataInserimento");
                    clienteModel.DataModifica = dataRow.Field<DateTime?>("DataModifica");
                    clienteModelList.Add(clienteModel);
                }
            }

            return clienteModelList;
        }

        public class RicercaCliente
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public string CodiceFiscale { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }

        }

        public ClienteModel GetCliente(int idCliente)
        {
            var clienteModel = new ClienteModel();

            var sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("\t[Id]");
            sb.AppendLine("\t,[Nome]");
            sb.AppendLine("\t,[Cognome]");
            sb.AppendLine("\t,[CodiceFiscale]");
            sb.AppendLine("\t,[DataNascita]");
            sb.AppendLine("\t,[Sesso]");
            sb.AppendLine("\t,[Indirizzo]");
            sb.AppendLine("\t,[Citta]");
            sb.AppendLine("\t,[Cap]");
            sb.AppendLine("\t,[Email]");
            sb.AppendLine("\t,[Telefono]");
            sb.AppendLine("\t,[IdTipoStatus]");
            sb.AppendLine("\t,[DataInserimento]");
            sb.AppendLine("\t,[DataModifica]");
            sb.AppendLine("FROM [dbo].[MDClienti] ");
            sb.AppendLine("WHERE [IdTipoStatus]=@IdTipoStatus ");
            sb.AppendLine($"AND Id=@Id");

            using (var cmd = new SqlCommand(sb.ToString()))
            {
                var ds = new DataSet();

                cmd.Parameters.AddWithValue("@Id", idCliente);
                cmd.Parameters.AddWithValue("@IdTipoStatus", 13);

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

                if (ds.Tables.Count <= 0) return new ClienteModel();
                var dataTable = ds.Tables[0];
                if (dataTable == null || dataTable.Rows.Count <= 0) return new ClienteModel();

                DataRow dataRow = dataTable.Rows[0];

                clienteModel.Id = dataRow.Field<int>("Id");
                clienteModel.Nome = dataRow.Field<string>("Nome");
                clienteModel.Cognome = dataRow.Field<string>("Cognome");
                clienteModel.CodiceFiscale = dataRow.Field<string>("CodiceFiscale");
                clienteModel.DataNascita = dataRow.Field<DateTime?>("DataNascita");
                clienteModel.Sesso = dataRow.Field<string>("Sesso");
                clienteModel.Indirizzo = dataRow.Field<string>("Indirizzo");
                clienteModel.Citta = dataRow.Field<string>("Citta");
                clienteModel.Cap = dataRow.Field<string>("Cap");
                clienteModel.Email = dataRow.Field<string>("Email");
                clienteModel.Telefono = dataRow.Field<string>("Telefono");
                clienteModel.IdTipoStatus = dataRow.Field<int>("IdTipoStatus");
                clienteModel.DataInserimento = dataRow.Field<DateTime?>("DataInserimento");
                clienteModel.DataModifica = dataRow.Field<DateTime?>("DataModifica");

            }

            return clienteModel;
        }

        public int? InsertClienteGetId(ClienteModel clienteModel)
        {
            int? idInserito = null;

            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [dbo].[MDClienti](");
            sb.AppendLine("\t[Nome]");
            sb.AppendLine("\t,[Cognome]");
            sb.AppendLine("\t,[CodiceFiscale]");
            sb.AppendLine("\t,[DataNascita]");
            sb.AppendLine("\t,[Sesso]");
            sb.AppendLine("\t,[Indirizzo]");
            sb.AppendLine("\t,[Citta]");
            sb.AppendLine("\t,[Cap]");
            sb.AppendLine("\t,[Email]");
            sb.AppendLine("\t,[Telefono]");
            sb.AppendLine("\t,[IdTipoStatus]");
            sb.AppendLine("\t,[DataInserimento]");
            sb.AppendLine("\t,[DataModifica]");
            sb.AppendLine(")VALUES(");
            sb.AppendLine("\t@Nome");
            sb.AppendLine("\t,@Cognome");
            sb.AppendLine("\t,@CodiceFiscale");
            sb.AppendLine("\t,@DataNascita");
            sb.AppendLine("\t,@Sesso");
            sb.AppendLine("\t,@Indirizzo");
            sb.AppendLine("\t,@Citta");
            sb.AppendLine("\t,@Cap");
            sb.AppendLine("\t,@Email");
            sb.AppendLine("\t,@Telefono");
            sb.AppendLine("\t,@IdTipoStatus");
            sb.AppendLine("\t,@DataInserimento");
            sb.AppendLine("\t,@DataModifica");
            sb.AppendLine(")");
            sb.AppendLine("SELECT SCOPE_IDENTITY()");


            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (var cmd = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    if (!string.IsNullOrWhiteSpace(clienteModel.Nome))
                    {
                        cmd.Parameters.AddWithValue("@Nome", clienteModel.Nome);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Nome", DBNull.Value);
                    }


                    if (!string.IsNullOrWhiteSpace(clienteModel.Cognome))
                    {
                        cmd.Parameters.AddWithValue("@Cognome", clienteModel.Cognome);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Cognome", DBNull.Value);
                    }


                    if (!string.IsNullOrWhiteSpace(clienteModel.CodiceFiscale))
                    {
                        cmd.Parameters.AddWithValue("@CodiceFiscale", clienteModel.CodiceFiscale);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CodiceFiscale", DBNull.Value);
                    }


                    if (clienteModel.DataNascita.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@DataNascita", clienteModel.DataNascita);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DataNascita", DBNull.Value);
                    }


                    if (!string.IsNullOrWhiteSpace(clienteModel.Sesso) && (clienteModel.Sesso.ToUpper().Equals("M") || clienteModel.Sesso.ToUpper().Equals("F")))
                    {
                        cmd.Parameters.AddWithValue("@Sesso", clienteModel.Sesso.ToUpper());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Sesso", DBNull.Value);
                    }


                    if (!string.IsNullOrWhiteSpace(clienteModel.Indirizzo))
                    {
                        cmd.Parameters.AddWithValue("@Indirizzo", clienteModel.Indirizzo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Indirizzo", DBNull.Value);
                    }


                    if (!string.IsNullOrWhiteSpace(clienteModel.Citta))
                    {
                        cmd.Parameters.AddWithValue("@Citta", clienteModel.Citta);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Citta", DBNull.Value);
                    }


                    if (!string.IsNullOrWhiteSpace(clienteModel.Cap))
                    {
                        cmd.Parameters.AddWithValue("@Cap", clienteModel.Cap);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Cap", DBNull.Value);
                    }


                    if (!string.IsNullOrWhiteSpace(clienteModel.Email))
                    {
                        cmd.Parameters.AddWithValue("@Email", clienteModel.Email);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                    }


                    if (!string.IsNullOrWhiteSpace(clienteModel.Telefono))
                    {
                        cmd.Parameters.AddWithValue("@Telefono", clienteModel.Telefono);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Telefono", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@IdTipoStatus", 13);
                    cmd.Parameters.AddWithValue("@DataInserimento", DateTime.Now);
                    cmd.Parameters.AddWithValue("@DataModifica", DateTime.Now);

                    object value = cmd.ExecuteScalar();
                    if (value != DBNull.Value && value != null)
                    {
                        idInserito = Convert.ToInt32(value);
                        clienteModel.Id = idInserito.Value;
                    }
                }
            }

            return idInserito;
        }



    }
}
