using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;
using Service.Model;
using Service.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TesteRHEstrategiaAPI.Util;

namespace TesteRHEstrategiaAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly HttpClient client;
        private readonly PessoaService _pessoaService ;
        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
            client = new HttpClient();
        }
        [HttpGet]
        public ActionResult<IEnumerable<PessoaViewModel>> Get()

        {
            var pessoas =   _pessoaService.Get().ToList();
            if (pessoas is null)
            {
                return NotFound("Nenhuma Pessoa Encontrada");
            }
            return Ok(pessoas);
        }

        [HttpGet("{id}", Name = "detalhes")]
        public ActionResult<PessoaViewModel> Get(int id)
        {
            var pessoa = _pessoaService.GetById(id);
            if (pessoa is null)
            {
                return NotFound("Pessoa não encontrada");
            }
            return pessoa;
        }

        [HttpPost]
        public ActionResult Post([FromBody] PessoaViewModel pessoa)
        {
            _pessoaService.Add(pessoa);
            return Ok(pessoa);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PessoaViewModel pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest("Pessoa não encontrada");

            }
            _pessoaService.Update(id, pessoa);

            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public ActionResult<Pessoa> Delete(int id)
        {
            _pessoaService.Delete(id);
            return Ok(new { mensagem = "Pessoa Deletada com Sucesso" });
        }

        [HttpGet("ValidaCpf")]
        public IActionResult ValidaCpf( [FromQuery]  string cpf)
        {
           var retorno = cpf.CpfValido();

            if (retorno)
            {
                return Json(new { Valido = true });
            }
            else
            {
                return Json(new { Valido = false });
            }
        }

        [HttpGet("RetornaEndereco")]
        public async Task<IActionResult> RetornaEndereco( [FromQuery]string cep)
        {
            var response = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var retornoConsulta = JsonConvert.DeserializeObject<RetornaEndereco>(json);
                return Json(new {retorno = retornoConsulta }) ;
            }
            else
            {
                return BadRequest("Endereço não encontrado ");
            }
        }
    }
}
