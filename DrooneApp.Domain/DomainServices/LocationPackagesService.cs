using System.Collections.Generic;
using System.Linq;
using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.Entities;


namespace DroneApp.Domain.DomainServices
{
    public class LocationPackagesService :ILocationPackagesService
	{
		public void SetPackages(List<LocationPackage> packages)
		{
			Packages = packages.OrderByDescending(p => p.Weight).ToList();
			PackagesWeight = packages.Sum(l => l.Weight);
		}

		/// <inheritdoc/>
		public List<LocationPackage> Packages { get; set; }

		/// <inheritdoc/>
		public List<LocationPackage> GetNextPackage(int tripAvailableWeight)
		{
			var packagesToReturn = Packages.OrderByDescending(p => p.Weight).ToList();

			if (tripAvailableWeight < PackagesWeight)
			{
				var packageToReturn = new List<LocationPackage>();
				foreach (var packages in packagesToReturn)
				{
					if (tripAvailableWeight >= packages.Weight)
					{
						Packages.Remove(packages);
						PackagesWeight = Packages.Sum(l => l.Weight);
						packageToReturn.Add(packages);
						break;
					}
				}
				packagesToReturn = packageToReturn;
			}
			else
			{
				Packages = new List<LocationPackage>();
			}
			PackagesWeight = Packages.Sum(l => l.Weight);
			return packagesToReturn;
		}

		/// <inheritdoc/>
		public int PackagesWeight { get; set; }
	}
}
