using MotherboardModule.Contracts.DTOs;
using System;
using System.Collections.Generic;

namespace MotherboardModule.Contracts.Services
{
    public interface IMotherboardServices
    {
        #region Motherboard Profile Management
        /// <summary>
        /// Registers a new motherboard profile in the system.
        /// </summary>
        /// <param name="registerMotherboard"></param>
        /// <returns></returns>
        Task<Guid> RegisterNewMotherboardAsync(RegisterMotherboardDto registerMotherboard);
        #endregion

        #region Motherboard Profile Retrieval
        /// <summary>
        /// Retrieves a motherboard profile by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MotherboardProfileDto?> GetMotherboardProfileByIdAsync(Guid id);
        /// <summary>
        /// Retrieves all motherboard profiles.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MotherboardProfileDto>> GetAllMotherboardProfilesAsync();
        /// <summary>
        /// Retrieves a motherboard profile by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<MotherboardProfileDto?> GetMotherboardProfileByNameAsync(string name);
        #endregion

        #region Enums
        /// <summary>
        /// Gets the names of all motherboard manufacturers defined in the Manufacturer enum.
        /// </summary>
        /// <returns><see cref="IEnumerable{string}"/></returns>
        Task<IEnumerable<string>> GetMotherboardManufacturerNamesAsync();
        /// <summary>
        /// Gets the names of all chipset manufacturers defined in the ChipsetManufacturer enum.
        /// </summary>
        /// <returns><see cref="IEnumerable{string}"/></returns>
        Task<IEnumerable<string>> GetChipsetManufacturerNamesAsync();
        #endregion

        #region Chipset Profile Management
        /// <summary>
        /// Registers a new chipset profile in the system.
        /// </summary>
        /// <param name="registerChipset"></param>
        /// <returns></returns>
        Task<Guid> RegisterNewChipsetAsync(RegisterChipsetDto registerChipset);
        /// <summary>
        /// Updates an existing chipset profile in the system.
        /// </summary>
        /// <param name="updateChipset"></param>
        /// <returns></returns>
        Task<bool> UpdateChipsetProfileAsync(UpdateChipsetDto updateChipset);
        /// <summary>
        /// Deletes a chipset profile from the system by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteChipsetProfileAsync(Guid id);
        #endregion

        #region Chipset Profile Retrieval
        /// <summary>
        /// Retrieves a chipset profile by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ChipsetProfileDto?> GetChipsetProfileByIdAsync(Guid id);
        /// <summary>
        /// Retrieves all chipset profiles.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ChipsetProfileDto>> GetAllChipsetProfilesAsync();
        /// <summary>
        /// Retrieves a chipset profile by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ChipsetProfileDto?> GetChipsetProfileByNameAsync(string name);
        #endregion
    }
}
