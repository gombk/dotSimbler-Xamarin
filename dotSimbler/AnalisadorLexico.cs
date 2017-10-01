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
using System.Text.RegularExpressions;

namespace dotSimbler
{
    public class AnalisadorLexico
    {
        private static List<string> comandos = new List<string>() { "ADD", "SUB", "MUL", "DIV", "INC", "DEC", "STORE" };

        public Resposta verificaComando(string[] verificar)
        {
            Resposta r = new Resposta();
            Regex rg = new Regex(@"([H-Z])");
            r.executa = true;

            if (!comandos.Contains(verificar[0].ToUpper()))
            {
                r.executa = false;
                r.erro += "O comando " + verificar[0] + " é inválido.\n";
                return r;
            }

            if (!verificar[1].ToUpper().Equals("AX") || !verificar[1].ToUpper().Equals("BX") || !verificar[1].ToUpper().Equals("CX") || !verificar[1].ToUpper().Equals("DX"))
            {
                if (rg.IsMatch(verificar[1]) || verificar[1].Length > 2)
                {
                    r.executa = false;
                    r.erro += "O operando " + verificar[1] + "é inválido.\n";
                    return r;
                }
            }

            return r;
        }
    }
}