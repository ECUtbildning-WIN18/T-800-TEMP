using System;
using System.Text;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace T800.Domain
{
    class Selfdestruct
    {
        public void Selfdestruction()
        {
            {
                //Title
                Console.WriteLine("     +--------------------------------+");
                Console.WriteLine("     |                                |");
                Console.WriteLine("     |  Self-Destruction for Robots   |");
                Console.WriteLine("     |                                |");
                Console.WriteLine("     +--------------------------------+");
                //Progressbar
                Console.WriteLine("Preparing for Self-Destruction..");
                Console.Write("Self-Destruction... ");
                using (var progress = new ProgressBar())
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        progress.Report((double)i / 100);
                        Thread.Sleep(20);
                    }
                }
                Console.WriteLine("Robot Succesfully Terminated.");
                //Terminated-art
                Console.WriteLine("      NO!                           MNO!");
                Console.WriteLine("     MNO!!         [NBK]           MNNOO!");
                Console.WriteLine("    MMNO!                           MNNOO!!");
                Console.WriteLine("   MNOONNOO!   MMMMMMMMMMPPPOII!  MNNO!!!!");
                Console.WriteLine("   !O! NNO! MMMMMMMMMMMMMPPPOOOII!! NO!");
                Console.WriteLine("         ! MMMMMMMMMMMMMPPPPOOOOIII! !");
                Console.WriteLine("          MMMMMMMMMMMMPPPPPOOOOOOII!!");
                Console.WriteLine("          MMMMMOOOOOOPPPPPPPPOOOOMII!");
                Console.WriteLine("          MMMMM..    OPPMMP    .,OMI!");
                Console.WriteLine("          MMMM::   o.,OPMP,.o   ::I!!");
                Console.WriteLine("            NNM:::.,, OOPM!P,.::::!!");
                Console.WriteLine("           MMNNNNNOOOOPMO!!IIPPO!!O!");
                Console.WriteLine("           MMMMMNNNNOO: !!:!!IPPPPOO!");
                Console.WriteLine("            MMMMMNNOOMMNNIIIPPPOO!!");
                Console.WriteLine("               MMMONNMMNNNIIIOO!");
                Console.WriteLine("             MN MOMMMNNNIIIIIO!OO");
                Console.WriteLine("            MNO! IiiiiiiiiiiiI OOOO");
                Console.WriteLine("       NNN.MNO!   O!!!!!!!!!O   OONO NO!");
                Console.WriteLine("      MNNNNNO!    OOOOOOOOOOO    MMNNON!");
                Console.WriteLine("        MNNNNO!    PPPPPPPPP    MMNON!");
                Console.WriteLine("           OO!                   ON!");
                Environment.Exit(0);
            }
        }
public class ProgressBar : IDisposable, IProgress<double>
        {
            private const int blockCount = 10;
            private readonly TimeSpan animationInterval = TimeSpan.FromSeconds(1.0 / 8);
            private const string animation = @"|/-\";
            private readonly Timer timer;
            private double currentProgress = 0;
            private string currentText = string.Empty;
            private bool disposed = false;
            private int animationIndex = 0;
            public ProgressBar()
            {
                timer = new Timer(TimerHandler);
                if (!Console.IsOutputRedirected)
                {
                    ResetTimer();
                }
            }
            public void Report(double value)
            {
                // Make sure value is in [0..1] range
                value = Math.Max(0, Math.Min(1, value));
                Interlocked.Exchange(ref currentProgress, value);
            }
            private void TimerHandler(object state)
            {
                lock (timer)
                {
                    if (disposed) return;
                    int progressBlockCount = (int)(currentProgress * blockCount);
                    int percent = (int)(currentProgress * 100);
                    string text = string.Format("[{0}{1}] {2,3}% {3}",
                        new string('#', progressBlockCount), new string('-', blockCount - progressBlockCount),
                        percent,
                        animation[animationIndex++ % animation.Length]);
                    UpdateText(text);
                    ResetTimer();
                }
            }
            private void UpdateText(string text)
            {
                int commonPrefixLength = 0;
                int commonLength = Math.Min(currentText.Length, text.Length);
                while (commonPrefixLength < commonLength && text[commonPrefixLength] == currentText[commonPrefixLength])
                {
                    commonPrefixLength++;
                }
                StringBuilder outputBuilder = new StringBuilder();
                outputBuilder.Append('\b', currentText.Length - commonPrefixLength);
                outputBuilder.Append(text.Substring(commonPrefixLength));
                int overlapCount = currentText.Length - text.Length;
                if (overlapCount > 0)
                {
                    outputBuilder.Append(' ', overlapCount);
                    outputBuilder.Append('\b', overlapCount);
                }
                Console.Write(outputBuilder);
                currentText = text;
            }
            private void ResetTimer()
            {
                timer.Change(animationInterval, TimeSpan.FromMilliseconds(-1));
            }
            public void Dispose()
            {
                lock (timer)
                {
                    disposed = true;
                    UpdateText(string.Empty);
                }
            }
        }
    }
}


