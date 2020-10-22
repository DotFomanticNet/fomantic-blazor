using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fomantic.Blazor.Docs.Helpers
{
    public static class FileUtil
    {
        public async static Task SaveAs(this IJSRuntime js, string filename, byte[] data)
        {
            await js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));
        }

        public async static Task SaveAs(this IJSRuntime js, string filename, string data)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(data);
            await js.SaveAs(filename, bytes);
        }
    }
}
