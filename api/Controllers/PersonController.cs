using api.Application.DTOs;
using api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/v1/persons")]
public class PersonsController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonsController(IPersonService personService)
    {
        _personService = personService;
    }

    /// <summary>Lista todas as persons cadastradas.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PersonDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var persons = await _personService.GetAllAsync();
        return Ok(persons);
    }

    /// <summary>Busca uma person pelo ID.</summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var person = await _personService.GetByIdAsync(id);
        return person is null ? NotFound() : Ok(person);
    }

    /// <summary>Cadastra uma nova person.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] PersonDto dto)
    {
        var id = await _personService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    /// <summary>Atualiza uma person existente.</summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] PersonDto dto)
    {
        var updated = await _personService.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    /// <summary>Remove uma person (e seu cartão de vacinação).</summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _personService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
