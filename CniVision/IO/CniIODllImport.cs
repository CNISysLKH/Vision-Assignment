using System;
using System.Runtime.InteropServices;

namespace CniVision.IO
{
    public static class CniIODllImport
    {
        public static readonly ushort PCI_7230 = 6;

        [DllImport("PCI-Dask64.dll")]
        public static extern short Register_Card(ushort CardType, ushort card_num);
        [DllImport("PCI-Dask64.dll")]
        public static extern short Release_Card(ushort CardNumber);
        [DllImport("PCI-Dask64.dll")]
        public static extern short DO_WritePort(ushort CardNumber, byte Port, uint Value);
        [DllImport("PCI-Dask64.dll")]
        public static extern short DO_ReadPort(ushort CardNumber, ushort Port, out uint Value);
        [DllImport("PCI-Dask64.dll")]
        public static extern short DI_ReadPort(ushort CardNumber, ushort Port, out uint Value);


        public static short WritePort_Output(ushort CardNumber, byte Port, string CheckOutput)
        {
            string sValue = "";
            for (int i = 15; i >= 0; --i)
            {
                sValue += CheckOutput[i];
            }
            uint Value = (uint)Convert.ToInt16(sValue, 2);

            return DO_WritePort(CardNumber, Port, Value);
        }

        public static short ReadPort_Output(ushort CardNumber, byte Port, ref string Output)
        {
            short ret;
            uint in_Value;
            ret = DO_ReadPort(CardNumber, Port, out in_Value);

            Output = Convert.ToString(in_Value, 2).PadLeft(16, '0');

            

            return ret;
        }

        public static short ReadPort_Input(ushort CardNumber, byte Port, ref string Input)
        {
            short ret;
            uint in_Value;
            ret = DI_ReadPort(CardNumber, Port, out in_Value);

            Input = Convert.ToString(in_Value, 2).PadLeft(16, '0');

            return ret;
        }




    }
}
