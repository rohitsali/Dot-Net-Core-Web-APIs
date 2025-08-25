using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace DotNetCoreWebAPIs.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);

                return Ok(companies);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        //   var result = collection
        //  .Where(...)               // 1. Filter data
        //  .GroupBy(...)             // 2. Group filtered data
        //  .Where(...)               // 3. Filter groups (optional)
        //  .Select(...)              // 4. Project result (transform data)
        //  .OrderBy(...)             // 5. Sort results
        //  .Take(...)                // 6. Take top N (pagination or limit)
        //  .ToList();                // 7. Execute query and materialize
    }
}
