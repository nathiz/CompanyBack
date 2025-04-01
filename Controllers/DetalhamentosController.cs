using Microsoft.AspNetCore.Mvc;

namespace CompanyBack;

// Define a rota base para o controller de DetalhamentosProcessos
[Route("api/[controller]")]
[ApiController]
public class DetalhamentosController : ControllerBase
{
    private readonly DetalhamentoProcessosService _service;

    // Construtor do controller, recebe a injeção de dependência do serviço
    public DetalhamentosController(DetalhamentoProcessosService service)
    {
        _service = service;
    }

    // GET: api/Detalhamentos
    // Obtém todos os detalhamentos de processos cadastrados no sistema
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetalhamentoProcesso>>> GetDetalhamentoProcessos()
    {
        var detalhamentoProcessos = await _service.GetAllAsync();
        return Ok(detalhamentoProcessos);
    }

    // GET: api/Detalhamentos/{id}
    // Obtém um detalhamento de processo específico pelo ID informado
    [HttpGet("{id}")]
    public async Task<ActionResult<DetalhamentoProcesso>> GetDetalhamentoProcesso(int id)
    {
        var detalhamentoProcesso = await _service.GetByIdAsync(id);
        if (detalhamentoProcesso == null)
        {
            return NotFound(); // Retorna 404 se não encontrado
        }
        return Ok(detalhamentoProcesso);
    }

    // POST: api/Detalhamentos
    // Cria um novo detalhamento de processo
    [HttpPost]
    public async Task<ActionResult<DetalhamentoProcesso>> PostDetalhamentoProcesso(DetalhamentoProcesso detalhamentoProcesso)
    {
        var createdProcesso = await _service.CreateAsync(detalhamentoProcesso);
        return CreatedAtAction(nameof(GetDetalhamentoProcesso), new { id = createdProcesso.Id }, createdProcesso);
    }

    // PUT: api/Detalhamentos/{id}
    // Atualiza um detalhamento de processo existente pelo ID
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDetalhamentoProcesso(int id, DetalhamentoProcesso detalhamentoProcesso)
    {
        if (id != detalhamentoProcesso.Id)
        {
            return BadRequest(); // Retorna 400 se os IDs não coincidirem
        }

        var updated = await _service.UpdateAsync(detalhamentoProcesso);
        if (!updated)
        {
            return NotFound(); // Retorna 404 se o detalhamento não existir
        }

        return NoContent(); // Retorna 204 em caso de sucesso
    }

    // DELETE: api/Detalhamentos/{id}
    // Remove um detalhamento de processo pelo ID informado
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDetalhamentoProcesso(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound(); // Retorna 404 se o detalhamento não for encontrado
        }
        return NoContent(); // Retorna 204 se for deletado com sucesso
    }
}