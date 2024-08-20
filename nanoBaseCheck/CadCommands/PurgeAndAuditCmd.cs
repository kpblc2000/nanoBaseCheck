using HostMgd.ApplicationServices;
using Teigha.Runtime;

namespace nanoBaseCheck.CadCommands
{
    public static class PurgeAndAuditCmd
    {
        [CommandMethod("-kpblc-purge-and-audit")]
        public static void PurgeNadAuditCommand()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null)
            {
                return;
            }

            // Вот здесь ошибка - пространство имен nanoCAD тупо не опознается
            nanoCAD.Document comDoc = doc.AcadDocument as nanoCAD.Document;
        }
    }
}
