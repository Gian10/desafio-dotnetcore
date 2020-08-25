using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BarbecueRestApi.Models
{
    public class Participant
    {
        [JsonProperty(PropertyName = "participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty(PropertyName = "nameParticipant")]
        public string NameParticipant { get; set; }

        [JsonProperty(PropertyName = "goingToEat")]
        public Boolean GoingToEat { get; set; }

        [JsonProperty(PropertyName = "goingToDrink")]
        public Boolean GoingToDrink { get; set; }

        [JsonProperty(PropertyName = "isGuest")]
        public Boolean IsGuest { get; set; }

        [JsonProperty(PropertyName = "participantReferenceId")]
        public int? ParticipantReferenceId { get; set; }

        [JsonProperty(PropertyName = "canceled")]
        public Boolean Canceled { get; set; }

        [JsonProperty(PropertyName = "establishmentId")]
        public int EstablishmentId { get; set; }

        [JsonProperty(PropertyName = "drinkPrice")]
        public double DrinkPrice { get; set; }

        [JsonProperty(PropertyName = "foodPrice")]
        public double FoodPrice { get; set; }

        [JsonProperty(PropertyName = "establishment")]
        public Establishment Establishment { get; set; }

        public Participant(int participantId, string nameParticipant, bool goingToEat, bool goingToDrink, bool isGuest, int? participantReferenceId, bool canceled, int establishmentId, double drinkPrice, double foodPrice)
        {
            ParticipantId = participantId;
            NameParticipant = nameParticipant;
            GoingToEat = goingToEat;
            GoingToDrink = goingToDrink;
            IsGuest = isGuest;
            ParticipantReferenceId = participantReferenceId;
            Canceled = canceled;
            EstablishmentId = establishmentId;
            DrinkPrice = drinkPrice;
            FoodPrice = foodPrice;
        }
    }
}
