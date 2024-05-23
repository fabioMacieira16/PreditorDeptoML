using Microsoft.ML.Data;

namespace PreditorDeptoML.Model;
/// <summary>
/// Classe para representar a previsão do departamento
/// </summary>
public class PrevisaoDepartamento
{
    /// <summary>
    /// Departamento previsto para a pergunta
    /// </summary>
    [ColumnName("PredictedLabel")]
    public string DepartamentoPrevisto { get; set; } = string.Empty;
}