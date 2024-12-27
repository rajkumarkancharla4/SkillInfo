using SkillInfoAdo.net.Interfaceses;
using SkillInfoAdo.net.Models;
using System.Reflection.Metadata.Ecma335;

namespace SkillInfoAdo.net.Serviceses
{
    public class CourseinfoStroreproceService : ICourseInfoStoreprocedure
    {
        private readonly ICourseInfoStoreprocedureRepository _courseInfoStoreprocedureRepository;
        public CourseinfoStroreproceService(ICourseInfoStoreprocedureRepository courseInfoStoreprocedureRepository)
        {
            _courseInfoStoreprocedureRepository = courseInfoStoreprocedureRepository;
        }

        public async Task<bool> courseinfowithstoreprocedure(List<CourseInfoModel> courseInfoModel)
        {
            try
            {
                var result = await _courseInfoStoreprocedureRepository.Courseinfostoreprocedure(courseInfoModel);
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
       
    }
    
}
