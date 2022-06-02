

//Ispis u koracima
//Kreiranje tablice na osnovu izraza


using System;
class Program
{
  static char[,] matrica = new char[,]{};
  static string forma = "";
  static string[] simboli = new string[] {};
  static char dnfKnf = '1';

  static bool prekiniAlUnos = false;
  
  static void Main (string[] args)
  {
      UnosPodataka();
      string krajnjiIzraz = "";
      char trenutnaVelicina = '2', obrnutoDnfKnf;
      bool tacnost = true, provera = true; ;
      int pocetakX = 0, pocetakY = 0, krajX = 0, krajY = 0;
      char[,] temp = new char[4, 4], temp2 = new char[4, 4];
      //pravi kopiju karte
      for (int i = 0; i < matrica.GetLength(0); i++)
        {
           for (int j = 0; j < matrica.GetLength(1); j++)
            {
              temp[i, j] = matrica[i, j];
            }
        }
      for (int i = 0; i < matrica.GetLength(0); i++)
        {
          for (int j = 0; j < matrica.GetLength(1); j++)
            {
              temp2[i, j] = matrica[i, j];
            }
        }

      if (dnfKnf == '1') obrnutoDnfKnf = '0';
        else obrnutoDnfKnf = '1';

      //odredjivanje parametara tako da gledaju vodoravne podmatrice
      for (int br = 0; br < 7; br++)
        {
          //odredjuje parametre tako da gledaju razlicite grupe
          switch (br)
            {
              case 0://vodoravne grupe od 8
                krajY = 2;
                pocetakX=0;
                pocetakY=0;
                krajX = 4;
                trenutnaVelicina = '8';
                break;
              case 1://vodoravne grupe od 4
                 krajY = 1;
                 pocetakX=0;
                 pocetakY=0;
                 krajX = 4;
                 trenutnaVelicina = '4';
                 break;
              case 2://uspravne grupe od 8
                 krajY = 4;
                 pocetakX=0;
                 pocetakY=0;
                 krajX = 2;
                 trenutnaVelicina = '8';
                 break;
              case 3://uspravne grupe od 4
                 krajY = 4;
                 pocetakX=0;
                 pocetakY=0;
                 krajX = 1;
                 trenutnaVelicina = '4';
                 break;
              case 4://grupe 2x2
                 krajY = 2;
                 pocetakX=0;
                 pocetakY=0;
                 krajX = 2;
                 trenutnaVelicina = '4';
                 break;
              case 5://grupe od 2 polja vodoravno
                 krajY = 1;
                 pocetakX=0;
                 pocetakY=0;
                 krajX = 2;
                 trenutnaVelicina = '2';
                 break;
              case 6://grupe od 2 polja uspravno
                 krajY = 2;
                 pocetakX=0;
                 pocetakY=0;
                 krajX = 1;
                 trenutnaVelicina = '2';
                 break;
              default:
                 break;
                }
        while (krajY <= 5 && krajX <= 5)//kaze sve dok je <= od 5 da bi u poslednjem krugu mogao da gleda i poslednju i prvu kolonu
        {
          tacnost = true;
          provera = false;
          for (int i = pocetakY; i < krajY; i++)
            {
              for (int j = pocetakX; j < krajX; j++)
                {
                  //proverava da li je bilo koja od vrednosti u podmatrici koju posmatra suprotna od trazene
                  if (temp[i % 4, j % 4] == obrnutoDnfKnf) { tacnost = false; break; }
                  if (temp[i % 4, j % 4] == dnfKnf) provera = true;
                }
              if (!tacnost) break;
            }
          //ako je posmatrana podmatrica dobra ovo ce je pretvoriti u odgovarajucu vrednost
          if (tacnost && provera)
            {
              for (int i = pocetakY; i < krajY; i++)
                {
                   for (int j = pocetakX; j < krajX; j++) { temp[i % 4, j % 4] = trenutnaVelicina; matrica[i % 4, j % 4] = trenutnaVelicina; }
                }
                
                //smanjivanje
                if(br == 0 || br == 2)//u ovim slucajevima su osmice
                { 
                  if(dnfKnf =='0')krajnjiIzraz += MinimalizujOsmiceKNF(matrica, a, b, c, d,br, pocetakX, pocetakY);
                            else krajnjiIzraz += MinimalizujOsmiceDNF(matrica,a,b,c,d,br,pocetakX, pocetakY);
                }
                else if(br == 1 || br == 3 || br == 4)//u ovim slucajevima su cetvorke
                {
                  if(dnfKnf =='0')krajnjiIzraz += MinimalizujCetvorkeKNF(matrica, a, b, c, d,br, pocetakX, pocetakY);
                            else krajnjiIzraz += MinimalizujCetvorkeDNF(matrica,a,b,c,d,br,pocetakX, pocetakY);
                }
                else if(br == 5 || br == 6)//u ovim slucajevima su dvojke
                {
                  if(dnfKnf =='0')krajnjiIzraz += MinimalizujDvojkeKNF(matrica, a, b, c, d,br, pocetakX, pocetakY);
                            else krajnjiIzraz += MinimalizujDvojkeDNF(matrica,a,b,c,d,br,pocetakX, pocetakY);
                }
                //crtanje
                IspisivanjeTablice();
                //ubacivanje starih vrednosti u matricu
                for (int i = 0; i < 4; i++)
                  {
                    for (int j = 0; j < 4; j++)
                      {
                        matrica[i, j] = temp2[i, j];
                      }
                  }
            }
        //odredjuje koji parametri se inkrementiraju
        switch (br)
          {
          case 0:
          case 1://vodoravne grupe cetvorki i osmica
            pocetakY++;
            krajY++;
            break;
          case 2:
          case 3://uspravne grupe cetvorki i osmica
            pocetakX++;
            krajX++;
            break;
          case 4:
          case 5://grupe 2x2 i vodoravne dvojke
            pocetakX++;
            krajX++;
            if (krajX == 6)
              {
                pocetakX = 0;
                krajX = 2;
                pocetakY++;
                krajY++;
              }
             break;
          case 6://uspravne dvojke
            pocetakX++;
            krajX++;
            if (krajX == 6)
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

  static void UnosPodataka()
  {
      forma = ""; matrica = new char[,]{};simboli = new string[]{};
      string izbor = opcije(new string[] {"TA","AL","PR"}, "Da li želite da unesete tablicu ili algebarski izraz?\n[Ta] - tablica\n[Al] - algebarski izraz\n[Pr] - prekini program\nMožete da prekinete program u bilo kom trenutnku.");
      if (izbor == "TA")
      {
        UnosTablice();
      }
      else if (izbor == "AL")
      {
        UnosIzraza();
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
      Console.WriteLine("Program je prekinut. Napišite [POKRENI] da biste ga ponovo pokrenuli.");
      while (Console.ReadLine().ToUpper() != "POKRENI"){}//Čeka se da korisnik traži pokretanje, ToUpper da bi i pogrešan unos, na primer, PoKrEni ipak pokrenuo program.
      Console.Clear();//Nakon toga ponovo počinje unos podataka
      UnosPodataka();
  }
  static void UnosTablice()
  {
        Console.WriteLine("Koliko promenljivih želite?");
        int bp =0;
        string bps = string.Empty;
        bool nijeValidno = true;
        while (nijeValidno)
        {
            bps = Console.ReadLine();
            nijeValidno = !int.TryParse(bps, out bp) || bp > 4 || bp < 2;
            if (nijeValidno) Console.WriteLine("Nevažeči broj promenljivih. Da li želite 2, 3 ili 4?");
            TraziPrekid(bps);
        }
        Console.WriteLine("Unesite " + bp + " simbola, svaki u posebnom redu.");
        string[] simb = new string[]{};
        int br = 1;
        while (br <= bp)
        {
            UnosPromenljivih(ref br, ref simb);
        }
        int x = 0;
        x = bp -  (bp == 4? 0:1);//4 reda - 4p / 2r-3p,1r-2p
        matrica = new char[4, x];
        for (int i = 0; i < 4; i++)
        {
          bool validanRed = false;
          bool greskaRed = false;
          while (!validanRed)
          {
            validanRed = greskaRed = false;
            int j = 0;
            Console.WriteLine("Unesite " + (i+1) + ". red :");
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
        forma = opcije(new string[]{"KNF","DNF"},"KNF ili DNF : ");
       
  }

  static void UnosPromenljivih(ref int brPromenljivih, ref string[] simboli)
  {
      string[] zabranjeniSimboli = new string[] {"I", "AND", "*", "∙", "ILI", "OR", "+", "NE", "NOT", "¬", "′", "EksILI", "XOR", "⊕", "NI", "NAND","NILI","NOR", "(",")"};
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
                  Console.WriteLine("Unos je nevažeći. Ime promenljive ne sme da sadrži simbole ili reči koje se odnose na operacije, na primer, ''I''.");
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
                    Array.Resize(ref simboli, simboli.Length+1);
                    simboli[simboli.Length-1] = u.ToString();
                    brPromenljivih++;
                  }
                }
                else Console.WriteLine("Već ste uneli ovaj simbol.");
            }
          }
      }
  }
  static void UnosIzraza()
  {  
      string Operacije = "[I][AND][∙][*]\n[ILI][OR][+]\n[NE][NOT][!][′]\n[EksILI][XOR][⊕]\n[NI][NAND]\n[NILI][NOR]";
      Console.WriteLine("Primeri validnih algebarskih izraza:");
      Console.WriteLine("Q ILI N\nQ + N\nQ OR N\nQ XOR N\nQ ⊕ N");
      Console.WriteLine("Između svakog simbola i operacije mora biti tačno jedan razmak.");
      string sO = opcije(new string[] {"DA", "NE"}, "Da li želite da vidite spisak svih mogućih operacija? [DA]/[NE]");
      if (sO == "DA") Console.WriteLine(Operacije);
      string rU = opcije(new string[] {"DA", "NE"}, "Da li želite da sami unesete sve simbole? [DA]/[NE]");
      simboli = new string[]{};
      if (rU == "DA")
      {
          Console.WriteLine("Unesite po jedan simbol u redu. Unos završavate znakom ''.''. Dozvoljena su do 4 simbola.");
          string u = string.Empty;
          int brPromenljivih = 0;
          prekiniAlUnos = false;
          while (!prekiniAlUnos && brPromenljivih < 4)
          {
              UnosPromenljivih(ref brPromenljivih, ref simboli);
          }
      }
      else
      {
        bool validno = false;
        while (!validno)
        {
          bool greska = false, slovoGreska = false, razmakGreska = false;
          Console.WriteLine("Unesite izraz: ");
          string s = Console.ReadLine();
          TraziPrekid(s);
          string[] e = s.Split(' ');
          simboli = new string[] {};
          int simboliTL = 1; //broji koliko simbola ima pre njihovog pojedinacnog proveravanja, da bi se proverio broj razmaka.
          bool broji = false;
          foreach (char c in s)
          {
            if (broji)
            {
                if (char.IsLetter(c))
                {
                  simboliTL++;
                  broji = false;
                }
            }
            if (!broji && !char.IsLetter(c))
            {
               broji = true;
            }
          }
          foreach (string str in e)
          {
            string[] dozvoljeni = new string[] {"I", "AND", "*", "∙", "ILI", "OR", "+", "NE", "NOT", "¬", "′", "EksILI", "XOR", "⊕", "NI", "NAND","NILI","NOR", "(",")"};
            if (!nizSadrzi(dozvoljeni, str) && !nizSadrzi(simboli, str))
            {
                Array.Resize(ref simboli, simboli.Length+1);
                simboli[simboli.Length-1] = str;
            }
          }
          foreach (string str in simboli)
          { if (!char.IsLetter(str[0])) {greska = true;  slovoGreska = true;}}
          if (simboli.Length == 0) greska = true;
          if (simboli.Length != simboliTL) greska = true; razmakGreska = true;
          validno = !greska;
          if (!greska)
          {
            Console.WriteLine("Simboli ovog izraza su : ");
            foreach (string str in simboli) Console.WriteLine(str);
          }
          else if (slovoGreska) Console.WriteLine("Simbol mora da počne slovom.");
          else if (simboli.Length == 0) Console.WriteLine("U izrazu nema simbola.");
          else if (razmakGreska) Console.WriteLine("Između svakog simbola i operacije mora da bude tačno jedan razmak.");
        }
      }
      forma = opcije(new string[] {"KNF","DNF"},"KNF ili DNF : ");
  }
  static bool nizSadrzi(string[] niz, string s)
  {
    foreach (string str in niz) if (str == s) return true;
    return false;
  }
  private static string MinimalizujDvojkeKNF(char[,] mat, string a, string b, string c, string d,int brojac,int pocetakX,int pocetakY)
        {
            string s = "";
            string[] leg = { "00", "01", "11", "10" };
            //vertikalne dvojke
                    if (brojac == 6)
                    {
                        string el = "";
                        //a b-vrste
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
                        //c i d-kolone
                        if (el != "")
                        {
                            el += "+";
                        }
                        //uzeto od vertikalnih cetvorki
                        if (leg[pocetakX][0] == '0')
                        {
                            el += c + "+";
                        }
                        else
                        {
                            el += "!" + c + "+";
                        }
                        if (leg[pocetakX][1] == '1')
                        {
                            el += "!" + d;
                        }
                        else
                        {
                            el += d;
                        }
                        s += "(" + el + ")";
                    }
            
            //horizontalne dvojke
                    if (brojac == 5)
                    {
                        string el = "";
                //a i b-vsrte
                        if (leg[pocetakY][0] == '0')
                        {
                            el += a + "+";
                        }
                        else
                        {
                            el += "!" + a + "+";
                        }
                        if (leg[pocetakY][1] == '1')
                        {
                            el += "!" + b;
                        }
                        else
                        {
                            el += b;
                        }
                        if (el != "")
                        {
                            el += "+";
                        }
                        //c d-kolona
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
                            el += "!" + c;
                        }
                        s += "(" + el + ")";
            }
            return s;
        }
   private static string MinimalizujDvojkeDNF(char[,] mat, string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
        {
            string s = "";
            string[] leg = { "00", "01", "11", "10" };
            //vertikalne dvojke
            if (brojac == 6)
            {
                string el = "";
                //a b-vrste
                if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                {
                    el += "!" + a;
                }
                if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                {
                    el +=a;
                }
                if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                {
                    el += "!" + b;
                }
                if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                {
                    el +=b;
                }
                //c i d-kolone
                if (el != "")
                {
                    el += "+";
                }
                //uzeto od vertikalnih cetvorki
                if (leg[pocetakX][0] == '0')
                {
                    el += "!" + c + "+";
                }
                else
                {
                    el +=c + "+";
                }
                if (leg[pocetakX][1] == '1')
                {
                    el +=d;
                }
                else
                {
                    el +="!"+ d;
                }
                s += "(" + el + ")";
            }

            //horizontalne dvojke
            if (brojac == 5)
            {
                string el = "";
                //a i b-vsrte
                if (leg[pocetakY][0] == '0')
                {
                    el += a + "+";
                }
                else
                {
                    el += "!" + a + "+";
                }
                if (leg[pocetakY][1] == '1')
                {
                    el += "!" + b;
                }
                else
                {
                    el += b;
                }
                if (el != "")
                {
                    el += "+";
                }
                //c d-kolona
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
                    el += "!" + c;
                }
                s += "(" + el + ")";
            }
            return s;
        }
        private static string MinimalizujCetvorkeKNF(char[,] mat, string a, string b, string c, string d,int brojac,int pocetakX,int pocetakY)
        {
            string s = "";
            string[] leg = { "00", "01", "11", "10" };
            //vertikalne cetvorke
            if (brojac==3)
            {
                string el = "";
                if (leg[pocetakX][0] == '0')
                {
                    el += c + "+";
                }
                else
                {
                    el += "!" + c + "+";
                }
                if (leg[pocetakX][1] == '1')
                {
                    el += "!" + d;
                }
                else
                {
                    el += d;
                }
                s += "(" + el + ")";
            }    
            //horizontalne cetvorke
                if (brojac == 1)
                {
                    string el = "";
                    if (leg[pocetakY][0] == '0')
                    {
                        el += a + "+";
                    }
                    else
                    {
                        el += "!" + a + "+";
                    }
                    if (leg[pocetakY][1] == '1')
                    {
                        el += "!" + b;
                    }
                    else
                    {
                        el += b;
                    }
                    s += "(" + el + ")";

                }
            //kvadratne cetvorke
                    if (brojac == 4)
                    {
                        string el = "";
                        //a/x1 i b/x2-vrste
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
                        //c i d-kolone
                        if (el != "")
                        {
                            el += "+";
                        }
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
            return s;
        }
private static string MinimalizujCetvorkeDNF(char[,] mat, string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
        {
            string s = "";
            string[] leg = { "00", "01", "11", "10" };
            //vertikalne cetvorke
            if (brojac == 3)
            {
                string el = "";
                if (leg[pocetakX][0] == '0')
                {
                    el += "!" + c + "+";
                }
                else
                {
                    el +=c + "+";
                }
                if (leg[pocetakX][1] == '1')
                {
                    el += d;
                }
                else
                {
                    el +="!"+ d;
                }
                s += "(" + el + ")";
            }
            //horizontalne cetvorke
            if (brojac == 1)
            {
                string el = "";
                if (leg[pocetakY][0] == '0')
                {
                    el += "!" + a + "+";
                }
                else
                {
                    el +=a + "+";
                }
                if (leg[pocetakY][1] == '1')
                {
                    el += b;
                }
                else
                {
                    el +="!"+ b;
                }
                s += "(" + el + ")";

            }
            //kvadratne cetvorke
            if (brojac == 4)
            {
                string el = "";
                //a/x1 i b/x2-vrste
                if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                {
                    el += "!" + a;
                }
                if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                {
                    el +=a;
                }
                if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                {
                    el += "!" + b;
                }
                if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                {
                    el +=b;
                }
                //c i d-kolone
                if (el != "")
                {
                    el += "+";
                }
                if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '0')
                {
                    el += "!" + c;
                }
                if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '1')
                {
                    el +=c;
                }
                if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '0')
                {
                    el += "!" + d;
                }
                if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '1')
                {
                    el +=d;
                }
                s += el;
            }
            return s;
        }
        private static string MinimalizujOsmiceKNF(char[,] mat, string a, string b, string c, string d,int brojac,int pocetakX,int pocetakY)
        {
            string s = "";
            string[] leg = { "00", "01", "11", "10" };
            //vertikalne osmice
            if (brojac==2)
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
                if (s != "")
                {
                    s += "+";
                }
                s += el;
            }
            //horizontalne osmice
                if (brojac == 0)
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
                    if (s != "")
                    {
                        s += "+";
                    }
                    s += el;
                }

            return s;
        }
        private static string MinimalizujOsmiceDNF(char[,] mat, string a, string b, string c, string d, int brojac, int pocetakX, int pocetakY)
        {
            string s = "";
            string[] leg = { "00", "01", "11", "10" };
            //vertikalne osmice
            if (brojac == 2)
            {
                string el = "";
                if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '0')
                {
                    el += "!" + c;
                }
                if (leg[pocetakX][0] == leg[(pocetakX + 1) % 4][0] && leg[pocetakX][0] == '1')
                {
                    el +=c;
                }
                if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '0')
                {
                    el += "!" + d;
                }
                if (leg[pocetakX][1] == leg[(pocetakX + 1) % 4][1] && leg[pocetakX][1] == '1')
                {
                    el +=d;
                }
                if (s != "")
                {
                    s += "+";
                }
                s += el;
            }
            //horizontalne osmice
            if (brojac == 0)
            {
                string el = "";
                if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '0')
                {
                    el += "!" + a;
                }
                if (leg[pocetakY][0] == leg[(pocetakY + 1) % 4][0] && leg[pocetakY][0] == '1')
                {
                    el +=a;
                }
                if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '0')
                {
                    el += "!" + b;
                }
                if (leg[pocetakY][1] == leg[(pocetakY + 1) % 4][1] && leg[pocetakY][1] == '1')
                {
                    el +=b;
                }
                if (s != "")
                {
                    s += "+";
                }
                s += el;
            }

            return s;
        }
  static void IspisivanjeTablice()
    {
		Console.ForegroundColor = ConsoleColor.White;
		int visina = 11;
		int sirina = 11;
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
						Console.Write(' ');
					}
				}
				//izmedju redovi sa brojevima
				else if (red % 2 == 1)
				{
					if (kol == 1)
					{
						Console.Write(' ');
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
						Console.Write(' ');
					}
					else if (kol % 2 == 0) Console.Write(uspravna);
					//ispisivanje vrednosti u tablicu
					else
					{
						Console.Write(' ');
						Console.Write(' ');
						Console.Write(matrica[k, j]);
						Console.Write(' ');
						j++;
            if (j == matrica.GetLength(1)) { j = 0;k++; }
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





/*
  Ispis u koracima (A i T)
  Kreiranje tablice od algebarskog izraza
  Dizajn tablice
  Algoritmi resavanja tablica
  nacin kako da program pravi one kocke
*/