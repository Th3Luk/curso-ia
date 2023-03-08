// See https://aka.ms/new-console-template for more information
using GeracaoModelo;

Console.WriteLine("Caso queria processar os valores, digite 1:");
Console.WriteLine("Caso queria processar os sinais, digite 2:");

ConsoleKeyInfo key = Console.ReadKey();
LeituraDadosTradingView leitura = new LeituraDadosTradingView();
if (key.Key == ConsoleKey.D1)    
    await leitura.LendoArquivosCSVValores();
 else if (key.Key == ConsoleKey.D2)
    await leitura.LendoArquivosCSVSinais();
else 
    Console.WriteLine("acabou");
