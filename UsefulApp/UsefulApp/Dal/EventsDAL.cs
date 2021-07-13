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
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_SHOWEVENTS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listEventsModels.Add(new EventsModels
                        {
                            id_event = Convert.ToInt32(rdr[0]),
                            nameEvent = rdr[1].ToString(),
                            id_user = Convert.ToInt32(rdr[2]),
                            eventDate = Convert.ToDateTime(rdr[3])
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

        public List<EventsModels> GetListEventMonth(string eventMonth)
        {
            var listEventsModels = new List<EventsModels>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_SHOWEVENTS_MONTH", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@month", SqlDbType.NVarChar).Value = eventMonth;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listEventsModels.Add(new EventsModels
                        {
                            id_event = Convert.ToInt32(rdr[0]),
                            nameEvent = rdr[1].ToString(),
                            id_user = Convert.ToInt32(rdr[2]),
                            eventDate = Convert.ToDateTime(rdr[3])
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


        public EventsModels AddEvents(string eventName, string userName)
        {
            var eventaux = new EventsModels();
            
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_add_event", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@eventName", SqlDbType.NVarChar).Value = eventName;
                    cmd.Parameters.AddWithValue("@username", SqlDbType.NVarChar).Value = userName;
                    cmd.Parameters.AddWithValue("@EventDate", SqlDbType.Date).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return eventaux;
        }


    }
}
