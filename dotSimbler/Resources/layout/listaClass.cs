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

namespace dotSimbler.Resources.layout
{
    public class listaClass
    {
    public int id { get; set; }
    public string nomeComando { get; set; }
    public string desComando { get; set; }
    
    public override string ToString()
    {
        return nomeComando + ": " + desComando;
    }
}
}