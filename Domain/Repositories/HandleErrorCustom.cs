using Microsoft.AspNetCore.Mvc;
using System;

namespace ihandleErrorcustom
{
    public interface IHandleErrorCustom
    {
        IActionResult HandleException(Exception ex);

    }
}
