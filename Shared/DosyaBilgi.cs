namespace CustomCarousel.Shared;

public class DosyaBilgi
{
    public Guid DosyaId { get; set; }
    public string DosyaPath { get; set; }
    public string DosyaAdi { get; set; }
    public double DosyaBoyutu { get; set; }
    public int DosyaSiraNo { get; set; }

    public DosyaBilgi()
    {
        DosyaPath = "";
        DosyaAdi = "";
        DosyaBoyutu = 0;
        DosyaSiraNo = 0;
    }
}
