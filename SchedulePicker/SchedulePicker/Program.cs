using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
//using EvoPdf;
//using EvoPdf.PdfToText;

namespace SchedulePicker
{
    class Program
    {
        public static string ExtractTextFromPdf(string path)
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                return text.ToString();
            }
        }
        static void Main(string[] args)
        {

            string text = ExtractTextFromPdf("Horarios Sistemas II-2019.pdf");
            //Console.WriteLine(text) ;
            List<Complete> listComp = new List<Complete>();
            string[] completes = text.Split('\n');
            foreach (string row in completes)
            {
                Subject subject = new Subject();
                foreach (char c in row)
                {
                    if (Char.IsNumber(c))
                    {
                        subject.Code += c;
                        //Console.WriteLine(subject.Code);

                    }
                    else if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') && c != ' ')
                    {
                        break;
                    }
                    
                }
                //1803001INGLES I 1 MA 815 - 945(693B) CESPEDES GUIZADA MARIA BENITA
                
                string[] splitbyguion = row.Split('-');
                for (int i = splitbyguion.Length-1; i >=0 ; i--)
                {
                    string[] word = splitbyguion[i].Split(' ');
                    foreach (var w in word)
                    {
                        //Console.WriteLine(w.Length);
                        for (int index = w.Length; index >=0 ; index--)
                        {
                            List<Professor> professors = new List<Professor>();
                            if ((w[index] >= 'a' && w[index] <= 'z') || (w[index] >= 'A' && w[index] <= 'Z') || w[index] != ' ')
                            {
                                professors[index].Name = professors[index].Name + w[index];
                            }
                            //Console.WriteLine(professors[index].Name);
                            if (w[index] == ')' || w[index] == '(')
                            {
 
                            }
                        }
                        
                        
                    }
                }
            }

            Console.ReadKey();

        }
    }
}
