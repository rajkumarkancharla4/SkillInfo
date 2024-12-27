using SkillInfoAdo.net.DBContextDataDetails;
using SkillInfoAdo.net.Entities;
using SkillInfoAdo.net.Interfaceses;

namespace SkillInfoAdo.net.Repositories
{
    public class SkillInfoRepository : ISkillInfoAddRepository
    {
        private readonly DbDataDetail _dbDataDetail;
        public SkillInfoRepository(DbDataDetail dbDataDetail)
        {
            _dbDataDetail = dbDataDetail;
        }
        public async Task<bool> AddSkillInfo(List<SkillInfoEntity> skillInfoEntity)
        {
              try
                {
                    int result = 0;

                    // Filter valid skill records
                    var validSkillInfoEntities = new List<SkillInfoEntity>();
                    foreach (var record in skillInfoEntity)
                    {
                        if (IsValidSkillId(record.SkillID)) // Adjust based on SkillInfoEntity's property name
                        {
                            validSkillInfoEntities.Add(record);
                        //    Console.WriteLine($"Valid SkillId: {record.SkillID}");
                        }
                    else
                        {
                        return result > 0;
                        }
                    }

               

                if (validSkillInfoEntities.Any())
                    {
                        // Add valid records to the database
                        await _dbDataDetail.SkillInfo.AddRangeAsync(validSkillInfoEntities);
                       result = await _dbDataDetail.SaveChangesAsync();
                    return result > 0;
                   
                    }

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
        }
        private static bool IsValidSkillId(string skillId)
        {
            // Check if the skill ID starts with "800" and is numeric
            return skillId.StartsWith("800") && skillId.All(char.IsDigit) &&
           skillId != "800101101"; // Exclude this specific SkillId;
        }

    }
    }
