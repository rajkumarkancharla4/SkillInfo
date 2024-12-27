using SkillInfoAdo.net.Models;

namespace SkillInfoAdo.net.Interfaceses
{
    public interface ICourseInfoStoreprocedureRepository
    {
        public Task <bool> Courseinfostoreprocedure(List<CourseInfoModel> courseInfoModel);
    }
}
