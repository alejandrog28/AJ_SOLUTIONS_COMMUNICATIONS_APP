using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;


namespace AJ_SOLUTIONS_COMMUNICATIONS_APP
{
    public partial class Form1 : Form
    {
        
        SoundPlayer ReproductoWav;
        public bool flagReporte = false;

        private string path = @"C:\Registros";
        private string pathAudio = "";

        public Form1()
        {
            InitializeComponent();
            ReproductoWav = new SoundPlayer();
            
        }

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int Grabar(string Comando, string StringRetono, int Longitud, int hwndCallback);




        private void Form1_Load(object sender, EventArgs e)
        {
            lblState.Text = "No Receive Data";
            pictureBoxledSerial.Image = Properties.Resources.green_led_off_md;

            btnOpen.Enabled = false;
            btnClose.Enabled = false;

            btnSpeaker.Enabled = false;
            btnMicrophone.Enabled = false;

           
        }

        public bool ValidateSticker()
        {
            string numberSticker = txtNumeroSticker.Text;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!string.IsNullOrEmpty(numberSticker))
            {
                string nameTxt = $@"{path}\Report_Audio_Convert" + "_" + "OP38487" + "_" + "[" + numberSticker + "]" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";
                string nameAudio = $@"\Audio_{numberSticker}.wav";

                if (File.Exists(nameTxt)||File.Exists($"{path}{numberSticker}"))
                {
                    MessageBox.Show("Ya este numero de sticker ya existe en la carpeta registros");

                    return false;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un numero de sticker para realizar la prueba", "Mensanje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            timer1.Start();

            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            try
            {
                serialPort1.PortName = cbxPort.Text;

                if (!serialPort1.IsOpen)
                {
                    //Open port
                    serialPort1.Open();
                }

                btnSpeaker.Enabled = true;
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            try
            {
                lblState.Text = "No Receive Data";
                pictureBoxledSerial.Image = Properties.Resources.green_led_off_md;

                serialPort1.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timer1.Stop();
            txtReceive.Clear();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();

            timer1.Stop();

        }

        private void btnSpeaker_Click(object sender, EventArgs e)
        {
            if (!ValidateSticker())
            {
                return;
            }

            btnSpeaker.Enabled = false;
            btnMicrophone.Enabled = true;

            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("A1");
                    Thread.Sleep(100);
                }
                else
                {
                    MessageBox.Show("puerto serial no disponible");
                    return;
                }

                Thread primerHilo = new Thread(Beep);
                primerHilo.Start();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnMicrophone_Click(object sender, EventArgs e)
        {

            btnMicrophone.Enabled = false;
            pathAudio = "";


            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("B1");
                    Thread.Sleep(100);
                }


                Grabar("open new Type waveaudio Alias recsound", "", 0, 0);
                Grabar("record recsound", "", 0, 0);

                Thread.Sleep(100);

                ReproductoWav.Stop();
                pathAudio = $@"{path}\Audio_{txtNumeroSticker.Text}.wav";

                if (!string.IsNullOrEmpty(txtNumeroSticker.Text))
                {

                    Grabar("save recsound " + pathAudio, "", 0, 0);
                    Grabar("close recsound", "", 0, 0);
                    MessageBox.Show("Archivo Guardado en:" + pathAudio);

                }

                
                btnMicrophone.Enabled = true;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {

                if (serialPort1.IsOpen && serialPort1.BytesToRead > 0)
                {
                    lblState.Text = "Receive";


                    //Read text from port
                    string serialReceive = serialPort1.ReadExisting();

                    txtReceive.SelectionStart = txtReceive.TextLength;
                    txtReceive.ScrollToCaret();

                    txtReceive.Text += serialReceive + Environment.NewLine;

                    Thread.Sleep(500);

                    string[] valores = serialReceive.Split(';');

                    string ID = valores[0];

                    string idCompare = "C";


                    if (String.Compare(ID, idCompare) == 0)
                    {
                        //Comparacion resolucion y frecuencia

                        int frequency = int.Parse(valores[1]);
                        int resolution = int.Parse(valores[2]);



                        if (frequency >= 900 && frequency <= 1100 && resolution >= 0 && resolution <= 1023)
                        {
                            txtReceive.Text += "OK" + Environment.NewLine;
                            pictureBoxledSerial.Image = Properties.Resources.green_led_on_md;

                        }
                        else
                        {
                            txtReceive.Text += "ERROR" + Environment.NewLine;
                            pictureBoxledSerial.Image = Properties.Resources.green_led_off_md;
                        }
     

                    }

                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                }

                Reporte();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            txtReceive.SelectionStart = txtReceive.TextLength;
            txtReceive.ScrollToCaret();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            ReproductoWav.SoundLocation = pathAudio;
            ReproductoWav.Play();
            txtReceive.Clear();
        }

        static void Beep()
        {

            Console.Beep(1000, 8000);

        }

         public void Reporte()
        {
            //#################### CAPTURA DE DATOS - ARCHIVO TXT

            string sticker = txtNumeroSticker.Text;

            string nombre = @"Report_Audio_Convert" + "_" + "OP38487" + "_" +"[" + sticker + "]" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";

            string completo = path + @"\" + nombre;

            StreamWriter Escribir = File.CreateText(completo);
            Escribir.WriteLine("############# REPORTE AUDIO - " + sticker + "###########");
            Escribir.WriteLine("--------------------------------------------------------------------");
            Escribir.WriteLine("IDENTIFICADOR;FRECUENCIA;RESOLUCION");
            Escribir.Write(txtReceive.Text);
            Escribir.WriteLine("----------------------------------------------------------------------");
            Thread.Sleep(2000);
            Escribir.Close();

            MessageBox.Show("REPORTE GENERADO");
        }

        private void cbxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
        }

        private void cbxPort_Click(object sender, EventArgs e)
        {

            try
            {
                cbxPort.Items.Clear();  

                //Get all ports
                string[] ports = SerialPort.GetPortNames();
                cbxPort.Items.AddRange(ports);
                //cbxPort.SelectedIndex = 0;
                serialPort1.BaudRate = 115200;

                serialPort1.ReadTimeout = 500;
                serialPort1.WriteTimeout = 500;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
