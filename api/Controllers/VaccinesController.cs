using api.Application.DTOs;
using api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/v1/vaccines")]
public class VaccinesController : ControllerBase
{
    private readonly IVaccineService _vaccineService;

    public VaccinesController(IVaccineService vaccineService)
    {
        _vaccineService = vaccineService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VaccineDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _vaccineService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(VaccineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var vaccine = await _vaccineService.GetByIdAsync(id);
        return vaccine is null ? NotFound() : Ok(vaccine);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(VaccineDto dto)
    {
        var id = await _vaccineService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, VaccineDto dto)
    {
        var updated = await _vaccineService.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _vaccineService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
