using Microsoft.EntityFrameworkCore;

namespace CompanyBack;

public class DetalhamentoProcessosService
{
    private readonly ApplicationDbContext _context;

    public DetalhamentoProcessosService(ApplicationDbContext context)
    {
        _context = context;
    }

    //Retorna todos os detalhamentos de processos
    public async Task<IEnumerable<DetalhamentoProcesso>> GetAllAsync()
    {
        return await _context.DetalhamentoProcessos.ToListAsync();
    }

    //Retorna um detalhamento de processo específico pelo ID
    public async Task<DetalhamentoProcesso?> GetByIdAsync(int id)
    {
        return await _context.DetalhamentoProcessos.FindAsync(id);
    }

    //Cria um novo detalhamento de processo
    public async Task<DetalhamentoProcesso> CreateAsync(DetalhamentoProcesso detalhamentoProcesso)
    {
        _context.DetalhamentoProcessos.Add(detalhamentoProcesso);
        await _context.SaveChangesAsync();
        return detalhamentoProcesso;
    }

    //Atualiza um detalhamento de processo existente
    public async Task<bool> UpdateAsync(DetalhamentoProcesso detalhamentoProcesso)
    {
        if (!_context.DetalhamentoProcessos.Any(dp => dp.Id == detalhamentoProcesso.Id))
            return false;

        _context.Entry(detalhamentoProcesso).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    //Exclui um detalhamento de processo do banco de dados
    public async Task<bool> DeleteAsync(int id)
    {
        var detalhamentoProcesso = await _context.DetalhamentoProcessos.FindAsync(id);
        if (detalhamentoProcesso == null)
            return false;

        _context.DetalhamentoProcessos.Remove(detalhamentoProcesso);
        await _context.SaveChangesAsync();
        return true;
    }
}