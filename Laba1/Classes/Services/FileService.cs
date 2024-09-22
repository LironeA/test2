using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;

namespace Laba1.Classes.Services
{
    public class FileService
    {
        public async Task<int[]> ReadIntArrayFromFileAsync(FileResult file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            using var stream = await file.OpenReadAsync();
            using var reader = new StreamReader(stream);
            string text = await reader.ReadToEndAsync();

            string[] tokens = text.Split(new[] { ' ', '\r', '\n', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> integers = new List<int>();

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number))
                    integers.Add(number);
                else
                    throw new FormatException("Файл містить нецілі числа.");
            }

            return integers.ToArray();
        }

        public async Task SaveIntArrayToFileAsync(int[] array, string filePath)
        {
            var text = string.Join(" ", array);
            using var writer = new StreamWriter(filePath, false);
            await writer.WriteAsync(text);
        }
    }
}
