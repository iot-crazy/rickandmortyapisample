using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: api/<Characters>
        [HttpGet]
        public async Task<IEnumerable<CharacterViewModel>> Get()
        {
            return await _characterService.GetAllAsync();
        }

        // GET api/<Characters>/5
        [HttpGet("{id}")]
        public async Task<CharacterViewModel> Get(int id)
        {
            return await _characterService.GetAsync(id);
        }

        // POST api/<Characters>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Characters>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Characters>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
