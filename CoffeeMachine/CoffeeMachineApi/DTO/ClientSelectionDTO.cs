using System;

namespace CoffeeApiMachine.DTO
{
    public class ClientChoiceDTO
    {
        public long DrinkTypeId { get; set; }

        public bool UsePersonalMug { get; set; }

        public string BadgeNumber { get; set; }

        public int SugarQty { get; set; }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }


            ClientChoiceDTO other = (ClientChoiceDTO)obj;
            return (DrinkTypeId, UsePersonalMug, BadgeNumber, SugarQty) == (other.DrinkTypeId, other.UsePersonalMug, other.BadgeNumber, other.SugarQty);
        }
    }
}
