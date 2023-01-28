using System.Collections.Generic;
using DroneApp.Domain.Entities;

namespace DroneApp.Service.IServices
{
    public interface IDeliveryService
    {
        /// <summary>
        /// Get drone deliveires based on instructions string
        /// </summary>
        /// <param name="instrunctiones">Instructions String</param>
        /// <returns>List of drones with its respectives trips</returns>
        List<Drone> GetDroneDeliveries(string instrunctiones);

        /// <summary>
        /// Get the fewest number of trips by drone based on a list of drones and locations
        /// </summary>
        /// <param name="drones">List of Drones</param>
        /// <param name="locations">List of Locations</param>
        void getTripsByDrone(List<Drone> drones, List<LocationPackage> locations);
    }
}
