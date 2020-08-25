using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "establishmentId")]
        public int EstablishmentId { get; set; }

        [JsonProperty(PropertyName = "nameEstablishment")]
        public string NameEstablishment { get; set; }

        [JsonProperty(PropertyName = "drinkPrice")]
        public double DrinkPrice { get; set; }

        [JsonProperty(PropertyName = "foodPrice")]
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
