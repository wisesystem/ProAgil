using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ProAgilContext _context;

        public ValuesController(ProAgilContext context){

            _context = context;

        }   

        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<Evento>> Get()
        //public IActionResult Get()
        public async Task<IActionResult> Get()
        {
            try
            {
                //var results = _context.Eventos.ToList();
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);       
            }
            catch (System.Exception)
            {
                
                //return BadRequest(); 
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            


            //return new string[] { "value1", "value2", "WiseSystem .NET" };
            /* 
            return new Evento[] { 
                new Evento() { 
                    EventoId = 1,                    
                    Tema = "Angular e .NET Core",
                    Local = "Belo Horizonte",
                    Lote = "1 Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                } ,
                new Evento() {                     
                    EventoId = 2,                    
                    Tema = "Angular e Suas Novidades",
                    Local = "São Paulo",
                    Lote = "2 Lote",
                    QtdPessoas = 350,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                } 
            };
            */ 
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //public ActionResult<Evento> Get(int id)
        //public IActionResult Get(int id)
        public async Task<IActionResult> Get(int id)
        {
           /* return  new Evento[] { 
                new Evento() { 
                    EventoId = 1,
                    Tema = "Angular e .NET Core",
                    Local = "Belo Horizonte",
                    Lote = "1 Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                } ,
                new Evento() { 
                    EventoId = 2,
                    Tema = "Angular e Suas Novidades",
                    Local = "São Paulo",
                    Lote = "2 Lote",
                    QtdPessoas = 350,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                } 
            }.
             */
           //return _context.Eventos.FirstOrDefault(x => x.EventoId == id);

            try
            {
                //var results = _context.Eventos.ToList();
                //var results = _context.Eventos.FirstOrDefault(x => x.EventoId == id);
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(results);       
            }
            catch (System.Exception)
            {
                
                //return BadRequest(); 
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }           



        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
