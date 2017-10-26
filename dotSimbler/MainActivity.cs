using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace dotSimbler
{
    [Activity(Label = "dotSimbler", MainLauncher = true)]
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
        Button btnSobre;
        Button btnSimulador;
        Button btnHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            txtAX = FindViewById<TextView>(Resource.Id.txtAX);
            txtBX = FindViewById<TextView>(Resource.Id.txtBX);
            txtCX = FindViewById<TextView>(Resource.Id.txtCX);
            txtDX = FindViewById<TextView>(Resource.Id.txtDX);
            txtSflag = FindViewById<TextView>(Resource.Id.txtSflag);
            txtOflag = FindViewById<TextView>(Resource.Id.txtOflag);
            txtZflag = FindViewById<TextView>(Resource.Id.txtZflag);
            txtComp = FindViewById<EditText>(Resource.Id.txtComp);
            btnExec = FindViewById<Button>(Resource.Id.btnExec);
            btnSimulador = FindViewById<Button>(Resource.Id.btnSimulador);
            btnSobre = FindViewById<Button>(Resource.Id.btnSobre);
            btnHelper = FindViewById<Button>(Resource.Id.btnHelper);

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
                    /*else if (txtAX.Text == "")
                    {
                        txtOflag.Text = "1";
                    }
                    else if (txtAX.Text == "")
                    {

                    }*/
                }
            }

        }
    }
}

