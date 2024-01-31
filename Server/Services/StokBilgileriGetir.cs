using CustomCarousel.Shared;
using System.Data;
using System.Data.SqlClient;

namespace CustomCarousel.Server.Services;

public class StokBilgileriGetir : IStokBilgileriGetir
{
    private readonly string connectionString = "data source = 'SERVER\\ETA';DataBase=HRZ_KATRE_CIAS;Trusted_Connection=no;user ID=sa;Password=Eta.2017;";

    public DataTable StokListesiniGetir(string eksorgu = "", bool hatagoster = false)
    {
        try
        {
            string komutstr = @"SELECT id, Kategoriid, StokKodu, StokCinsi, Birim, Birim2, Aciklama1, Aciklama2, Aciklama3, Aciklama4, Aciklama5, GrupKodu, SL.KategoriKodu, KL.KategoriAdi, Resim,Resim2, Fiyat1, Fiyat2, Fiyat3, Fiyat4, Fiyat5, KDVOrani, OzelKod1, OzelKod2, OzelKod3, OzelKod4, OzelKod5, StokAktif,tevkifatKodu,tevkifatOrani, DovizKodu1, DovizKodu2, DovizKodu3, DovizKodu4, DovizKodu5, DovizTuru1, DovizTuru2, DovizTuru3, DovizTuru4, DovizTuru5 From StokListesi SL
                    Left Join (SELECT KategoriKod, KategoriAdi from KategoriListesi) KL on KL.KategoriKod = SL.KategoriKodu";
            DataTable table = new DataTable();

            using(SqlConnection kli_baglanti = new(connectionString))
            {
                if(kli_baglanti.State == ConnectionState.Closed)
                {
                    kli_baglanti.Open();
                }

                using(SqlCommand kli_komut = new(komutstr, kli_baglanti))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(kli_komut);

                    sqlDataAdapter.Fill(table);
                }

                if(kli_baglanti.State == ConnectionState.Open)
                    kli_baglanti.Close();
            }

            return table;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<StokListesiBilgileri>> StokBilgileriListesiniDoldur(DataTable tablo)
    {
        List<StokListesiBilgileri> klbListe = new List<StokListesiBilgileri>();
        for(int i = 0; i < tablo.Rows.Count; ++i)
        {
            StokListesiBilgileri klb = new StokListesiBilgileri();
            /*string komutstr = @"SELECT id, KategoriUstid, KategoriAltid, KategoriStokBaglanabilir, KategoriStokVar, KategoriAktif, KategoriKod, KategoriAdi From KategoriListesi";*/
            klb.id = Convert.ToInt32(tablo.Rows[i]["id"]);
            klb.kategoriAdi = tablo.Rows[i]["KategoriAdi"].ToString();
            klb.kategoriid = Convert.ToInt32(tablo.Rows[i]["Kategoriid"]);
            klb.kategorikodu = tablo.Rows[i]["KategoriKodu"].ToString();
            klb.KDVliGercekFiyat = Convert.ToInt32(tablo.Rows[i]["Fiyat1"]);
            klb.stokcinsi = tablo.Rows[i]["StokCinsi"].ToString();
            klb.aciklama1 = tablo.Rows[i]["Aciklama1"].ToString();
            klb.fiyat1 = Convert.ToInt32(tablo.Rows[i]["Fiyat1"]);
            klb.gercekFiyat = Convert.ToInt32(tablo.Rows[i]["Fiyat1"]);
            klbListe.Add(klb);
        }
        return klbListe;
    }

    public async Task<Sonuc<List<StokListesiBilgileri>>> StokListesiniAl()
    {
        Sonuc<List<StokListesiBilgileri>> sonuc = new();
        string baglantistr = connectionString;

        SqlConnection baglanti = new SqlConnection(baglantistr);

        try
        {

            DataTable tablo = StokListesiniGetir();
            if(tablo == null)
            {
                sonuc.sonuc = false;
                sonuc.mesaj = "";
                sonuc.data = null;
            }
            else if(tablo.Rows.Count == 0)
            {
                sonuc.sonuc = false;
                sonuc.mesaj = "Henüz kategoriler eklenmemiş.";
                sonuc.data = new List<StokListesiBilgileri>();
            }
            else
            {
                List<StokListesiBilgileri> klbListe = await StokBilgileriListesiniDoldur(tablo);
                sonuc.sonuc = true;
                sonuc.mesaj = "Başarılı";
                sonuc.data = klbListe;
            }
        }
        catch(Exception ex)
        {
            sonuc.mesaj = ex.Message;
            sonuc.sonuc = false;
            sonuc.data = null;
        }
        return sonuc;
    }
}