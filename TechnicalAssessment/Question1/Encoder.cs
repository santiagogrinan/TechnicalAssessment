using System;
using System.Collections.Generic;
using System.Text;

namespace Question1
{
    class Encoder
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Public
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public Encoder()
        {
            m_transcode = CreateTranscode();
        }

        //=====================================================================
        public string Encode(string input)
        {
            return Encode(input, m_transcode);
        }

        //=====================================================================
        public string Decode(string input)
        {
            return Decode(input, m_transcode);
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Static Functions
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        static string Encode(string input, char[] transcode)
        {
            int l = input.Length;
            int cb = (l / 3 + (Convert.ToBoolean(l % 3) ? 1 : 0)) * 4;

            char[] output = new char[cb];
            for (int i = 0; i < cb; i++)
            {
                output[i] = '=';
            }

            int c = 0;
            int reflex = 0;
            const int s = 0x3f;

            for (int j = 0; j < l; j++)
            {
                reflex <<= 8;
                reflex &= 0x00ffff00;
                reflex += input[j];

                int x = ((j % 3) + 1) * 2;
                int mask = s << x;
                while (mask >= s)
                {
                    int pivot = (reflex & mask) >> x;
                    output[c++] = transcode[pivot];
                    int invert = ~mask;
                    reflex &= invert;
                    mask >>= 6;
                    x -= 6;
                }
            }

            switch (l % 3)
            {
                case 1:
                    reflex <<= 4;
                    output[c++] = transcode[reflex];
                    break;

                case 2:
                    reflex <<= 2;
                    output[c++] = transcode[reflex];
                    break;

            }
            
            return new string(output);
        }

        //=====================================================================
        static string Decode(string input, char[] transcode)
        {
            int l = input.Length;
            int cb = (l / 4 + ((Convert.ToBoolean(l % 4)) ? 1 : 0)) * 3;
            char[] output = new char[cb];
            int c = 0;
            int bits = 0;
            int reflex = 0;
            for (int j = 0; j < l; j++)
            {
                reflex <<= 6;
                bits += 6;
                bool fTerminate = ('=' == input[j]);
                if (!fTerminate)
                    reflex += indexOf(input[j], transcode);

                while (bits >= 8)
                {
                    int mask = 0x000000ff << (bits % 8);
                    output[c++] = (char)((reflex & mask) >> (bits % 8));
                    int invert = ~mask;
                    reflex &= invert;
                    bits -= 8;
                }

                if (fTerminate)
                    break;
            }

            return new string(output);
        }

        //=====================================================================
        static char[] CreateTranscode()
        {
            char[] result = new char[64];
            for (int i = 0; i < 64; i++)
            {
                result[i] = (char)((int)'A' + i);
                if (i > 25) result[i] = (char)((int)result[i] + 6);
                if (i > 51) result[i] = (char)((int)result[i] - 0x4b);
            }
            result[62] = '+';
            result[63] = '/';

            return result;
        }

        //=====================================================================
        static int indexOf(char ch, char[] transcode)
        {
            int index;
            for (index = 0; index < transcode.Length; index++)
                if (ch == transcode[index])
                    break;
            return index;
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Fields
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        static char[] m_transcode;

        #endregion
    }
}
