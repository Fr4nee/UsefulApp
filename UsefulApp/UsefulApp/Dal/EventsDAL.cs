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
                    SqlCommand cmd = new SqlCommand("SP_EVENTS1_GET_LIST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listEventsModels.Add(new EventsModels
                        {
                            id_event = Convert.ToInt32(rdr[0]),
                            nameEvent = rdr[1].ToString()
                            
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
