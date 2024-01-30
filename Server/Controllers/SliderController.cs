using CustomCarousel.Server.Services;
using CustomCarousel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CustomCarousel.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderResimService _sliderResimService;

        public SliderController(ISliderResimService sliderResimService)
        {
            _sliderResimService = sliderResimService;
        }

        [HttpGet]
        public async Task<IActionResult> SliderlariAl()
        {
            Sonuc<List<SliderResim>> sonuc = new();
            sonuc = await _sliderResimService.SliderListesiniAl();
            return Ok(sonuc);
        }
    }
}