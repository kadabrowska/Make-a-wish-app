using MakeAWishApp.Data.Models;
using MakeAWishApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakeAWishApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly AssignmentService _assignmentService;

        public AssignmentController(AssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpPost("assign")]
        public IActionResult AssigGift([FromBody] AssignmentRequest request) 
        {
            try
            {
                _assignmentService.AddAssignmentForGiver(request.GiverId, request.ReceiverId);
                return Ok("Assignment completed");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("my-assignment/delete")]
        public IActionResult DeleteAssignmentForGiver()
        {
            try
            {
                var giverIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId");
                if(giverIdClaim == null)
                {
                    return Unauthorized("UserId not fount in token");
                }

                var giverId = int.Parse(giverIdClaim.Value);

                _assignmentService.DeleteAssignmentForGiver(giverId);

                return Ok("Assignment deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("my-assignment")]
        public IActionResult GetAssignmentForGiver(int giverId)
        {
            var giverIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (giverIdClaim == null)
            {
                return Unauthorized("UserId not fount in token");
            }

            var giverLoggedIn = int.Parse(giverIdClaim.Value);

            _assignmentService.GetAssignmentForGiver(giverId);

            return Ok();
        }


    }
}
