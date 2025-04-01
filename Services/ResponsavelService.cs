using Microsoft.EntityFrameworkCore;

namespace CompanyBack;

public class ResponsavelService
{
    private readonly ApplicationDbContext _context;

    public ResponsavelService(ApplicationDbContext context)
    {
        _context = context;
    }

    //Retorna todos os responsáveis
    public async Task<IEnumerable<Responsavel>> GetAllAsync()
    {
        return await _context.Responsaveis.ToListAsync();
    }

    //Retorna um responsável específico pelo ID
    public async Task<Responsavel?> GetByIdAsync(int id)
    {
        return await _context.Responsaveis.FindAsync(id);
    }

    //Cria um novo responsável
    public async Task<Responsavel> CreateAsync(Responsavel responsavel)
    {
        _context.Responsaveis.Add(responsavel);
        await _context.SaveChangesAsync();
        return responsavel;
    }

    //Atualiza um responsável existente
    public async Task<bool> UpdateAsync(Responsavel responsavel)
    {
        if (!_context.Responsaveis.Any(r => r.Id == responsavel.Id))
            return false;

        _context.Entry(responsavel).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    //Exclui um responsável do banco de dados
    public async Task<bool> DeleteAsync(int id)
    {
        var responsavel = await _context.Responsaveis.FindAsync(id);
        if (responsavel == null)
            return false;

        _context.Responsaveis.Remove(responsavel);
        await _context.SaveChangesAsync();
        return true;
    }
}