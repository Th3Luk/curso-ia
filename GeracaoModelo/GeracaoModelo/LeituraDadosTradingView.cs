using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeracaoModelo
{
    public class LeituraDadosTradingView
    {
        public enum Colunas
        {
            Trade = 0,
            TipoEntrada = 1,
            Valores = 2,
            Data = 3,
            Preco = 4,
            LucroMaximo = 11,
            PrejuizoMaximo = 13
        }

        public async Task LendoArquivosCSVValores()
        {
            string[] linhaCSV = await File.ReadAllLinesAsync("C://Treinamento//preco.csv");

            StringBuilder novoCSV = new StringBuilder();
            novoCSV.Append("data,ATR,RSI,VOLUME,Med 9,Med 21,med200,Valor\n");

            foreach (string linha in linhaCSV)
            {
                string[] valores = linha.ToLower().Split(",");
                if (!valores[(int)Colunas.Valores].Equals("abertura"))
                {
                    if (valores[(int)Colunas.TipoEntrada].Equals("saída de compra") || valores[(int)Colunas.TipoEntrada].Equals("saída de venda"))
                    {
                        novoCSV.Append(valores[(int)Colunas.Data] + "," +
                                valores[(int)Colunas.Valores].Replace("#", ",") + "," +
                                valores[(int)Colunas.Preco]
                                + "\n");
                    }
                }
            }
            await File.WriteAllTextAsync("C://Treinamento//precosIA.csv", novoCSV.ToString());
        }

        public async Task LendoArquivosCSVSinais()
        {
            string[] linhaCSV = await File.ReadAllLinesAsync("C://Treinamento//bandas.csv");

            StringBuilder novoCSV = new StringBuilder();
            novoCSV.Append("Tipo entrada,ATR,RSI,VOLUME,Med 9,Med 21,med200,Sucesso\n");

            foreach (string linha in linhaCSV)
            {
                string[] valores = linha.ToLower().Split(",");
                if (!string.IsNullOrEmpty(valores[(int)Colunas.LucroMaximo]))
                {
                    if (valores[(int)Colunas.TipoEntrada].Equals("entrada de compra") || valores[(int)Colunas.TipoEntrada].Equals("entrada de venda"))
                    {
                        novoCSV.Append((valores[(int)Colunas.TipoEntrada].Equals("entrada de compra") ? "LONG" : "SHORT")  + "," +
                                valores[(int)Colunas.Valores].Replace("#", ",") + "," +
                                CalcularSucesso(valores[(int)Colunas.LucroMaximo], valores[(int)Colunas.PrejuizoMaximo])
                                + "\n");
                    }
                }
            }
            await File.WriteAllTextAsync("C://Treinamento//bandasIA.csv", novoCSV.ToString());
        }

        public bool CalcularSucesso(string lucro, string prejuizo)
        {
            decimal valorLucro;
            decimal valorPrejuizo;
            var provider = new CultureInfo("en-US");
            decimal.TryParse(lucro, NumberStyles.Number, provider, out valorLucro);
            decimal.TryParse(prejuizo, NumberStyles.Number, provider, out valorPrejuizo);

            if (valorLucro >= 1m && valorPrejuizo > -2m)
                return true;
            return false;
        }

    }
}
