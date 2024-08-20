using nanoBaseCheck.Extensions.Interfaces;
using nanoBaseCheck.Infrastructure;
using Teigha.Runtime;

namespace nanoBaseCheck.CadCommands
{
    public static class AboutCmd
    {
        [CommandMethod("kpblc-about")]
        public static void AboutDialogCommand()
        {
            IMessageService msgService = new MessageService();
            msgService.InfoMessage("Версия приложения " + typeof(AboutCmd).Assembly.GetName().Version);
        }

        [CommandMethod("-kpblc-about")]
        public static void AboutCmdLineCommand()
        {
            IMessageService msgService = new MessageService();
            msgService.ConsoleMessage("Версия приложения " + typeof(AboutCmd).Assembly.GetName().Version);
        }
    }
}
