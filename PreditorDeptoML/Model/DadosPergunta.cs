using Microsoft.ML.Data;

namespace PreditorDeptoML.Model;

/// <summary>
/// Classe para representar os dados da pergunta
/// </summary>
public class DadosPergunta
{
    /// <summary>
    /// Texto da pergunta
    /// </summary>
    [LoadColumn(0)]
    public string TextoPergunta { get; set; } = string.Empty;

    /// <summary>
    /// Departamento associado à pergunta
    /// </summary>
    [LoadColumn(1), ColumnName("Label")]
    public string Departamento { get; set; } = string.Empty;
}
