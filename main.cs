//FALI PRONALAZAK DVOJKI,CETVORKI I OSMICA KADA IMA OD 2 DO 3 PROMENJIVE
//FALI ISPIS PO KORACIMA JER JE PROGRAM EDUKATIVNOG TIPA
//FALI KOD ZA MANJE OD 4 PROMENLJIVE
using System;
class Program
{
    static char[,] matrica = new char[,] { };
    static char[,] nepromenjenaMatrica = new char[,] { };
    static string forma = "";
    static string[] simboli = new string[] { };
    static char dnfKnf = ' ';
    static int bp; //brojPromenljivih
    static bool prekiniAlUnos;
    static char trenutnaVelicina = '2';

    static void Main(string[] args)
    {
        while (true)
        {
            matrica = new char[,] { };
            nepromenjenaMatrica = new char[,] { };
            forma = "";
            dnfKnf = ' ';
            bp = 0;
            prekiniAlUnos = false;
            simboli = new string[] { };
            char obrnutoDnfKnf;
            bool tacnost = true, provera = true, izvrsiloSe = false;
            int pocetakX = 0, pocetakY = 0, krajX = 0, krajY = 0, br = 0;
            string krajnjiIzraz = "",trenutniIzraz="";
            //UnosPodataka
            UnosPodataka();
            char[,] MatricaSaPromenama = new char[matrica.GetLength(0), matrica.GetLength(1)];
            nepromenjenaMatrica = new char[matrica.GetLength(0), matrica.GetLength(1)];
            //pravi kopiju karte
            for (int i = 0; i < matrica.GetLength(0); i++)
            {
                for (int j = 0; j < matrica.GetLength(1); j++)
                {
                    MatricaSaPromenama[i, j] = matrica[i, j];
                }
            }
            for (int i = 0; i < matrica.GetLength(0); i++)
            {
                for (int j = 0; j < matrica.GetLength(1); j++)
                {
                    nepromenjenaMatrica[i, j] = matrica[i, j];
                }
            }
            if (dnfKnf == '1') obrnutoDnfKnf = '0';
            else obrnutoDnfKnf = '1';
            //odredjujemo koje slucajeve da gleda u odnosu na to kolika je tablica (u tablici sa 3 promenljive vodoravne 4 i 8 ne postoje)
            if (bp == 4) br = 0;
            else if (bp == 3) br = 3;
            else if (bp == 2) br = 5;
            //odredjivanje parametara tako da gledaju vodoravne podmatrice
            for (; br < 9; br++)
            {
                switch (br)//odredjuje parametre tako da gledaju razlicite grupe
                {
                    case 0://grupe od 16
                        krajY = 4;
                        pocetakX = 0;
                        pocetakY = 0;
                        krajX = 4;
                        trenutnaVelicina = 's';
                        break;
                    case 1://vodoravne grupe od 8
                        krajY = 2;
                        pocetakX = 0;
                        pocetakY = 0;
                        krajX = 4;
                        trenutnaVelicina = '8';
                        break;
                    case 2://vodoravne grupe od 4
                        krajY = 1;
                        pocetakX = 0;
                        pocetakY = 0;
                        krajX = 4;
                        trenutnaVelicina = '4';
                        break;
                    case 3://uspravne grupe od 8
                        krajY = 4;
                        pocetakX = 0;
                        pocetakY = 0;
                        krajX = 2;
                        trenutnaVelicina = '8';
                        break;
                    case 4://uspravne grupe od 4
                        krajY = 4;
                        pocetakX = 0;
                        pocetakY = 0;
                        krajX = 1;
                        trenutnaVelicina = '4';
                        break;
                    case 5://grupe 2x2
                        krajY = 2;
                        pocetakX = 0;
                        pocetakY = 0;
                        krajX = 2;
                        trenutnaVelicina = '4';
                        break;
                    case 6://grupe od 2 polja vodoravno
                        krajY = 1;
                        pocetakX = 0;
                        pocetakY = 0;
                        krajX = 2;
                        trenutnaVelicina = '2';
                        break;
                    case 7://grupe od 2 polja uspravno
                        krajY = 2;
                        pocetakX = 0;
                        pocetakY = 0;
                        krajX = 1;
                        trenutnaVelicina = '2';
                        break;
                    case 8://Izolovane grupe
                        krajY = 1;
                        pocetakX = 0;
                        pocetakY = 0;
                        krajX = 1;
                        trenutnaVelicina = 'i';
                        break;
                    default:
                        break;
                }
                while (krajY <= matrica.GetLength(0) + 1 && krajX <= matrica.GetLength(1) + 1)//kaze sve dok je <= od 5 da bi u poslednjem krugu mogao da gleda i poslednju i prvu kolonu
                {
                    tacnost = true;
                    provera = false;
                    for (int i = pocetakY; i < krajY; i++)
                    {
                        for (int j = pocetakX; j < krajX; j++)
                        {
                            //proverava da li je bilo koja od vrednosti u podmatrici koju posmatra suprotna od trazene
                            if (MatricaSaPromenama[i % matrica.GetLength(0), j % matrica.GetLength(1)] == obrnutoDnfKnf) { tacnost = false; break; }
                            if (MatricaSaPromenama[i % matrica.GetLength(0), j % matrica.GetLength(1)] == dnfKnf) provera = true;
                        }
                        if (!tacnost) break;
                    }
                    //ako je posmatrana podmatrica dobra ovo ce je pretvoriti u odgovarajucu vrednost
                    if (tacnost && provera)
                    {
                        izvrsiloSe = true;
                        for (int i = pocetakY; i < krajY; i++)
                        {
                            for (int j = pocetakX; j < krajX; j++) { MatricaSaPromenama[i % matrica.GetLength(0), j % matrica.GetLength(1)] = trenutnaVelicina; matrica[i % matrica.GetLength(0), j % matrica.GetLength(1)] = trenutnaVelicina; }
                        }
                        //smanjivanje
                        if ((br == 1 || br == 3) && bp == 4)//u ovim slucajevima su osmice
                        {
                            if (dnfKnf == '0')
                            {
                                trenutniIzraz = MinimalizujOsmiceCetriPromKNF(simboli[0], simboli[1], simboli[2], simboli[3], br, pocetakX, pocetakY);
                                krajnjiIzraz+= trenutniIzraz;
                            }
                            else
                            {
                                trenutniIzraz = MinimalizujOsmiceCetriPromDNF(simboli[0], simboli[1], simboli[2], simboli[3], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                        }
                        else if ((br == 2 || br == 4 || br == 5) && bp == 4) //u ovim slucajevima su cetvorke
                        {
                            if (dnfKnf == '0')
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "*";
                                trenutniIzraz= MinimalizujCetvorkeCetriPromKNF(simboli[0], simboli[1], simboli[2], simboli[3], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                            else
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = MinimalizujCetvorkeCetriPromDNF(simboli[0], simboli[1], simboli[2], simboli[3], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                        }
                        else if ((br == 6 || br == 7) && bp == 4) //u ovim slucajevima su dvojke
                        {
                            if (dnfKnf == '0')
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "*";
                                trenutniIzraz = MinimalizujDvojkeCetriPromKNF(simboli[0], simboli[1], simboli[2], simboli[3], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                            else
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = MinimalizujDvojkeCetriPromDNF(simboli[0], simboli[1], simboli[2], simboli[3], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                        }
                        if (br == 8 && bp == 4)//IZOLOVAN SLUCAJ CETRI PROMENJIVE
                        {
                            if (dnfKnf == '0')
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = IzolovanSlucajCetriPromenjiveKNF(simboli[0], simboli[1], simboli[2], simboli[3], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                            else
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = IzolovanSlucajCetriPromenjiveDNF(simboli[0], simboli[1], simboli[2], simboli[3], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                        }
                        if ((br == 5 || br == 4) && bp == 3)//CETVORKE TRI PROMENJIVE
                        {
                            if (dnfKnf == '0')
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "*";
                                trenutniIzraz = MinimalizujCetvorkeTriPromKNF(simboli[0], simboli[1], simboli[2], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                            else
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = MinimalizujCetvorkeTriPromDNF(simboli[0], simboli[1], simboli[2], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                        }
                        if ((br == 6 || br == 7) && bp == 3)//DVOJKE TRI PROMENJIVE
                        {
                            if (dnfKnf == '0')
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "*";
                                trenutniIzraz = MinimalizujDvojkeTriPromKNF(simboli[0], simboli[1], simboli[2], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                            else
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = MinimalizujDvojkeTriPromDNF(simboli[0], simboli[1], simboli[2], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                        }
                        if (br == 8 && bp == 3)//IZOLOVAN SLUCAJ
                        {
                            if (dnfKnf == '0')
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = IzolovanSlucajTriPromenjiveKNF(simboli[0], simboli[1], simboli[2], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                            else
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = IzolovanSlucajTriPromenjiveDNF(simboli[0], simboli[1], simboli[2], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                        }
                        else if ((br == 6 || br == 7) && bp == 2) //DVOJKE DVE PROMENJIVE
                        {
                            if (dnfKnf == '0')
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "*";
                                trenutniIzraz = MinimalizujDvojkeDvePromKNF(simboli[0], simboli[1], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                            else
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = MinimalizujDvojkeDvePromDNF(simboli[0], simboli[1], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                        }
                        if (br == 8 && bp == 2)//IZOLOVAN SLUCAJ DVE PROMENJIVE
                        {
                            if (dnfKnf == '0')
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz = IzolovanSlucajDvePromenjiveKNF(simboli[0], simboli[1], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                            else
                            {
                                if (krajnjiIzraz != "")
                                    krajnjiIzraz += "+";
                                trenutniIzraz += IzolovanSlucajDvePromenjiveDNF(simboli[0], simboli[1], br, pocetakX, pocetakY);
                              krajnjiIzraz+= trenutniIzraz;
                            }
                        }
                        if (br == 0 && bp == 4 && dnfKnf == '1')
                            krajnjiIzraz += "true";
                        else if (br == 3 && bp == 3 && dnfKnf == '1')
                            krajnjiIzraz += "true";
                        else if (br == 5 && bp == 2 && dnfKnf == '1')
                            krajnjiIzraz += "true";
                        else if (br == 0 && bp == 4 && dnfKnf == '0')
                            krajnjiIzraz += "false";
                        else if (br == 3 && bp == 3 && dnfKnf == '0')
                            krajnjiIzraz += "false";
                        else if (br == 5 && bp == 2 && dnfKnf == '0')
                            krajnjiIzraz += "false";
                        //crtanje
                        IspisivanjeTablice();
                        //Ispisivanje trenutne minimalizacije
                        Console.WriteLine("Minimalizacijom ove grupe dobijamo: " + trenutniIzraz);
                        //ubacivanje starih vrednosti u matricu
                        for (int i = 0; i < matrica.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrica.GetLength(1); j++)
                            {
                                matrica[i, j] = nepromenjenaMatrica[i, j];
                            }
                        }
                    }
                    switch (br)//odredjuje koji parametri se inkrementiraju
                    {
                        case 0:
                        case 1:
                        case 2://vodoravne grupe cetvorki i osmica
                            pocetakY++;
                            krajY++;
                            break;
                        case 3:
                        case 4://uspravne grupe cetvorki i osmica
                            pocetakX++;
                            krajX++;
                            break;
                        case 5:
                        case 6://grupe 2x2 i vodoravne dvojke
                            pocetakX++;
                            krajX++;
                            if (krajX == matrica.GetLength(1) + 2)
                            {
                                pocetakX = 0;
                                krajX = 2;
                                pocetakY++;
                                krajY++;
                            }
                            break;
                        case 7:
                        case 8://uspravne dvojke i izolovane grupe
                            pocetakX++;
                            krajX++;
                            if (krajX == matrica.GetLength(1) + 2)
                            {
                                pocetakX = 0;
                                krajX = 1;
                                pocetakY++;
                                krajY++;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            if (izvrsiloSe == true) Console.WriteLine("Skracen izraz je: " + krajnjiIzraz);
            else NemogucSlucaj();
            Console.WriteLine();
        }
    }
    static string opcije(string[] mogucnosti, string ispis)//izbor knf/dnf ili izbor tablica/algebarski izraz
    {
        string s = "";
        while (!nizSadrzi(mogucnosti, s))
        {
            Console.WriteLine(ispis);
            s = Console.ReadLine().ToUpper();
            TraziPrekid(s);
        }
        return s;
    }
    //unos podataka
    static void UnosPodataka()
    {
        forma = ""; matrica = new char[,] { }; simboli = new string[] { };
        string izbor = opcije(new string[] { "KA", "TA", "PR"}, "Da li želite da unesete kartu ili da prekinete program?\n[KA] - unos direktno u kartu\n[TA] - unos tablicom istinitosti.\n[Pr] - prekini program\nMožete da prekinete program u bilo kom trenutnku.");
        if (izbor == "KA")
        {
            UnosKarte();
        }
        else if(izbor == "TA")
        {
            UnosPrekoTablice();
        }
        else TraziPrekid(izbor);
    }
    static void TraziPrekid(string s)
    {
        if (s.ToUpper() == "PR") PrekiniProgram();
    }
    static void PrekiniProgram()
    {
        Console.Clear();
        Environment.Exit(0);
    }
    static void UnosKarte()
    {
        Console.WriteLine("Koliko promenljivih želite?");
        bp = 0;
        string bps = string.Empty;
        bool nijeValidno = true;
        while (nijeValidno)
        {
            bps = Console.ReadLine();
            nijeValidno = !int.TryParse(bps, out bp) || bp > 4 || bp < 2;
            if (nijeValidno) Console.WriteLine("Nevažeči broj promenljivih. Da li želite 2, 3 ili 4?");
            TraziPrekid(bps);
        }
        Console.WriteLine("Unesite " + bp + " promenljive, svaku u posebnom redu.(maksimalan broj karaktera je 5)");
        string[] simb = new string[] { };
        int br = 1;
        while (br <= bp)
        {
            UnosPromenljivih(ref br);
        }
        int x = 0;
        int y = 0;
        //int x = (bp == 4 ? 4 : 2); 
        //int y = (bp == 2 ? 2 : 4);
        if (bp == 4)
        {
            x = 4;
            y = 4;
        }
        else if (bp == 3)
        {
            x = 2;
            y = 4;
        }
        else
        {
            x = 2;
            y = 2;
        }
        Console.WriteLine("Primer Karnoove mape za " + bp + " promenjivih:");
        IspisivanjeTablice();
        if (bp == 4)
        {
            Console.WriteLine("Promenljive koje oznacavaju vrste su: {0} i {1}", simboli[0], simboli[1]);
            Console.WriteLine("Promenljive koje oznacavaju kolone su: {0} i {1}", simboli[2], simboli[3]);
        }
        else if (bp == 3)
        {
            Console.WriteLine("Promenljive koje oznacavaju vrste su: {0} i {1}", simboli[0], simboli[1]);
            Console.WriteLine("Promenljiva koja oznacava kolone je: {0}", simboli[2]);
        }
        else if (bp == 2)
        {
            Console.WriteLine("Promenljiva koja oznacava kolone je: {0}", simboli[0]);
            Console.WriteLine("Promenljiva koja oznacava kolone je: {0}", simboli[1]);
        }
        matrica = new char[y, x];
        for (int i = 0; i < y; i++)
        {
            bool validanRed = false;
            bool greskaRed = false;
            while (!validanRed)
            {
                validanRed = greskaRed = false;
                int j = 0;
                Console.WriteLine("Unesite " + (i + 1) + ". red :");
                string red = Console.ReadLine();
                TraziPrekid(red);
                string[] clanovi = red.Split(' ');
                if (clanovi.Length != x)
                {
                    greskaRed = true;
                    Console.WriteLine("Red mora da ima " + x + " vrednosti.");
                }
                else
                {
                    foreach (string clan in clanovi)
                    {
                        if (clan != "0" && clan != "1" && clan != "d" && clan != "b" && !greskaRed)
                        {
                            Console.WriteLine("Dozvoljene vrednosti su ''0'', ''1'', ''d'' i ''b''");
                            greskaRed = true;
                        }
                        else if (!greskaRed)
                        {
                            matrica[i, j] = Convert.ToChar(clan);
                            j++;
                        }
                    }
                }
                validanRed = !greskaRed;
            }
        }
        forma = opcije(new string[] { "KNF", "DNF" }, "KNF ili DNF : ");
        dnfKnf = (forma == "KNF") ? '0' : '1';
        Console.WriteLine();
    }
    static void UnosPrekoTablice()
    {
        string[] leg1 = { "0", "1" };
        string[] leg = { "00", "01", "11", "10" };
        string bps = string.Empty;
        string red;
        char funkcija = ' ';
        bool nijeValidno = true;
        Console.WriteLine("Koliko promenljivih želite?");
        bp = 0;
        while (nijeValidno)
        {
            bps = Console.ReadLine();
            nijeValidno = !int.TryParse(bps, out bp) || bp > 4 || bp < 2;
            if (nijeValidno) Console.WriteLine("Nevažeči broj promenljivih. Da li želite 2, 3 ili 4?");
            TraziPrekid(bps);
        }
        Console.WriteLine("Unesite " + bp + " promenljive, svaku u posebnom redu.(maksimalan broj karaktera je 5)");
        int br = 1;
        while (br <= bp)
        {
            UnosPromenljivih(ref br);
        }
        int x = 0;
        int y = 0;
        //int x = (bp == 4 ? 4 : 2); 
        //int y = (bp == 2 ? 2 : 4);
        if (bp == 4)
        {
            x = 4;
            y = 4;
        }
        else if (bp == 3)
        {
            x = 2;
            y = 4;
        }
        else
        {
            x = 2;
            y = 2;
        }
        matrica = new char[y, x];
        Console.WriteLine("unesite 1, 0 ili d (b) u odnosu na to da li je funkcija u tom slucaju tacna netacna ili zanemarljiva");
        if (bp == 4)
        {
            Console.WriteLine("{0},{1},{2},{3}",simboli[0],simboli[1],simboli[2],simboli[3]);
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    while (true)
                    {
                        Console.Write(leg[i][0]);
                        for (int k = 0; k < simboli[0].Length; k++) Console.Write(" ");
                        Console.Write(leg[i][1]);
                        for (int k = 0; k < simboli[1].Length; k++) Console.Write(" ");
                        Console.Write(leg[j][0]);
                        for (int k = 0; k < simboli[2].Length; k++) Console.Write(" ");
                        Console.Write(leg[j][1]);
                        for (int k = 0; k < simboli[3].Length+1; k++) Console.Write(" ");
                        red = Console.ReadLine();
                        if (red.Length != 1)
                        {
                            Console.WriteLine("uneli ste vise od jednog karaktera, morate da unesete 1, 0 ili d (b)");
                            continue;
                        }
                        funkcija = Convert.ToChar(red);
                        if (funkcija == '1' || funkcija == '0' || funkcija == 'd' || funkcija == 'b') break;
                        else Console.WriteLine("uneli ste {0},a ne 1, 0 ili d (b)", funkcija);
                    }
                    matrica[i, j] = funkcija;
                }
            }
        }
        if (bp == 3)
        {
            Console.WriteLine("{0},{1},{2}", simboli[0], simboli[1], simboli[2]);
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    while (true)
                    {
                        Console.Write(leg[i][0]);
                        for (int k = 0; k < simboli[0].Length; k++) Console.Write(" ");
                        Console.Write(leg[i][1]);
                        for (int k = 0; k < simboli[1].Length; k++) Console.Write(" ");
                        Console.Write(leg1[j]);
                        for (int k = 0; k < simboli[2].Length + 1; k++) Console.Write(" ");
                        red = Console.ReadLine();
                        if (red.Length != 1)
                        {
                            Console.WriteLine("uneli ste vise od jednog karaktera, morate da unesete 1, 0 ili d (b)");
                            continue;
                        }
                        funkcija = Convert.ToChar(red);
                        if (funkcija == '1' || funkcija == '0' || funkcija == 'd' || funkcija == 'b') break;
                        else Console.WriteLine("uneli ste {0},a ne 1, 0 ili d (b)", funkcija);
                    }
                    matrica[i, j] = funkcija;
                }
            }
        }
        if (bp == 2)
        {
            Console.WriteLine("{0},{1}", simboli[0], simboli[1]);
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    while (true)
                    {
                        Console.Write(leg1[i]);
                        for (int k = 0; k < simboli[0].Length; k++) Console.Write(" ");
                        Console.Write(leg1[j]);
                        for (int k = 0; k < simboli[1].Length + 1; k++) Console.Write(" ");
                        red = Console.ReadLine();
                        if (red.Length != 1)
                        {
                            Console.WriteLine("uneli ste vise od jednog karaktera, morate da unesete 1, 0 ili d (b)");
                            continue;
                        }
                        funkcija = Convert.ToChar(red);
                        if (funkcija == '1' || funkcija == '0' || funkcija == 'd' || funkcija == 'b') break;
                        else Console.WriteLine("uneli ste {0},a ne 1, 0 ili d (b)", funkcija);
                    }
                    matrica[i, j] = funkcija;
                }
            }
        }
        forma = opcije(new string[] { "KNF", "DNF" }, "KNF ili DNF : ");
        dnfKnf = (forma == "KNF") ? '0' : '1';
        Console.WriteLine();
        if (bp == 4)
        {
            Console.WriteLine("Promenljive koje oznacavaju vrste su: {0} i {1}", simboli[0], simboli[1]);
            Console.WriteLine("Promenljive koje oznacavaju kolone su: {0} i {1}", simboli[2], simboli[3]);
        }
        else if (bp == 3)
        {
            Console.WriteLine("Promenljive koje oznacavaju vrste su: {0} i {1}", simboli[0], simboli[1]);
            Console.WriteLine("Promenljiva koja oznacava kolone je: {0}", simboli[2]);
        }
        else if (bp == 2)
        {
            Console.WriteLine("Promenljiva koja oznacava kolone je: {0}", simboli[0]);
            Console.WriteLine("Promenljiva koja oznacava kolone je: {0}", simboli[1]);
        }
    }
    static void UnosPromenljivih(ref int brPromenljivih)
    {
        string[] zabranjeniSimboli = new string[] { "*", "+", "!", "(", ")" };
        bool validanUnos = false;
        string u = string.Empty;
        while (!validanUnos)
        {
            bool v = true;
            u = Console.ReadLine();
            TraziPrekid(u);
            if (u == ".")
            {
                prekiniAlUnos = true;
                validanUnos = true;
            }
            if (!prekiniAlUnos)
            {
                int i = 0;
                if (u.Length > 5)
                {
                    Console.WriteLine("Vasa promenljiva ima vise od 5 karaktera probajte ponovo.");
                    v = false;
                }else if (u == "")
                {
                    Console.WriteLine("Niste nista uneli.");
                    v = false;
                }
                foreach (char c in u)
                {
                    if (!char.IsLetter(c))
                    {
                        if (c == ' ')
                        {
                            Console.WriteLine("Razmaci nisu dozvoljeni u imenima promenljivih.");
                            v = false;
                        }
                        else if (i == 0)
                        {
                            Console.WriteLine("Na prvom mestu imena promenljive su dozvoljena samo slova.");
                            v = false;
                        }
                    }
                    i++;
                }
                foreach (string zs in zabranjeniSimboli)
                {
                    if (u.Contains(zs))
                    {
                        Console.WriteLine("Unos je nevažeći.");
                        v = false;
                    }
                }
                validanUnos = v;
                if (u != "*")
                {
                    if (!nizSadrzi(simboli, u.ToString()))
                    {
                        if (validanUnos)
                        {
                            Array.Resize(ref simboli, simboli.Length + 1);
                            simboli[simboli.Length - 1] = u.ToString();
                            brPromenljivih++;
                        }
                    }
                    else Console.WriteLine("Već ste uneli ovaj simbol.");
                }
            }
        }
    }
    static bool nizSadrzi(string[] niz, string s)
    {
        foreach (string str in niz) if (str == s) return true;
        return false;
    }
    static void NemogucSlucaj()
    {
        IspisivanjeTablice();
        if (dnfKnf == '1') Console.WriteLine("Uneli ste sve 0 iako ste odabrali DNF(on trazi jedinice),ili je puna matrica zanemarljivih vrednosti, zbog ovoga je nemoguce minimalizovati");
        else Console.WriteLine("Uneli ste sve 1 iako ste odabrali KNF(on trazi nule),ili je puna matrica zanemarljivih vrednosti, zbog ovoga je nemoguce minimalizovati");
    }
    //kraj unosa podataka
    private static string IzolovanSlucajDvePromenjiveDNF(string a, string b, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg1 = { "0", "1" };
        if (leg1[pocetakY] == "0")
            s += "!" + a;
        else
            s += a;
        if (leg1[pocetakX] == "0")
            s += "*" + "!" + b;
        else
            s += "*" + b;
        return s;
    }
    private static string IzolovanSlucajDvePromenjiveKNF(string a, string b, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg1 = { "0", "1" };
        if (leg1[pocetakY] == "0")
            s += a;
        else
            s += "!" + a;
        if (leg1[pocetakX] == "0")
            s += "*" + b;
        else
            s += "*" + "!" + b;
        return s;
    }
    private static string IzolovanSlucajTriPromenjiveKNF(string a, string b, string c, int brojac, int pocetakX, int pocetakY)
    {
        string s = "(";
        string[] leg1 = { "0", "1" };
        string[] leg = { "00", "01", "11", "10" };
        if (leg1[pocetakX] == "0")
            s += c;
        else
            s += "!" + c;
        if (leg[pocetakY][0] == '0')
            s += a + "+";
        else
            s += "!" + a + "+";
        if (leg[pocetakY][1] == '1')
            s += "!" + b;
        else
            s += b;
        s += ")";
        return s;
    }
    private static string IzolovanSlucajTriPromenjiveDNF(string a, string b, string c, int brojac, int pocetakX, int pocetakY)
    {
        string s = "(";
        string[] leg1 = { "0", "1" };
        string[] leg = { "00", "01", "11", "10" };
        if (leg1[pocetakX] == "0")
            s += "!" + c;
        else
            s += c;
        if (leg[pocetakY][0] == '0')
            s += "!" + a + "+";
        else
            s += a + "+";
        if (leg[pocetakY][1] == '1')
            s += b;
        else
            s += "!" + b;
        s += ")";
        return s;
    }
    private static string IzolovanSlucajCetriPromenjiveDNF(string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
    {
        string s = "(";
        string[] leg = { "00", "01", "11", "10" };
        if (leg[pocetakY][0] == '0')
            s += "!" + a + "*";
        else
            s += a + "*";
        if (leg[pocetakY][1] == '0')
            s += "!" + b + "*";
        else
            s += b + "*";
        if (leg[pocetakX][0] == '0')
            s += "!" + c + "*";
        else
            s += c + "*";
        if (leg[pocetakX][1] == '0')
            s += "!" + d;
        else
            s += d;
        s += ")";
        return s;
    }
    private static string IzolovanSlucajCetriPromenjiveKNF(string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
    {
        string s = "(";
        string[] leg = { "00", "01", "11", "10" };
        if (leg[pocetakY][0] == '0')
            s += a + "+";
        else
            s += "!" + a + "+";
        if (leg[pocetakY][1] == '0')
            s += b + "+";
        else
            s += "!" + b + "+";
        if (leg[pocetakX][0] == '0')
            s += "!" + c + "+";
        else
            s += c + "+";
        if (leg[pocetakX][1] == '0')
            s += "!" + d;
        else
            s += d;
        s += ")";
        return s;
    }
    private static string MinimalizujDvojkeDvePromDNF(string a, string b, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg1 = { "0", "1" };
        if (brojac == 7)//vertikalne dvojke
        {
            if (leg1[pocetakX] == "0")
                s += "!" + b;
            else
                s += b;
        }
        if (brojac == 6)//vodoravne dvojke
        {
            if (leg1[pocetakY] == "0")
                s += "!" + a;
            else
                s += a;
        }
        return s;
    }
    private static string MinimalizujDvojkeDvePromKNF(string a, string b, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg1 = { "0", "1" };
        if (brojac == 7)//vertikalne dvojke
        {
            if (leg1[pocetakX] == "0")
                s += b;
            else
                s += "!" + b;
        }
        if (brojac == 6)//vodoravne dvojke
        {
            if (leg1[pocetakY] == "0")
                s += a;
            else
                s += "!" + a;
        }
        return s;
    }
    private static string MinimalizujDvojkeTriPromDNF(string a, string b, string c, int brojac, int pocetakX, int pocetakY)
    {
        string s = "(";
        string[] leg = { "00", "01", "11", "10" };
        string[] leg1 = { "0", "1" };
        //vodoravne dvojke
        if (brojac == 6)//ispisuje se x1 i x2
        {
            if (leg[pocetakY][0] == '0')
                s += "!" + a + "*";
            else
                s += a + "*";
            if (leg[pocetakY][1] == '1')
                s += b;
            else
                s += "!" + b;
            s += ")";
        }
        //vertikalne dvojke
        if (brojac == 7) // ispisano x1 i jedno od x2 i x3
        {
            if (leg1[pocetakX] == "0")
                s += "!" + c + "*";
            else
                s += c + "*";
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                s += "!" + a;
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                s += a;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                s += "!" + b;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                s += b;
            s += ")";
        }
        return s;
    }
    private static string MinimalizujDvojkeTriPromKNF(string a, string b, string c, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg = { "00", "01", "11", "10" };
        string[] leg1 = { "0", "1" };
        string el = "";
        //vodoravne dvojke
        if (brojac == 6)//ispisuje se x2 i x3
        {
            if (leg[pocetakY][0] == '0')
                el += a + "+";
            else
                el += "!" + a + "+";
            if (leg[pocetakY][1] == '1')
                el += "!" + b;
            else
                el += b;
            s += "(" + el + ")";
        }
        //vertikalne dvojke
        if (brojac == 7)// ispisano x1 i jedno od x2 i x3
        {
            if (leg1[pocetakX] == "0")
                el += c + "+";
            else
                el += "!" + c + "+";
            //c d-kolona
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                el += a;
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                el += "!" + a;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                el += b;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                el += "!" + b;
            s += "(" + el + ")";
        }
        return s;
    }
    private static string MinimalizujCetvorkeTriPromDNF(string a, string b, string c, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg = { "00", "01", "11", "10" };
        string[] leg1 = { "0", "1" };
        string el = "";
        //kvadratne cetvorke
        if (brojac == 5) //ispisuje samo jednu promenjivu od x2 i x3
        {
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                el += "!" + a;
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                el += a;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                el += "!" + b;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                el += b;
            s += el;
        }
        //vertikalne cetvorke
        if (brojac == 4)
        {
            el = "";
            if (leg1[pocetakX][0] == '0')
                el += "!" + c;
            else
                el += c;
            s += el;
        }
        return s;
    }
    private static string MinimalizujCetvorkeTriPromKNF(string a, string b, string c, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg = { "00", "01", "11", "10" };
        string[] leg1 = { "0", "1" };
        string el = "";
        //kvadratne cetvorke
        if (brojac == 5)
        {
            if (el != "")
                el += "+";
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                el += a;
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                el += "!" + a;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                el += b;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                el += "!" + b;
            s += el;
        }
        //vertikalne cetvorke
        if (brojac == 4)
        {
            el = "";
            if (leg1[pocetakX] == "0")
                el += c;
            else
                el += "!" + c;
            s += el;
        }
        return s;
    }
    private static string MinimalizujDvojkeCetriPromKNF(string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg = { "00", "01", "11", "10" };
        //vertikalne dvojke
        if (brojac == 7)// x1 ili x2 sa x3 i x4
        {
            string el = "";
            //a b-vrste
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                el += a;
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                el += "!" + a;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                el += b;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                el += "!" + b;
            //c i d-kolone
            el += "+";
            if (leg[pocetakX][0] == '0')
                el += c + "+";
            else
                el += "!" + c + "+";
            if (leg[pocetakX][1] == '1')
                el += "!" + d;
            else
                el += d;
            s += "(" + el + ")";
        }
        //horizontalne dvojke
        if (brojac == 6)
        {
            string el = "";
            //a i b-vsrte
            if (leg[pocetakY][0] == '0')
                el += a + "+";
            else
                el += "!" + a + "+";
            if (leg[pocetakY][1] == '1')
                el += "!" + b;
            else
                el += b;
            el += "+";
            //c d-kolona
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '0')
                el += c;
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '1')
                el += "!" + c;
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '0')
                el += d;
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '1')
                el += "!" + c;
            s += "(" + el + ")";
        }
        return s;
    }
    private static string MinimalizujDvojkeCetriPromDNF(string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg = { "00", "01", "11", "10" };
        //vertikalne dvojke
        if (brojac == 7)
        {
            string el = "";
            //a b-vrste
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                el += "!" + a;
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                el += a;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                el += "!" + b;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                el += b;
            //c i d-kolone
            el += "*";
            if (leg[pocetakX][0] == '0')
                el += "!" + c + "+";
            else
                el += c + "+";
            if (leg[pocetakX][1] == '1')
                el += d;
            else
                el += "!" + d;
            s += "(" + el + ")";
        }
        //horizontalne dvojke
        if (brojac == 6)
        {
            string el = "";
            //a i b-vsrte
            if (leg[pocetakY][0] == '0')
                el += "!" + a + "+";
            else
                el += a + "+";
            if (leg[pocetakY][1] == '1')
                el += b;
            else
                el += "!" + b;
            el += "+";
            //c d-kolona
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '0')
                el += "!" + c;
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '1')
                el += c;
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '0')
                el += "!" + d;
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '1')
                el += d;
            s += "(" + el + ")";
        }
        return s;
    }
    private static string MinimalizujCetvorkeCetriPromKNF(string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg = { "00", "01", "11", "10" };
        //vertikalne cetvorke
        if (brojac == 4)
        {
            string el = "";
            if (leg[pocetakX][0] == '0')
                el += c + "+";
            else
                el += "!" + c + "+";
            if (leg[pocetakX][1] == '1')
                el += "!" + d;
            else
                el += d;
            s += "(" + el + ")";
        }
        //horizontalne cetvorke
        if (brojac == 2)
        {
            string el = "";
            if (leg[pocetakY][0] == '0')
                el += a + "+";
            else
                el += "!" + a + "+";
            if (leg[pocetakY][1] == '1')
                el += "!" + b;
            else
                el += b;
            s += "(" + el + ")";
        }
        //kvadratne cetvorke
        if (brojac == 5)
        {
            string el = "";
            //a/x1 i b/x2-vrste
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                el += a;
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                el += "!" + a;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                el += b;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                el += "!" + b;
            //c i d-kolone
            el += "+";
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '0')
                el += c;
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '1')
                el += "!" + c;
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '0')
                el += d;
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '1')
                el += "!" + d;
            s += "(" + el + ")";
        }
        return s;
    }
    private static string MinimalizujCetvorkeCetriPromDNF(string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg = { "00", "01", "11", "10" };
        //vertikalne cetvorke
        if (brojac == 4)
        {
            string el = "";
            if (leg[pocetakX][0] == '0')
                el += "!" + c + "*";
            else
                el += c + "*";
            if (leg[pocetakX][1] == '1')
                el += d;
            else
                el += "!" + d;
            s += el;
        }
        //horizontalne cetvorke
        if (brojac == 2)
        {
            string el = "";
            if (leg[pocetakY][0] == '0')
                el += "!" + a + "*";
            else
                el += a + "*";
            if (leg[pocetakY][1] == '1')
                el += b;
            else
                el += "!" + b;
            s += el;
        }
        //kvadratne cetvorke
        if (brojac == 5)
        {
            string el = "";
            //a/x1 i b/x2-vrste
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                el += "!" + a;
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                el += a;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                el += "!" + b;
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                el += b;
            el += "*";
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '0')
                el += "!" + c;
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '1')
                el += c;
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '0')
                el += "!" + d;
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '1')
                el += d;
            s += el;
        }
        return s;
    }
    private static string MinimalizujOsmiceCetriPromKNF(string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg = { "00", "01", "11", "10" };
        //vertikalne osmice
        if (brojac == 3)
        {
            string el = "";
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '0')
            {
                el += c;
            }
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '1')
            {
                el += "!" + c;
            }
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '0')
            {
                el += d;
            }
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '1')
            {
                el += "!" + d;
            }
            s += el;
        }
        //horizontalne osmice
        if (brojac == 1)
        {
            string el = "";
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
            {
                el += a;
            }
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
            {
                el += "!" + a;
            }
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
            {
                el += b;
            }
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
            {
                el += "!" + b;
            }
            s += el;
        }
        return s;
    }
    private static string MinimalizujOsmiceCetriPromDNF(string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
    {
        string s = "";
        string[] leg = { "00", "01", "11", "10" };
        //vertikalne osmice
        if (brojac == 3)
        {
            string el = "";
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '0')
            {
                el += "!" + c;
            }
            if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '1')
            {
                el += c;
            }
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '0')
            {
                el += "!" + d;
            }
            if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '1')
            {
                el += d;
            }
            s += el;
        }
        //horizontalne osmice
        if (brojac == 1)
        {
            string el = "";
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
            {
                el += "!" + a;
            }
            if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
            {
                el += a;
            }
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
            {
                el += "!" + b;
            }
            if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
            {
                el += b;
            }
            s += el;
        }
        return s;
    }
    //ISPIS
    static void IspisivanjeTablice()
    {
        int visina = 0;
        int sirina = 0;
        if (bp == 4) { visina = 11; sirina = 11; }
        else if (bp == 3) { visina = 11; sirina = 7; }
        else if (bp == 2) { visina = 7; sirina = 7; }
        char vodoravna = '\u2500', uspravna = '\u2502';
        char goreL = '\u250C', goreD = '\u2510';
        char doleL = '\u2514', doleD = '\u2518';
        char srednjeL = '\u251C', srednjeD = '\u2524';
        char gornji = '\u252C', donji = '\u2534';
        char centralni = '\u253C';
        int k = 0, j = 0;//brojaci za ispisivanje tablice

        for (int red = 0; red < visina; red++)
        {
            for (int kol = 0; kol < sirina; kol++)
            {
                //ispisivanje gornjih brojeva u 1. redu tabeli
                if (red == 1)
                {
                    if (kol % 2 == 0) Console.Write(uspravna);
                    else
                    {
                        Console.Write(' ');
                        if (bp == 4)
                        {
                            switch (kol)
                            {
                                case 1:
                                    Console.Write(' '); Console.Write(' ');
                                    break;
                                case 3:
                                    Console.Write("00");
                                    break;
                                case 5:
                                    Console.Write("01");
                                    break;
                                case 7:
                                    Console.Write("11");
                                    break;
                                case 9:
                                    Console.Write("10");
                                    break;
                            }
                        }
                        else if (bp == 3)
                        {
                            switch (kol)
                            {
                                case 1:
                                    Console.Write(' '); Console.Write(' ');
                                    break;
                                case 3:
                                    Console.Write(" 0");
                                    break;
                                case 5:
                                    Console.Write(" 1");
                                    break;
                            }
                        }
                        else if (bp == 2)
                        {
                            switch (kol)
                            {
                                case 1:
                                    Console.Write(' '); Console.Write(' ');
                                    break;
                                case 3:
                                    Console.Write(" 0");
                                    break;
                                case 5:
                                    Console.Write(" 1");
                                    break;
                            }
                        }
                        Console.Write(' ');
                    }
                }
                //redovi sa brojevima
                else if (red % 2 == 1)
                {
                    if (kol == 1)
                    {
                        Console.Write(' ');
                        if (bp == 4 || bp == 3)
                        {
                            switch (red)
                            {
                                case 3:
                                    Console.Write("00");
                                    break;
                                case 5:
                                    Console.Write("01");
                                    break;
                                case 7:
                                    Console.Write("11");
                                    break;
                                case 9:
                                    Console.Write("10");
                                    break;
                            }
                        }
                        else if (bp == 2)
                        {
                            switch (red)
                            {
                                case 3:
                                    Console.Write(" 0");
                                    break;
                                case 5:
                                    Console.Write(" 1");
                                    break;
                            }
                        }
                        Console.Write(' ');
                    }
                    else if (kol % 2 == 0) Console.Write(uspravna);
                    //ispisivanje vrednosti u tablicu
                    else
                    {
                        Console.Write(' ');
                        Console.Write(' ');
                        if (dnfKnf != ' ')
                        {
                            if (matrica[k, j] == trenutnaVelicina)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(nepromenjenaMatrica[k, j]);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(nepromenjenaMatrica[k, j]);
                            }
                            Console.Write(' ');
                            j++;
                            if (j == matrica.GetLength(1)) { j = 0; k++; }
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write(' ');
                            Console.Write(' ');
                        }
                    }

                }
                //ispisivanje svih linija
                else
                {
                    //linije za prvi i poslednji red
                    if (red == 0)
                    {
                        if (kol == 0) Console.Write(goreL);
                        else if (kol == sirina - 1) Console.Write(goreD);
                        else if (kol % 2 == 0) Console.Write(gornji);
                        else
                        {
                            for (int i = 0; i < 4; i++) Console.Write(vodoravna);
                        }
                    }
                    else if (red == visina - 1)
                    {
                        if (kol == 0) Console.Write(doleL);
                        else if (kol == sirina - 1) Console.Write(doleD);
                        else if (kol % 2 == 0) Console.Write(donji);
                        else
                        {
                            for (int i = 0; i < 4; i++) Console.Write(vodoravna);
                        }
                    }
                    //svih ostalih u sredini
                    else
                    {
                        if (kol == 0) Console.Write(srednjeL);
                        else if (kol == sirina - 1) Console.Write(srednjeD);
                        else if (kol % 2 == 0) Console.Write(centralni);
                        else { for (int i = 0; i < 4; i++) Console.Write(vodoravna); }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
