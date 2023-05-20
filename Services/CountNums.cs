using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityBot.Services
{
    public class CountNums
    {
        public static string SumNubers(string sourceText)
        {
            string[] signs = sourceText.Split(' ');
            int[] nums = new int[signs.Length];
            bool numCheck;

            try
            {
                for (int i = 0; i < signs.Length; i++)
                {
                    numCheck = Int32.TryParse(signs[i], out nums[i]);

                    if (numCheck == false)
                        throw new Exception("Сообщение должно содержать только натуральные числа, записанные через пробел");
                }

                int sumResult = 0;
                foreach (int num in nums)
                {
                    if (num <= int.MaxValue || num >= int.MinValue)
                        sumResult += num;
                    else
                        throw new Exception("Число не подходящего размера:(");
                }
                return sumResult.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return e.Message;
            }
        }
    }
}

