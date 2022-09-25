namespace WebAPI.Models
{
    public class JsonModel
    {
        public JsonModel(string Source,
            string Port,
            string DatabaseName,
            string UserId, string Password)
        {
            this.Source = Source;
            this.Port = Port;
            this.DatabaseName = DatabaseName;
            this.UserId = UserId;
            this.Password = Password;
        }

        public JsonModel()
        {
            this.Source = String.Empty;
            this.Port = String.Empty;
            this.DatabaseName = String.Empty;
            this.UserId = String.Empty;
            this.Password = String.Empty;
        }

        public string? Source { get; set; }
        public string? Port { get; set; }
        public string? DatabaseName { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }

        public override string ToString()
        {
            return $"Source: {Source}, Port: {Port}, DatabaseName: {DatabaseName}, UserId: {UserId}, Password: {Password}";
        }
    }
}
