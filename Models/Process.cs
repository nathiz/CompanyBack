namespace CompanyBack;

public class Process
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int AreaId { get; set; }
    public Area Area { get; set; }
    public List<SubProcess> Subprocessos { get; set; } = new List<SubProcess>();
    public List<Ferramenta> Ferramentas { get; set; } = new List<Ferramenta>();
    public List<Responsavel> Responsaveis { get; set; } = new List<Responsavel>();
    public List<Documento> Documentos { get; set; } = new List<Documento>();
}