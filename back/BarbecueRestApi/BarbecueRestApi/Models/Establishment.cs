using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BarbecueRestApi.Models
{
    public class Establishment
    {
        public int EstablishmentId { get; set; }

        public string NameEstablishment { get; set; }

        public double DrinkPrice { get; set; }

        public double FoodPrice { get; set; }

        public Establishment(int establishmentId, string nameEstablishment, double drinkPrice, double foodPrice)
        {
            EstablishmentId = establishmentId;
            NameEstablishment = nameEstablishment;
            DrinkPrice = drinkPrice;
            FoodPrice = foodPrice;
        }
    }


}
