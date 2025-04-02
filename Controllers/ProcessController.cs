using Microsoft.AspNetCore.Mvc;

namespace CompanyBack;

[Route("api/[controller]")]
[ApiController]
public class ProcessoController : ControllerBase
{
    private readonly ProcessoService _processoService; // A dependência do service de Processo
    private readonly ApplicationDbContext _context;    // A dependência do contexto da base de dados

    // Construtor único com injeção de dependência
    public ProcessoController(ProcessoService processoService, ApplicationDbContext context)
    {
        _processoService = processoService;  // Injeção de dependência do service
        _context = context;                  // Injeção de dependência do contexto
    }

    // GET: api/Processo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Process>>> GetProcessos()
    {
        return Ok(await _processoService.GetAllAsync()); // Retorna a lista de processos
    }

    // GET: api/Processo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Process>> GetProcesso(int id)
    {
        var processo = await _processoService.GetByIdAsync(id); // Busca um processo pelo id
        if (processo == null)
        {
            return NotFound();
        }
        return Ok(processo); // Retorna o processo encontrado
    }

    // POST: api/Processo
    [HttpPost]
    public async Task<ActionResult<Process>> PostProcesso([FromBody] Process processo)
    {
        if (processo == null || string.IsNullOrEmpty(processo.Nome) || processo.AreaId <= 0)
        {
            return BadRequest("Nome e AreaId são obrigatórios.");
        }

        var area = await _context.Areas.FindAsync(processo.AreaId);
        if (area == null)
        {
            return BadRequest("A área especificada não existe.");
        }

        processo.Area = null; // Evita erro na inserção

        _context.Processos.Add(processo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProcesso), new { id = processo.Id }, processo);
    }

    // PUT: api/Processo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProcesso(int id, Process processo)
    {
        if (id != processo.Id)
        {
            return BadRequest();
        }
        await _processoService.UpdateAsync(processo); // Atualiza o processo
        return NoContent();
    }

    // DELETE: api/Processo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProcesso(int id)
    {
        var deleted = await _processoService.DeleteAsync(id); // Deleta o processo
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}