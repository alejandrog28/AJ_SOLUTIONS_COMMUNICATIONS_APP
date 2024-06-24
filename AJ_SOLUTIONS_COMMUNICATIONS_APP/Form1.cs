using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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

            

            try
            {
                //Get all ports
                string[] ports = SerialPort.GetPortNames();
                cbxPort.Items.AddRange(ports);
                //cbxPort.SelectedIndex = 0;
                serialPort1.BaudRate = 115200;
                btnClose.Enabled = false;
                serialPort1.ReadTimeout = 500;
                serialPort1.WriteTimeout = 500; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            timer1.Start();

            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            try
            {
                //Open port
                serialPort1.PortName = cbxPort.Text;
                serialPort1.Open();


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
            

            btnSpeaker.Enabled = false;
            btnMicrophone.Enabled = true;



            try
            {
                if (serialPort1.IsOpen)
                {

                    serialPort1.WriteLine("A1");
                    Thread.Sleep(100);


                }

                

                Thread primerHilo = new Thread(Beep);
                primerHilo.Start();

                btnSpeaker.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnMicrophone_Click(object sender, EventArgs e)
        {

            btnSpeaker.Enabled = true;
            btnMicrophone.Enabled = false;
            

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

                UrlReproductor.Text = "";
                ReproductoWav.Stop();

                SaveFileDialog CajaDeDiaologoGuardar = new SaveFileDialog();
                CajaDeDiaologoGuardar.AddExtension = true;
                CajaDeDiaologoGuardar.FileName = "Audio_.wav";
                CajaDeDiaologoGuardar.Filter = "Sonido (*.wav)|*.wav";
                CajaDeDiaologoGuardar.ShowDialog();
                if (!string.IsNullOrEmpty(CajaDeDiaologoGuardar.FileName))
                {
                    UrlReproductor.Text = CajaDeDiaologoGuardar.FileName;


                    Grabar("save recsound " + CajaDeDiaologoGuardar.FileName, "", 0, 0);
                    Grabar("close recsound", "", 0, 0);
                    MessageBox.Show("Archivo Guardado en:" + CajaDeDiaologoGuardar.FileName);

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
            ReproductoWav.SoundLocation = UrlReproductor.Text;
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

            string path = @"C:\REPORTES_AJ_SOLUTIONS";

            string nombre = @"\Report_Audio_Convert" + "-" + "OP38067" + "-" +"[" + sticker + "]" + "-" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt";

            string completo = path + nombre;

            StreamWriter Escribir = File.CreateText(completo);
            Escribir.WriteLine("############# REPORTE AUDIO - " + sticker + "###########");
            Escribir.WriteLine("--------------------------------------------------------------------");
            Escribir.WriteLine("IDENTIFICADOR;FRECUENCIA;RESOLUCION");
            Escribir.Write(txtReceive.Text);
            Escribir.WriteLine("----------------------------------------------------------------------");
            Thread.Sleep(2000);
            Escribir.Close();

            

           // MessageBox.Show("REPORTE GENERADO");
        }
    }
}
