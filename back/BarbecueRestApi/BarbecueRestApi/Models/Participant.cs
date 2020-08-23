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
        public int ParticipantId { get; set; }
   
        public string NameParticipant { get; set; }

        public Boolean GoingToEat { get; set; }

        public Boolean GoingToDrink { get; set; }

        public Boolean IsGuest { get; set; }
        public int? ParticipantReferenceId { get; set; }
        public Boolean Canceled { get; set; }
        public int EstablishmentId { get; set; }
        public double DrinkPrice { get; set; }
        public double FoodPrice { get; set; }
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
