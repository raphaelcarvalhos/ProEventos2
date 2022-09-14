using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos2.API.Models;

namespace ProEventos2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento(){
              EventoId = 1,
              Tema = "Angular 11 e .NET 5",
              Local = "Salvador",
              Lote = "1º Lote",
              QtdPessoas = 250,
              DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
              ImagemURL = "foto.png"
          },
          new Evento(){
              EventoId = 2,
              Tema = "Angular 11 e suas novidades",
              Local = "Simões Filho",
              Lote = "2º Lote",
              QtdPessoas = 350,
              DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
              ImagemURL = "foto1.png"
          }
          };
         public EventoController()
        {
        }

        [HttpGet]

        public IEnumerable<Evento> Get()
        {
          return _evento;
        }

        [HttpGet("{id}")]

        public IEnumerable<Evento> GetById(int id)
        {
          return _evento.Where(evento => evento.EventoId == id);
        }
    }
}
