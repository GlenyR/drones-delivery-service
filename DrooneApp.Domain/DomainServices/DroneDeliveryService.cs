using System.Collections.Generic;
using System.Linq;
using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.Entities;


namespace DroneApp.Domain.DomainServices
{
    public class DroneDeliveryService: IDroneDeliveryService
    {
		// <inheritdoc/>
		public List<Drone> Drones { get; set; }

		/// <inheritdoc/>
		public Drone GetNextDroneWithCapacity()
		{
			var drone = Drones.Where(d => d.Rank > 0).OrderBy(d => d.Rank).Take(1).First();
			return drone.Rank > 0 ? drone : null;
		}

		/// <inheritdoc/>
        public void DeliverPackages()
        {
			Drones.ForEach(d => d.Delivery());
		}
    }
}
