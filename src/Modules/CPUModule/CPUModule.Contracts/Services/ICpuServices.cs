using CPUModule.Contracts.DTOs.CPU;
using CPUModule.Contracts.DTOs.CPUArchitectures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPUModule.Contracts.Services
{
    public interface ICpuServices
    {
        #region CPU Profile Operations

        #region CPU Profile Management
        /// <summary>
        /// Registers a new CPU profile in the system.
        /// </summary>
        /// <param name="registerCpu"></param>
        /// <returns></returns>
        Task<Guid> RegisterNewCpuAsync(RegisterCpuDto registerCpu);
        /// <summary>
        /// Updates an existing CPU profile in the system.
        /// </summary>
        /// <param name="updateCpu"></param>
        /// <returns></returns>
        Task<bool> UpdateCpuProfileAsync(UpdateCpuDto updateCpu);
        /// <summary>
        /// Deletes a CPU profile from the system by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteCpuProfileAsync(Guid id);
        #endregion

        #region CPU Profile Retrieval
        /// <summary>
        /// Retrieves a CPU profile by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CPUProfileDto?> GetCpuProfileByIdAsync(Guid id);
        /// <summary>
        /// Retrieves all CPU profiles in a minimal format, containing only essential information.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CPUMiniProfileDto>> GetAllCpuMinimalProfilesAsync();
        /// <summary>
        /// Retrieves a CPU profile by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<CPUProfileDto?> GetCpuProfileByNameAsync(string name);
        #endregion

        #region Enums
        /// <summary>
        /// Gets the names of all cooler types defined in the CoolerType enum.
        /// </summary>
        /// <returns><see cref="IEnumerable{string}"/></returns>
        Task<IEnumerable<string>> GetCoolerTypeNamesAsync();
        /// <summary>
        /// Gets the names of all CPU family types defined in the CpuFamilyType enum.
        /// </summary>
        /// <returns><see cref="IEnumerable{string}"/></returns>
        Task<IEnumerable<string>> GetCpuFamilyTypeNamesAsync();
        /// <summary>
        /// Gets the names of all CPU manufacturers defined in the Manufacturer enum.
        /// </summary>
        /// <returns><see cref="IEnumerable{string}"/></returns>
        Task<IEnumerable<string>> GetCpuManufacturerNamesAsync();
        /// <summary>
        /// Gets the names of all PCIe versions defined in the PCIeVersion enum.
        /// </summary>
        /// <returns><see cref="IEnumerable{string}"/></returns>
        Task<IEnumerable<string>> GetPciExpressVersionNamesAsync();
        /// <summary>
        /// Gets the names of all RAM types defined in the RamType enum.
        /// </summary>
        /// <returns><see cref="IEnumerable{string}"/></returns>
        Task<IEnumerable<string>> GetRamTypeNamesAsync();
        #endregion

        #endregion

        #region CPU Architecture Operations

        #region CPU Architecture Management
        /// <summary>
        /// Registers a new CPU architecture in the system.
        /// </summary>
        /// <param name="registerCpuArchitecture"></param>
        /// <returns></returns>
        Task<Guid> RegisterNewCpuArchitectureAsync(RegisterCpuArchitectureDto registerCpuArchitecture);
        /// <summary>
        /// Updates an existing CPU architecture in the system.
        /// </summary>
        /// <param name="updateCpuArchitecture"></param>
        /// <returns></returns>
        Task<bool> UpdateCpuArchitectureAsync(UpdateCpuArchitectureDto updateCpuArchitecture);
        /// <summary>
        /// Deletes a CPU architecture from the system by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteCpuArchitectureAsync(Guid id);
        #endregion

        #region CPU Architecture Retrieval
        /// <summary>
        /// Retrieves a CPU architecture by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CPUArchitectureDto?> GetCpuArchitectureByIdAsync(Guid id);
        /// <summary>
        /// Retrieves all CPU architectures.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CPUArchitectureDto>> GetAllCpuArchitecturesAsync();
        #endregion

        #endregion

    }
}
