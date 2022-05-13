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
        public async Task<ActionResult<Album>> CreateAlbum(AlbumForm album) => Ok(await _albumService.CreateAsync(album));


        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumEntity>> GetAlbumById(int id) => Ok(await _albumService.GetByIdAsync(id));


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumDto>>> GetAllAlbums() => Ok(await _albumService.GetAllAsync());


        [HttpPut("{id}")]
        public async Task<ActionResult<AlbumDto>> UpdateAlbum(int id, AlbumForm album) => Ok(await _albumService.UpdateAsync(id, album));


        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> DeleteAlbum(int id) => Ok(await _albumService.DeleteAsync(id));

    }
}
