
namespace AJ_SOLUTIONS_COMMUNICATIONS_APP
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gpbPort = new System.Windows.Forms.GroupBox();
            this.pictureBoxledSerial = new System.Windows.Forms.PictureBox();
            this.btnMicrophone = new System.Windows.Forms.Button();
            this.btnSpeaker = new System.Windows.Forms.Button();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.cbxPort = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gpbBeep = new System.Windows.Forms.GroupBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.UrlReproductor = new System.Windows.Forms.Label();
            this.txtNumeroSticker = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxledSerial)).BeginInit();
            this.gpbBeep.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbPort
            // 
            this.gpbPort.Controls.Add(this.pictureBoxledSerial);
            this.gpbPort.Controls.Add(this.btnMicrophone);
            this.gpbPort.Controls.Add(this.btnSpeaker);
            this.gpbPort.Controls.Add(this.txtReceive);
            this.gpbPort.Controls.Add(this.lblState);
            this.gpbPort.Controls.Add(this.btnOpen);
            this.gpbPort.Controls.Add(this.btnClose);
            this.gpbPort.Controls.Add(this.lblPort);
            this.gpbPort.Controls.Add(this.cbxPort);
            this.gpbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbPort.Location = new System.Drawing.Point(12, 12);
            this.gpbPort.Name = "gpbPort";
            this.gpbPort.Size = new System.Drawing.Size(324, 321);
            this.gpbPort.TabIndex = 0;
            this.gpbPort.TabStop = false;
            this.gpbPort.Text = "AJ Solutions";
            // 
            // pictureBoxledSerial
            // 
            this.pictureBoxledSerial.Image = global::AJ_SOLUTIONS_COMMUNICATIONS_APP.Properties.Resources.green_led_off_md;
            this.pictureBoxledSerial.Location = new System.Drawing.Point(22, 24);
            this.pictureBoxledSerial.Name = "pictureBoxledSerial";
            this.pictureBoxledSerial.Size = new System.Drawing.Size(30, 29);
            this.pictureBoxledSerial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxledSerial.TabIndex = 8;
            this.pictureBoxledSerial.TabStop = false;
            // 
            // btnMicrophone
            // 
            this.btnMicrophone.Location = new System.Drawing.Point(178, 115);
            this.btnMicrophone.Name = "btnMicrophone";
            this.btnMicrophone.Size = new System.Drawing.Size(129, 23);
            this.btnMicrophone.TabIndex = 7;
            this.btnMicrophone.Text = "MICROPHONE";
            this.btnMicrophone.UseVisualStyleBackColor = true;
            this.btnMicrophone.Click += new System.EventHandler(this.btnMicrophone_Click);
            // 
            // btnSpeaker
            // 
            this.btnSpeaker.Location = new System.Drawing.Point(22, 115);
            this.btnSpeaker.Name = "btnSpeaker";
            this.btnSpeaker.Size = new System.Drawing.Size(94, 23);
            this.btnSpeaker.TabIndex = 6;
            this.btnSpeaker.Text = "SPEAKER";
            this.btnSpeaker.UseVisualStyleBackColor = true;
            this.btnSpeaker.Click += new System.EventHandler(this.btnSpeaker_Click);
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(22, 144);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(285, 171);
            this.txtReceive.TabIndex = 0;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(181, 18);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(0, 16);
            this.lblState.TabIndex = 4;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(22, 86);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(232, 86);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(92, 49);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(89, 16);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port Serial: ";
            // 
            // cbxPort
            // 
            this.cbxPort.FormattingEnabled = true;
            this.cbxPort.Location = new System.Drawing.Point(187, 41);
            this.cbxPort.Name = "cbxPort";
            this.cbxPort.Size = new System.Drawing.Size(121, 24);
            this.cbxPort.TabIndex = 0;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gpbBeep
            // 
            this.gpbBeep.Controls.Add(this.label1);
            this.gpbBeep.Controls.Add(this.txtNumeroSticker);
            this.gpbBeep.Controls.Add(this.btnPlay);
            this.gpbBeep.Controls.Add(this.UrlReproductor);
            this.gpbBeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbBeep.Location = new System.Drawing.Point(343, 13);
            this.gpbBeep.Name = "gpbBeep";
            this.gpbBeep.Size = new System.Drawing.Size(412, 314);
            this.gpbBeep.TabIndex = 1;
            this.gpbBeep.TabStop = false;
            this.gpbBeep.Text = "URL ";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(132, 85);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // UrlReproductor
            // 
            this.UrlReproductor.AutoSize = true;
            this.UrlReproductor.Location = new System.Drawing.Point(17, 43);
            this.UrlReproductor.Name = "UrlReproductor";
            this.UrlReproductor.Size = new System.Drawing.Size(0, 16);
            this.UrlReproductor.TabIndex = 8;
            // 
            // txtNumeroSticker
            // 
            this.txtNumeroSticker.Location = new System.Drawing.Point(198, 146);
            this.txtNumeroSticker.Name = "txtNumeroSticker";
            this.txtNumeroSticker.Size = new System.Drawing.Size(100, 22);
            this.txtNumeroSticker.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "NUMERO DE STICKER: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 337);
            this.Controls.Add(this.gpbBeep);
            this.Controls.Add(this.gpbPort);
            this.Name = "Form1";
            this.Text = "AJ SOLUTIONS APP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpbPort.ResumeLayout(false);
            this.gpbPort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxledSerial)).EndInit();
            this.gpbBeep.ResumeLayout(false);
            this.gpbBeep.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cbxPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button btnSpeaker;
        private System.Windows.Forms.Button btnMicrophone;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gpbBeep;
        private System.Windows.Forms.PictureBox pictureBoxledSerial;
        private System.Windows.Forms.Label UrlReproductor;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroSticker;
    }
}

