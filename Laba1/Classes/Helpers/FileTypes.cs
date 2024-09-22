using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Laba1.Classes.Helpers
{
    public static class FileTypes
    {
        public static readonly FilePickerFileType Text = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            { DevicePlatform.Android, new[] { "text/plain" } },
            { DevicePlatform.iOS, new[] { "public.text" } },
            { DevicePlatform.macOS, new[] { "public.text" } },
            { DevicePlatform.WinUI, new[] { ".txt" } },
        });
    }
}