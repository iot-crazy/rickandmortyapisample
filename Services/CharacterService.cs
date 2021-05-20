using System.Threading.Tasks;
using Data;
using AutoMapper;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ViewModels;
using System.Linq;

namespace Services
{
    public sealed class CharacterService : ICharacterService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CharacterService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task AddAsync(DTO.Character character)
        {
            _dataContext.Characters.Add(_mapper.Map<Data.Character>(character));
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<DTO.Character> characters)
        {
            _dataContext.Characters.AddRange(_mapper.Map<IEnumerable<Data.Character>>(characters));
            await _dataContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _dataContext.Characters.CountAsync();
        }

        public async Task Clean()
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Characters");
        }

        public async Task<IEnumerable<CharacterViewModel>>GetAllAsync()
        {
            return await _mapper.ProjectTo<CharacterViewModel>(_dataContext.Characters)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CharacterViewModel> GetAsync(int ID)
        {
            return await _mapper.ProjectTo<CharacterViewModel>(_dataContext.Characters.Where(x => x.ID == ID))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

    }
}
