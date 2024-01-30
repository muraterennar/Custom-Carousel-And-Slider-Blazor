namespace CustomCarousel.Shared;

public class Sonuc<T>
{
    public bool sonuc { get; set; }
    public string mesaj { get; set; }
    public T data { get; set; }
    public Sonuc()
    {
        mesaj = "";
    }
}