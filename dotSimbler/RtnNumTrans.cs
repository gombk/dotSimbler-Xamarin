using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace dotSimbler
{
    class RtnNumTrans
    {
        //Transforma Decimal em Binário
        public static String DecBin(int valorDec)
        {
            int resto = -1;
            StringBuilder sb = new StringBuilder();

            if (valorDec == 0)
            {
                return "0";
            }

            // enquanto o resultado da divisão por 2 for maior que 0 adiciona o resto ao início da String de retorno
            while (valorDec > 0)
            {
                resto = valorDec % 2;
                valorDec = valorDec / 2;
                sb.Insert(0, resto);
            }

            return sb.ToString();
        }

        //Transforma Decimal em Hexadecimal
        public static String DecHex(int valorDec)
        {
            char[] hexa = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            int resto = -1;
            StringBuilder sb = new StringBuilder();

            if (valorDec == 0)
            {
                return "0";
            }

            // enquanto o resultado da divisão por 16 for maior que 0 adiciona o resto ao início da String de retorno
            while (valorDec > 0)
            {
                resto = valorDec % 16;
                valorDec = valorDec / 16;
                sb.Insert(0, hexa[resto]);
            }

            return sb.ToString();
        }

        //Transforma Hexadecimal em Binario
        public static String HexaBin(String valorHexa)
        {
            int posicao = 0;
            int posicaoArrayHexa = -1;
            StringBuilder sb = new StringBuilder();
            String valorConvertidoParaBinario = null;
            char[] hexa = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

            // enquanto tem caracteres em hexa para converter
            while (posicao < valorHexa.Length)
            {
                // pega a posição do caractere no array de caracteres hexadecimais
                posicaoArrayHexa = Array.BinarySearch(hexa, valorHexa[posicao]);
                // pega o valor em decimal (correspondente à posição do caractere no array de hexadecimais) e converte para binário
                valorConvertidoParaBinario = DecBin(posicaoArrayHexa);
                /*
                *  Se o valor convertido para binário tem menos de 4 dígitos, complementa o valor convertido com '0' à esquerda até
                *  ficar com 4 dígitos, se não for o caractere mais à esquerda do valor em hexadecimal
                */
                if (valorConvertidoParaBinario.Length != 4 && posicao > 0)
                {
                    for (int i = 0; i < (4 - valorConvertidoParaBinario.Length); i++)
                    {
                        sb.Append("0");
                    }
                }

                sb.Append(valorConvertidoParaBinario);
                posicao++;
            }
            return sb.ToString();
        }

        //Transforma Hexadecimal em Decimal
        public static int HexaDec(String valorHexa)
        {
            int valor = 0;
            int posicaoCaractere = -1;
            char[] hexa = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

            // soma ao valor final o dígito binário da posição * 16 elevado ao contador da posição (começa em 0)
            for (int i = valorHexa.Length; i > 0; i--)
            {
                posicaoCaractere = Array.BinarySearch(hexa, valorHexa[i - 1]);
                valor += posicaoCaractere * Convert.ToInt32(Math.Pow(16, (valorHexa.Length - i)));
            }

            return valor;
        }

        //Transforma Binario em Decimal
        public static int BinDec(String valorBin)
        {
            int valor = 0;

            // soma ao valor final o dígito binário da posição * 2 elevado ao contador da posição (começa em 0)
            for (int i = valorBin.Length; i > 0; i--)
            {
                valor += Int32.Parse(valorBin[i - 1] + "") * Convert.ToInt32(Math.Pow(2, (valorBin.Length - i)));
            }

            return valor;
        }

        //Transforma Binario em Hexadecimal
        public static String BinHexa(String valorBin)
        {
            char[] hexa = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            StringBuilder sb = new StringBuilder();
            int posicaoInicial = 0;
            int posicaoFinal = 0;
            char caractereEncontrado = '-';

            // começa a pegar grupos de 4 dígitos da direita para a esquerda, por isso posicaoInicial e posicaoFinal ficam na posição de fim da String
            posicaoInicial = valorBin.Length;
            posicaoFinal = posicaoInicial;

            while (posicaoInicial > 0)
            {
                // pega de 4 em 4 caracteres da direita para a esquerda. Se o último grupo à esquerda tiver menos de 4 caracteres, pega os restantes (1, 2 ou 3)
                posicaoInicial = ((posicaoInicial - 4) >= 0) ? posicaoInicial - 4 : 0;

                /*
                *  Transforma o grupo de 4 caracteres em um dígito hexadecimal. Primeiro converte o grupo de 4 (ou menos) caracteres em decimal e depois pega
                *  o caractere correspondente no array de hexadecimais. Utilize o método converteBinarioParaDecimal(String) mais acima.
                */
                caractereEncontrado = hexa[BinDec(valorBin.Substring(posicaoInicial, posicaoFinal))];
                // insere no início da String de retorno
                sb.Insert(0, caractereEncontrado);

                posicaoFinal = posicaoInicial;
            }

            return sb.ToString();
        }
    }
}