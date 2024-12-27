
using Microsoft.Data.SqlClient;
using SkillInfoAdo.net.Interfaceses;
using SkillInfoAdo.net.Models;
using System.Data;


namespace SkillInfoAdo.net.Repositories
{
    public class CourseInfoSeStoreprocedureRepository:ICourseInfoStoreprocedureRepository
    {
        private readonly string  _connectionString;
        public CourseInfoSeStoreprocedureRepository(IConfiguration configuration)
        {
            // Retrieve the connection string from appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async  Task <bool> Courseinfostoreprocedure(List<CourseInfoModel> courseInfoModel)
        {
            try
            {

                List<int> outputMessages = new List<int>();


                //Connection Establish here
                using (SqlConnection con = new SqlConnection(_connectionString))
                 {
                    await con.OpenAsync();

                    foreach (var list in courseInfoModel)
                    {

                        using(SqlCommand cmd =new SqlCommand("SP_Courseinfo",con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            //BindingAddress Parameters
                            cmd.Parameters.AddWithValue("@SubscriberID ", list.SubscriberID);
                            cmd.Parameters.AddWithValue("@CourseID", list.CourseID);
                            cmd.Parameters.AddWithValue("@CourseName", list.CourseName);
                            cmd.Parameters.AddWithValue("@CourseType", list.CourseType);
                            cmd.Parameters.AddWithValue("@CourseHours", list.CourseHours);
                            cmd.Parameters.AddWithValue("@ContentLevel", list.ContentLevel);
                            cmd.Parameters.AddWithValue("@SessionID", list.SessionID);
                            cmd.Parameters.AddWithValue("@CurriculumDispCat", list.CurriculumDispCat);
                            cmd.Parameters.AddWithValue("@SubscribedDateTime", list.SubscribedDateTime);
                            cmd.Parameters.AddWithValue("@Payload", list.Payload);
                            //add outputparameter
                            SqlParameter outputparam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 250)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(outputparam);
                            await cmd.ExecuteNonQueryAsync();

                            int  outputmessage =Convert.ToInt32(outputparam.Value);
                            outputMessages.Add(outputmessage);

                        }

                    }

                }

                return outputMessages.All(msg => msg == 1); 


            }
           catch(Exception ex)
            {
                throw;

            }
        }
    }
}
