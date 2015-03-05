using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.DirectoryServices;
using System.Configuration;
using System.Runtime.InteropServices;
using System.DirectoryServices.AccountManagement;

namespace NETBcastChat
{
    public partial class Form1 : Form
    {
        public const string CLASSE_RETE = "192.168.1.255"; //classe di rete
        public const int PORTA_RETE = 9060; //porta di ascolto e invio
        public const int UDP_BUFFER_SIZE = 10000000; //dimensione del buffer di rete
        public const int LIST_BUFFER_SIZE = 7950; //dimensione del buffer di rete
        public const int NUMERO_MAX_SEGMENTI = 9999; //numero massimo di segmenti in cui dividere il messaggio
        public string nome_utente;//contiene il nome utente
        List<string> buffer_ricevuto;//stringhe ricevute
        
        //definizione backgroundworker e delegati
        BackgroundWorker bw = new BackgroundWorker();
        delegate void BindTextBoxControl(string text);
        delegate void ServiceMSGHandlerDelegate(string SrvMsgCMD, string SrvMsgTxt);

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_invia_Click(object sender, EventArgs e)//invio messaggio
        {
            string BroadCastmsg="";
            bool isBroadCast = false;
            if (cmb_users.Text == "")
            {
                MessageBox.Show("Selezionare un destinatario dall'elenco", "Manca il destinatario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_users.Focus();
            }
            else
            {//aggiunge intestazione al messaggio prima di inviarlo
                if (cmb_users.Text.ToUpper() == "BROADCAST")
                {
                    isBroadCast = true;
                    BroadCastmsg = "******MESSAGGIO BROADCAST******\n";
                }
                rtbox_invia.SelectionStart = 0;
                rtbox_invia.SelectionLength = 0;
                rtbox_invia.SelectedText = nome_utente + " " + DateTime.Now.ToString() + ":\n" + BroadCastmsg;
                rtbox_invia.SelectionStart = rtbox_invia.GetFirstCharIndexFromLine(0);
                rtbox_invia.SelectionLength = rtbox_invia.Lines[0].Length;
                rtbox_invia.SelectionFont = new Font(new FontFamily("Arial"), 12, FontStyle.Bold);
                rtbox_invia.SelectionColor = Color.Black;
                if (isBroadCast)//colora di rosso il messaggio broadcast
                {
                    rtbox_invia.SelectionStart = rtbox_invia.GetFirstCharIndexFromLine(1);
                    rtbox_invia.SelectionLength = rtbox_invia.Lines[1].Length;
                    rtbox_invia.SelectionFont = new Font(new FontFamily("Arial"), 10, FontStyle.Bold);
                    rtbox_invia.SelectionColor = Color.Red;
                }
                string Destinatario = string.Format("{0,20}", cmb_users.Text);
                string DatiDaInviare = rtbox_invia.Rtf;

                if (invia_msg(Destinatario, DatiDaInviare))//se l'invio del messaggio va a buon fine:
                {
                    //inserisce nella casella superiore il messaggio inviato
                    rtbox_invia.Select(0, rtbox_invia.GetFirstCharIndexFromLine(1));
                    rtbox_invia.SelectedText = "\nA: " + cmb_users.Text + " " + DateTime.Now.ToString() + ":\n";
                    rtbox_invia.SelectAll();
                    rtbox_invia.SelectionFont = new Font(new FontFamily("Arial"), 8, FontStyle.Bold);
                    rtbox_invia.SelectionColor = Color.Gray;
                    rtbox_ricevuto.SelectionStart = rtbox_ricevuto.TextLength;
                    rtbox_ricevuto.SelectedRtf = rtbox_invia.Rtf;
                    rtbox_ricevuto.ScrollToCaret();

                    //svuota la textbox di invio
                    rtbox_invia.Clear();
                }
                else
                {
                    MessageBox.Show("Messaggio troppo grande,\nprova ad eliminare qualche immagine\no a ridurre il testo", "Errore invio messaggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rtbox_invia.SelectionStart = rtbox_invia.GetFirstCharIndexFromLine(0);
                    rtbox_invia.SelectionLength = rtbox_invia.Lines[0].Length;
                    rtbox_invia.SelectedText = "";
                }
                rtbox_invia.Focus();
            }
        }

        private bool invia_msg(string destinatariop, string datidainviarep)//funzione per l'invio dei messaggi
        {
            bool successo;
            successo = true;
            //invia il messaggio come datagramma in broadcast
            //attende un tempo random prima di mandare il messaggio
            //per evitare collisioni
            Random RandomClass = new Random();
            int AttesaRandom = RandomClass.Next(2, 50); //attende un tempo random per evitare collisioni
            Thread.Sleep(AttesaRandom);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep2 = new IPEndPoint(IPAddress.Parse(CLASSE_RETE), PORTA_RETE);//meglio questo, non è routabile
            //IPEndPoint iep2 = new IPEndPoint(IPAddress.Broadcast, PORTA_RETE);//255.255.255.255
            string hostname = Dns.GetHostName();
            
            //gestione messaggi grandi, vengono divisi in piccoli pezzi
            string[] buffer_invio = SplitIntoChunks(datidainviarep, LIST_BUFFER_SIZE);
            string avanzamento;
            int i;

            if (buffer_invio.GetUpperBound(0) < NUMERO_MAX_SEGMENTI)
            {//se il numero di segmenti non è troppo grande
                for (i = 0; i <= buffer_invio.GetUpperBound(0); i++)
                {//invia i singoli segmenti
                    avanzamento = string.Format("{0,4}", i.ToString()) + string.Format("{0,4}", buffer_invio.GetUpperBound(0).ToString()); //9 byte, dichiarano a che punto siamo della tasmissione
                    byte[] data = Encoding.ASCII.GetBytes(destinatariop + avanzamento + buffer_invio[i]);
                    sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                    sock.SendBufferSize = UDP_BUFFER_SIZE;
                    try
                    {
                        sock.SendTo(data, iep2);
                    }
                    catch (SocketException ex)
                    {
                        successo = false;
                        break;//esce dal ciclo
                    }
                }
                sock.Close();
            }
            else//se il messaggio è troppo grande
            {
                successo = false;
            }
            return successo;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)//background worker di ascolto
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, PORTA_RETE);
            sock.Bind(iep);
            EndPoint ep = (EndPoint)iep;
            byte[] data = new byte[UDP_BUFFER_SIZE];
            sock.ReceiveBufferSize = UDP_BUFFER_SIZE;
            int recv;
            string stringData;
            string destinatario;
            string avanzamento;
            bool srvmsg;
            int progresso;
            int totale;
            while (true)
            {
                data = new byte[10240000];
                recv = sock.ReceiveFrom(data, ref ep);
                stringData = Encoding.ASCII.GetString(data, 0, recv);

                destinatario = stringData.Substring(0, 20); //estrae il destinatario dal messaggio
                avanzamento = stringData.Substring(20, 8); //gestione messaggi grandi
                progresso = Convert.ToInt16(avanzamento.Substring(0, 4));//avanzamento
                totale = Convert.ToInt16(avanzamento.Substring(4, 4));//dimensione array da ricevere
                stringData = stringData.Substring(28); //estrae i dati ricevuti dal messaggio
                if (progresso==0){//se è il primo messaggio
                    buffer_ricevuto.Clear();//svuota la lista
                }
                buffer_ricevuto.Add(stringData);//inserisce i dati nella lista

                if (progresso == totale)
                {
                    stringData=string.Join("",buffer_ricevuto.ToArray());

                    //controlla se è un messaggio di servizio e lo gestisce
                    srvmsg = destinatario.Substring(0, 6) == "SRVMSG";

                    if (srvmsg)
                    {//gestisce i messaggi di servizio
                        this.Invoke(new ServiceMSGHandlerDelegate(ServiceMSGHandler), new object[] { destinatario, stringData });
                    }
                    else
                    {
                        if (destinatario.ToUpper() == string.Format("{0,20}", nome_utente).ToUpper() || destinatario.ToUpper() == "           BROADCAST")
                        {//controlla se si è il destinatario del messaggio o se è un messaggio Broadcast
                            this.Invoke(new BindTextBoxControl(UpdateTextbox), new object[] { stringData });
                        }
                    }
                    if (bw.CancellationPending)//se si sta chiudendo il programma
                    {
                        sock.Close();//chiude il socket
                    }
                }
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // this.tbProgress.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                //this.tbProgress.Text = "Canceled!";
            }
            else if (!(e.Error == null))
            {
                //this.tbProgress.Text = ("Error: " + e.Error.Message);
            }
            else
            {
                //this.tbProgress.Text = "Done!";
            }
        }

