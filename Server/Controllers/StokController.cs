using CustomCarousel.Server.Services;
using CustomCarousel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CustomCarousel.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StokController : ControllerBase
{
    private readonly IStokBilgileriGetir _stokBilgileriGetir;

    public StokController(IStokBilgileriGetir stokBilgileriGetir)
    {
        _stokBilgileriGetir = stokBilgileriGetir;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        Sonuc<List<StokListesiBilgileri>> sonuc = new();
        sonuc = await _stokBilgileriGetir.StokListesiniAl();
        return Ok(sonuc);
    }
}
