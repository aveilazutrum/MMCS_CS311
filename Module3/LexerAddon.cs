using System;
using System.IO;
using SimpleScanner;
using ScannerHelper;
using System.Collections.Generic;

namespace  GeneratedLexer
{
    
    public class LexerAddon
    {
        public Scanner myScanner;
        private byte[] inputText = new byte[255];

        public int idCount = 0;
        public int minIdLength = Int32.MaxValue;
        public double avgIdLength = 0;
        public int maxIdLength = 0;
        public int sumInt = 0;
        public double sumDouble = 0.0;
        public List<string> idsInComment = new List<string>();
        

        public LexerAddon(string programText)
        {
            
            using (StreamWriter writer = new StreamWriter(new MemoryStream(inputText)))
            {
                writer.Write(programText);
                writer.Flush();
            }
            
            MemoryStream inputStream = new MemoryStream(inputText);
            
            myScanner = new Scanner(inputStream);
        }

        public void Lex()
        {
            // Чтобы вещественные числа распознавались и отображались в формате 3.14 (а не 3,14 как в русской Culture)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            int tok = 0;
            double sum = 0;
			do
			{
				tok = myScanner.yylex();
				// выход по концу текста
				if (tok == (int)Tok.EOF)
				{
					break;
				}  // поиск переменных
				else if (tok == (int)Tok.ID)
				{
					string text = myScanner.yytext;
					// минимум и максимум имени переменной
					if (minIdLength > text.Length)
					{
						minIdLength = text.Length;
					}
					if (maxIdLength < text.Length)
					{
						maxIdLength = text.Length;
					}
					sum += myScanner.yyleng;
					idCount++;

				}
				// сумма всех целых чисел
				else if (tok == (int)Tok.INUM)
				{
					sumInt += myScanner.LexValueInt;
				}
				// сумма всех дробных чисел 
				else if (tok == (int)Tok.RNUM)
				{
					sumDouble += myScanner.LexValueDouble;
				}
				
			} while (true);
			// средняя длина имени переменной 
			avgIdLength = sum / idCount;
		}
	}
}





