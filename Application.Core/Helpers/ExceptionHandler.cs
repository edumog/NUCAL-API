using NUCAL.Application.Core.DTOs;
using System;
using System.Collections.Generic;

namespace NUCAL.Application.Core.Helpers
{
    public static class ExceptionHandler
    {
        public static ResponseDTO GetResult(Exception exception)
        {
            ResponseDTO response = new ResponseDTO();
            response.Succeeded = false;
            response.StatusCode = 500;
            response.Errors = new List<ErrorDTO>();
            response.Errors.Add(new ErrorDTO()
            {
                Code = exception.GetType().Name,
                Description = exception.Message
            });
            return response;
        }
    }
}
