namespace Task10_Mini_Microservice.server.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string? Exception { get; set; }
        public DateTime Timestamp { get; set; }
    }
}