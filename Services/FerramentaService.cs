using Microsoft.EntityFrameworkCore;

namespace CompanyBack;

public class FerramentaService
{
    private readonly ApplicationDbContext _context;

    public FerramentaService(ApplicationDbContext context)
    {
        _context = context;
    }

    //Retorna todas as ferramentas
    public async Task<IEnumerable<Ferramenta>> GetAllAsync()
    {
        return await _context.Ferramentas.ToListAsync();
    }

    //Retorna uma ferramenta específica pelo ID
    public async Task<Ferramenta?> GetByIdAsync(int id)
    {
        return await _context.Ferramentas.FindAsync(id);
    }

    //Cria uma nova ferramenta
    public async Task<Ferramenta> CreateAsync(Ferramenta ferramenta)
    {
        _context.Ferramentas.Add(ferramenta);
        await _context.SaveChangesAsync();
        return ferramenta;
    }

    //Atualiza uma ferramenta existente
    public async Task<bool> UpdateAsync(Ferramenta ferramenta)
    {
        if (!_context.Ferramentas.Any(f => f.Id == ferramenta.Id))
            return false;

        _context.Entry(ferramenta).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    //Exclui uma ferramenta do banco de dados
    public async Task<bool> DeleteAsync(int id)
    {
        var ferramenta = await _context.Ferramentas.FindAsync(id);
        if (ferramenta == null)
            return false;

        _context.Ferramentas.Remove(ferramenta);
        await _context.SaveChangesAsync();
        return true;
    }
}