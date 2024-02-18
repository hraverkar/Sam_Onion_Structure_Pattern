using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public static class FileHelper
    {
        public static byte[] FileStringToBase(string file)
        {
            if (string.IsNullOrEmpty(file))
                return null;
            var dataParts = file.Split(';');
            if (dataParts.Length > 1)
            {
                var base64Data = dataParts[1].Split(',');

                if (base64Data.Length > 1)
                {
                    return Convert.FromBase64String(base64Data[1]);
                }
            }
            return null;
        }

    }
}
