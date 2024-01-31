using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCarousel.Shared
{
    public class StokListesiBilgileri
    {
        public int id { get; set; }
        public int kategoriid { get; set; }
        public string stokkodu { get; set; }
        public string stokcinsi { get; set; }
        public string birim { get; set; }
        public string birim2 { get; set; }
        public string aciklama1 { get; set; }
        public string aciklama2 { get; set; }
        public string aciklama3 { get; set; }
        public string aciklama4 { get; set; }
        public string aciklama5 { get; set; }
        public string grupkodu { get; set; }
        public string kategorikodu { get; set; }
        public string kategoriAdi { get; set; }
        public string resim { get; set; }
        public string resim2 { get; set; }
        public decimal fiyat1 { get; set; }
        public string dovizkodu1 { get; set; }
        public string dovizturu1 { get; set; }
        public decimal fiyat2 { get; set; }
        public string dovizkodu2 { get; set; }
        public string dovizturu2 { get; set; }
        public decimal fiyat3 { get; set; }
        public string dovizkodu3 { get; set; }
        public string dovizturu3 { get; set; }
        public decimal fiyat4 { get; set; }
        public string dovizkodu4 { get; set; }
        public string dovizturu4 { get; set; }
        public decimal fiyat5 { get; set; }
        public string dovizkodu5 { get; set; }
        public string dovizturu5 { get; set; }
        public decimal kdvorani { get; set; }
        public string ozelkod1 { get; set; }
        public string ozelkod2 { get; set; }
        public string ozelkod3 { get; set; }
        public string ozelkod4 { get; set; }
        public string ozelkod5 { get; set; }
        public string stokAciklama { get; set; }
        public int stokaktif { get; set; }
        public string tevkifatKodu { get; set; }
        public decimal tevkifatOrani { get; set; }
        public decimal nakitFiyat { get; set; }
        public decimal krediKartiFiyati { get; set; }
        public decimal sanalPosFiyati { get; set; }
        public decimal gercekFiyat { get; set; }
        public decimal nakitOrani { get; set; }
        public decimal krediKartiOrani { get; set; }
        public decimal sanalPosOrani { get; set; }
        public decimal KDVliGercekFiyat
        {
            get
            {
                return gercekFiyat + (gercekFiyat * kdvorani / 100);
            }
            set
            {
                gercekFiyat = value * (100 / (100 + kdvorani));
            }

        }
        public decimal KDVliNakitFiyat
        {
            get
            {
                return nakitFiyat + (nakitFiyat * kdvorani / 100);
            }
            set
            {
                nakitFiyat = value * (100 / (100 + kdvorani));
            }

        }
        public decimal KDVliKrediKartiFiyati
        {
            get
            {
                return krediKartiFiyati + (krediKartiFiyati * kdvorani / 100);
            }
            set
            {
                krediKartiFiyati = value * (100 / (100 + kdvorani));
            }

        }
        public decimal KDVlisanalPosFiyati
        {
            get
            {
                return sanalPosFiyati + (sanalPosFiyati * kdvorani / 100);
            }
            set
            {
                sanalPosFiyati = value * (100 / (100 + kdvorani));
            }

        }
        public List<DosyaBilgi> stokResimBilgileri { get; set; }
        public int kategoriDurumu
        {
            get
            {
                if(!kategorikodu.Trim().Equals(""))
                    return 1;
                else
                    return 0;
            }
            set
            {
                if(!kategorikodu.Trim().Equals(""))
                    value = 1;
                else
                    value = 0;
            }

        }
        public bool aktifmi
        {
            get
            {
                return stokaktif == 1 ? true : false;
            }
            set
            {
                if(value)
                {
                    stokaktif = 1;
                }
                else
                    stokaktif = 0;
            }
        }
        public string aktif
        {
            get
            {
                return stokaktif == 1 ? "Aktif" : "Pasif";
            }
            set
            {
                if(value.Trim().Equals("Aktif"))
                {
                    stokaktif = 1;
                }
                else
                    stokaktif = 0;
            }
        }
        public bool sec { get; set; }


        public StokListesiBilgileri()
        {
            id = 0;
            kategoriid = 0;
            stokkodu = "";
            stokcinsi = "";
            birim = "";
            birim2 = "";
            aciklama1 = "";
            aciklama2 = "";
            aciklama3 = "";
            aciklama4 = "";
            aciklama5 = "";
            grupkodu = "";
            kategorikodu = "";
            kategoriAdi = "";
            resim = "";
            resim2 = "";
            fiyat1 = 0;
            fiyat2 = 0;
            fiyat3 = 0;
            fiyat4 = 0;
            fiyat5 = 0;
            dovizkodu1 = "";
            dovizkodu2 = "";
            dovizkodu3 = "";
            dovizkodu4 = "";
            dovizkodu5 = "";
            dovizturu1 = "";
            dovizturu2 = "";
            dovizturu3 = "";
            dovizturu4 = "";
            dovizturu5 = "";
            kdvorani = 0;
            ozelkod1 = "";
            ozelkod2 = "";
            ozelkod3 = "";
            ozelkod4 = "";
            ozelkod5 = "";
            stokAciklama = "";
            tevkifatKodu = "";
            tevkifatOrani = 0;
            stokResimBilgileri = new List<DosyaBilgi>();
        }
        public StokListesiBilgileri Copy(StokListesiBilgileri slb)
        {
            this.aciklama1 = slb.aciklama1;
            this.stokAciklama = slb.stokAciklama;
            this.aciklama2 = slb.aciklama2;
            this.aciklama3 = slb.aciklama3;
            this.aciklama4 = slb.aciklama4;
            this.aciklama5 = slb.aciklama5;
            this.birim = slb.birim;
            this.birim2 = slb.birim2;
            this.fiyat1 = slb.fiyat1;
            this.fiyat2 = slb.fiyat2;
            this.fiyat3 = slb.fiyat3;
            this.fiyat4 = slb.fiyat4;
            this.fiyat5 = slb.fiyat5;
            this.dovizkodu1 = slb.dovizkodu1;
            this.dovizkodu2 = slb.dovizkodu2;
            this.dovizkodu3 = slb.dovizkodu3;
            this.dovizkodu4 = slb.dovizkodu4;
            this.dovizkodu5 = slb.dovizkodu5;
            this.dovizturu1 = slb.dovizturu1;
            this.dovizturu2 = slb.dovizturu2;
            this.dovizturu3 = slb.dovizturu3;
            this.dovizturu4 = slb.dovizturu4;
            this.dovizturu5 = slb.dovizturu5;
            this.grupkodu = slb.grupkodu;
            this.id = slb.id;
            this.kategoriid = slb.kategoriid;
            this.kategorikodu = slb.kategorikodu;
            this.kategoriAdi = slb.kategoriAdi;
            this.kdvorani = slb.kdvorani;
            this.ozelkod1 = slb.ozelkod1;
            this.ozelkod2 = slb.ozelkod2;
            this.ozelkod3 = slb.ozelkod3;
            this.ozelkod4 = slb.ozelkod4;
            this.ozelkod5 = slb.ozelkod5;
            this.resim = slb.resim;
            this.resim2 = slb.resim2;
            this.stokcinsi = slb.stokcinsi;
            this.stokkodu = slb.stokkodu;
            this.stokaktif = slb.stokaktif;
            this.tevkifatKodu = slb.tevkifatKodu;
            this.tevkifatOrani = slb.tevkifatOrani;
            this.nakitFiyat = 0;
            this.nakitOrani = 0;
            this.krediKartiFiyati = 0;
            this.krediKartiOrani = 0;
            this.sanalPosFiyati = 0;
            this.sanalPosFiyati = 0;
            this.sanalPosOrani = 0;
            this.gercekFiyat = 0;

            return this;
        }
    }
}
