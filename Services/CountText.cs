using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBot.Services
{
    public class CountText
    {
        public static int GetCharCount(string text)
        {
            return text.Replace(" ", "").Length;
        }
    }
}




//* static int GetCharCount(string text)

//*    {

//*return text.Replace(" ","").Length;

//*   }

//*static int SumTextLength(string Text)

//*    {

//*  return Text.Length;

//*    }  /*

