using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AluPlast.ControlLoader.MyService
{
    public class Generator
    {
        private Timer _Timer;

        public Generator(string address)
        {
            this._Timer = new Timer(1000);
            this._Timer.Elapsed += _Timer_Elapsed;

        }

        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Tik");
        }

        

        public void Start()
        {
            Console.WriteLine("Generator started!");

            _Timer.Start();
        }

        public void Stop()
        {
            _Timer.Stop();

            Console.WriteLine("Generator stopped!");
        }
    }
}
