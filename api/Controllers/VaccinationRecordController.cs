using api.Application.DTOs;
using api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/v1/vaccinationRecord")]
public class VaccinationRecordController : ControllerBase
{
    private readonly IVaccinationRecordService _service;

    public VaccinationRecordController(IVaccinationRecordService service)
    {
        _service = service;
    }

    /// <summary>Lista todas as vacinações registradas.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VaccinationRecordDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    /// <summary>Lista vacinações de uma pessoa específica.</summary>
    [HttpGet("pessoa/{pessoaId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<VaccinationRecordDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByPessoaId(Guid pessoaId)
    {
        return Ok(await _service.GetByPersonIdAsync(pessoaId));
    }

    /// <summary>Busca uma vacinação pelo ID.</summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(VaccinationRecordDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var registro = await _service.GetByIdAsync(id);
        return registro is null ? NotFound() : Ok(registro);
    }

    /// <summary>Registra uma vacinação.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(VaccinationRecordDto dto)
    {
        try
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>Remove um registro de vacinação.</summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var removed = await _service.DeleteAsync(id);
        return removed ? NoContent() : NotFound();
    }
}
