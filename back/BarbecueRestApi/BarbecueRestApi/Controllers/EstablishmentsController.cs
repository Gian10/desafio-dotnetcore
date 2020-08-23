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

namespace BarbecueRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentsController : ControllerBase
    {

        // Utilização do Swagger para facilitar o uso das rotas desenvolvidas. https://localhost:44353/swagger/index.html

        private readonly EstablishmentService _establishmentService;

        public EstablishmentsController(EstablishmentService establishmentService)
        {
            _establishmentService = establishmentService;
        }


        // GET: api/Establishments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Establishment>>> GetEstablishment()
        {
            return Ok(await _establishmentService.ListEstablishment());
        }


        // Insereção de estabelecimento
       [HttpPost]
        public async Task<ActionResult<Establishment>> PostEstablishment([FromBody] Establishment establishment)
        {
            var response = await _establishmentService.InsertEstablishment(establishment);
            return CreatedAtAction("GetEstablishment", new { id = response.EstablishmentId }, response);
        }

    }
}