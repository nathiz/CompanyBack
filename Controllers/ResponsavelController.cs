using Microsoft.AspNetCore.Mvc;

namespace CompanyBack;

[Route("api/[controller]")]
[ApiController]
public class ResponsavelController : ControllerBase
{
    private readonly ResponsavelService _service; // Injeção do serviço

    public ResponsavelController(ResponsavelService service)
    {
        _service = service;
    }

    // GET: api/Responsavel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Responsavel>>> GetResponsaveis()
    {
        var responsaveis = await _service.GetAllAsync();
        return Ok(responsaveis);
    }

    // GET: api/Responsavel/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Responsavel>> GetResponsavel(int id)
    {
        var responsavel = await _service.GetByIdAsync(id);
        if (responsavel == null)
        {
            return NotFound();
        }
        return Ok(responsavel);
    }

    // POST: api/Responsavel
    [HttpPost]
    public async Task<ActionResult<Responsavel>> PostResponsavel(Responsavel responsavel)
    {
        var createdResponsavel = await _service.CreateAsync(responsavel);
        return CreatedAtAction(nameof(GetResponsavel), new { id = createdResponsavel.Id }, createdResponsavel);
    }

    // PUT: api/Responsavel/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutResponsavel(int id, Responsavel responsavel)
    {
        if (id != responsavel.Id)
        {
            return BadRequest();
        }

        var updated = await _service.UpdateAsync(responsavel);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Responsavel/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResponsavel(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}