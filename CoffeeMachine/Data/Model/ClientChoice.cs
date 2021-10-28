namespace Data.Model
{
    public class ClientChoice
    {
        public long Id { get; set; }

        public TypeDrink TypeDrink { get; set; }

        public bool UsePersonalMug { get; set; }

        public int SugarQty { get; set; }

        public Badge Badge { get; set; }
        public long BadgeId { get; internal set; }
    }
}