        private void Form1_Load(object sender, EventArgs e) //caricamento della form
        {
            this.ActiveControl = rtbox_invia;
            buffer_ricevuto=new List<string>();//inizializza il buffer di ricezione
            //avvia il background worker di ascolto
            bw.DoWork += new DoWorkEventHandler(bw_DoWork); bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged); bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }

            //reperisce il nome utente
            UserPrincipal userPrincipal = UserPrincipal.Current;
            nome_utente = userPrincipal.DisplayName.Trim(); //prende solo i primi 20 caratteri
            
            //inserisce solo il broadcast nella combo, gli altri vengono aggiunti man mano che si presentano in rete)
            combobox_additem(cmb_users, "Broadcast");

            //comunica al mondo che esiste
            invia_msg("SRVMSG        CISONO", nome_utente);
            
            //chiede chi c'è
            invia_msg("SRVMSG         CHICE", nome_utente);

            //configura la combo box dei colori
            combobox_additem(cmb_colori, "Rosso");
            combobox_additem(cmb_colori, "Verde");
            combobox_additem(cmb_colori, "Giallo");
            combobox_additem(cmb_colori, "Blu");
            combobox_additem(cmb_colori, "Nero");
            cmb_colori.Text = "Nero";//imposta il colore di default

            //configura la combo della dimensione del testo
            for (int ind = 5; ind <= 100; ind++)
            {
                combobox_additem(cmb_fontsize, ind.ToString());
            }
            cmb_fontsize.Text = "10";//imposta la dimensione di default

