using BarbecueRestApi.Data;
using BarbecueRestApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarbecueRestApi.Services
{
    public class ParticipantService
    {

        private readonly BarbecueRestApiContext _context;

        public ParticipantService(BarbecueRestApiContext context)
        {
            _context = context;
        }

        
        public async Task<List<Participant>> ListParticipants()
        {
            var res = _context.Participant.Where(c => c.Canceled == false).ToListAsync();
            return await res;
        }

        
        public async Task<List<Participant>> ListGuest()
        {
            var res = _context.Participant.Where(m => m.IsGuest == true & m.Canceled == false).ToListAsync();
            return await res;
        }

        
        public async Task<List<Participant>> InsertParticipant(Participant emploee, Participant guest )
        {
            var establishment = _context.Establishment.Last();
            emploee.EstablishmentId = establishment.EstablishmentId;
            emploee.DrinkPrice = establishment.DrinkPrice;
            emploee.FoodPrice = establishment.FoodPrice;

            _context.Add(emploee);
            await _context.SaveChangesAsync();
           
            if (guest != null)
            {
                var emploeeId = _context.Participant.OrderByDescending(x => x.ParticipantId).Take(1).Single();
                guest.ParticipantReferenceId = emploeeId.ParticipantId;
                guest.EstablishmentId = establishment.EstablishmentId;
                guest.DrinkPrice = establishment.DrinkPrice;
                guest.FoodPrice = establishment.FoodPrice;

                _context.Add(guest);
                await _context.SaveChangesAsync();
            } 
            var listParticipant = await _context.Participant.ToListAsync();
            return listParticipant;
        }

        
        public async Task<Participant> CancelResquest(int id)
        {
            var req = await _context.Participant.FindAsync(id);
            req.Canceled = true;
            await _context.SaveChangesAsync();
            return req;
        }

        
        public async Task<double> TotalCollected()
        {
            var sumDrink =  _context.Participant.Where(d => d.GoingToDrink == true & d.Canceled == false).Sum(a => a.DrinkPrice + 0);
            var sumFood = _context .Participant.Where(f => f.GoingToEat == true & f.Canceled == false).Sum(a => a.FoodPrice + 0);
            var totalCollected = sumDrink + sumFood;
            return totalCollected;
        }

        
        public async Task<double> TotalDrinkSum()
        {
            var sumDrink = _context.Participant.Where(d => d.GoingToDrink == true & d.Canceled == false).Sum(a => a.DrinkPrice + 0);
            return sumDrink;
        }

        
        public async Task<double> TotalFoodSum()
        {
            var sumFood = _context.Participant.Where(f => f.GoingToEat == true & f.Canceled == false).Sum(a => a.FoodPrice + 0);
            return sumFood;
        }
       




    }
}
