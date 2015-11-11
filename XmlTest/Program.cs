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

        static void test(Question q, int id)
        {
            Question q1 = expert.questions.Find(delegate(Question q2)
            {
                return q2.Id == id;
            }
            );

            if (!q.isConclusion)
            {
                Console.WriteLine(q1.no);
                test(q1, q1.no);
                Console.WriteLine(q1.yes);
                test(q1, q1.yes);

            }
            else
                Console.WriteLine(q.content);
        }


        static void Main(string[] args)
        {
            string path = "FebrileSeizures.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(ExpertSystem), "http://tempuri.org/XMLSchema.xsd");

            StreamReader reader = new StreamReader(path);
            expert = (ExpertSystem)serializer.Deserialize(reader);
            reader.Close();

           // Console.WriteLine("title: {0}", expert.title);
           // Console.WriteLine("description: {0}", expert.description);

          /*  foreach (Question t in expert.questions)
            {
                Console.WriteLine("ID: {0}", t.Id);
                Console.WriteLine("yes: {0}, no: {1}, isConclusion: {2}", t.yes, t.no, t.isConclusion);
                Console.WriteLine("content: {0}", t.content);
            }*/
            /*
            foreach (Source s in expert.sources)
            {
                Console.WriteLine("linkdescription: {0}", s.linkDesccription);
                Console.WriteLine("link: {0}", s.link);
            }
            */
            int id = 0;
            Question q = null;
           // while (true)
           // {
                q = expert.questions.Find(delegate(Question q1)
                {
                    return q1.Id == id;
                }
                );
                
                Console.WriteLine(q.yes);
                test(q, q.yes);
                Console.WriteLine(q.no);
                test(q, q.no);
                
              //  Console.WriteLine("content: {0}", q.content);

          /*      if (!q.isConclusion)
                {
                    Console.WriteLine("Press y for 'yes' or n for 'no'");
                    ConsoleKeyInfo cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Y)
                    {
                        id = q.yes;
                        
                    }
                    else if (cki.Key == ConsoleKey.N)
                    {
                        id = q.no;
                    }
                }
                else
                    break;*/
              //  Console.WriteLine(id);
           // }
            Console.ReadKey();
        }
    }
}
