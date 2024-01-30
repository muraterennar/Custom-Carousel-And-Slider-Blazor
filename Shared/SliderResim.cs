namespace CustomCarousel.Shared;

public class SliderResim
{
    public int id { get; set; }
    public string sliderAdi { get; set; }
    public string sliderLinki
    {
        get;
        set;
    }
    public int sliderLinkFlag { get; set; }
    public bool sliderLinkVarMi
    {
        get
        {
            if(sliderLinkFlag == 1)
                return true;
            else
                return false;
        }
        set
        {
            if(value)
                sliderLinkFlag = 1;
            else
                sliderLinkFlag = 0;
        }

    }
    public int sliderAktifFlag { get; set; }

    public bool sliderAktifMi
    {
        get
        {
            if(sliderAktifFlag == 1)
                return true;
            else
                return false;
        }
        set
        {
            if(value)
                sliderAktifFlag = 1;
            else
                sliderAktifFlag = 0;
        }

    }

    public int ResimTuruFlag { get; set; } //1: Slider Resim, 2: Düz Resim

    public string sliderResim { get; set; }
    public int siraNo { get; set; }

    public string hazirlayan { get; set; }
    public DateTime tarih { get; set; }
    public Guid resimId { get; set; }
    //public DosyaYukleme Resim { get; set; }
    //public DosyaBilgi DosyaBilgi { get; set; }

    public SliderResim()
    {
        id = 0;
        ResimTuruFlag = 1;
        sliderAdi = "";
        sliderLinki = "";
        sliderLinkFlag = 0;
        sliderAktifFlag = 0;
        sliderResim = "";
        hazirlayan = "";
        tarih = DateTime.Now;
        //Resim = new DosyaYukleme();
        //DosyaBilgi = new DosyaBilgi();
    }
}