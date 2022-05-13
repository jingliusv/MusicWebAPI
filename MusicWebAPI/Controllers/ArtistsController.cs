using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicWebAPI.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> CreateArtist(ArtistForm artist)
        {
            return Ok(await _artistService.CreateAsync(artist));        
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(int id) => Ok(await _artistService.GetByIdAsync(id));        


        [HttpGet("artist/{name}")]
        public async Task<ActionResult<Artist>> GetArtistByName(string name) => Ok(await _artistService.GetByNameAsync(name));


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDto>>> GetAllArtists() => Ok(await _artistService.GetAllAsync());


        [HttpPut("{id}")]
        public async Task<ActionResult<Artist>> UpdateArtist(int id, ArtistForm artist) => Ok(await _artistService.UpdateAsync(id, artist));


        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(int id) => Ok(await _artistService.DeleteAsync(id));

    }
}
