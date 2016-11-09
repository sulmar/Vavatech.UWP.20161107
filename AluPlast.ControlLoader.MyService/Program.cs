using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AluPlast.ControlLoader.MyService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<Generator>(sc =>
                {
                    sc.ConstructUsing(() => new Generator("http://www.vavatech.pl"));
                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.Stop());
                });


                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.StartAutomatically();
                hostConfigurator.EnableShutdown();

                hostConfigurator.SetServiceName("MyService");
                hostConfigurator.SetDisplayName("My Service");
                hostConfigurator.SetDescription("My Super Service");

                hostConfigurator.StartAutomatically();
            });


         
        }
    }
}
