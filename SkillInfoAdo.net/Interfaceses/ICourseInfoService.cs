using SkillInfoAdo.net.Models;

namespace SkillInfoAdo.net.Interfaceses
{
    public interface ICourseInfoService
    {
        public Task<bool> CourseInfoServiceInfo(List<CourseInfoModel> courseInfoModel);
    }
}
