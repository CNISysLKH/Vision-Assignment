﻿using System.Runtime.InteropServices;
using System;

namespace CniVision
{
    public delegate void CallbackDelegate();

    public class DASK
    {


        public const ushort PCI_7230 = 6;

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

        public static string[] Input = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] Output = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] Check_Input = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] Check_Output = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };

        public static short WritePort_Output(ushort CardNumber, byte Port)
        {

            string sValue = "";
            for (int i = 15; i >= 0; --i)
            {
                sValue += Check_Output[i];
            }

            uint Value = (uint)Convert.ToInt16(sValue, 2);

            return DO_WritePort(CardNumber, Port, Value);
        }

        public static short ReadPort_Output(ushort CardNumber, byte Port)
        {
            short ret;
            uint in_Value;
            ret = DO_ReadPort(CardNumber, Port, out in_Value);

            string sValue = Convert.ToString(in_Value, 2).PadLeft(16, '0');

            for (int i = 15; i >= 0; --i)
            {
                Output[i] = sValue.Substring(15 - i, 1);

            }

            return ret;
        }

        public static short ReadPort_Input(ushort CardNumber, byte Port)
        {
            short ret;
            uint in_Value;
            ret = DI_ReadPort(CardNumber, Port, out in_Value);

            string sValue = Convert.ToString(in_Value, 2).PadLeft(16, '0');
            for (int i = 15; i >= 0; --i)
            {
                Input[i] = sValue.Substring(15 - i, 1);

            }



            return ret;
        }
    }
}
