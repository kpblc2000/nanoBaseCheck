using System;
using System.Runtime.CompilerServices;

namespace nanoBaseCheck.Extensions.Interfaces
{
    public  interface IMessageService
    {
        void InfoMessage(string Message,  [CallerMemberName] string CallMethod = null);
        void ErrorMessage(string Message,[CallerMemberName] string CallMethod = null);
        void ExceptionMessage(Exception Ex, [CallerMemberName] string CallMethod = null);
        void ConsoleMessage(string Message, [CallerMemberName] string CallMethod = null);
    }
}
