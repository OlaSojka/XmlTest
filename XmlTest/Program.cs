using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace XmlTest
{
    class Program
    {
         static ExpertSystem expert;
         private static List<List<int>> listaList;

        private static List<int> test(Question q, List<int> index)
        {
            while (true)
            {
                Question q1 = expert.questions.Find(x => x.Id == q.no);
                Question q2 = expert.questions.Find(x => x.Id == q.yes);

                if (q.isConclusion)
                    return index;

                List<int> nowaLista = index;
                nowaLista.Add(q1.Id);
                listaList.Add(nowaLista);
                test(q1, nowaLista);

                index.Add(q2.Id);
                q = q2;
            }
        }

        // public static List<List<int>> listOLists = new List<List<int>>();

        static void Main(string[] args)
        {
            /*  const string path = "Headaches.xml";

              XmlSerializer serializer = new XmlSerializer(typeof(ExpertSystem), "http://tempuri.org/XMLSchema.xsd");

              StreamReader reader = new StreamReader(path);
              expert = (ExpertSystem)serializer.Deserialize(reader);
              reader.Close();*/

            expert = new ExpertSystem();
            expert.questions.Add(new Question(0, false, 1, 2, ""));
            expert.questions.Add(new Question(1, true, 0, 0, "wniosek"));
            expert.questions.Add(new Question(2, false, 3, 4, ""));
            expert.questions.Add(new Question(3, true, 0, 0, "wniosek"));
            expert.questions.Add(new Question(4, false, 5, 6, ""));
            expert.questions.Add(new Question(5, true, 0, 0, "wniosek"));
            expert.questions.Add(new Question(6, false, 7, 8, ""));
            expert.questions.Add(new Question(7, true, 0, 0, "wniosek"));
            expert.questions.Add(new Question(8, true, 0, 0, "wniosek"));

            listaList = new List<List<int>>();

              int id = 0;
              Question q = null;
              q = expert.questions.Find(q1 => q1.Id == id);

              List<int> listaYes = new List<int>();
              listaYes.Add(q.Id);
              //listaYes.Add(q.yes);

             // List<int> listaNo = new List<int>();
             // listaNo.Add(q.Id);
             // listaNo.Add(q.no);
             //
              listaList.Add(listaYes);
              //listaList.Add(listaNo);
             
             // test(q, q.yes, listaList.FindIndex(x => x.Equals(listaYes)));

             // test(q, q.no, listaList.FindIndex(x => x.Equals(listaNo)));


              List<int> eeee = test(q, listaYes);
            /*  for (int i = 0; i < eeee.Count; i++)
              {
                  Console.WriteLine(eeee.ElementAt(i));
                  Console.WriteLine();
              }*/

            /*   List<int> nowa = new List<int>();
               listOLists.Add(nowa);
               test(nowa, 0);

               foreach (var lista in listOLists)
               {
                   foreach (var id2 in lista)
                   {
                       Console.Write(id2 + ", ");
                   }
                   Console.WriteLine();
               }*/
            Console.ReadKey();
        }

        /*   public static void test(List<int> prev, int counter)
           {
           if(counter == 3)
               return;


                   List<int> newVector = new List<int>(prev);
                   newVector.Add(0);
                   listOLists.Add(newVector);
                   test(newVector, counter + 1);

                   prev.Add(1);
                   test(prev, counter + 1);

           }*/

        static void CountDown(int num)
        {
            Console.WriteLine("{0} ", num);
            if (num > 0)
                CountDown(--num);
        }
    }


}
