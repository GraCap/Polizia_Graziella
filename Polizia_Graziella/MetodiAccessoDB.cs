using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


//creazione agente restituisce oggetto
namespace Polizia_Graziella
{
    class MetodiAccessoDB
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionPolizia"].ConnectionString;
        public static List<Agente> ElencoAgenti()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("Select * from AgentiDiPolizia", connection))
            {
                connection.Open();
                SqlDataReader readerRecord = cmd.ExecuteReader();

                List<Agente> Agenti = new List<Agente>();

                while (readerRecord.Read())
                    Agenti.Add(new Agente(readerRecord["Nome"].ToString(), readerRecord["Cognome"].ToString(), readerRecord["CF"].ToString(),
                                          (DateTime)readerRecord["DataNascita"], (int)readerRecord["AnniDiServizio"]));

                connection.Close();
               
                return Agenti;
            }
        }

        public static List<Agente> ElencoAgentiPerArea(int codiceArea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("AgentiPerArea", connection))    //richiamo la stored procedure
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codiceArea", codiceArea);
                List<Agente> Agenti = new List<Agente>();

                connection.Open();
                SqlDataReader readerRecord = cmd.ExecuteReader();

                while(readerRecord.Read())
                    Agenti.Add(new Agente(readerRecord["Nome"].ToString(), readerRecord["Cognome"].ToString(), readerRecord["CF"].ToString(),
                                          (DateTime)readerRecord["DataNascita"], (int)readerRecord["AnniDiServizio"]));
              
                connection.Close();

                return Agenti;
            }
        }


        //Nel vecchio DB non era presente la stored procedure
        /*  CREATE PROCEDURE AgentiPerAnniDiServizio
	                @anniDiServizio int
                AS
                BEGIN
	
	                SELECT AgentiDiPolizia.Nome, AgentiDiPolizia.Cognome, AgentiDiPolizia.CF, AgentiDiPolizia.DataNascita, 
                            AgentiDiPolizia.AnniDiServizio
	                FROM     AgentiDiPolizia
	                WHERE AgentiDiPolizia.AnniDiServizio <= @anniDiServizio
	                GROUP BY AgentiDiPolizia.Nome, AgentiDiPolizia.Cognome, AgentiDiPolizia.CF, 
                            AgentiDiPolizia.DataNascita, AgentiDiPolizia.AnniDiServizio
                END
         */
        public static List<Agente> AgentiPerAnniDiServizio(int anni)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("AgentiPerAnniDiServizio", connection))    //richiamo la stored procedure
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@anniDiServizio", anni);
                List<Agente> Agenti = new List<Agente>();

                connection.Open();
                SqlDataReader readerRecord = cmd.ExecuteReader();

                while (readerRecord.Read())
                    Agenti.Add(new Agente(readerRecord["Nome"].ToString(), readerRecord["Cognome"].ToString(), readerRecord["CF"].ToString(),
                                          (DateTime)readerRecord["DataNascita"], (int)readerRecord["AnniDiServizio"]));

                connection.Close();

                return Agenti;
            }
        }

        public static void RegistraNuovoAgente(string nome, string cognome, string cf, DateTime dataNascita, int anniDiServizio)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("Select AgentiDiPolizia.Nome, AgentiDiPolizia.Cognome, " +
                                                            "AgentiDiPolizia.CF, AgentiDiPolizia.DataNascita, " +
                                                            "AgentiDiPolizia.AnniDiServizio from AgentiDiPolizia", 
                                                            connectionString))
            {
                da.Fill(ds, "AgentiDiPolizia");
                DataTable tabellaAgenti = ds.Tables["AgentiDiPolizia"];

                //aggiunge il record nella tabella agenti di polizia
                tabellaAgenti.Rows.Add(nome, cognome, cf, dataNascita, anniDiServizio); 
               
                new SqlCommandBuilder(da);
                
              
                    connection.Open();     
                    da.Update(ds, "AgentiDiPolizia");
                    //SqlCommand cmd = new SqlCommand("Select @@IDENTITY", connection);
                    //int id = (int)(decimal)cmd.ExecuteScalar(); //genera eccezione Unable to covert systemobj to systemint32
                    //non riesco a recuperare id dell'ultimo record inserito
                    connection.Close();


                //uso id per recuperare agente appena inserito e magari mostrarlo a video per feedback utente di avvenuta registrazione
                //public static Agente RegistraNuovoAgente();
            }
        }
    }
}
