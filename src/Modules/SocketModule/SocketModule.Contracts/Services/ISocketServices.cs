using SocketModule.Contracts.DTOs;
using System;
using System.Collections.Generic;

namespace SocketModule.Contracts.Services
{
    public interface ISocketServices
    {
        #region Socket Profile Management
        /// <summary>
        /// Registers a new socket profile in the system.
        /// </summary>
        /// <param name="registerSocket"></param>
        /// <returns></returns>
        Task<Guid> RegisterNewSocketAsync(RegisterSocketDto registerSocket);
        /// <summary>
        /// Updates an existing socket profile in the system.
        /// </summary>
        /// <param name="updateSocket"></param>
        /// <returns></returns>
        Task<bool> UpdateSocketProfileAsync(UpdateSocketDto updateSocket);
        /// <summary>
        /// Deletes a socket profile from the system by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteSocketProfileAsync(Guid id);
        #endregion

        #region Socket Profile Retrieval
        /// <summary>
        /// Retrieves a socket profile by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SocketProfileDto?> GetSocketProfileByIdAsync(Guid id);
        /// <summary>
        /// Retrieves all socket profiles.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SocketProfileDto>> GetAllSocketProfilesAsync();
        /// <summary>
        /// Retrieves a socket profile by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<SocketProfileDto?> GetSocketProfileByNameAsync(string name);
        #endregion

        #region Cross-Module Integration
        /// <summary>
        /// Checks whether a socket profile exists. Intended for other modules
        /// (e.g. CPU Module) to validate socket references without depending
        /// on the Socket Module's internal domain implementation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> SocketExistsAsync(Guid id);
        #endregion

        #region Enums
        /// <summary>
        /// Gets the names of all socket manufacturers defined in the Manufacturer enum.
        /// </summary>
        /// <returns><see cref="IEnumerable{string}"/></returns>
        Task<IEnumerable<string>> GetSocketManufacturerNamesAsync();
        #endregion
    }
}
