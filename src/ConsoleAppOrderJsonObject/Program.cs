using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;

Console.WriteLine("***** Testes com .NET 9 | Manipulando a ordem de itens com JsonObject *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

var plataformaDotNet = new JsonObject()
{
    ["descricao"] = "Plataforma .NET",
    ["anoInicial"] = 2002,
    ["pessoasChave"] = new JsonArray("Anders Hejlsberg", "Scott Hanselman", "Mads Torgersen", "Miguel de Icaza"),
    ["ferramentas"] = new JsonObject
    {
        ["microsoft"] = new JsonArray("Visual Studio 2019", "Visual Studio 2022", "Visual Studio Code"),
        ["jetBrains"] = "Rider"
    }
};

PrintJsonObjectContent(plataformaDotNet);

Console.WriteLine();
Console.WriteLine("Pressione qualquer tecla para continuar...");
Console.ReadKey();

Console.WriteLine();
Console.WriteLine("Demonstrando o uso dos metodos IndexOf e Insert com JsonObject...");
var posPessoasChave = plataformaDotNet.IndexOf("pessoasChave");
plataformaDotNet.Insert(posPessoasChave, "versaoAtual", "8.0.402");

PrintJsonObjectContent(plataformaDotNet);

static void PrintJsonObjectContent(JsonObject jsonObjectSample)
{
    Console.WriteLine();
    Console.WriteLine("Conteudo sem indentacao:");
    Console.WriteLine(jsonObjectSample.ToJsonString());

    Console.WriteLine();
    Console.WriteLine("Conteudo com indentacao:");
    Console.WriteLine(jsonObjectSample.ToJsonString(
        new JsonSerializerOptions() { WriteIndented = true }));
}