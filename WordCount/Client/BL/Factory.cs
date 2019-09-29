using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Client.Models;

namespace Client
{
    public interface IText
    {
        string GetText();
    }

    public class GetTextFromFile : IText
    {
        public string GetText()
        {
            string result = "";
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Files|*.txt";
            var dialog_result = fileDialog.ShowDialog();

            if(dialog_result == DialogResult.OK)
            {
                string path = fileDialog.FileName;
                result = File.ReadAllText(path);
            }

            return result;
        }
    }

    public class GetTextFromDatabase : IText
    {
        public string GetText()
        {
            return GetTextData();
        }

        private string GetTextData()
        {
            string result = "";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:6600");
            HttpResponseMessage response = client.GetAsync("api/text/get").Result;
            if(response.IsSuccessStatusCode)
            {
                TextData textData = response.Content.ReadAsAsync<TextData>().Result;
                result = textData.Text;
            }

            return result;
        }
    }

    public static class TextFactory
    {
        public static IText Instance(string from)
        {
            if(from == "File")
            {
                return new GetTextFromFile();
            }
            else if(from == "Database")
            {
                return new GetTextFromDatabase();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
