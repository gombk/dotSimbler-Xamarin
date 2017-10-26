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
    [Activity(Label = "Helper")]
    public class Helper : Activity
    {
        Button btnSobre;
        Button btnSimulador;
        Button btnHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Helper);

            btnSimulador = FindViewById<Button>(Resource.Id.btnSimulador);
            btnSobre = FindViewById<Button>(Resource.Id.btnSobre);
            btnHelper = FindViewById<Button>(Resource.Id.btnHelper);

            btnSobre.Click += BtnSobre_Click;
            btnSimulador.Click += BtnSimulador_Click;

            btnHelper.Enabled = false;
        }

        private void BtnSobre_Click(object sender, System.EventArgs e)
        {
            var intSobre = new Intent(this, typeof(Sobre));
            StartActivity(intSobre);
        }

        private void BtnSimulador_Click(object sender, System.EventArgs e)
        {
            var intSimulador = new Intent(this, typeof(MainActivity));
            StartActivity(intSimulador);
        }

    }
}