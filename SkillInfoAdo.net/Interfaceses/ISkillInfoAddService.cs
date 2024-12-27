using SkillInfoAdo.net.Entities;

namespace SkillInfoAdo.net.Interfaceses
{
    public interface ISkillInfoAddService
    {
        public Task<bool> addSkillInfoService(List<SkillInfoEntity> skillInfoEntity);
    }
}