            lbl_vers.Text = PORTA_RETE.ToString();//imposta la porta di rete nella label della versione
        }

        private void UpdateTextbox(string _Text)//inserisce i messaggi ricevuti nella textbox
        {
            rtbox_ricevuto.AppendText(System.Environment.NewLine);
            rtbox_ricevuto.SelectedRtf = _Text;
            rtbox_ricevuto.ScrollToCaret();

            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Activate();
        }

        private void ServiceMSGHandler(string SrvMsgCMD,string SrvMsgTxt)//gestisce i messaggi di servizio
        {
            switch (SrvMsgCMD.Substring(6))
            {
                case "        CISONO"://alla presentazione di un utente lo aggiunge nella combo
                    combobox_additem(cmb_users, SrvMsgTxt);
                    break;
                case "         CHICE"://quando chiedono chi c'è risponde
                    invia_msg("SRVMSG        CISONO", nome_utente);
                    break;
                case "         ADDIO"://rimuove un utente che si sconnette
                    cmb_users.Items.Remove(SrvMsgTxt);
                    break;
                default:
                    break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Chiudendo l'applicazione non riceverai più i messaggi.\nSei sicuro di voler uscire?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No;
            if (!e.Cancel)//se non si annulla lo spegnimento
            {
                bw.CancelAsync();//ferma il background worker di ascolto
                invia_msg("SRVMSG         ADDIO", nome_utente);//avvisa in rete che ci si sta disconnettendo
            }
        }

        //emoticons
        private void smile1_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(smile1.Image);
            rtbox_invia.Paste();
        }
        private void smile2_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(smile2.Image);
            rtbox_invia.Paste();
        }

        private void thumbup_img_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(thumbup_img.Image);
            rtbox_invia.Paste();
        }

        private void combobox_additem(ComboBox CBox,string Item)
        {//controlla se l'elemento non è già nella lista, altrimenti lo aggiunge
            if (!CBox.Items.Contains(Item))
            {
                CBox.Items.Add(Item);
            }  
        }

        private void btn_grassetto_Click(object sender, EventArgs e)//grassetto
        {
            if (rtbox_invia.SelectionFont.Bold)
            {
                rtbox_invia.SelectionFont = new Font(rtbox_invia.Font.FontFamily, rtbox_invia.Font.Size, FontStyle.Regular);
            }
            else
            {
                rtbox_invia.SelectionFont = new Font(rtbox_invia.Font.FontFamily, rtbox_invia.Font.Size, FontStyle.Bold);
            }
            rtbox_invia.Focus();
        }

        private void btn_corsivo_Click(object sender, EventArgs e)//corsivo
        {
            FontStyle fontstyle_m = FontStyle.Regular;
            if (rtbox_invia.SelectionFont.Italic)
            {
                fontstyle_m = rtbox_invia.SelectionFont.Style & FontStyle.Regular;
                rtbox_invia.SelectionFont = new Font(rtbox_invia.Font.FontFamily, rtbox_invia.Font.Size, fontstyle_m);
            }
            else
            {
                fontstyle_m = rtbox_invia.SelectionFont.Style & FontStyle.Italic;
                rtbox_invia.SelectionFont = new Font(rtbox_invia.Font.FontFamily, rtbox_invia.Font.Size, FontStyle.Italic);
            }
            rtbox_invia.Focus();
        }

        private void cmb_colori_SelectedIndexChanged(object sender, EventArgs e) //colori testo
        {
            switch (cmb_colori.Text)
            {
                case "Rosso":
                    rtbox_invia.SelectionColor = Color.Red;
                    break;
                case "Verde":
                    rtbox_invia.SelectionColor = Color.Green;
                    break;
                case "Giallo":
                    rtbox_invia.SelectionColor = Color.Yellow;
                    break;
                case "Blu":
                    rtbox_invia.SelectionColor = Color.Blue;
                    break;
                case "Nero":
                    rtbox_invia.SelectionColor = Color.Black;
                    break;
                default:
                    rtbox_invia.SelectionColor = Color.Black;
                    break;
            }
            rtbox_invia.Focus();
        }

        private void cmb_fontsize_SelectedIndexChanged(object sender, EventArgs e) //dimensioni font
        {
            rtbox_invia.SelectionFont = new Font(rtbox_invia.Font.FontFamily, float.Parse(cmb_fontsize.Text), rtbox_invia.Font.Style);
            rtbox_invia.Focus();
        }

        private void btn_incolla_Click(object sender, EventArgs e) //bottone incolla
        {
            rtbox_invia.Paste();
        }

        //Divide la stringa in parti nell'array
        private string[] SplitIntoChunks(string toSplit, int chunkSize)
        {
            int stringLength = toSplit.Length;

            int chunksRequired = (int)Math.Ceiling((decimal)stringLength / (decimal)chunkSize);
            var stringArray = new string[chunksRequired];

            int lengthRemaining = stringLength;

            for (int i = 0; i < chunksRequired; i++)
            {
                int lengthToUse = Math.Min(lengthRemaining, chunkSize);
                int startIndex = chunkSize * i;
                stringArray[i] = toSplit.Substring(startIndex, lengthToUse);

                lengthRemaining = lengthRemaining - lengthToUse;
            }

            return stringArray;
        }

    }
}
