

using Entities_POJO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlDropDownModel : CtrlBaseModel
    {
       
        public string Label { get; set; }
        public string ListId { get; set; }

        private string URL_API_LISTs = "https://localhost:44384/api/list/";

        public string ListOptions
        {
            get
            {
                var htmlOptions = "";
                var lst = GetOptionsFromAPI();

                foreach(var option in lst)
                {
                    htmlOptions += "<option value='" + option.Description + "'>" + option.Value + "</option>";
                }
                return htmlOptions;
            }
            set
            {

            }
        }


        private List<OptionList> GetOptionsFromAPI()
        {
            var client = new WebClient();
            var response = client.DownloadString(URL_API_LISTs + ListId);
            var options = JsonConvert.DeserializeObject<List<OptionList>>(response); 
            return options;
        }


    
        public CtrlDropDownModel()
        {
            ViewName = "";
        }
    }
}