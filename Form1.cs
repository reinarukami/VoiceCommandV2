using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace VoiceCommandV2
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine MrecEngine = new SpeechRecognitionEngine();
        SpeechRecognitionEngine SrecEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer vocEngine = new SpeechSynthesizer();

        GrammarBuilder gmainbuilder = new GrammarBuilder();
        GrammarBuilder gsubbuilder = new GrammarBuilder();

        Choices MainCommand = new Choices(new string[] { "command" });
        Choices SubCommands = new Choices(new string[] { "daily report", "facebook" ,"natnat", "notepad" , "lock screen" , "cancel", "email"});

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vocEngine.SpeakAsync("Loading Resources");

            InitializeBuilder(gmainbuilder, MainCommand, MrecEngine);
            InitializeBuilder(gsubbuilder, SubCommands, SrecEngine);

            SrecEngine.SpeechRecognized += subcommand_start;
            MrecEngine.SpeechRecognized += command_start;

            MrecEngine.SetInputToDefaultAudioDevice();
            MrecEngine.RecognizeAsync(RecognizeMode.Multiple);

            vocEngine.SpeakAsync("Loading Complete");
        }

        private  void command_start(object sender, SpeechRecognizedEventArgs e)
        {

            MrecEngine.RecognizeAsyncStop();

            SrecEngine.SetInputToDefaultAudioDevice();      
            SrecEngine.RecognizeAsync(RecognizeMode.Single);

            vocEngine.SpeakAsync("Please speak command");

        }

        private void subcommand_start(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                SrecEngine.RecognizeAsyncStop();

                if (e.Result.Text == "daily report")
                {
                    vocEngine.Speak(e.Result.Text + "command initiated");
                    Process.Start("chrome", "https://docs.google.com/spreadsheets/d/1Bj6PQPnl2tKhlmQo4WkkQg2dZE_kdM1qmOGj7Mfl_74/edit#gid=428803611");
                    Process.Start("chrome", "http://eyebe.ivp.co.jp/");
                    Process.Start("chrome", "https://docs.google.com/spreadsheets/d/1xNAlAKyv7d6T85N_LWBZTFrkX943IYFdTynAEswlxeA/edit#gid=1301708221");
                }
                if(e.Result.Text == "facebook")
                {
                    vocEngine.Speak(e.Result.Text + "command initiated");
                    Process.Start("chrome", "facebook.com");
                }
                if(e.Result.Text == "email")
                { 
                    vocEngine.Speak(e.Result.Text + "command initiated");
                    Process.Start("chrome", "https://mail.google.com/mail/u/1/");
                }
                if (e.Result.Text == "natnat")
                {
                    vocEngine.Speak("taku taku");
                }
                if(e.Result.Text == "notepad")
                {
                    vocEngine.Speak(e.Result.Text + "command Initiated");
                    Process.Start("notepad++");
                }
                if(e.Result.Text =="lock screen")
                {
                    vocEngine.Speak(e.Result.Text+ "command Initiated");
                    Process.Start("Rundll32.exe", "user32.dll,LockWorkStation");
                }
                if(e.Result.Text == "cancel")
                {
                    vocEngine.Speak("command cancelled");
                    SrecEngine.RecognizeAsyncCancel();
                }

            }

            finally
            {
                LoadMainGrammar(gmainbuilder, MrecEngine);
            }

        }

        private static void ListGrammars(SpeechRecognitionEngine recognizer)
        {
            // Make a copy of the recognizer's grammar collection.
            List<Grammar> loadedGrammars = new List<Grammar>(recognizer.Grammars);

            if (loadedGrammars.Count > 0)
            {
                Console.WriteLine("Loaded grammars:");
                foreach (Grammar g in recognizer.Grammars)
                {
                    Console.WriteLine(" - {0}", g.Name);
                }
            }
            else
            {
                Console.WriteLine("No grammars loaded.");
            }
            Console.WriteLine();
        }

        private static void LoadMainGrammar(GrammarBuilder builder, SpeechRecognitionEngine engine)
        {
            Grammar grammar = new Grammar(builder);
            engine.LoadGrammarAsync(grammar);
            engine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private static void InitializeBuilder(GrammarBuilder builder, Choices commands, SpeechRecognitionEngine engine)
        {
            builder.Append(commands);
            Grammar grammar = new Grammar(builder);
            engine.LoadGrammarAsync(grammar);
        }

        private void mute_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            if(mute_chkbox.Checked == true)
            {
                vocEngine.Speak("Voice Recognition disabled");
                MrecEngine.RecognizeAsyncStop();

                SrecEngine.RecognizeAsyncCancel();
                SrecEngine.RecognizeAsyncStop();
            }

            if(mute_chkbox.Checked == false)
            {
                vocEngine.Speak("Voice Recognition enabled");
                MrecEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
        }
    }
}
