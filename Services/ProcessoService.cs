using Microsoft.EntityFrameworkCore;

namespace CompanyBack;

public class ProcessoService
{
    private readonly ApplicationDbContext _context;
    
    public ProcessoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AreaExists(int areaId)
    {
        return await _context.Areas.AnyAsync(a => a.Id == areaId);
        
    }

    //Retorna todos os processos, incluindo subprocessos relacionados
    public async Task<IEnumerable<Process>> GetAllAsync()
    {
        return await _context.Processos.Include(p => p.Subprocessos).ToListAsync();
    }

    //Retorna um processo específico pelo ID
    public async Task<Process?> GetByIdAsync(int id)
    {
        return await _context.Processos.Include(p => p.Subprocessos).FirstOrDefaultAsync(p => p.Id == id);
    }

    //Cria um novo processo no banco de dados
    public async Task<Process> CreateAsync(Process process)
    {
        _context.Processos.Add(process);
        await _context.SaveChangesAsync();
        return process;
    }

    //Atualiza os dados de um processo existente
    public async Task<bool> UpdateAsync(Process process)
    {
        if (!_context.Processos.Any(p => p.Id == process.Id))
            return false;

        _context.Entry(process).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    //Exclui um processo do banco de dados
    public async Task<bool> DeleteAsync(int id)
    {
        var process = await _context.Processos.FindAsync(id);
        if (process == null)
            return false;

        _context.Processos.Remove(process);
        await _context.SaveChangesAsync();
        return true;
    }
}