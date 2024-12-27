using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillInfoAdo.net.Entities;
using SkillInfoAdo.net.Interfaceses;
using SkillInfoAdo.net.Models;

namespace SkillInfoAdo.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class courseInfoController : ControllerBase
    {

        private readonly ICourseInfoService _courseInfoService;
        private readonly ICourseInfoStoreprocedure _courseInfoStoreprocedure;
        public readonly ISkillInfoAddService _skillInfoAddService;
        public courseInfoController(ICourseInfoService courseInfoService,ICourseInfoStoreprocedure courseInfoStoreprocedure ,ISkillInfoAddService skillInfoAddService)
        {
            _courseInfoService = courseInfoService;
            _courseInfoStoreprocedure = courseInfoStoreprocedure;
            _skillInfoAddService = skillInfoAddService;
        }
        [HttpPost]
        [Route("Course")]
        public async Task<IActionResult> AddCourserDetails([FromBody] List<CourseInfoModel> courseInfoModel)
        {
            try
            {   if(courseInfoModel==null || courseInfoModel.Count>0)
                {
                    return BadRequest("insert model not valid ");
                }


                var result = await _courseInfoService.CourseInfoServiceInfo(courseInfoModel);
                if (result == null) {
                    return BadRequest(" Fail ti Insert");
                }

                return Ok(result);
            }

            catch (Exception Ex)
            {
                throw;

            }
        }
        [HttpPost]
        [Route("StoreProcedure")]
        public async Task<IActionResult> AddCourseInfoByStoreprocedures([FromBody]List<CourseInfoModel> courseInfoMdel)
        {
            try
            {
                if (courseInfoMdel == null)
                {
                    return BadRequest("Insert Model Not valid ");
                }
                var result = await _courseInfoStoreprocedure.courseinfowithstoreprocedure(courseInfoMdel);
                if (!result)
                {
                    return BadRequest("getting the error in inside sql server");
                        
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw;
            }


        }

        [HttpPost]
        [Route("SkillInfo")]
        public async Task<IActionResult> AddSkillInfo([FromBody]List<SkillInfoEntity> skillInfoEntities)
        {
            try
            {
                if(skillInfoEntities==null || skillInfoEntities.Count>0)
                {
                    BadRequest("Insert model Not correct");
                }

                var result = await _skillInfoAddService.addSkillInfoService(skillInfoEntities);
                if(!result)
                {
                    return BadRequest("Internal server  Issue");
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }
        
    }
}
