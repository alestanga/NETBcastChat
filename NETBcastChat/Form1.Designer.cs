namespace NETBcastChat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtbox_ricevuto = new System.Windows.Forms.RichTextBox();
            this.rtbox_invia = new System.Windows.Forms.RichTextBox();
            this.btn_invia = new System.Windows.Forms.Button();
            this.cmb_users = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_about = new System.Windows.Forms.Label();
            this.btn_grassetto = new System.Windows.Forms.Button();
            this.btn_corsivo = new System.Windows.Forms.Button();
            this.cmb_colori = new System.Windows.Forms.ComboBox();
            this.lbl_colorefont = new System.Windows.Forms.Label();
            this.cmb_fontsize = new System.Windows.Forms.ComboBox();
            this.lbl_fontsize = new System.Windows.Forms.Label();
            this.lbl_vers = new System.Windows.Forms.Label();
            this.btn_incolla = new System.Windows.Forms.Button();
            this.smile2 = new System.Windows.Forms.PictureBox();
            this.smile1 = new System.Windows.Forms.PictureBox();
            this.thumbup_img = new System.Windows.Forms.PictureBox();
            this.lbl_incolla = new System.Windows.Forms.Label();
            this.info_allegati = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.smile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smile1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbup_img)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbox_ricevuto
            // 
            this.rtbox_ricevuto.BackColor = System.Drawing.SystemColors.Window;
            this.rtbox_ricevuto.Location = new System.Drawing.Point(12, 13);
            this.rtbox_ricevuto.Name = "rtbox_ricevuto";
            this.rtbox_ricevuto.ReadOnly = true;
            this.rtbox_ricevuto.Size = new System.Drawing.Size(726, 247);
            this.rtbox_ricevuto.TabIndex = 0;
            this.rtbox_ricevuto.Text = "";
            // 
            // rtbox_invia
            // 
            this.rtbox_invia.EnableAutoDragDrop = true;
            this.rtbox_invia.Location = new System.Drawing.Point(12, 266);
            this.rtbox_invia.Name = "rtbox_invia";
            this.rtbox_invia.Size = new System.Drawing.Size(726, 111);
            this.rtbox_invia.TabIndex = 1;
            this.rtbox_invia.Text = "";
            // 
            // btn_invia
            // 
            this.btn_invia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_invia.Location = new System.Drawing.Point(16, 401);
            this.btn_invia.Name = "btn_invia";
            this.btn_invia.Size = new System.Drawing.Size(68, 26);
            this.btn_invia.TabIndex = 2;
            this.btn_invia.Text = "&Invia";
            this.btn_invia.UseVisualStyleBackColor = true;
            this.btn_invia.Click += new System.EventHandler(this.btn_invia_Click);
            // 
            // cmb_users
            // 
            this.cmb_users.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_users.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_users.FormattingEnabled = true;
            this.cmb_users.Location = new System.Drawing.Point(109, 407);
            this.cmb_users.Name = "cmb_users";
            this.cmb_users.Size = new System.Drawing.Size(148, 21);
            this.cmb_users.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Destinatario:";
            // 
            // lbl_about
            // 
            this.lbl_about.AutoSize = true;
            this.lbl_about.Font = new System.Drawing.Font("Arial", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_about.Location = new System.Drawing.Point(731, 3);
            this.lbl_about.Name = "lbl_about";
            this.lbl_about.Size = new System.Drawing.Size(17, 6);
            this.lbl_about.TabIndex = 8;
            this.lbl_about.Text = "By Ale";
            // 
            // btn_grassetto
            // 
            this.btn_grassetto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_grassetto.Location = new System.Drawing.Point(513, 398);
            this.btn_grassetto.Name = "btn_grassetto";
            this.btn_grassetto.Size = new System.Drawing.Size(20, 23);
            this.btn_grassetto.TabIndex = 9;
            this.btn_grassetto.Text = "G";
            this.btn_grassetto.UseVisualStyleBackColor = true;
            this.btn_grassetto.Visible = false;
            // 
            // btn_corsivo
            // 
            this.btn_corsivo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_corsivo.Location = new System.Drawing.Point(539, 398);
            this.btn_corsivo.Name = "btn_corsivo";
            this.btn_corsivo.Size = new System.Drawing.Size(20, 24);
            this.btn_corsivo.TabIndex = 10;
            this.btn_corsivo.Text = "C";
            this.btn_corsivo.UseVisualStyleBackColor = true;
            this.btn_corsivo.Visible = false;
            // 
            // cmb_colori
            // 
            this.cmb_colori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_colori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_colori.FormattingEnabled = true;
            this.cmb_colori.Location = new System.Drawing.Point(263, 407);
            this.cmb_colori.Name = "cmb_colori";
            this.cmb_colori.Size = new System.Drawing.Size(89, 21);
            this.cmb_colori.TabIndex = 11;
            this.cmb_colori.SelectedIndexChanged += new System.EventHandler(this.cmb_colori_SelectedIndexChanged);
            // 
            // lbl_colorefont
            // 
            this.lbl_colorefont.AutoSize = true;
            this.lbl_colorefont.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_colorefont.Location = new System.Drawing.Point(260, 391);
            this.lbl_colorefont.Name = "lbl_colorefont";
            this.lbl_colorefont.Size = new System.Drawing.Size(68, 14);
            this.lbl_colorefont.TabIndex = 12;
            this.lbl_colorefont.Text = "Colore testo:";
            // 
            // cmb_fontsize
            // 
            this.cmb_fontsize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_fontsize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_fontsize.FormattingEnabled = true;
            this.cmb_fontsize.Location = new System.Drawing.Point(358, 407);
            this.cmb_fontsize.Name = "cmb_fontsize";
            this.cmb_fontsize.Size = new System.Drawing.Size(62, 21);
            this.cmb_fontsize.TabIndex = 13;
            this.cmb_fontsize.SelectedIndexChanged += new System.EventHandler(this.cmb_fontsize_SelectedIndexChanged);
            // 
            // lbl_fontsize
            // 
            this.lbl_fontsize.AutoSize = true;
            this.lbl_fontsize.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fontsize.Location = new System.Drawing.Point(355, 389);
            this.lbl_fontsize.Name = "lbl_fontsize";
            this.lbl_fontsize.Size = new System.Drawing.Size(65, 14);
            this.lbl_fontsize.TabIndex = 14;
            this.lbl_fontsize.Text = "Dimensione:";
            // 
            // lbl_vers
            // 
            this.lbl_vers.AutoSize = true;
            this.lbl_vers.Font = new System.Drawing.Font("Arial", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vers.Location = new System.Drawing.Point(1, 2);
            this.lbl_vers.Name = "lbl_vers";
            this.lbl_vers.Size = new System.Drawing.Size(29, 7);
            this.lbl_vers.TabIndex = 15;
            this.lbl_vers.Text = "lbl_vers";
            this.lbl_vers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_incolla
            // 
            this.btn_incolla.Image = global::NETBcastChat.Properties.Resources.Paste;
            this.btn_incolla.Location = new System.Drawing.Point(441, 396);
            this.btn_incolla.Name = "btn_incolla";
            this.btn_incolla.Size = new System.Drawing.Size(39, 36);
            this.btn_incolla.TabIndex = 16;
            this.btn_incolla.UseVisualStyleBackColor = true;
            this.btn_incolla.Click += new System.EventHandler(this.btn_incolla_Click);
            // 
            // smile2
            // 
            this.smile2.Image = global::NETBcastChat.Properties.Resources.smiley_sad;
            this.smile2.Location = new System.Drawing.Point(703, 388);
            this.smile2.Name = "smile2";
            this.smile2.Size = new System.Drawing.Size(33, 33);
            this.smile2.TabIndex = 7;
            this.smile2.TabStop = false;
            this.smile2.Click += new System.EventHandler(this.smile2_Click);
            // 
            // smile1
            // 
            this.smile1.Image = global::NETBcastChat.Properties.Resources.th;
            this.smile1.Location = new System.Drawing.Point(666, 388);
            this.smile1.Name = "smile1";
            this.smile1.Size = new System.Drawing.Size(33, 33);
            this.smile1.TabIndex = 6;
            this.smile1.TabStop = false;
            this.smile1.Click += new System.EventHandler(this.smile1_Click);
            // 
            // thumbup_img
            // 
            this.thumbup_img.Image = global::NETBcastChat.Properties.Resources.thumbsup;
            this.thumbup_img.Location = new System.Drawing.Point(628, 388);
            this.thumbup_img.Name = "thumbup_img";
            this.thumbup_img.Size = new System.Drawing.Size(32, 32);
            this.thumbup_img.TabIndex = 17;
            this.thumbup_img.TabStop = false;
            this.thumbup_img.Click += new System.EventHandler(this.thumbup_img_Click);
            // 
            // lbl_incolla
            // 
            this.lbl_incolla.AutoSize = true;
            this.lbl_incolla.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_incolla.Location = new System.Drawing.Point(442, 380);
            this.lbl_incolla.Name = "lbl_incolla";
            this.lbl_incolla.Size = new System.Drawing.Size(37, 14);
            this.lbl_incolla.TabIndex = 18;
            this.lbl_incolla.Text = "Incolla";
            // 
            // info_allegati
            // 
            this.info_allegati.AutoSize = true;
            this.info_allegati.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_allegati.ForeColor = System.Drawing.Color.DarkGreen;
            this.info_allegati.Location = new System.Drawing.Point(36, 1);
            this.info_allegati.Name = "info_allegati";
            this.info_allegati.Size = new System.Drawing.Size(140, 12);
            this.info_allegati.TabIndex = 19;
            this.info_allegati.Text = "Adesso si possono allegare i file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 435);
            this.Controls.Add(this.info_allegati);
            this.Controls.Add(this.lbl_incolla);
            this.Controls.Add(this.thumbup_img);
            this.Controls.Add(this.btn_incolla);
            this.Controls.Add(this.lbl_vers);
            this.Controls.Add(this.lbl_fontsize);
            this.Controls.Add(this.cmb_fontsize);
            this.Controls.Add(this.lbl_colorefont);
            this.Controls.Add(this.cmb_colori);
            this.Controls.Add(this.btn_corsivo);
            this.Controls.Add(this.btn_grassetto);
            this.Controls.Add(this.lbl_about);
            this.Controls.Add(this.smile2);
            this.Controls.Add(this.smile1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_users);
            this.Controls.Add(this.btn_invia);
            this.Controls.Add(this.rtbox_invia);
            this.Controls.Add(this.rtbox_ricevuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Messaggi Interni";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.smile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smile1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbup_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbox_ricevuto;
        private System.Windows.Forms.RichTextBox rtbox_invia;
        private System.Windows.Forms.Button btn_invia;
        private System.Windows.Forms.ComboBox cmb_users;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox smile1;
        private System.Windows.Forms.PictureBox smile2;
        private System.Windows.Forms.Label lbl_about;
        private System.Windows.Forms.Button btn_grassetto;
        private System.Windows.Forms.Button btn_corsivo;
        private System.Windows.Forms.ComboBox cmb_colori;
        private System.Windows.Forms.Label lbl_colorefont;
        private System.Windows.Forms.ComboBox cmb_fontsize;
        private System.Windows.Forms.Label lbl_fontsize;
        private System.Windows.Forms.Label lbl_vers;
        private System.Windows.Forms.Button btn_incolla;
        private System.Windows.Forms.PictureBox thumbup_img;
        private System.Windows.Forms.Label lbl_incolla;
        private System.Windows.Forms.Label info_allegati;
    }
}

