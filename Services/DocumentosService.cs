using Microsoft.EntityFrameworkCore;

namespace CompanyBack;

public class DocumentosService
{
    private readonly ApplicationDbContext _context;

    public DocumentosService(ApplicationDbContext context)
    {
            _context = context;
    }

    //Retorna todos os documentos
    public async Task<IEnumerable<Documento>> GetAllAsync()
    {
        return await _context.Documentos.ToListAsync();
    }

    //Retorna um documento específico pelo ID
    public async Task<Documento?> GetByIdAsync(int id)
    {
        return await _context.Documentos.FindAsync(id);
    }

    //Cria um novo documento
    public async Task<Documento> CreateAsync(Documento documento)
    {
        _context.Documentos.Add(documento);
        await _context.SaveChangesAsync();
        return documento;
    }

    //Atualiza um documento existente
    public async Task<bool> UpdateAsync(Documento documento)
    {
        if (!_context.Documentos.Any(d => d.Id == documento.Id))
            return false;

        _context.Entry(documento).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    //Exclui um documento do banco de dados
    public async Task<bool> DeleteAsync(int id)
    {
        var documento = await _context.Documentos.FindAsync(id);
        if (documento == null)
            return false;

        _context.Documentos.Remove(documento);
        await _context.SaveChangesAsync();
        return true;
    }
}