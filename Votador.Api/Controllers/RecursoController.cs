using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Api.ViewModels;
using Votador.Business.Interfaces;
using Votador.Business.Models;

namespace Votador.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecursoController : ControllerBase
    {
        private readonly IRecursoRepositorio _recursoRepositorio;
        private readonly IRecursoService _recursoService;
        private readonly IMapper _mapper;

        public RecursoController(IRecursoRepositorio recursoRepositorio, IRecursoService recursoService, IMapper mapper) : base()
        {
            _recursoRepositorio = recursoRepositorio;
            _recursoService = recursoService;
            _mapper = mapper;
        }

        // GET: api/Recurso
        [HttpGet("resultado")]
        public async Task<IEnumerable<RecursoVotoViewModel>> Resultado()
        {
            var recursoVoto = await _recursoRepositorio.ObterRecursosMaisVotados();

            return _mapper.Map<IEnumerable<RecursoVotoViewModel>>(recursoVoto);
        }

        // GET: api/Recurso
        [HttpGet]
        public async Task<IEnumerable<RecursoViewModel>> Listar()
        {
            var recurso = await _recursoService.Listar();

            return _mapper.Map<IEnumerable<RecursoViewModel>>(recurso);
        }

        // GET: api/Recurso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecursoViewModel>> Obter(int id)
        {
            var recurso = await _recursoService.Obter(id);

            if (recurso == null)
                return NotFound();

            return _mapper.Map<RecursoViewModel>(recurso);
        }

        // POST: api/Recurso
        [HttpPost]
        public async Task<ActionResult<RecursoViewModel>> Incluir(RecursoViewModel recursoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recurso = _mapper.Map<Recurso>(recursoViewModel);

            await _recursoService.Incluir(recurso);
            recursoViewModel.Id = recurso.Id;

            return Ok(recursoViewModel);
        }

        // PUT: api/Recurso/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, RecursoViewModel recursoViewModel)
        {
            if (!ModelState.IsValid || id != recursoViewModel.Id) 
                return BadRequest();

            var recursoAtualizacao = await _recursoService.Obter(id);
            recursoAtualizacao.Titulo = recursoViewModel.Titulo;
            recursoAtualizacao.Descricao = recursoViewModel.Descricao;

            await _recursoService.Atualizar(_mapper.Map<Recurso>(recursoAtualizacao));

            return Ok(recursoViewModel);
        }

        // DELETE: api/Recurso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecursoViewModel>> Deletar(int id)
        {
            var recurso = await _recursoService.Obter(id);
            var recursoViewModel = _mapper.Map<RecursoViewModel>(recurso);

            if (recursoViewModel == null) 
                return NotFound();

            await _recursoService.Deletar(id);

            return Ok(recursoViewModel);
        }
    }
}
