using DroneApp.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace DroneApp.Domain.Entities
{
    /// <summary>
    /// Drone entity class
    /// </summary>
    public class Drone
    {
		public Drone(string name, int capacity)
		{
			Name = name;
			Capacity = capacity;
			SetStatistics();
		}
		public string Name { get; set; }
		public int Capacity { get; set; }
		public List<Trip> Trips { get; set; } = new();
		private int TotalLoaded { get; set; }
		public int AvailableCapacity { get; set; }
		public int Rank { get; set; }

		public void AddPackages(List<LocationPackage> packages)
		{
			Rank = 0;
			if (packages.Sum(p => p.Weight) > 0)
			{
				var tripNo = GetOpenTrip();
				var openTrip = Trips.First(t => t.TripNo == tripNo);
				openTrip.Locations.AddRange(packages);
				SetStatistics();
			}
		}

		internal void SetStatistics()
		{
			var tripNo = GetOpenTrip();
			var openTrip = Trips.First(t => t.TripNo == tripNo);
			TotalLoaded = openTrip.Locations.Sum(t => t.Weight);
			AvailableCapacity = Capacity - TotalLoaded;
			Rank = AvailableCapacity > 0 ? Capacity + AvailableCapacity : 0;
		}

		public void Delivery()
		{
			var tripNo = GetOpenTrip();
			var openTrip = Trips.First(t => t.TripNo == tripNo);
            openTrip.Status = StringConstants.Delivered;
            SetStatistics();
		}

		private int GetOpenTrip()
		{
            var openTrip = Trips.FirstOrDefault(t => t.Status == StringConstants.Open);
            int tripNo = 0;
			if (openTrip == null)
			{
				var trips = Trips.Count();
				tripNo = trips + 1;
				Trips.Add(new Trip(tripNo));
			}
			else
			{
				tripNo = openTrip.TripNo;
			}

			return tripNo;
		}
	}
}
