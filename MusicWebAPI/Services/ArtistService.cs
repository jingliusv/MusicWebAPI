using MusicWebAPI.Data;

namespace MusicWebAPI.Services
{
    public interface IArtistService
    {
        Task<Artist> CreateAsync(ArtistForm artist);
        Task<ArtistEntity> GetByNameAsync(string name);
        Task<ArtistEntity> GetByIdAsync(int id);
        Task<IEnumerable<ArtistEntity>> GetAllAsync();
        Task<Artist> UpdateAsync(int id, ArtistForm artist);
        Task<Artist> DeleteAsync(int id);
    }
    public class ArtistService : IArtistService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ArtistService(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Artist> CreateAsync(ArtistForm artist)
        {
            // kolla om artist finns
            var artistEntity = await GetByNameAsync(artist.Name);
            // om det inte finns så skapar vi en
            if(artistEntity == null)
            {
                var createArtist = _mapper.Map<ArtistEntity>(artist);
                _context.Artists.Add(createArtist);
                await _context.SaveChangesAsync();
                return _mapper.Map<Artist>(createArtist);
            }
            return null!;
        }

        public async Task<Artist> DeleteAsync(int id)
        {
            var deleteArtist = await _context.Artists.FindAsync(id);
            if(deleteArtist != null)
            {
                _context.Artists.Remove(deleteArtist);
                await _context.SaveChangesAsync();
                return _mapper.Map<Artist>(deleteArtist);
            }
            return null!;
        }

        public async Task<IEnumerable<ArtistEntity>> GetAllAsync()
        {
            return await _context.Artists.Include(a => a.Albums).ToListAsync();
        }

        public async Task<ArtistEntity> GetByIdAsync(int id)
        {           
            var artistEntity = await _context.Artists.Include(a => a.Albums).Where(a => a.Id == id).FirstOrDefaultAsync(a => a.Id == id); ;
            if (artistEntity != null)
                return artistEntity;

            return null!;
        }

        public async Task<ArtistEntity> GetByNameAsync(string name)
        {
            var artistEntity = await _context.Artists.Include(a => a.Albums).Where(a => a.Name == name).FirstOrDefaultAsync(a => a.Name.ToLower() == name.ToLower());
            if (artistEntity != null)
                return artistEntity;

            return null!;
        }

        public async Task<Artist> UpdateAsync(int id, ArtistForm artist)
        {
            var artistUpdated = await _context.Artists.FindAsync(id);
            if(artistUpdated != null)
            {
                _mapper.Map(artist, artistUpdated);
                await _context.SaveChangesAsync();
                return _mapper.Map<Artist>(artistUpdated);
            }
            return null!;
        }
    }
}
