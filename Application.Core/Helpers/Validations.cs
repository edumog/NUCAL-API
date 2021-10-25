using NUCAL.Application.Core.DTOs;
using System;
using System.Collections.Generic;

namespace NUCAL.Application.Core.Helpers
{
    public static class Validations
    {
        public static ResponseDTO CheckAvailability(string propertyName, Object value)
        {
            ResponseDTO response = new ResponseDTO();
            if (value == null)
            {
                response.Succeeded = true;
                response.StatusCode = 200;
            }
            else
            {
                response.Succeeded = false;
                response.StatusCode = 400;
                response.Errors = new List<ErrorDTO>
                {
                    new ErrorDTO{ Code = "NotAvailable", Description = $"{ propertyName } is not available"}
                };
            }
            return response;
        }

        public static ResponseDTO CheckExistence(object item)
        {
            ResponseDTO response = new ResponseDTO();
            if (item == null)
            {
                response = GetNotFoundResponse(response);
            }
            else response.Succeeded = true;
            return response;
        }

        public static ResponseDTO CheckExistence<TItem>(List<TItem> items)
        {
            ResponseDTO response = new ResponseDTO();
            if (items.Count == 0)
            {
                response = GetNotFoundResponse(response);
            }
            else response.Succeeded = true;
            return response;
        }

        private static ResponseDTO GetNotFoundResponse(ResponseDTO response)
        {
            response.Succeeded = false;
            response.StatusCode = 404;
            response.Errors = new List<ErrorDTO>
            {
                new ErrorDTO{ Code = "NotFound", Description = "Not found" }
            };
            return response;
        }

    }
}
