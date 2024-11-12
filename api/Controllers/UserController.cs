using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase{
        
        private readonly IMongoCollection<User>? _users;
        public UsersController(MongoDbService mongoDbService){
            _users = mongoDbService.Database?.GetCollection<User>("users");
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get(){
            try{
                // Console.WriteLine("Getting users...");
                return await _users?.Find(FilterDefinition<User>.Empty).ToListAsync();
            }
            catch(Exception ex){
                Console.WriteLine($"Error: {ex.Message}");
            }
            return null;
        }

        [HttpPost]

        public async Task<ActionResult<User>> Post(User user){
            await _users?.InsertOneAsync(user);
            return CreatedAtAction(nameof(Get), user);
        }
    }
}