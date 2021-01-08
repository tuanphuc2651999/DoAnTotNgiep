using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Liz.DoAn
{
   public class Commons
    {
        public static bool IsValidDate(string inputValue, string format)
        {
            try
            {
                var date = DateTime.ParseExact(inputValue.ToString(), format, CultureInfo.CurrentCulture);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DateTime ConvertStringToDate(string date)
        {         
            DateTime dateTime = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            return dateTime;
        }
        public static string FormatHoTen(string hoTen)
        {
            string hoTenMoi = "";
            List<char> hovaTen = new List<char>();
            foreach (var item in hoTen.Trim())
            {
                hovaTen.Add(item);
            }
            hovaTen[0] = char.ToUpper(hovaTen[0]);
            for (int i = 0; i < hovaTen.Count; i++)
            {
                if (hovaTen[i] == 32)
                {
                    if (hovaTen[i + 1] != 32)
                    {
                        hovaTen[i + 1] = char.ToUpper(hovaTen[i + 1]);
                    }
                }
            }
            for (int i = 0; i < hovaTen.Count; i++)
            {
                if (hovaTen[i] == 32)
                {
                    if (hovaTen[i - 1] == 32)
                    {
                        hovaTen.RemoveAt(i);
                        i--;
                    }
                }
            }

            foreach (var item in hovaTen)
            {
                hoTenMoi += item;
            }
            return hoTenMoi;
        }

        public static bool KiemTraEmailHopLe(string emailaddress)
        {
            return Regex.IsMatch(emailaddress, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
