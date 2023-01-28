using System;
using System.Collections.Generic;
using System.Linq;
using DroneApp.Service.IServices;
using Microsoft.AspNetCore.Components;
using DroneDomain = DroneApp.Domain.Entities.Drone;

namespace DroneApp.Server.Pages
{
    public partial class Drone
    {
        [Inject]
        public IDeliveryService DeliveryService { get; set; }

        public string Instructions { get; set; }

        public string OutPut { get; set; }

        private List<DroneDomain> DroneDeliveries { get; set; } = new();

        private string Error = string.Empty;

        private void ProcessDelivery()
        {
            Error = string.Empty;
            DroneDeliveries.Clear();
            OutPut = string.Empty;
            try
            {
                DroneDeliveries = DeliveryService.GetDroneDeliveries(Instructions);

              if (DroneDeliveries != null && DroneDeliveries.Any())
                {
                    foreach (var drone in DroneDeliveries)
                    {
                        OutPut = OutPut + string.Format("{0}", drone.Name) + Environment.NewLine;
                        foreach (var trip in drone.Trips.Where(t => t.Locations.Count() > 0))
                        {
                            OutPut = OutPut +  string.Format("Trip # {0}", trip.TripNo) + Environment.NewLine;
                            foreach (var location in trip.Locations)
                            {
                                OutPut = OutPut + string.Format("{0},", location.Name);
                            }
                            OutPut = OutPut.Remove(OutPut.Length - 1) + Environment.NewLine;
                        }
                        OutPut = OutPut + Environment.NewLine;
                    }
                }
            }
            catch (Exception exception)
            {
                Error = exception.Message;
            }
        }
    }
}
