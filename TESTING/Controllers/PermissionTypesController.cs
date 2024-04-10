using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TESTING.Conecct;
using TESTING.Models;


namespace TESTING.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        public async Task<List<PermissionTypes>> Get() =>
            await db.PermissionTypes.ToListAsync();

        [HttpGet("{id}")]
        public async Task<PermissionTypes?> Get(int id) =>
            await db.PermissionTypes.FindAsync(id);


        [HttpPost]
        public async Task<bool> Post([FromBody] PermissionTypes value)
        {
            try
            {
                await db.PermissionTypes.AddAsync(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] PermissionTypes value)
        {
            var entity = await db.PermissionTypes.FindAsync(id);
            if (entity != null)
            {
                try
                {
                    entity.Description = value.Description;
                    db.PermissionTypes.Update(entity);
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
            var entity = await db.PermissionTypes.FindAsync(id);
            if (entity != null)
            {
                try
                {
                    db.PermissionTypes.Remove(entity);
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
