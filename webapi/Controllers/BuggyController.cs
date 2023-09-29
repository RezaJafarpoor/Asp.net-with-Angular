using Infrastructure.DataBase;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi.errors;

namespace webapi.Controllers
{
    public class BuggyController: BaseApiController
    
    {
        private readonly StoreContext storeContext;

        public BuggyController(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest() {
            var thing = storeContext.Products.Find(42);
            if(thing == null) {
                return NotFound(new ApiResponse(404));
            }
            return Ok();

        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = storeContext.Products.Find(42);
            


            return Ok();

        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            


            return BadRequest(new ApiResponse(400));

        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetbadRequest(int id)
        {
            


            return Ok();

        }

    }
}
