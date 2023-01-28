namespace DroneApp.Domain.Entities
{
    /// <summary>
    /// Location entity with needed information for drone's deliveries
    /// </summary>
    public class LocationPackage
    {
		public LocationPackage(string name, int weight)
		{
			Name = name;
			Weight = weight;
		}
		public string Name { get; set; }
		public int Weight { get; set; }
	}
}
