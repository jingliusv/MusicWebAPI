using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicWebAPI.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService ?? throw new ArgumentNullException(nameof(albumService));
        }

        [HttpPost]
        public async Task<ActionResult<Album>> CreateAlbum(AlbumForm album)
        {
            var createdAlbum = await _albumService.CreateAsync(album);
            if(createdAlbum != null)
                return Ok(createdAlbum);

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumEntity>> GetAlbumById(int id)
        {
            var album = await _albumService.GetByIdAsync(id);
            if (album != null)
                return Ok(album);

            return NotFound("Tyvärr, vi hittar inte det albumet som du sökt.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumDto>>> GetAllAlbums()
        {
            return Ok(await _albumService.GetAllAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AlbumDto>> UpdateAlbum(int id, AlbumForm album)
        {
            var updatedAlbum = await _albumService.UpdateAsync(id, album);
            if(updatedAlbum != null)
                return Ok(updatedAlbum);

            return BadRequest("Nogot gick felt och vi kunde inte uppdatera albumet.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> DeleteAlbum(int id)
        {
            var deletedAlbum = await _albumService.DeleteAsync(id);
            if(deletedAlbum != null)
                return Ok(deletedAlbum);

            return NotFound("Tyvärr, vi kunde inte hitta albumet som du vill ta bort.");
        }
    }
}
