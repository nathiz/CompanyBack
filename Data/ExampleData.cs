namespace CompanyBack;

public class ExampleData
{
    private readonly ApplicationDbContext _context;

    public ExampleData(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedDataAsync()
    {
        // Adiciona a Área de Pessoas
        var areaPessoas = new Area
        {
            Nome = "Pessoas",
            Departamento = "RH",
            Setor = "Recrutamento"
        };
        _context.Areas.Add(areaPessoas);
        await _context.SaveChangesAsync();  // Salva a área e garante que o Id foi gerado

        // Processo: Recrutamento e Seleção
        var processoRecrutamento = new Process
        {
            Nome = "Recrutamento e Seleção",
            Descricao = "Processo para recrutamento e seleção de candidatos.",
            AreaId = areaPessoas.Id
        };
        _context.Processos.Add(processoRecrutamento);
        await _context.SaveChangesAsync();  // Salva o processo e garante que o Id foi gerado

        // Subprocessos de Recrutamento
        var subProcess1 = new SubProcess { Nome = "Definição de perfil da vaga", ProcessId = processoRecrutamento.Id };
        var subProcess2 = new SubProcess { Nome = "Divulgação da vaga", ProcessId = processoRecrutamento.Id };
        var subProcess3 = new SubProcess { Nome = "Triagem de currículos", ProcessId = processoRecrutamento.Id };
        var subProcess4 = new SubProcess { Nome = "Entrevistas", ProcessId = processoRecrutamento.Id };
        var subProcess5 = new SubProcess { Nome = "Oferta de contratação", ProcessId = processoRecrutamento.Id };
        _context.Subprocessos.AddRange(subProcess1, subProcess2, subProcess3, subProcess4, subProcess5);
        await _context.SaveChangesAsync();  // Salva os subprocessos

        // Ferramentas
        var ferramentaTrello = new Ferramenta { Nome = "Trello", Descricao = "Gestão de candidatos", ProcessoId = processoRecrutamento.Id };
        var ferramentaNotion = new Ferramenta { Nome = "Notion", Descricao = "Armazenamento de descrições das vagas", ProcessoId = processoRecrutamento.Id };
        _context.Ferramentas.AddRange(ferramentaTrello, ferramentaNotion);

        // Responsáveis
        var responsavelEquipe = new Responsavel { Nome = "Equipe de Recrutamento", ProcessoId = processoRecrutamento.Id };
        _context.Responsaveis.Add(responsavelEquipe);

        // Documentos
        var docFluxoRecrutamento = new Documento { Nome = "Fluxo de Recrutamento", Tipo = "PDF", ProcessoId = processoRecrutamento.Id };
        _context.Documentos.Add(docFluxoRecrutamento);

        // Salvar todas as alterações de uma vez
        await _context.SaveChangesAsync();
    }
}