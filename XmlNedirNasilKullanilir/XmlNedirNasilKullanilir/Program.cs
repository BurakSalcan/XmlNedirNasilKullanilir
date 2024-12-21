using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlNedirNasilKullanilir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Tanımlama

            //xml(Extencible Marcub Language), genişletilebilir programlama dili olarak tanımlanır. 
            ///Html gibi etiketler kullanılarak oluşturulur. Ancak xml'de etiketleri biz belirleriz.
            //Amacı veri toplamak veya farklı platformlar arasında veri transferi sağlamaktır. 
            //RSS, Ajax, Web servisleri oluşturulabilir. 
            //XML ile tanımlama yaparken herhangi bir standart yoktur. Ancak bazı kurallara uyulması gerekir.
            //En önemli kural, XML dosyasının başında xml tanımlayıcısının oluşturulması gerekir. 
            //<?xml version="1.0" encoding="UTF-8"?>

            #endregion

            #region Xml Verilerini Okuyalım

            //XDocument dokuman = XDocument.Load("../../Kisiler.xml");
            //XElement rootElement = dokuman.Root;
            //foreach (XElement item in rootElement.Elements())
            //{
            //    int id = Convert.ToInt32(item.Attribute("id").Value);
            //    string isim = item.Element("adi").Value;
            //    string soyisim = item.Element("soyadi").Value;
            //    Console.WriteLine($"{id}) {isim} {soyisim}");
            //}


            #endregion

            #region Merkez Bankası Döviz Kurlarını Okuyalım

            XDocument kurlar = XDocument.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            XElement rootElement = kurlar.Root;
            foreach  (XElement kur in rootElement.Elements())
            {
                string kod = kur.Attribute("Kod").Value;
                string isim = kur.Element("Isim").Value;
                int unit = int.Parse(kur.Element("Unit").Value);//Parse, yalnızca int'ten stringe veri çevirir. Özel bir çeşit converttir.
                double ForexSelling = 0;
                if (!string.IsNullOrEmpty(kur.Element("ForexSelling").Value))
                {
                    ForexSelling = Convert.ToDouble(kur.Element("ForexSelling").Value.Replace('.', ','));
                }
                double satis = ForexSelling / unit;
                Console.WriteLine($"{kod} - {isim} = {ForexSelling} TL");
            }

            #endregion
        }
    }
}
