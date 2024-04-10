using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TESTING.Conecct;
using TESTING.KafkaWorker;
using TESTING.Models;


namespace TESTING.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private ModelContext db = new ModelContext();
        private readonly ILogger _log;
        private readonly IConfiguration _config;

        public PermissionsController(ILogger log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }


        [HttpGet]
        public async Task<List<Permissions>> Get()
        {
            await new ConsumeWorker(_log, "Get").StartAsync(CancellationToken.None);
            return await db.Permissions.ToListAsync();
        }
            
            

        [HttpGet("{id}")]
        public async Task<Permissions?> Get(int id)
        {
            await new ConsumeWorker(_log, "GetId").StartAsync(CancellationToken.None);
            return await db.Permissions.FindAsync(id);
        }
       


        [HttpPost]
        public async Task<bool> Post([FromBody] Permissions value)
        {
            try
            {
                await db.Permissions.AddAsync(value);
                await new ConsumeWorker(_log, "Create").StartAsync(CancellationToken.None);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Permissions value)
        {
            var entity = await db.Permissions.FindAsync(id);
            if (entity != null)
            {
                try
                {
                    entity.EmployeeForceName = value.EmployeeForceName;
                    entity.EmployeeSuname = value.EmployeeSuname;
                    entity.PermissonType = value.PermissonType;
                    entity.Description = value.Description;
                    db.Permissions.Update(entity);
                    await new ConsumeWorker(_log, "Modify").StartAsync(CancellationToken.None);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var entity = await db.Permissions.FindAsync(id);
            if (entity != null)
            {
                try
                {
                    db.Permissions.Remove(entity);
                    await new ConsumeWorker(_log, "Remove").StartAsync(CancellationToken.None);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
