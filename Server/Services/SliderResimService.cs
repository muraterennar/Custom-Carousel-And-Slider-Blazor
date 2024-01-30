using CustomCarousel.Shared;
using System.Data;
using System.Data.SqlClient;

namespace CustomCarousel.Server.Services;

public class SliderResimService : ISliderResimService
{
    private readonly string connectionString = "data source = 'SERVER\\ETA';DataBase=HRZ_KATRE_CIAS;Trusted_Connection=no;user ID=sa;Password=Eta.2017;";

    public DataTable SliderlariOku(string eksorgu = "", bool hatagoster = false)
    {
        try
        {
            string komutstr = @"SELECT id,SliderAdi,SliderLinki,SliderLinkFlag,SliderAktifFlag,SliderResim,Hazirlayan,Tarih,resimId,ResimTuruFlag,SiraNo FROM SliderResim";
            komutstr += " " + eksorgu;
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


    public async Task<List<SliderResim>> SlideriListesiniDoldur(DataTable tablo)
    {
        List<SliderResim> klbListe = new List<SliderResim>();
        for(int i = 0; i < tablo.Rows.Count; ++i)
        {
            SliderResim klb = new SliderResim();
            /*string komutstr = @"SELECT id, KategoriUstid, KategoriAltid, KategoriStokBaglanabilir, KategoriStokVar, KategoriAktif, KategoriKod, KategoriAdi From KategoriListesi";*/
            klb.id = Convert.ToInt32(tablo.Rows[i]["id"]);
            klb.sliderAdi = tablo.Rows[i]["SliderAdi"].ToString();
            klb.sliderLinki = tablo.Rows[i]["SliderLinki"].ToString();
            klb.sliderResim = tablo.Rows[i]["SliderResim"].ToString();
            klb.hazirlayan = tablo.Rows[i]["Hazirlayan"].ToString();
            klb.tarih = Convert.ToDateTime(tablo.Rows[i]["Tarih"]);
            klb.resimId = Guid.Parse(tablo.Rows[i]["resimId"].ToString());
            klb.sliderLinkFlag = Convert.ToInt32(tablo.Rows[i]["SliderLinkFlag"]);
            klb.sliderAktifFlag = Convert.ToInt32(tablo.Rows[i]["SliderAktifFlag"]);
            klb.ResimTuruFlag = Convert.ToInt32(tablo.Rows[i]["ResimTuruFlag"]);
            klb.siraNo = Convert.ToInt32(tablo.Rows[i]["SiraNo"]);
            klbListe.Add(klb);
        }
        return klbListe;
    }

    public async Task<Sonuc<List<SliderResim>>> SliderListesiniAl()
    {
        Sonuc<List<SliderResim>> sonuc = new();
        string baglantistr = connectionString;

        SqlConnection baglanti = new SqlConnection(baglantistr);

        try
        {

            DataTable tablo = SliderlariOku();
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
                sonuc.data = new List<SliderResim>();
            }
            else
            {
                List<SliderResim> klbListe = await SlideriListesiniDoldur(tablo);
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