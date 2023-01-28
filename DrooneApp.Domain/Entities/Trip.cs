using System.Collections.Generic;
using System.Linq;

namespace DroneApp.Domain.Entities
{
    /// <summary>
    /// Trip entity class
    /// </summary>
    public class Trip
    {
		public Trip(int tripNo)
		{
			TripNo = tripNo;
			Locations = new List<LocationPackage>();
			Status = "OPEN";
		}
		public int TripNo { get; set; }
		public string Status { get; set; }
		public List<LocationPackage> Locations { get; set; }

		internal float GetWeight()
		{
			return Locations.Sum(l => l.Weight);
		}
	}
}
