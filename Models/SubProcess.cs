namespace CompanyBack;

public class SubProcess
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int ProcessoId { get; set; }
    public Process? Processo { get; set; }

    public List<SubProcess> SubprocessosFilhos { get; set; } = new List<SubProcess>();
    public List<Ferramenta> Ferramentas { get; set; } = new List<Ferramenta>();
    public List<Responsavel> Responsaveis { get; set; } = new List<Responsavel>();
    public List<Documento> Documentos { get; set; } = new List<Documento>();
}