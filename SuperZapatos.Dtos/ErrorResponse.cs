namespace SuperZapatos.Dtos
{
    public class ErrorResponse
    {
        public string Error_Msg { get; set; }

        public int Error_Code { get; set; }

        public bool Success { get; set; }


        public ErrorResponse(string message, int code, bool success)
        {
            Error_Msg = message;
            Error_Code = code;
            Success = success;
        }

    }
}
