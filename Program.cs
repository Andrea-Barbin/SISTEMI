using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BarbinTraduzioneTarga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //INIZIO

            //DICHIARAZIONE VARIABILI
            string targa, parteLettere = "", parteNumeri = "";
            int valoreFinale = 0, i = 0, lunghTarga = 7;
            bool targaCorretta = true;

            //FASE DI INPUT

            //CICLO DO WHILE PER RIPETERE L'INSERIMENTO DELLA TARGA IN CASO SIA ERRATO
            do
            {

                //SEGNALAZIONE DI ERRORE IN CASO DI TARGA NON ACCETTABILE
                if (!targaCorretta)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nErrore, è stata inserita una targa di un formato non accettabile.\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    i = 0;
                    targaCorretta = !targaCorretta; //Una volta che la targa è stata inserita in modo errato la variabile bool da falsa ritorna vera per evitare di interrompere l'iterazione do-while.
                }

                //INSERIMENTO TARGA
                Console.WriteLine("Inserire una targa espressa nel formato LL CCC LL (L -> lettera dell'alfabeto inglese, C -> cifra in base 10):");
                targa = Console.ReadLine();

                //CONTROLLO LUNGHEZZA TARGA, se è diversa da 7 occorre ripetere l'inserimento.
                if (targa.Length != lunghTarga)
                {
                    targaCorretta = !targaCorretta;
                }

                else
                {

                    //CONTROLLO CORRETTEZZA TARGA, ciclo do-while che esamina tutti i caratteri della targa
                    do
                    {
                        //Se i primi due simboli e gli ultimi due non sono tutte lettere, oppure i 3 centrali non sono tutti numeri, allora la targa non è accettabile.
                        if (((i < 2 || i > 4) && (targa[i] < 65 || targa[i] > 90)) || ((i > 1 && i < 5) && (targa[i] < 48 || targa[i] > 57)))
                        {
                            targaCorretta = !targaCorretta;
                        }

                        i++;

                    } while (targaCorretta && i < targa.Length);
                }

            } while (!targaCorretta);

            //FASE DI ELABORAZIONE DATI

            //SUDDIVISIONE LETTERE E NUMERI IN DUE STRINGHE DIFFERENTI
            for (int k = 0; k < targa.Length; k++)
            {

                if (targa[k] > 64 && targa[k] < 91)
                {
                    parteLettere += targa[k];
                }
                else
                {
                    parteNumeri += targa[k];
                }

            }

            //ASSEGNAZIONE DEL RELATIVO VALORE PER CIASCUNA LETTERA 
            for (int j = 0; j < parteLettere.Length; j++)
            {

                valoreFinale += (25 - (90 - parteLettere[j])) * (int)Math.Pow(26, (3 - j)) * (int)Math.Pow(10, 3);

            }

            valoreFinale += Convert.ToInt32(parteNumeri);


            //FASE DI OUTPUT

            Console.WriteLine($"\nIl valore della targa è {valoreFinale}.");
            Console.ReadLine();

            //FINE

        }
    }
}


