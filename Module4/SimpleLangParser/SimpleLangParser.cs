﻿using System;
using System.Collections.Generic;
using System.Text;
using SimpleLexer;
namespace SimpleLangParser
{
    public class ParserException : System.Exception
    {
        public ParserException(string msg)
            : base(msg)
        {
        }

    }

    public class Parser
    {
        private SimpleLexer.Lexer l;

        public Parser(SimpleLexer.Lexer lexer)
        {
            l = lexer;
        }

        public void Progr()
        {
            Block();
        }

        public void Expr() 
        {
			// проверка на сумму или разность
			// проверка на переменную или число
            if (l.LexKind == Tok.ID || l.LexKind == Tok.INUM)
            {
                l.NextLexem();
				// проверка на плюс или минус
				if (l.LexKind == Tok.PLUS || l.LexKind == Tok.MINUS)
				{
					l.NextLexem();
					// повторный вызов для того чтобы продолжить проверку
					Expr();
				}
            }
            else
            {
                SyntaxError("expression expected");
            }
        }

        public void Assign() 
        {
			// проверка на оператор присвоения
            l.NextLexem();  // пропуск id
            if (l.LexKind == Tok.ASSIGN)
            {
                l.NextLexem();
            }
            else {
                SyntaxError(":= expected");
            }
			// вызов проверки на выражение
            Expr();
        }

		public void For()
		{
			// проверка на for
			if (l.LexKind != Tok.FOR)
			{
				SyntaxError("for expected");
			}
			l.NextLexem();
			// оператор присвоения
			Assign();
			// проверка на ключевое слово to
			if (l.LexKind != Tok.TO)
			{
				SyntaxError("to expected");
			}
			l.NextLexem();
			// проверка на выражение
			Expr();
			// проверка на ключевое слово do
			if (l.LexKind != Tok.DO)
			{
				SyntaxError("do expected");
			}
			l.NextLexem();
			// проверка на начало блока операторов
			if (l.LexKind == Tok.BEGIN)
			{
				Block();
			}
			else
			{
				// или на выражение
				Statement();
			}

		}

		public void StatementList() 
        {
			// список выражений
            Statement();
			// проверка на запятую
            while (l.LexKind == Tok.SEMICOLON)
            {
                l.NextLexem();
				// выражение
                Statement();
            }
        }

        public void Statement() 
        {
			// выражение
            switch (l.LexKind)
            {
				// блок операторов
                case Tok.BEGIN:
                    {
                        Block(); 
                        break;
                    }
				// цикл
                case Tok.CYCLE:
                    {
                        Cycle(); 
                        break;
                    }
				// переменная и оператор присвоения
                case Tok.ID:
                    {
                        Assign();
                        break;
                    }
				// цикл for
				case Tok.FOR:
					{
						For();
						break;
					}
                default:
                    {
                        SyntaxError("Operator expected");
                        break;
                    }
            }
        }

        public void Block() 
        {
			// отдельный блок операторов
            l.NextLexem();    // пропуск begin
            StatementList();
			// конец блока
            if (l.LexKind == Tok.END)
            {
                l.NextLexem();
            }
            else
            {
                SyntaxError("end expected");
            }

        }

        public void Cycle() 
        {
			// цикл
            l.NextLexem();  // пропуск cycle
            Expr();
            Statement();
        }

        public void SyntaxError(string message) 
        {
            var errorMessage = "Syntax error in line " + l.LexRow.ToString() + ":\n";
            errorMessage += l.FinishCurrentLine() + "\n";
            errorMessage += new String(' ', l.LexCol - 1) + "^\n";
            if (message != "")
            {
                errorMessage += message;
            }
            throw new ParserException(errorMessage);
        }
   
    }
}
