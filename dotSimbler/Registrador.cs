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
    class Registrador
    {
        private String AX = "00000000";
        private String BX = "00000000";
        private String CX = "00000000";
        private String DX = "00000000";

        //Retorna o valor de AX
        public String GetAX()
        {
            return AX;
        }

        //Guarda o valor em AX
        public void SetAX(String AX)
        {
            AX = CompletaReg(AX);
            this.AX = AX;
        }

        //Retorna o valor de BX
        public String GetBX() { return BX; }
        //Guarda Valor de BX
        public void SetBX(String BX)
        {
            BX = CompletaReg(BX);
            this.BX = BX;
        }

        //Retorna o valor de CX
        public String GetCX()
        {
            return CX;
        }
        //Guarda o valor de CX
        public void SetCX(String CX)
        {
            CX = CompletaReg(CX);
            this.CX = CX;
        }

        //Retorna valor de DX
        public String GetDX() { return DX; }
        //Guarda o valor de DX
        public void SetDX(String DX)
        {
            DX = CompletaReg(DX);
            this.DX = DX;
        }

        //Ajusta a quantidade de bits para 8
        public string CompletaReg(string vl)
        {
            if (vl.Length == 8)
                return vl;
            string ret = "00000000";
            ret = ret.Substring(0, ret.Length - vl.Length) + vl;
            return ret;
        }

        public static explicit operator Registrador(string v)
        {

            return new Registrador { };
        }
    }
}