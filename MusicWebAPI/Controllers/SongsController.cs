using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicWebAPI.Controllers
{
    [Route("api/songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService ?? throw new ArgumentNullException(nameof(songService));
        }

        [HttpPost]
        public async Task<ActionResult<Song>> CreateSong(SongForm song) => Ok(await _songService.CreateAsync(song));

        [HttpGet("{id}")]
        public async Task<ActionResult<SongDto>> GetSongById(int id) => Ok(await _songService.GetByIdAsync(id));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetAllSongs() => Ok(await _songService.GetAllAsync());


        [HttpPut("{id}")]
        public async Task<ActionResult<Song>> UpdateSong(int id, SongForm song) => Ok(await _songService.UpdateAsync(id, song));

        [HttpDelete("{id}")]
        public async Task<ActionResult<Song>> DeleteSong(int id) => Ok(await _songService.DeleteAsync(id));
    }
}
