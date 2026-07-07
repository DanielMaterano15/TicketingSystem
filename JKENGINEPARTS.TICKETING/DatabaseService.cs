using System;
using System.Collections.Generic;
using Npgsql;
using JKENGINEPARTS.TICKETING.Models;

namespace JKENGINEPARTS.TICKETING
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Host=db.zruiaflceoyvcfnnujjp.supabase.co;" +
                                                    "Port=5432;" + 
                                                    "Database=postgres;" + 
                                                    "Username=postgres;" + 
                                                    "Password=C59VrAGER0kwLa2K;" + 
                                                    "SSL Mode=Require;" + 
                                                    "Trust Server Certificate=true";

        public List<Ticket> ObtenerTickets()
        {
            var lista = new List<Ticket>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT id, taller_nombre, vehiculo_info, status FROM ticekts ORDER BY "
            }
        }
    }

}