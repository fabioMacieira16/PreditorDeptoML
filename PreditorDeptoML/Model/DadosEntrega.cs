using Microsoft.ML.Data;

namespace PreditorDeptoML.Model;
public class DadosEntrega
{
    /// <summary>
    /// ID da Entrega
    /// </summary>
    [LoadColumn(0)]
    public int IDEntrega { get; set; }

    /// <summary>
    /// ID do Motorista associado à entrega
    /// </summary>
    [LoadColumn(1)]
    public int IDMotorista { get; set; }

    /// <summary>
    /// Destinatário da entrega
    /// </summary>
    [LoadColumn(2)]
    public string Destinatario { get; set; } = string.Empty;

    /// <summary>
    /// Endereço de entrega
    /// </summary>
    [LoadColumn(3)]
    public string EnderecoEntrega { get; set; } = string.Empty;

    /// <summary>
    /// Data de entrega prevista
    /// </summary>
    [LoadColumn(4)]
    public DateTime DataEntregaPrevista { get; set; }

    /// <summary>
    /// ID do Status associado à entrega
    /// </summary>
    [LoadColumn(5)]
    public int IDStatus { get; set; }
}