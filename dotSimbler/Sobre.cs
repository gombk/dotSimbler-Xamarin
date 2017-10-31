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
    [Activity(Label = "Sobre")]
    public class Sobre : Activity
    {
        ImageButton btnSobre;
        ImageButton btnSimulador;
        ImageButton btnHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Sobre);

            btnSimulador = FindViewById<ImageButton>(Resource.Id.btnSimulador);
            btnSobre = FindViewById<ImageButton>(Resource.Id.btnSobre);
            btnHelper = FindViewById<ImageButton>(Resource.Id.btnHelper);

            btnHelper.Click += BtnHelper_Click;
            btnSimulador.Click += BtnSimulador_Click;

            btnSobre.Enabled = false;
        }
        private void BtnHelper_Click(object sender, System.EventArgs e)
        {
            var intHelper = new Intent(this, typeof(Helper));
            StartActivity(intHelper);
        }

        private void BtnSimulador_Click(object sender, System.EventArgs e)
        {
            var intSimulador = new Intent(this, typeof(MainActivity));
            StartActivity(intSimulador);
        }

    }
}