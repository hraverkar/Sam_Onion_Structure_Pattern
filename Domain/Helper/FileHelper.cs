using ExcelDataReader;
using System;
using System.IO;

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

        public static void ReadFileExcel(byte[] excelFileContent)
        {
            using var stream = new MemoryStream(excelFileContent);
            // Create an ExcelDataReader object
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                // Read data row by row
                while (reader.Read())
                {
                    // Process each row
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetValue(i) + "\t");
                    }

                    Console.WriteLine(); // Move to the next line for the next row
                }
            }
        }

    }
}
