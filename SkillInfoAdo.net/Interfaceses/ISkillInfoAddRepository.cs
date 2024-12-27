using SkillInfoAdo.net.Entities;

namespace SkillInfoAdo.net.Interfaceses
{
    public interface ISkillInfoAddRepository
    {
        public Task<bool> AddSkillInfo(List<SkillInfoEntity> skillInfoEntity);
    }
}
