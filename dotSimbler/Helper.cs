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
    [Activity(Label = "Helper")]
    public class Helper : Activity
    {
        ImageButton btnSobre;
        ImageButton btnSimulador;
        ImageButton btnHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Helper);

            //ListView
            var comandosListView = FindViewById<ListView>(Resource.Id.comandoslistView);
            comandosListView.FastScrollEnabled = true;
            comandosListView.ItemClick += ComandosListView_ItemClick;
            var listaAdapter = new ListaAdapter(this, repLista.Comandos);

            //btnSimulador = FindViewById<ImageButton>(Resource.Id.btnSimulador);
            //btnSobre = FindViewById<ImageButton>(Resource.Id.btnSobre);
            //btnHelper = FindViewById<ImageButton>(Resource.Id.btnHelper);

            //btnSobre.Click += BtnSobre_Click;
            //btnSimulador.Click += BtnSimulador_Click;

            //btnHelper.Enabled = false;
        }

        //private void BtnSobre_Click(object sender, System.EventArgs e)
        //{
        //    var intSobre = new Intent(this, typeof(Sobre));
        //    StartActivity(intSobre);
        //}

        //private void BtnSimulador_Click(object sender, System.EventArgs e)
        //{
        //    var intSimulador = new Intent(this, typeof(MainActivity));
        //    StartActivity(intSimulador);
        //}

        private void ComandosListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, repLista.Comandos[e.Position].ToString(), ToastLength.Long).Show();
        }
    }
}