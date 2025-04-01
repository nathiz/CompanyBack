using Microsoft.AspNetCore.Mvc;

namespace CompanyBack;

[Route("api/[controller]")]
[ApiController]
public class DocumentosController : ControllerBase
{
    private readonly DocumentosService _service; // A dependência do service de Documentos

    public DocumentosController(DocumentosService service)
    {
        _service = service; // Injeção de dependência do service
    }

    // GET: api/Documentos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Documento>>> GetDocumentos()
    {
        var documentos = await _service.GetAllAsync(); // Retorna a lista de documentos
        return Ok(documentos);
    }

    // GET: api/Documentos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Documento>> GetDocumento(int id)
    {
        var documento = await _service.GetByIdAsync(id); // Busca um documento pelo id
        if (documento == null)
        {
            return NotFound(); // Retorna 404 se o documento não for encontrado
        }
        return Ok(documento); // Retorna o documento encontrado
    }

    // POST: api/Documentos
    [HttpPost]
    public async Task<ActionResult<Documento>> PostDocumento(Documento documento)
    {
        var createdDocumento = await _service.CreateAsync(documento); // Cria um novo documento
        return CreatedAtAction(nameof(GetDocumento), new { id = createdDocumento.Id }, createdDocumento); // Retorna o documento criado com o status 201
    }

    // PUT: api/Documentos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDocumento(int id, Documento documento)
    {
        if (id != documento.Id)
        {
            return BadRequest(); // Retorna 400 se os IDs não coincidirem
        }

        var updated = await _service.UpdateAsync(documento); // Atualiza o documento

        if (!updated)
        {
            return NotFound(); // Retorna 404 se o documento não for encontrado
        }

        return NoContent(); // Retorna 204 caso a atualização seja bem-sucedida
    }

    // DELETE: api/Documentos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDocumento(int id)
    {
        var deleted = await _service.DeleteAsync(id); // Deleta o documento pelo ID
        if (!deleted)
        {
            return NotFound(); // Retorna 404 se o documento não for encontrado
        }
        return NoContent(); // Retorna 204 caso a exclusão seja bem-sucedida
    }
}