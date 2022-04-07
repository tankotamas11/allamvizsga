using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrafelmeletWeb.Pages
{
    public class GrafokModel : PageModel
    {
        struct Email
        {
            public string kuldo;
            public string fogado;
        }
        public struct Szemely
        {
            public string email;
            public int kuldottszam;

        }
        public int pozicio(string[] a, string b)
        {
            int c = 0;
            while (a[c] != b && c < 5652)
            {
                if (c > 5652) { return -1; }
                c++;
            }
            return c;
        }
        public int[,] proba = new int[5, 5];
        public bool seged = true;
        public int elso = 5653;
        public int szam = 0;
        public string[] persons = new string[5653];
        public Szemely[] szemelyek = new Szemely[5653];
        public int[,] matrix = new int[5653, 5653];
        public string[] data = { "alma", "szilva", "barack" };
        public void OnGet()
        {
            for (int k = 0; k < 5; k++)
            {
                for (int h = 0; h < 5; h++)
                {
                    if (k < h) { proba[k, h] = (k + h) % 2; }

                }

            }


            StreamReader sr = new StreamReader(@"C:\Users\tanko\OneDrive\Dokumentumok\harmadev\masodikfelev\netgyakorlat\allamvizsga\GrafelmeletWeb\GrafelmeletWeb\list1.txt");
            int i = 0;
            //string[] persons = new string[5653];
            while (sr.EndOfStream == false && i < 5)
            {
                Szemely potszemely;
                potszemely.email = sr.ReadLine();
                potszemely.kuldottszam = 0;
                szemelyek[i] = potszemely;
                //Console.WriteLine(persons[i]);
                i++;

            }
            //elso=persons[0];
            StreamReader sr2 = new StreamReader(@"C:\Users\tanko\OneDrive\Dokumentumok\harmadev\masodikfelev\netgyakorlat\allamvizsga\GrafelmeletWeb\GrafelmeletWeb\list2.txt");
            int j = 0;
            //string[] persons = new string[5653];
            //int[,] matrix = new int[5653, 5653];
            Email[] messages = new Email[88976];
            //88976 email
            while (sr2.EndOfStream == false && j < 2)
            {
                //persons[i] = sr.ReadLine();
                string line = sr2.ReadLine();
                string[] parts = line.Split(' ');
                Email email = new Email();
                email.kuldo = parts[0];
                email.fogado = parts[1];
                messages[j] = email;
                j++;
                var p = new GrafokModel();
                int segedi = p.pozicio(persons, email.kuldo);
                int segedj = p.pozicio(persons, email.fogado);
                //Console.WriteLine(matrix[segedi, segedj]);
                matrix[segedi, segedj]++;
                //Console.WriteLine(matrix[segedi, segedj]);

            }

            for (int s = 0; s < 5653; s++)
            {
                szam = szam + matrix[0, s];
            }

        }
    }
}
