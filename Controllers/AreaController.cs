using Microsoft.AspNetCore.Mvc;

namespace CompanyBack;

[Route("api/[controller]")]
[ApiController]
public class AreaController : ControllerBase
{
    private readonly AreaService _service; // A dependência do service de Área

    public AreaController(AreaService service)
    {
        _service = service; // Injeção de dependência do service
    }

    // GET: api/Area
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
    {
        return Ok(await _service.GetAllAsync()); // Retorna a lista de áreas
    }

    // GET: api/Area/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Area>> GetArea(int id)
    {
        var area = await _service.GetByIdAsync(id); // Busca uma área pelo id
        if (area == null)
        {
            return NotFound();
        }
        return Ok(area); // Retorna a área encontrada
    }

    // POST: api/Area
    [HttpPost]
    public async Task<ActionResult<Area>> PostArea(Area area)
    {
        var createdArea = await _service.CreateAsync(area); // Cria uma nova área
        return CreatedAtAction(nameof(GetArea), new { id = createdArea.Id }, createdArea);
    }

    // PUT: api/Area/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutArea(int id, Area area)
    {
        if (id != area.Id)
        {
            return BadRequest();
        }

        var updated = await _service.UpdateAsync(area); 

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Area/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArea(int id)
    {
        var deleted = await _service.DeleteAsync(id); // Deleta a área
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}