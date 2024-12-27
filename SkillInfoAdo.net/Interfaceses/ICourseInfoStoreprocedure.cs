using SkillInfoAdo.net.Models;

namespace SkillInfoAdo.net.Interfaceses
{
    public interface ICourseInfoStoreprocedure
    {
        public Task <bool> courseinfowithstoreprocedure(List<CourseInfoModel> courseInfoModel);
    }
}
