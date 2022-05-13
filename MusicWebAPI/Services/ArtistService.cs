using MusicWebAPI.Data;

namespace MusicWebAPI.Services
{
    public interface IArtistService
    {
        Task<Artist> CreateAsync(ArtistForm artist);
        Task<ArtistDto> GetByNameAsync(string name);
        Task<ArtistDto> GetByIdAsync(int id);
        Task<IEnumerable<ArtistDto>> GetAllAsync();
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
            var artistEntity = await _context.Artists.FirstOrDefaultAsync(a => a.Name.ToLower() == artist.Name.ToLower());
            // om det inte finns så skapar vi en
            if(artistEntity == null)
            {
                var createArtist = _mapper.Map<ArtistEntity>(artist);
                _context.Artists.Add(createArtist);
                await _context.SaveChangesAsync();
                return _mapper.Map<Artist>(createArtist);
            }
            throw new ApplicationException("Det finns en artist som har samma namn.");
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
            throw new KeyNotFoundException("Tyvärr, vi hittar inte artisten som du vill ta bort.");
        }

        public async Task<IEnumerable<ArtistDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ArtistDto>>(await _context.Artists
                .Include(a => a.Albums)
                .ToListAsync()); 
        }

        public async Task<ArtistDto> GetByIdAsync(int id)
        {           
            var artistEntity = await _context.Artists.Include(a => a.Albums).Where(a => a.Id == id).FirstOrDefaultAsync(a => a.Id == id); ;
            if (artistEntity == null)
                throw new KeyNotFoundException($"Tyvärr, vi kunde inte hitta artisten med Id nummer {id}.");

            return _mapper.Map<ArtistDto>(artistEntity);
        }

        public async Task<ArtistDto> GetByNameAsync(string name)
        {
            var artistEntity = await _context.Artists.Include(a => a.Albums).Where(a => a.Name == name).FirstOrDefaultAsync(a => a.Name.ToLower() == name.ToLower());
            if (artistEntity == null)
                throw new KeyNotFoundException($"Tyvärr, vi kunde inte hitta artisten med namn {name}.");
         
            return _mapper.Map<ArtistDto>(artistEntity);
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
            throw new KeyNotFoundException($"Tyvärr, vi kunde inte uppdatera artisten med Id nummer {id}.");
        }
    }
}
