using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menus.Model
{
    public static class UpdateAssistant
    {
        private static int matId;
        private static string matText;
        private static string matTime;
        public static int MatId { get => matId; set => matId = value; }
        public static string MatText { get => matText; set => matText = value; }
        public static string MatTime { get => matTime; set => matTime = value; }
    }
}
