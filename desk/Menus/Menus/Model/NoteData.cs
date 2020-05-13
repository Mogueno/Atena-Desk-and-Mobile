using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menus
{
    public static class NoteData
    {
        private static int facId;
        private static int curId;
        private static int matId;
        private static int noteid;

        public static int FacId { get => facId; set => facId = value; }
        public static int CurId { get => curId; set => curId = value; }
        public static int MatId { get => matId; set => matId = value; }
        public static int Noteid { get => noteid; set => noteid = value; }
    }
}
