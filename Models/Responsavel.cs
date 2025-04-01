namespace CompanyBack;

public class Responsavel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int? ProcessoId { get; set; }
    public Process Processo { get; set; }
    public int? SubProcessId { get; set; }
    public SubProcess SubProcesso { get; set; }
}