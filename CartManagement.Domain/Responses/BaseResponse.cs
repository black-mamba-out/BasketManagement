using System;
namespace CartManagement.Domain.Responses
{
    public class BaseResponse
    {
        public string ErrorMessage { get; set; }
        public string ResultMessage { get; set; }
    }
}
