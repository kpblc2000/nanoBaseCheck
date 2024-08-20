using HostMgd.ApplicationServices;
using HostMgd.EditorInput;
using nanoBaseCheck.Extensions.Interfaces;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Application = HostMgd.ApplicationServices.Application;

namespace nanoBaseCheck.Infrastructure
{
    internal class MessageService : IMessageService
    {
        public MessageService()
        {
            if (_appVersion == null)
            {
                _appVersion = typeof(MessageService).Assembly.GetName().Version;
            }
        }

        public void InfoMessage(string Message, [CallerMemberName] string CallMethod = null)
        {
            MessageBox.Show(GetMessage(Message, CallMethod), GetMsgBoxTitle("Инфо"), MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void ErrorMessage(string Message, [CallerMemberName] string CallMethod = null)
        {
            MessageBox.Show(GetMessage(Message, CallMethod), GetMsgBoxTitle("Ошибка"), MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public void ExceptionMessage(Exception Ex, [CallerMemberName] string CallMethod = null)
        {
            MessageBox.Show(GetMessage((Ex.Source ?? "") + " " + Ex.Message, CallMethod), GetMsgBoxTitle("Ошибка системы"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void ConsoleMessage(string Message, [CallerMemberName] string CallMethod = null)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null)
            {
                InfoMessage(Message, CallMethod);
                return;
            }
            Editor ed = doc.Editor;
            ed.WriteMessage("\n" + GetMessage(Message, CallMethod) + "\n");
        }

        private string GetMsgBoxTitle(string Title)
        {
            return _appName + " " + _appVersion + ": " + Title;
        }

        private string GetMessage(string Message, string CallMethod = null)
        {
#if DEBUG
            return (string.IsNullOrWhiteSpace(CallMethod) ? "" : $"{CallMethod} v.{_appVersion}: ") + Message;
#else
            return Message;
#endif
        }

        private static Version _appVersion;
        private readonly string _appName = "nanoCadCheck";
    }
}
