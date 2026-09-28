namespace Domain;

public sealed class Activity
{
    // General Information
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }
    public required string City { get; set; }
    public required string Venue { get; set; }

    // Location
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
