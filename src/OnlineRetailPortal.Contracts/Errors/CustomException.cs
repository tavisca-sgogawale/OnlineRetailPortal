﻿using OnlineRetailPortal.Contracts.Errors;

namespace OnlineRetailPortal.Contracts.Errors
{
    public class CustomException : BaseException
    {
        public CustomException(int code) : base(CustomErrorCodes.getErrorMessage(code), code)
        {
        }
    }

}
