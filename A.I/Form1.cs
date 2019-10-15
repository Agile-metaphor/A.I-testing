using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System.Xml;

namespace A.I
{

    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = false;
        Choices list = new Choices();
        String temp, condition,low,high;

        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new String[] {"Cortin", "hello", "how are you", "what time is it", "what day is it", "open google", "open youtube"
                , "wake", "sleep", "Cortin wake up","restart","update","open universe sandbox 2", "close universe sandbox 2",
                "whats the weather like","cortin"
            });


            Grammar gram = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gram);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }


            InitializeComponent();
            s.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            s.Speak("Welcome");
        }
    
        
        public static void closeProg(string t)
        {
            System.Diagnostics.Process[] procs = null;

            try
            {
                procs = Process.GetProcessesByName(t);
                Process prog = procs[0];

                if (!prog.HasExited)
                {
                    prog.Kill();
                }
            }
            finally
            {
                if(procs != null)
                {
                    foreach(Process p in procs)
                    {
                        p.Dispose();
                    }
                }
            }


        } 

        public void say(String h)
        {
            s.Speak(h);
            wake = false;
            textBox2.AppendText(h + "\n");
        }
        public void restart()
        {
            Process.Start(@"C:\Users\Baba\Desktop\Movement_Energy Calc\A.I/A.I.exe");
            Environment.Exit(0);
        }
        String[] jokes = new String[7]
        {   "A perfectionist walked into a bar..apparently, the bar wasn’t set high enough.",
            "Why do we tell actors to “break a leg?”..Because every play needs a cast",
            "I invented a new word!... Plagiarism!",
            "",
            "",
            "",
            ""
        };
        public void unisand2()
        {
            Process.Start(@"C:\Users\Baba\Desktop\Universe.Sandbox.2.v23.1.2\Universe Sandbox x64.exe");
        }
        //cccommands commandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommandscommands
       
        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;
            if(r == "cortin")
            {
                wake = true;
            }

            if (r == "Cortin wake up")
            {
                wake = true;
                label3.Text = "State: Awake";
            }
            if (r == "wake")
            {
                wake = true;
                label3.Text = "State: Awake";
            }
            if (r == "sleep")
            {
                wake = false;
                label3.Text = "State: Sleeping";
            }
            if (wake == true)




            {
                if (r == "update" || r == "restart")
                {
                    restart();
                }


                if (r == "Cortin")
                {
                    say("yes how can i help you");
                }
                //What U say 
                if (r == "hello")
                {
                    //What it should  say
                    say("hi");
                }
                if (r == "how are you")
                {
                    //What it should say
                    say("Fine");
                }
                if (r == "what time is it")
                {
                    say(DateTime.Now.ToString("M h:m tt"));
                }
                if (r == "what day is it")
                {
                    say(DateTime.Now.ToString("M/d/yyyy"));
                }
                if (r == "open youtube")
                {
                    say("opening youtube");
                    Process.Start("http://youtube.com");
                }
                if (r == "open google")
                {
                    say("opening google");
                    Process.Start("http://google.com");
                }
                if (r == "open universe sandbox 2")
                {
                    say("opening universe sandox 2");
                    unisand2();
                }
                if (r == "close universe sandbox 2")
                {
                    say("closing universe sandox 2");
                    closeProg("Universe Sandbox x64.exe");
                }

            }   
            textBox1.AppendText(r + "\n");
        }
        

        private void  Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
