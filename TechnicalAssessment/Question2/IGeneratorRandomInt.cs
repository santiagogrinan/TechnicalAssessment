using System;
using System.Collections.Generic;
using System.Text;

namespace Question2
{
    public interface IGeneratorRandomInt
    {
        public int GenerateInt(int minVal, int maxVAL); 
    }

    public class Generator : IGeneratorRandomInt
    {
        public int GenerateInt(int minVal, int maxVAL)
        {
            Random random = new Random();
            return random.Next(minVal, maxVAL);
        }
    }
}
