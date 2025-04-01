using System.ComponentModel.DataAnnotations;

namespace CompanyBack;

public class Area
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Departamento é obrigatório.")]
    public string Departamento { get; set; }

    [Required(ErrorMessage = "O campo Setor é obrigatório.")]
    public string Setor { get; set; }

    public List<Process> Processos { get; set; } = new List<Process>();
}
