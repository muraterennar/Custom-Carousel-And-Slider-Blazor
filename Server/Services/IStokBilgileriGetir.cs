using CustomCarousel.Shared;
using System.Data;
using System.Data.SqlClient;

namespace CustomCarousel.Server.Services;

public interface IStokBilgileriGetir
{
    public DataTable StokListesiniGetir(string eksorgu = "", bool hatagoster = false);
    public Task<List<StokListesiBilgileri>> StokBilgileriListesiniDoldur(DataTable tablo);
    public Task<Sonuc<List<StokListesiBilgileri>>> StokListesiniAl();
}
