﻿using Microsoft.AspNetCore.Http;
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
            try
            {
                var artistCreated = await _artistService.CreateAsync(artist);
                if (artistCreated != null)
                    return Ok(artistCreated);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(int id)
        {
            try
            {
                var artistFound = await _artistService.GetByIdAsync(id);
                if (artistFound != null)
                    return Ok(artistFound);

                return NotFound("Tyvärr, vi hittar inte artisten som du sökt.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("artist/{name}")]
        public async Task<ActionResult<Artist>> GetArtistByName(string name)
        {
            try
            {
                var artistFound = await _artistService.GetByNameAsync(name);
                if (artistFound != null)
                    return Ok(artistFound);

                return NotFound("Tyvärr, vi hittar inte artisten som du sökt.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDto>>> GetAllArtists()
        {
            try
            {
                return Ok(await _artistService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Artist>> UpdateArtist(int id, ArtistForm artist)
        {
            try
            {
                var updatedArtist = await _artistService.UpdateAsync(id, artist);
                if (updatedArtist != null)
                    return Ok(updatedArtist);

                return NotFound("Tyvärr, vi hittar inte artisten som du vill uppdatera.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(int id)
        {
            try
            {
                var deletedArtist = await _artistService.DeleteAsync(id);
                if (deletedArtist != null)
                    return Ok(deletedArtist);

                return NotFound("Tyvärr, vi hittar inte artisten som du vill ta bort.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
