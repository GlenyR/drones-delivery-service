using System;
using System.Collections.Generic;
using DroneApp.Domain.Common;
using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.Entities;

namespace DroneApp.Domain.DomainServices
{
    public class InstructionService: IInstructionService
    {

        /// <inheritdoc/>
        public (List<Drone>, List<LocationPackage>)  ParseInstruction(string input)
        {

            var drones = new List<Drone>();
            var locations = new List<LocationPackage>();

            var instructionsArrays = input.Split('\n');


            // First line has the drone list.

            var droneInstruction = instructionsArrays[0];

            var droneInstructionArray = droneInstruction.Split(',');
            var dronesCount = droneInstructionArray.Length / 2;

            if (dronesCount >= 100)
            {
                throw new Exception(StringConstants.MaxDronesAllowed);
            }
            
            for (int i = 0; i < dronesCount; i++)
            {
                var drone = new Drone(droneInstructionArray[i * 2], int.Parse(RemoveCharaters(droneInstructionArray[i * 2 + 1])));
                drones.Add(drone);
            }

            for (int i = 1; i < instructionsArrays.Length; i++)
            {
                var locationInstruction = instructionsArrays[i];

                if (locationInstruction != string.Empty)
                {
                    var locationInstructionArray = locationInstruction.Split(',');

                    var location = new LocationPackage(locationInstructionArray[0], int.Parse(RemoveCharaters(locationInstructionArray[1])));
                    locations.Add(location);
                }
            }
            return (drones, locations);
        }

        /// <inheritdoc/>
        public string RemoveCharaters(string value)
        {
            return value.Replace("[", string.Empty).Replace("]", string.Empty).Trim();
        }
    }
}
