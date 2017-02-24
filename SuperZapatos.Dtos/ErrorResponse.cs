using System.Runtime.Serialization;

namespace SuperZapatos.Dtos
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember(Name ="error_msg")]
        public string Error_Msg { get; set; }

        [DataMember(Name = "error_code")]
        public int Error_Code { get; set; }

        [DataMember(Name = "success")]
        public bool Success { get; set; }


        public ErrorResponse(string message, int code, bool success)
        {
            Error_Msg = message;
            Error_Code = code;
            Success = success;
        }

    }
}
