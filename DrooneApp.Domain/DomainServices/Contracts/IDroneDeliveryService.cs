using System.Collections.Generic;
using DroneApp.Domain.Entities;

namespace DroneApp.Domain.DomainServices.Contracts
{
    public interface IDroneDeliveryService
    {
        /// <summary>
        /// Get drone to fit the package
        /// </summary>
        /// <returns>Drone object</returns>
        Drone GetNextDroneWithCapacity();

        /// <summary>
        /// Get drones list
        /// </summary>
        /// <returns>Drones objects</returns>
        List<Drone> Drones { get; set; }

        /// <summary>
        /// Deliveries process
        /// </summary>
       void DeliverPackages();
    }
}
