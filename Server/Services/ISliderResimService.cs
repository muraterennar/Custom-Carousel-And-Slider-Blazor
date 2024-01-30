using CustomCarousel.Shared;
using System.Data;

namespace CustomCarousel.Server.Services;

public interface ISliderResimService
{
    public DataTable SliderlariOku(string eksorgu = "", bool hatagoster = false);
    public Task<Sonuc<List<SliderResim>>> SliderListesiniAl();

    public Task<List<SliderResim>> SlideriListesiniDoldur(DataTable tablo);
}
