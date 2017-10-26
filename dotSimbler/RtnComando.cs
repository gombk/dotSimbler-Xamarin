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
    class RtnComando
    {
        RtnNumTrans rtnNumTrans = new RtnNumTrans();
        public Registrador executa(String comando, String operando, Registrador reg)
        {
            String AX = reg.GetAX();
            String BX = reg.GetBX();
            String CX = reg.GetCX();
            String DX = reg.GetCX();

            //verifica se o Operando é valor ou Registrador, se for registrador, seta o valor no operando.
            switch (operando.ToUpper())
            {
                case "AX":
                    operando = reg.GetAX().ToString();
                    break;

                case "BX":
                    operando = reg.GetBX().ToString();
                    break;

                case "CX":
                    operando = reg.GetCX().ToString();
                    break;

                case "DX":
                    operando = reg.GetDX().ToString();
                    break;
            }

            //Executa o comando usado.
            switch (comando.ToUpper())
            {
                //Soma o operando ao Registrador AX
                case "ADD":
                    reg.SetAX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) + RtnNumTrans.BinDec(AX)));
                    break;

                //Subtrai o operando ao Registrador AX
                case "SUB":
                    reg.SetAX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) - RtnNumTrans.BinDec(AX)));
                    break;

                //Multiplica o operando ao registrador AX
                case "MUL":
                    reg.SetAX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) * RtnNumTrans.BinDec(AX)));
                    break;

                //Divide o operando ao registrador AX
                case "DIV":
                    reg.SetAX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) / RtnNumTrans.BinDec(AX)));
                    break;

                //Encerra a execução do programa
                case "HLT":
                    break;

                //Decrementa em "1" o valor do campo definido
                case "DEC":
                    if (operando.ToUpper() == "AX")
                    {
                        reg.SetAX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) - 0 - RtnNumTrans.BinDec(AX) - 1));
                    }
                    else if (operando.ToUpper() == "BX")
                    {
                        reg.SetBX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) - 0 - RtnNumTrans.BinDec(BX) - 1));
                    }
                    else if (operando.ToUpper() == "CX")
                    {
                        reg.SetCX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) - 0 - RtnNumTrans.BinDec(CX) - 1));
                    }
                    else if (operando.ToUpper() == "DX")
                    {
                        reg.SetDX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) - 0 - RtnNumTrans.BinDec(DX) - 1));
                    }
                    break;

                //Incrementa em "1" o valor do campo definido.
                case "INC":
                    if (operando.ToUpper() == "AX")
                    {
                        reg.SetAX(RtnNumTrans.DecBin(RtnNumTrans.BinDec(AX) + 1));
                    }
                    else if (operando.ToUpper() == "BX")
                    {
                        reg.SetBX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) - 0 - RtnNumTrans.BinDec(BX + 1)));
                    }
                    else if (operando.ToUpper() == "CX")
                    {
                        reg.SetCX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) - 0 - RtnNumTrans.BinDec(CX + 1)));
                    }
                    else if (operando.ToUpper() == "DX")
                    {
                        reg.SetDX(RtnNumTrans.DecBin(RtnNumTrans.HexaDec(operando) - 0 - RtnNumTrans.BinDec(DX + 1)));
                    }
                    break;

                //Efetua a operação "AND com valor atual do registrador acumulador (AX) e o valor especificado.
                case "AND":
                    string vlAND = reg.CompletaReg(RtnNumTrans.HexaBin(operando));
                    string axAND = reg.GetAX();
                    string rtAND = "";
                    for (int i = 0; i < vlAND.Length; i++)
                    {
                        if (vlAND[i].ToString() == "1" && axAND[i].ToString() == "1")
                        {
                            rtAND += "1";
                        }
                        else
                        {
                            rtAND += "0";
                        }
                    }
                    reg.SetAX(rtAND);
                    break;

                //Efetua a operação "NOT" com o valor atual do registrador acumulador (AX). 
                case "NOT":
                    string axNOT = reg.GetAX();
                    string rtNOT = "";
                    for (int i = 0; i < axNOT.Length; i++)
                    {
                        if (axNOT[i].ToString() == "1")
                        {
                            rtNOT += "0";
                        }
                        else
                        {
                            rtNOT += "1";
                        }
                    }
                    reg.SetAX(rtNOT);
                    break;

                //Efetua a operação "OU" com valor atual do registrador acumulador (AX) e o valor especificado.  
                case "OR":
                    string vlOR = reg.CompletaReg(RtnNumTrans.HexaBin(operando));
                    string axOR = reg.GetAX();
                    string rtOR = "";
                    for (int i = 0; i < vlOR.Length; i++)
                    {
                        if (vlOR[i].ToString() == "1" && axOR[i].ToString() == "1")
                        {
                            rtOR += "1";
                        }
                        else
                        {
                            rtOR += "0";
                        }
                    }
                    reg.SetAX(rtOR);
                    break;

                //Armazena o valor definido no registrador acumulador (AX) no campo especificado.
                case "STORE":
                    if (operando.ToUpper() == "AX")
                    {
                        reg.SetAX(reg.GetAX());
                        break;
                    }

                    if (operando.ToUpper() == "BX")
                    {
                        reg.SetBX(reg.GetAX());
                        break;
                    }

                    if (operando.ToUpper() == "CX")
                    {
                        reg.SetCX(reg.GetAX());
                        break;
                    }

                    if (operando.ToUpper() == "DX")
                    {
                        reg.SetDX(reg.GetAX());
                        break;
                    }

                    break;
            }

            return reg;
        }
    }
}