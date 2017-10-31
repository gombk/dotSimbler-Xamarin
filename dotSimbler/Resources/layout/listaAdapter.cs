using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace dotSimbler.Resources.layout
{
    public class ListaAdapter : BaseAdapter<listaClass>
    {
        private readonly Activity context;
        private readonly List<listaClass> Comandos;

        public ListaAdapter(Activity context, List<listaClass> Comandos)
        {
            this.context = context;
            this.Comandos = Comandos;
        }

        public override listaClass this[int position]
        {
            get
            {
                return Comandos[position];
            }
        }

        public override int Count
        {
            get
            {
                return Comandos.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return Comandos[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.listaComandos, parent, false);

            var txtComando = view.FindViewById<TextView>(Resource.Id.comandoTextView);
            var txtDescricao = view.FindViewById<TextView>(Resource.Id.descricaoTextView);

            txtComando.Text = Comandos[position].nomeComando;
            txtDescricao.Text = "Descrição: ADQWEHWQHEHOIHASHWQEH FUNCIONA CARALHO" + Comandos[position].desComando;

            return view;
        }
    }
}