namespace CompanyBack;

public class DetalhamentoProcesso
{
    public int Id { get; set; }
    public string FerramentasUtilizadas { get; set; }
    public string Responsaveis { get; set; }
    public string DocumentacaoAssociada { get; set; }
    public int ProcessId { get; set; }
    public Process Processo { get; set; }
}