using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using Senai.Gerir.Api.Repositorios;

namespace Senai.Gerir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;


            

        public TarefaController()
        {
            _tarefaRepositorio = new TarefaRepositorio();
        }

               


        
        [HttpPost]
        public IActionResult Cadastrar(Tarefa tarefa)
        {
            try
            {
                _tarefaRepositorio.Cadastrar(tarefa);
                    
                return Ok(tarefa);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

       
    }
}
