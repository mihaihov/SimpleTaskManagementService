using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementService 
{    
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public TaskController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("gettaskbyid", Name = "GetTaskById")]
        public async Task<Task?> GetTaskById(Guid Id)
        {
            return await _dbContext.Set<Task>().FindAsync(Id);
        }

        [HttpGet("getalltasks",Name = "GetAllTasks")]
        public async Task<IReadOnlyList<Task>> GetAllTasks()
        {
                List<Task> Tasks = await _dbContext.Set<Task>().ToListAsync();
                return Tasks;
        }

        [HttpPost("savenewtask", Name ="SaveNewTask")]
        public async Task<IActionResult> SaveNewTask([FromBody]Task Task)
        {
            try
            {
                await _dbContext.Set<Task>().AddAsync(Task);
                await _dbContext.SaveChangesAsync();
                return Ok(Task);
            }
             catch (Exception ex)
             {
                return StatusCode(500, new {message = ex.Message});
             }

        }

        [HttpPut("updatetask",Name = "UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody]Task Task)
        {
            try
            {
                _dbContext.Entry(Task).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return Ok(Task);
            }

            catch(Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }

        }
    }
}