using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarbecueRestApi.Data;
using BarbecueRestApi.Models;
using BarbecueRestApi.Services;
using System.IO;
using Newtonsoft.Json;

namespace BarbecueRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {

        // Utilização do Swagger para facilitar o uso das rotas desenvolvidas. https://localhost:44353/swagger/index.html

        private readonly ParticipantService _participantService;
        public ParticipantsController(ParticipantService participantService)
        {
            _participantService = participantService;
        }

        // GET: api/Participants        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipant()
        {
            return Ok(await _participantService.ListParticipants());
        }

        // Listar Convidados.
        [HttpGet("guest")]
        public async Task<ActionResult<IEnumerable<Participant>>> GetGuest()
        {
            var response = await _participantService.ListGuest();
            return response;

        }

        // Participar do Churrasco.  
        [HttpPost]
        public async Task<ActionResult<List<Participant>>> PostEstablishment([FromBody] ParticipantPostRequest request)
        {
            var response = await _participantService.InsertParticipant(request.emploee, request.guest);
            return response;
        }

        // Cancelar participação do Churrasco.
        // Cancelar participação do convidado no Churrasco.
        [HttpDelete("{id}")]
        public async Task<ActionResult<Participant>> CancelParticipant(int id)
        {
            var response = await _participantService.CancelResquest(id);
            return response;

        }

        // Total Arrecadado.
        // Total Gasto. Como não foi informado especificamente no problema a questão de gastos, somei o valor adquirido no churrasco
        [HttpGet("totalCollected")]
        public async Task<double> GetTotalSum()
        {
            var response = await _participantService.TotalCollected();
            return response;
        }

        // Total Gasto em Comida. 
        [HttpGet("totalSpendFood")]
        public async Task<double> GetTotalSpendFoodSum()
        {
            var response = await _participantService.TotalFoodSum();
            return response;
        }

        // Total Gasto em Bebida. 
        [HttpGet("totalSpendDrink")]
        public async Task<double> GetTotalSpendDrinkSum()
        {
            var response = await _participantService.TotalDrinkSum();
            return response;
        }

    }
}