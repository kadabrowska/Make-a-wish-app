using MakeAWishApp.Data.Models;
using MakeAWishApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakeAWishApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftController : ControllerBase
    {
        private readonly GiftService _giftService;

        public GiftController(GiftService giftService)
        {
            _giftService = giftService;
        }

        [Authorize]
        [HttpGet("my-gifts")]
        public IActionResult GetGiftsForLoggedUser()
        {
            try
            {
                if (HttpContext.User == null)
                {
                    return BadRequest(new { message = "User context is null" });
                }
                var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId");
                if(userIdClaim ==  null)
                {
                    return BadRequest(new { message = "UserId claim is missing in the token" });
                }
                var userId = int.Parse(userIdClaim.Value);
                var gifts = _giftService.GetGiftsForLoggedUser(userId);
                return Ok(gifts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("add")]
        public IActionResult AddGift([FromBody] Gift gift)
        {
            try
            {
                _giftService.AddGift(gift.Name, gift.Price, gift.PurchaseLink);
                return Ok(new { message = "Gift has been added" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{giftId}")]
        public IActionResult UpdateGift(int giftId, [FromBody] Gift gift)
        {
            try
            {
                _giftService.UpdateGift(giftId, gift.Name, gift.Price, gift.PurchaseLink);
                return Ok(new { message = "Gift updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete/{giftId}")]
        public IActionResult DeleteGift(int giftId)
        {
            try
            {
                _giftService.DeleteGift(giftId);
                return Ok(new { message = "Gift deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
