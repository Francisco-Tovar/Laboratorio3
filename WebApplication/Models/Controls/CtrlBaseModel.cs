using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlBaseModel
    {

        public string Id { get; set; }
        public string ViewName { get; set; }

        private string ReadFileText()
        {            
            string path = System.Configuration.ConfigurationManager.AppSettings["PathTemplates"];
            string combinedPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            string fileName = this.GetType().Name + ".html";

            path = combinedPath + fileName;
                
            string text = System.IO.File.ReadAllText(path);

            return text;
        }

        public string GetHtml()
        {
            var html = ReadFileText();

            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop != null) { 
                    var value = prop.GetValue(this, null).ToString();

                    var tag = string.Format("-#{0}-", prop.Name);
                    html = html.Replace(tag, value);
                }
            }
            return html;
        }
    }
}