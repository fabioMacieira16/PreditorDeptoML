using Microsoft.ML;
using PreditorDeptoML.Model;

/// <summary>
/// Espaço de nomes para classificação de departamento
/// </summary>
namespace ClassificadorDepartamento;

/// <summary>
/// Classe principal do programa
/// </summary>
class Programa
{
    /// <summary>
    /// Ponto de entrada principal para o aplicativo.
    /// Este aplicativo é um classificador de departamento.
    /// Ele usa Machine Learning para prever a qual departamento uma determinada pergunta deve ser direcionada.
    /// </summary>
    static void Main()
    {
        var contextoML = new MLContext();

        string diretorioProjeto = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        //string caminhoDadosPergunta = Path.Combine(diretorioProjeto, "MLTraining", "questions.csv");
        string caminhoDadosEntrega = Path.Combine(diretorioProjeto, "MLTraining", "deliveries.csv");
        string caminhoDadosStatusEntrega = Path.Combine(diretorioProjeto, "MLTraining", "delivery_statuses.csv");

        // Carregar os dados dos arquivos CSV
        //var dadosPergunta = contextoML.Data.LoadFromTextFile<DadosPergunta>(caminhoDadosPergunta, separatorChar: ',');
        var dadosEntrega = contextoML.Data.LoadFromTextFile<DadosEntrega>(caminhoDadosEntrega, separatorChar: ',');
        var dadosStatusEntrega = contextoML.Data.LoadFromTextFile<DadosStatusEntrega>(caminhoDadosStatusEntrega, separatorChar: ',');
        //var dados = contextoML.Data.LoadFromTextFile<DadosPergunta>(caminhoDados, separatorChar: ';');

        // Mesclar os dados de entrega com os status de entrega
        var dadosCompletosEntrega = contextoML.Transforms.Concatenate(dadosEntrega, "IDStatus", dadosStatusEntrega, "IDStatus");


        var pipeline = contextoML.Transforms.Text.FeaturizeText("Features", "TextoPergunta")
            .Append(contextoML.Transforms.Conversion.MapValueToKey("Label"))
            .Append(contextoML.MulticlassClassification.Trainers.SdcaNonCalibrated())
            .Append(contextoML.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        var modelo = pipeline.Fit(dadosCompletosEntrega);

        var motorPrevisao = contextoML.Model.CreatePredictionEngine<DadosPergunta, PrevisaoDepartamento>(modelo);

        Console.WriteLine("Digite sua pergunta ou digite 'SAIR' para sair.");


        while (true)
        {
            Console.Write("Pergunta: ");
            var entradaUsuario = Console.ReadLine();

            if (entradaUsuario.Equals("SAIR", StringComparison.CurrentCultureIgnoreCase))
                break;

            var exemploPergunta = new DadosPergunta { TextoPergunta = entradaUsuario };

            var resultado = motorPrevisao.Predict(exemploPergunta);

            Console.WriteLine($"A pergunta: '{exemploPergunta.TextoPergunta}' deve ser direcionada para: {resultado.DepartamentoPrevisto}");
        }
    }
}
