namespace Data.Model
{
    public class Badge
    {
        public long Id { get; set; }
    
        public string BadgeNumber { get; set; }

        public string Owner { get; set; }

        public ClientChoice ClientChoice { get; set; }
    }
}
