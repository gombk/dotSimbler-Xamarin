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
    class listaAdapter : BaseAdapter
    {
       private readonly Activity context;
       private readonly List<listaClass> comandos;
 
       public listaAdapter(Activity context, List<listaClass> filmes)
       {
           this.context = context;
           this.comandos = comandos;
       }

       public override Comando this[int position]
       {
           get
           {
               return comandos[position];
           }
       }
 
       public override int Count
       {
           get
           {
               return comandos.Count;
           }
       }
 
       public override long GetItemId(int position)
       {
           return comandos[position].id;
       }
 
       public override View GetView(int position, View convertView, ViewGroup parent)
       {
           var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.listaComandos, parent, false);
           //var txtTitulo = view.FindViewById<TextView>(Resource.Id.tituloTextView);
           //var txtDiretor = view.FindViewById<TextView>(Resource.Id.diretorTextView);
           //var txtLancamento = view.FindViewById<TextView>(Resource.Id.dataLancamentoTextView);
 
           //txtTitulo.Text = filmes[position].Titulo;
           //txtDiretor.Text = "Dirigido por: " + filmes[position].Diretor;
           //txtLancamento.Text = "Lançado em : " + filmes[position].DataLancamento.ToShortDateString();
           return view;
       }
  }

}