using DroneApp.Domain.Entities;
using System.Collections.Generic;

namespace DroneApp.Domain.DomainServices.Contracts
{
    public interface IInstructionService
    {
        /// <summary>
        /// Parse input string and returns the Drones and Location Packages into an instruction object.
        /// </summary>
        /// <param name="input">Input String</param>
        /// <returns>Instruction object</returns>
        (List<Drone>, List<LocationPackage>) ParseInstruction(string input);

        /// <summary>
        /// Remove characters
        /// </summary>
        /// <param name="value">Input String</param>
        /// <returns>A clean string</returns>
        abstract string RemoveCharaters(string value);

    }
}
