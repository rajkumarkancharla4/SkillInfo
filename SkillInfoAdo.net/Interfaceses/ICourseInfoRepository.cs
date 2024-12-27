using SkillInfoAdo.net.Models;

namespace SkillInfoAdo.net.Interfaceses
{
    public interface ICourseInfoRepository
    {
        public Task<bool> AddCourseInfoRepositoryInterface(List<CourseInfoModel> courseInfoModel);
    }
}
