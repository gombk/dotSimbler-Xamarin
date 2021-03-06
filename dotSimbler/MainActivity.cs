﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace dotSimbler.Resources.layout
{
    [Activity(Label = "dotSimbler", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView txtAX;
        TextView txtBX;
        TextView txtCX;
        TextView txtDX;
        TextView txtSflag;
        TextView txtOflag;
        TextView txtZflag;
        EditText txtComp;
        Button btnExec;
        ImageButton btnSobre;
        ImageButton btnSimulador;
        ImageButton btnHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Processo principal
            txtAX = FindViewById<TextView>(Resource.Id.txtAX);
            txtBX = FindViewById<TextView>(Resource.Id.txtBX);
            txtCX = FindViewById<TextView>(Resource.Id.txtCX);
            txtDX = FindViewById<TextView>(Resource.Id.txtDX);
            txtSflag = FindViewById<TextView>(Resource.Id.txtSflag);
            txtOflag = FindViewById<TextView>(Resource.Id.txtOflag);
            txtZflag = FindViewById<TextView>(Resource.Id.txtZflag);
            txtComp = FindViewById<EditText>(Resource.Id.txtComp);
            btnExec = FindViewById<Button>(Resource.Id.btnExec);

            //Botões de navegação entre telas
            btnSimulador = FindViewById<ImageButton>(Resource.Id.btnSimulador);
            btnSobre = FindViewById<ImageButton>(Resource.Id.btnSobre);
            btnHelper = FindViewById<ImageButton>(Resource.Id.btnHelper);

            btnExec.Click += BtnExec_Click;
            btnSobre.Click += BtnSobre_Click;
            btnHelper.Click += BtnHelper_Click;

            btnSimulador.Enabled = false;
        }
        private void BtnSobre_Click(object sender, System.EventArgs e)
        {
            var intSobre = new Intent(this, typeof(Sobre));
            StartActivity(intSobre);
        }

        private void BtnHelper_Click(object sender, System.EventArgs e)
        {
            var intHelper = new Intent(this, typeof(Helper));
            StartActivity(intHelper);
        }
            private void BtnExec_Click(object sender, System.EventArgs e)
        {
            Registrador registrador = new Registrador();
            RtnComando cmd = new RtnComando();
            AnalisadorLexico analisadorLexico = new AnalisadorLexico();
            var txt = txtComp.Text;
            var linhas = txt.Split('\n');
            bool exec = true;
            int count = 1;
            if (txt != "")
            {
                foreach (var item in linhas)
                {
                    var comando = item.Split(' ');
                    var analisador = analisadorLexico.verificaComando(comando);
                    if (!analisador.executa)
                    {
                        Toast.MakeText(this, analisador.erro + "Linha: " + count.ToString() + ".", ToastLength.Long).Show();
                        exec = false;
                        break;
                    }
                    count++;
                }

                if (exec)
                {

                    foreach (var item in linhas)
                    {
                        var comando = item.Split(' ');
                        var result = cmd.executa(comando[0], comando[1], registrador);

                        txtAX.Text = result.GetAX();
                        txtBX.Text = result.GetBX();
                        txtCX.Text = result.GetCX();
                        txtDX.Text = result.GetDX();

                        if (txtAX.Text == "0" || txtAX.Text == "000000")
                        {
                            txtZflag.Text = "1";
                        }
                        else
                        {
                            txtZflag.Text = "0";
                        }
                    }
                }
            }
            else
            {
                Toast.MakeText(this, "Não existem comandos para executar." , ToastLength.Long).Show();
            }
        }
}
}

