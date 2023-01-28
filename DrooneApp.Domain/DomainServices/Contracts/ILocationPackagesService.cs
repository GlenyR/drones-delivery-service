using System.Collections.Generic;
using DroneApp.Domain.Entities;

namespace DroneApp.Domain.DomainServices.Contracts
{
    public interface ILocationPackagesService
    {
		void SetPackages(List<LocationPackage> packages);
        
		/// <summary>
		/// Get and Set packages list
		/// </summary>
		/// <returns>Packages</returns>
		List<LocationPackage> Packages { get; set; }

		/// <summary>
		/// Get a package that fit the available capacity.
		/// </summary>
		/// <returns>Packages</returns>
		List<LocationPackage> GetNextPackage(int tripAvailableWeight);

        /// <summary>
        /// Get left packages weight
        /// </summary>
        /// <returns>weight</returns>
        int PackagesWeight { get; set; }
	}
}
