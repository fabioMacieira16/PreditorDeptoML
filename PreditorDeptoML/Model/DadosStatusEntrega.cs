using Microsoft.ML.Data;

namespace PreditorDeptoML.Model;

public class DadosStatusEntrega
{
    /// <summary>
    /// ID do Status
    /// </summary>
    [LoadColumn(0)]
    public int IDStatus { get; set; }

    /// <summary>
    /// Descrição do Status
    /// </summary>
    [LoadColumn(1)]
    public string DescricaoStatus { get; set; } = string.Empty;
}
