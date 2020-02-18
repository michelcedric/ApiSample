using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Base controller defintion
    /// </summary>
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Base method to return the correct http status code
        /// </summary>
        /// <returns></returns>       
        protected IActionResult StatusResultCode(object value)
        {
            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }
    }
}
