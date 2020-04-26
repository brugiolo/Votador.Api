using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Api.ViewModels;
using Votador.Business.Interfaces;
using Votador.Business.Models;

namespace Votador.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotoController : ControllerBase
    {
        private readonly IVotoRepositorio _votoRepositorio;
        private readonly IVotoService _votoService;
        private readonly IMapper _mapper;

        public VotoController(IVotoRepositorio votoRepositorio, IVotoService votoService, IMapper mapper) : base()
        {
            _votoRepositorio = votoRepositorio;
            _votoService = votoService;
            _mapper = mapper;
        }

        // GET: api/Voto
        [HttpGet]
        public async Task<IEnumerable<VotoViewModel>> Listar()
        {
            var votoViewModel = await _votoService.Listar();

            return _mapper.Map<IEnumerable<VotoViewModel>>(votoViewModel);
        }

        // GET: api/Voto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VotoViewModel>> Obter(int id)
        {
            var votoViewModel = await _votoService.Obter(id);

            if (votoViewModel == null)
                return NotFound();

            return _mapper.Map<VotoViewModel>(votoViewModel);
        }

        // POST: api/Voto
        [HttpPost]
        public async Task<ActionResult<VotoViewModel>> Incluir(VotoViewModel votoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var votoValido = await _votoRepositorio.ObterVotoValido(votoViewModel.UsuarioId, votoViewModel.RecursoId);
            if (!votoValido)
                return BadRequest("Só é possível votar uma vez em cada recurso.");

            var voto = _mapper.Map<Voto>(votoViewModel);
            await _votoService.Incluir(voto);

            return Ok(votoViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VotoViewModel>> Delete(int id)
        {
            var voto = await _votoService.Obter(id);
            var votoViewModel = _mapper.Map<VotoViewModel>(voto);

            if (votoViewModel == null) 
                return NotFound();

            await _votoService.Deletar(id);

            return Ok(votoViewModel);
        }
    }
}
