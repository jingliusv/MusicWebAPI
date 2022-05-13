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
        public async Task<ActionResult<Song>> CreateSong(SongForm song)
        {
            try
            {
                var createdSong = await _songService.CreateAsync(song);
                if (createdSong != null)
                    return Ok(createdSong);

                return BadRequest("Nogot gick felt. Vi kunde inte skapa den här sången. Prova igen senare!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SongDto>> GetSongById(int id)
        {
            try
            {
                var song = await _songService.GetByIdAsync(id);
                if (song != null)
                    return Ok(song);

                return NotFound("Tyvärr, vi hittar inte sången som du sökt.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetAllSongs()
        {
            try
            {
                return Ok(await _songService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Song>> UpdateSong(int id, SongForm song)
        {
            try
            {
                var updatedSong = await _songService.UpdateAsync(id, song);
                if (updatedSong != null)
                    return Ok(updatedSong);

                return BadRequest("Tyvärr, vi hittar inte sången som du uppdaderat.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Song>> DeleteSong(int id)
        {
            try
            {
                var deletedSong = await _songService.DeleteAsync(id);
                if (deletedSong != null)
                    return Ok(deletedSong);

                return NotFound("Något gick felt. Vi kunde inte ta bort den här sången.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
