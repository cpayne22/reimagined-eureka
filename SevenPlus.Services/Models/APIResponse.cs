using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenPlus.Services.Models
{
    public class APIResponse<T>
    {
        public bool IsValid { get; set; }
        public T ReturnValue { get; set; }
        public APIResponseError Error { get; set; }

        public APIResponse()
        {
            IsValid = true;
        }

        public APIResponse(T obj)
        {
            ReturnValue = obj;
        }
    }

    public class APIResponseError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public APIResponseError(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public APIResponseError(Exception e)
        {
            PropertyName = "";
            ErrorMessage = e.Message;
            if (e.InnerException != null)
            {
                ErrorMessage += "\r\n"+  e.InnerException;
            }
        }
    }
}
