using System;
using UsefulApp.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace UsefulApp.Dal
{
    class EventsDAL
    {
        private string _connectionString;
        public EventsDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }
        public List<EventsModels> GetList()
        {
            var listEventsModels = new List<EventsModels>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_Events_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listEventsModels.Add(new EventsModels
                        {
                            Id_Event = Convert.ToInt32(rdr[0]),
                            NameEvent = rdr[1].ToString()
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listEventsModels;
        }

       
    }
}
