using Microsoft.AspNetCore.Mvc;

namespace CompanyBack;

[Route("api/[controller]")]
[ApiController]
public class SubProcessController : ControllerBase
{
    private readonly SubProcessService _service; // A dependência do service de Subprocesso

    public SubProcessController(SubProcessService service)
    {
        _service = service; // Injeção de dependência do service
    }

    // GET: api/SubProcess
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubProcess>>> GetSubprocessos()
    {
        return Ok(await _service.GetAllAsync()); // Retorna a lista de subprocessos
    }

    // GET: api/SubProcess/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SubProcess>> GetSubprocesso(int id)
    {
        var subprocesso = await _service.GetByIdAsync(id); // Busca um subprocesso pelo id
        if (subprocesso == null)
        {
            return NotFound();
        }
        return Ok(subprocesso); // Retorna o subprocesso encontrado
    }

    // POST: api/SubProcess
    [HttpPost]
    public async Task<ActionResult<SubProcess>> PostSubprocesso(SubProcess subprocesso)
    {
        var createdSubprocesso = await _service.CreateAsync(subprocesso); // Cria um novo subprocesso
        return CreatedAtAction(nameof(GetSubprocesso), new { id = createdSubprocesso.Id }, createdSubprocesso);
    }

    // PUT: api/SubProcess/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSubprocesso(int id, SubProcess subprocesso)
    {
        if (id != subprocesso.Id)
        {
            return BadRequest();
        }
        await _service.UpdateAsync(subprocesso); // Atualiza o subprocesso
        return NoContent();
    }

    // DELETE: api/SubProcess/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubprocesso(int id)
    {
        var deleted = await _service.DeleteAsync(id); // Deleta o subprocesso
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent(); // Retorna NoContent após a exclusão
    }
}