using Microsoft.EntityFrameworkCore;

namespace CompanyBack;

public class SubProcessService
{
    private readonly ApplicationDbContext _context;

    public SubProcessService(ApplicationDbContext context)
    {
        _context = context;
    }

    //Retorna todos os subprocessos, incluindo subprocessos filhos (se houver)
    public async Task<IEnumerable<SubProcess>> GetAllAsync()
    {
        return await _context.Subprocessos.Include(sp => sp.SubprocessosFilhos).ToListAsync();
    }

    //Retorna um subprocesso específico pelo ID
    public async Task<SubProcess?> GetByIdAsync(int id)
    {
        return await _context.Subprocessos.Include(sp => sp.SubprocessosFilhos).FirstOrDefaultAsync(sp => sp.Id == id);
    }

    //Cria um novo subprocesso no banco de dados
    public async Task<SubProcess> CreateAsync(SubProcess subProcess)
    {
        _context.Subprocessos.Add(subProcess);
        await _context.SaveChangesAsync();
        return subProcess;
    }

    //Atualiza os dados de um subprocesso existente
    public async Task<bool> UpdateAsync(SubProcess subProcess)
    {
        if (!_context.Subprocessos.Any(sp => sp.Id == subProcess.Id))
            return false;

        _context.Entry(subProcess).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    //Exclui um subprocesso do banco de dados
    public async Task<bool> DeleteAsync(int id)
    {
        var subProcess = await _context.Subprocessos.FindAsync(id);
        if (subProcess == null)
            return false;

        _context.Subprocessos.Remove(subProcess);
        await _context.SaveChangesAsync();
        return true;
    }
}