using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContractsAndDot.Services
{
    internal class TransformService
    {
        public string TransformToJson(dynamic obj)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string inJson = JsonSerializer.Serialize(obj, options);
            return inJson;
        }

        public void WriteToFile(string path, string inJson)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(inJson);
                fileStream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}
