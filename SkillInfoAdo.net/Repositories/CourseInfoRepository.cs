using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SkillInfoAdo.net.Interfaceses;
using SkillInfoAdo.net.Models;
using System.Data.SqlClient;
using System.Reflection;

namespace SkillInfoAdo.net.Repositories
{
    public class CourseInfoRepository : ICourseInfoRepository
    {
        private readonly string _connectionString;
        public CourseInfoRepository(IConfiguration configuration)
        {
            // Retrieve the connection string from appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<bool> AddCourseInfoRepositoryInterface(List<CourseInfoModel> courseInfoModel)
        {
            try
            {


                foreach(var data in courseInfoModel)
                {

             
                //string query = "INSERT INTO CourseInfo (SubscriberID,CourseID,CourseName,CourseType,CourseHours,ContentLevel,SessionID,CurriculumDispCat,SubscribedDateTime,Payload) VALUES (@SubscriberID,@CourseID,@CourseName,@CourseType,@CourseHours,@ContentLevel,@SessionID,@CurriculumDispCat,@SubscribedDateTime,@Payload)";

                string query = @"
    MERGE INTO learningtable AS target
    USING (VALUES (@SubscriberID, @CourseID, @CourseName, @CourseType, @CourseHours, 
                   @ContentLevel, @SessionID, @CurriculumDispCat, @SubscribedDateTime, @Payload)) 
           AS source (SubscriberID, CourseID, CourseName, CourseType, CourseHours, 
                      ContentLevel, SessionID, CurriculumDispCat, SubscribedDateTime, Payload)
        ON target.CourseID = source.CourseID
    WHEN MATCHED THEN
        UPDATE SET 
            SubscriberID = source.SubscriberID,
            CourseName = source.CourseName,
            CourseType = source.CourseType,
            CourseHours = source.CourseHours,
            ContentLevel = source.ContentLevel,
            SessionID = source.SessionID,
            CurriculumDispCat = source.CurriculumDispCat,
            SubscribedDateTime = source.SubscribedDateTime,
            Payload = source.Payload
    WHEN NOT MATCHED THEN
        INSERT (SubscriberID, CourseID, CourseName, CourseType, CourseHours, 
                ContentLevel, SessionID, CurriculumDispCat, SubscribedDateTime, Payload)
        VALUES (source.SubscriberID, source.CourseID, source.CourseName, source.CourseType, source.CourseHours, 
                source.ContentLevel, source.SessionID, source.CurriculumDispCat, source.SubscribedDateTime, source.Payload);";




                int totalRowsAffected = 0;
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    await connection.OpenAsync();

                    foreach (var model in courseInfoModel)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@SubscriberID", model.SubscriberID);
                            command.Parameters.AddWithValue("@CourseID", model.CourseID);
                            command.Parameters.AddWithValue("@CourseName", model.CourseName);
                            command.Parameters.AddWithValue("@CourseType", model.CourseType);
                            command.Parameters.AddWithValue("@CourseHours", model.CourseHours);
                            command.Parameters.AddWithValue("@ContentLevel", model.ContentLevel);
                            command.Parameters.AddWithValue("@SessionID", model.SessionID);
                            command.Parameters.AddWithValue("@CurriculumDispCat", model.CurriculumDispCat);
                            command.Parameters.AddWithValue("@SubscribedDateTime", model.SubscribedDateTime);
                            command.Parameters.AddWithValue("@Payload", model.Payload);

                            totalRowsAffected += await command.ExecuteNonQueryAsync();
                        }
                    }

                    //await connection.OpenAsync();
                    //return await command.ExecuteNonQueryAsync(); // Returns the number of rows affected                                         
                }
                return totalRowsAffected == courseInfoModel.Count;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }                                             
}
