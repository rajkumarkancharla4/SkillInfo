using SkillInfoAdo.net.Entities;
using SkillInfoAdo.net.Interfaceses;

namespace SkillInfoAdo.net.Serviceses
{
    public class SkillInfoService : ISkillInfoAddService
    {
        private readonly ISkillInfoAddRepository _skillInfoAddRepository;
        public SkillInfoService(ISkillInfoAddRepository skillInfoAddRepository)
        {
            _skillInfoAddRepository = skillInfoAddRepository;
        }
        public async Task<bool> addSkillInfoService(List<SkillInfoEntity> skillInfoEntity)
        {
            try
            {
                var result = await _skillInfoAddRepository.AddSkillInfo(skillInfoEntity);
                return result;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
