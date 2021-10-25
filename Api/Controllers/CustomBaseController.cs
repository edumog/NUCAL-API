using Microsoft.AspNetCore.Mvc;
using NUCAL.Application.Core.DTOs;
using System;

namespace NUCAL.Api.Controllers
{
    public class CustomBaseController: ControllerBase
    {

        protected ActionResult GetCreationResponse(ResponseDTO response, Object item, string itemId = null, string routeName = null)
        {
            if(response.StatusCode == 201 && itemId == null && routeName == null)
            {
                return new CreatedResult("", item);
            }else if(response.StatusCode == 201)
            {
                return new CreatedAtRouteResult(routeName, new { id = itemId }, item);
            }
            else
            {
                return GetResponse(response, item);
            }
        }
        
        protected ActionResult GetResponse(ResponseDTO response, Object item = null)
        {
            switch(response.StatusCode)
            {
                case 200: case 204:
                    return new OkObjectResult(item);
                case 400:
                    return BadRequest();
                case 404:
                    return NotFound();
                case 500:
                    return new StatusCodeResult(500);
                default:
                    return Ok();
            }
        }

    }
}
