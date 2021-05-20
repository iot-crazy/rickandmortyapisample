using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace Interfaces.Services
{
    public interface ICharacterService
    {
        /// <summary>
        /// Add a single character to the database
        /// </summary>
        /// <param name="character">The character to add</param>
        /// <returns></returns>
        Task AddAsync(DTO.Character character);

        /// <summary>
        /// Adds a range of characters to the database in a single transaction
        /// </summary>
        /// <param name="characters">The characters to add.</param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<DTO.Character> characters);

        /// <summary>
        /// Counts the number of characters in the database
        /// </summary>
        /// <returns>The numebr of characters in the DB.</returns>
        Task<int> CountAsync();

        /// <summary>
        /// Truncates the characters table
        /// </summary>
        /// <returns></returns>
        Task Clean();

        /// <summary>
        /// Gets all characters
        /// </summary>
        /// <returns>Task<IEnumerable<CharacterViewModel>></returns>
        Task<IEnumerable<CharacterViewModel>> GetAllAsync();

        /// <summary>
        /// Get a single character by ID
        /// </summary>
        /// <param name="ID">The ID of the required character</param>
        /// <returns>A character, if found, else null</returns>
        Task<CharacterViewModel> GetAsync(int ID);
    }
}
