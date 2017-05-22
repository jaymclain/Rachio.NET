namespace Rachio.NET.Service
{
    public class ScheduleZone
    {
        public string ZoneId { get; set; }
        public int ZoneNumber { get; set; }
        public int? Duration { get; set; }
        public int SortOrder { get; set; }
    }
}
