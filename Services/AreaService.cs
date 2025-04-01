using Microsoft.EntityFrameworkCore;

namespace CompanyBack;

public class AreaService
{
    private readonly ApplicationDbContext _context;
    public AreaService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Retorna todas as áreas, incluindo os processos relacionados
    public async Task<IEnumerable<Area>> GetAllAsync()
    {
        return await _context.Areas.Include(a => a.Processos).ToListAsync();
    }

    // Retorna uma área específica pelo ID
    public async Task<Area?> GetByIdAsync(int id)
    {
        return await _context.Areas.Include(a => a.Processos).FirstOrDefaultAsync(a => a.Id == id);
    }

    // Cria uma nova área no banco de dados
    public async Task<Area> CreateAsync(Area area)
    {
        _context.Areas.Add(area);
        await _context.SaveChangesAsync();
        return area;
    }

    // Atualiza os dados de uma área existente
    public async Task<bool> UpdateAsync(Area area)
    {
        if (!_context.Areas.Any(a => a.Id == area.Id))
            return false;

        _context.Entry(area).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    // Exclui uma área do banco de dados
    public async Task<bool> DeleteAsync(int id)
    {
        var area = await _context.Areas.FindAsync(id);
        if (area == null)
            return false;

        _context.Areas.Remove(area);
        await _context.SaveChangesAsync();
        return true;
    }
}