using ihandleErrorcustom;
using Microsoft.AspNetCore.Mvc;



namespace handleErrorCustumer
{
    public class HandleErrorCustumer : IHandleErrorCustom
    {
        public IActionResult HandleException(Exception ex)
        {
            if (ex is CustomError customError)
            {
                return new ObjectResult(new { MessageError = customError.Message })
                {
                    StatusCode = 400,
                };
            }

            return new ObjectResult(new { Message = "Erro genérico.", ex })
            {
                StatusCode = 500,
            };
        }
    }
}
