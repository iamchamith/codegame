using System;
using System.Windows.Forms;
using BlocklyPro.ServiceRepository;
using BlocklyPro.ServiceRepository.Identity;
using BlocklyPro.Utility;
using SimpleInjector;

namespace BlocklyPro
{
    static class Program
    {
        private static Container container;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(GlobalConfig.Container.GetInstance<FrmLogin>());
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("some error happen");
        }
        private static void Bootstrap()
        {
            // Create the container as usual.
            GlobalConfig.Container = new Container();

            // Register your types, for instance:
            GlobalConfig.Container.Register<IXHRServiceRepository, XHRServiceRepository>(Lifestyle.Singleton);
            GlobalConfig.Container.Register<IIdentityServiceRepository, IdentityServiceRepository>();
            GlobalConfig.Container.Register<IGameServiceRepository, GameServiceRepository>();
            GlobalConfig.Container.Register<FrmLogin>();
 
        }
    }
}
