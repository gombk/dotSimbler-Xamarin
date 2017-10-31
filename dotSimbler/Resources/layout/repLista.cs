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
    public static class repLista
    {
       public static List<listaClass> Comandos { get; set; }
 
       static repLista()
       {
           Comandos = new List<listaClass>();
           for (int i = 0; i< 10; i++)
           {
               AddFilmes();
           }
       }

       private static void AddFilmes()
       {
            Comandos.Add(new listaClass
            {
                id = 1,
                nomeComando = "ADD",
                desComando = "Adiciona o valor especificado ao registrador acumulador (AX)."
            });
       }
   }
}