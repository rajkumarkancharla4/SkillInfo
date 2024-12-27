using SkillInfoAdo.net.Interfaceses;
using SkillInfoAdo.net.Models;

namespace SkillInfoAdo.net.Serviceses
{
    public class CourseInfoService:ICourseInfoService
    {
        private readonly ICourseInfoRepository _courseInfoRepository;
        public CourseInfoService(ICourseInfoRepository courseInfoRepository) 
        {
            _courseInfoRepository = courseInfoRepository;

        }

        public async Task<bool> CourseInfoServiceInfo(List<CourseInfoModel> courseInfoModel)
        {
            try
            {
                var result = await _courseInfoRepository.AddCourseInfoRepositoryInterface(courseInfoModel); 
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
