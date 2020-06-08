using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public string StyleCssClass { get; set; }
        public string IconCssClass { get; set; }
        public string ToasterClass { get; set; }

        public ResponseModel()
        {

        }

        public ResponseModel(string message, ResponseType type)
        {
            if (type == ResponseType.Success)
            {
                IconCssClass = "fa-check";
                StyleCssClass = "alert-success";
                Title = "Success";
                ToasterClass = "success";
            }
            else if (type == ResponseType.Failure)
            {
                IconCssClass = "fa-ban";
                StyleCssClass = "alert-danger";
                Title = "Error";
                ToasterClass = "error";
            }
            Message = message;
        }
    }
}
