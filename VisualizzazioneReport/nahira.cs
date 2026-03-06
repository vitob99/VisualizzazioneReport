using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgettoFabbrica
{
    // 1. OGGETTO PRODOTTO
    public class Prodotto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoCarta { get; set; }
    }

    // 2. LOGICA DEL REPORT
    public class Report
    {
        private List<Prodotto> lista;

        public Report(List<Prodotto> listaProdotti)
        {
            lista = listaProdotti;
        }

        public void StampaTutto()
        {
            Console.WriteLine("\n--- ELENCO PRODOTTI ---");
            foreach (var p in lista)
            {
                Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Carta: {p.TipoCarta}");
            }
        }

        public void StampaStatistiche()
        {
            Console.WriteLine("\n--- STATISTICHE FABBRICA ---");
            Console.WriteLine($"Totale prodotti: {lista.Count}");
            
            var piuUsato = lista.GroupBy(x => x.TipoCarta)
                                .OrderByDescending(g => g.Count())
                                .FirstOrDefault();

            if (piuUsato != null)
            {
                Console.WriteLine($"Carta più usata: {piuUsato.Key} ({piuUsato.Count()} pezzi)");
            }
        }
    }

    // 3. PROGRAMMA PRINCIPALE (MENU)
    class Program
    {
        static void Main(string[] args)
        {
            // Creiamo dei dati finti per testare il menu
            List<Prodotto> database = new List<Prodotto>
            {
                new Prodotto { Id = 1, Nome = "Quaderno A4", TipoCarta = "Riciclata" },
                new Prodotto { Id = 2, Nome = "Blocco Note", TipoCarta = "Premium" },
                new Prodotto { Id = 3, Nome = "Agenda", TipoCarta = "Riciclata" }
            };

            Report mioReport = new Report(database);
            bool esci = false;

            while (!esci)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("    MENU GESTIONALE FABBRICA    ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Visualizza tutti i prodotti");
                Console.WriteLine("2. Visualizza statistiche report");
                Console.WriteLine("0. Esci");
                Console.Write("\nScegli un'opzione: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        mioReport.StampaTutto();
                        break;
                    case "2":
                        mioReport.StampaStatistiche();
                        break;
                    case "0":
                        esci = true;
                        Console.WriteLine("Chiusura programma...");
                        break;
                    default:
                        Console.WriteLine("Opzione non valida!");
                        break;
                }

                if (!esci)
                {
                    Console.WriteLine("\nPremi un tasto per tornare al menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}