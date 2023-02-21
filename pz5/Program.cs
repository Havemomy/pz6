MailAdress Abakan = new MailAdress();
string ulica = Abakan.Ulica;
int kvartira = Abakan.Kvartira;
int dom = Abakan.Dom;


Abakan = new MailAdress();
Abakan.Ulica = "ул. Пушкина";
Abakan.Dom = 20;
Abakan.Kvartira = 90;

MailAdress Krasnoyarsk = new MailAdress();
Krasnoyarsk.Ulica = "пр. Энгри Бёрдс";
Krasnoyarsk.Dom = 1;
Krasnoyarsk.Kvartira = 9;

MailAdress Novosibirsk = new MailAdress();
Novosibirsk.Ulica = "ул. Пушкина";
Novosibirsk.Dom = 20;
Novosibirsk.Kvartira = 12;

MailAdress Moskva = new MailAdress();
Moskva.Ulica = "пр. Ленина";
Moskva.Dom = 31;
Moskva.Kvartira = 911;

MailAdress Sankt_Peterburg = new MailAdress();
Sankt_Peterburg.Ulica = "пр. Энгри Бёрдс";
Sankt_Peterburg.Dom = 1;
Sankt_Peterburg.Kvartira = 35;

Krasnoyarsk.Print(); Abakan.Print(); Novosibirsk.Print(); Moskva.Print(); Sankt_Peterburg.Print();

List<MailAdress> list = new List<MailAdress>();
list.Add(Krasnoyarsk);
list.Add(Abakan);
list.Add(Moskva);
list.Add(Sankt_Peterburg);
list.Add(Novosibirsk);

Console.WriteLine("---------------------------------------");

list.GroupBy(x => x.Ulica).Where(x => x.Count() > 1).ToList().ForEach(x => x.ToList().ForEach(x => x.Print()));

public class adresses
{
    public string ulica { get; set; }
    public int kvartira { get; set; }
    public adresses(string ulica, int kvartira)
    {
        ulica = ulica;
        kvartira = kvartira;
    }
}

public class MailAdress
{
    private string _ulica;
    private int _dom;
    private int _kvartira;

    public string Ulica
    {
        get { return _ulica; }
        set { _ulica = value; }

    }
    public int Dom
    {
        get { return _dom; }
        set
        {
            var tipUlici = _ulica.Split(' ')[0];
            if (tipUlici == "ул.")
            {
                if (value > 0 && value <= 100)
                {
                    _dom = value;
                }
            }
            if (tipUlici == "пер.")
            {
                if (value > 0 && value <= 30)
                    _dom = value;
            }
            if (tipUlici == "пр.")
            {
                if (value > 0 && value <= 1000)
                    _dom = value;
            }
        }
    }

    public int Kvartira
    {
        get { return _kvartira; }
        set { _kvartira = value; }
    }
    public void Print()
    {
        Console.WriteLine($"Улица: {Ulica} Дом: {Dom} Квартира: {Kvartira} ");
    }
}