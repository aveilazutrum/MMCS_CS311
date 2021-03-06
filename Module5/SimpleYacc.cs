// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.0
// Machine:  DESKTOP-ELLS3S8
// DateTime: 23.11.2019 0:20:51
// UserName: Makc0
// Input file <SimpleYacc.y - 23.11.2019 0:20:42>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;

namespace SimpleParser
{
public enum Tokens {
    error=1,EOF=2,BEGIN=3,END=4,CYCLE=5,INUM=6,
    RNUM=7,ID=8,ASSIGN=9,SEMICOLON=10,FOR=11,DO=12,
    TO=13,WHILE=14,IF=15,THEN=16,ELSE=17,REPEAT=18,
    VAR=19,UNTIL=20,RIGHT_BRACKET=21,LEFT_BRACKET=22,WRITE=23,PLUS=24,
    MINUS=25,DIVISION=26,MULT=27,COMMA=28};

// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<int,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
public class ScanObj {
  public int token;
  public int yylval;
  public LexLocation yylloc;
  public ScanObj( int t, int val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

public class Parser: ShiftReduceParser<int, LexLocation>
{
  // Verbatim content from SimpleYacc.y - 23.11.2019 0:20:42
// Ýòè îáúÿâëåíèÿ äîáàâëÿþòñÿ â êëàññ GPPGParser, ïðåäñòàâëÿþùèé ñîáîé ïàðñåð, ãåíåðèðóåìûé ñèñòåìîé gppg
    public Parser(AbstractScanner<int, LexLocation> scanner) : base(scanner) { }
  // End verbatim content from SimpleYacc.y - 23.11.2019 0:20:42

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[36];
  private static State[] states = new State[67];
  private static string[] nonTerms = new string[] {
      "progr", "$accept", "block", "stlist", "statement", "assign", "cycle", 
      "for", "if", "while", "repeat", "write", "var", "ident", "expr", "act", 
      };

  static Parser() {
    states[0] = new State(new int[]{3,4},new int[]{-1,1,-3,3});
    states[1] = new State(new int[]{2,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{8,22,3,4,5,31,11,35,15,43,14,50,18,55,23,60,19,65},new int[]{-4,5,-5,41,-6,9,-14,10,-3,29,-7,30,-8,34,-9,42,-10,49,-11,54,-12,59,-13,64});
    states[5] = new State(new int[]{4,6,10,7});
    states[6] = new State(-29);
    states[7] = new State(new int[]{8,22,3,4,5,31,11,35,15,43,14,50,18,55,23,60,19,65},new int[]{-5,8,-6,9,-14,10,-3,29,-7,30,-8,34,-9,42,-10,49,-11,54,-12,59,-13,64});
    states[8] = new State(-4);
    states[9] = new State(-5);
    states[10] = new State(new int[]{9,11});
    states[11] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,12,-14,21});
    states[12] = new State(new int[]{24,13,25,15,27,17,26,19,4,-16,10,-16,17,-16,20,-16,13,-16});
    states[13] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,14,-14,21});
    states[14] = new State(new int[]{24,13,25,15,27,17,26,19,4,-25,10,-25,17,-25,20,-25,13,-25,21,-25,8,-25,3,-25,5,-25,11,-25,15,-25,14,-25,18,-25,23,-25,19,-25,12,-25,16,-25});
    states[15] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,16,-14,21});
    states[16] = new State(new int[]{24,13,25,15,27,17,26,19,4,-26,10,-26,17,-26,20,-26,13,-26,21,-26,8,-26,3,-26,5,-26,11,-26,15,-26,14,-26,18,-26,23,-26,19,-26,12,-26,16,-26});
    states[17] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,18,-14,21});
    states[18] = new State(new int[]{24,13,25,15,27,17,26,19,4,-27,10,-27,17,-27,20,-27,13,-27,21,-27,8,-27,3,-27,5,-27,11,-27,15,-27,14,-27,18,-27,23,-27,19,-27,12,-27,16,-27});
    states[19] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,20,-14,21});
    states[20] = new State(new int[]{24,13,25,15,27,17,26,19,4,-28,10,-28,17,-28,20,-28,13,-28,21,-28,8,-28,3,-28,5,-28,11,-28,15,-28,14,-28,18,-28,23,-28,19,-28,12,-28,16,-28});
    states[21] = new State(-22);
    states[22] = new State(new int[]{28,23,9,-14,24,-14,25,-14,27,-14,26,-14,4,-14,10,-14,17,-14,20,-14,13,-14,21,-14,8,-14,3,-14,5,-14,11,-14,15,-14,14,-14,18,-14,23,-14,19,-14,12,-14,16,-14});
    states[23] = new State(new int[]{8,22},new int[]{-14,24});
    states[24] = new State(-15);
    states[25] = new State(-23);
    states[26] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,27,-14,21});
    states[27] = new State(new int[]{21,28,24,13,25,15,27,17,26,19});
    states[28] = new State(-24);
    states[29] = new State(-6);
    states[30] = new State(-7);
    states[31] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,32,-14,21});
    states[32] = new State(new int[]{24,13,25,15,27,17,26,19,8,22,3,4,5,31,11,35,15,43,14,50,18,55,23,60,19,65},new int[]{-5,33,-6,9,-14,10,-3,29,-7,30,-8,34,-9,42,-10,49,-11,54,-12,59,-13,64});
    states[33] = new State(-30);
    states[34] = new State(-8);
    states[35] = new State(new int[]{8,22},new int[]{-6,36,-14,10});
    states[36] = new State(new int[]{13,37});
    states[37] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,38,-14,21});
    states[38] = new State(new int[]{12,39,24,13,25,15,27,17,26,19});
    states[39] = new State(new int[]{8,22,3,4,5,31,11,35,15,43,14,50,18,55,23,60,19,65},new int[]{-4,40,-5,41,-6,9,-14,10,-3,29,-7,30,-8,34,-9,42,-10,49,-11,54,-12,59,-13,64});
    states[40] = new State(new int[]{10,7,4,-31,17,-31,20,-31});
    states[41] = new State(-3);
    states[42] = new State(-9);
    states[43] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,44,-14,21});
    states[44] = new State(new int[]{16,45,24,13,25,15,27,17,26,19});
    states[45] = new State(new int[]{8,22,3,4,5,31,11,35,15,43,14,50,18,55,23,60,19,65},new int[]{-4,46,-5,41,-6,9,-14,10,-3,29,-7,30,-8,34,-9,42,-10,49,-11,54,-12,59,-13,64});
    states[46] = new State(new int[]{17,47,10,7});
    states[47] = new State(new int[]{8,22,3,4,5,31,11,35,15,43,14,50,18,55,23,60,19,65},new int[]{-4,48,-5,41,-6,9,-14,10,-3,29,-7,30,-8,34,-9,42,-10,49,-11,54,-12,59,-13,64});
    states[48] = new State(new int[]{10,7,4,-32,17,-32,20,-32});
    states[49] = new State(-10);
    states[50] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,51,-14,21});
    states[51] = new State(new int[]{12,52,24,13,25,15,27,17,26,19});
    states[52] = new State(new int[]{8,22,3,4,5,31,11,35,15,43,14,50,18,55,23,60,19,65},new int[]{-5,53,-6,9,-14,10,-3,29,-7,30,-8,34,-9,42,-10,49,-11,54,-12,59,-13,64});
    states[53] = new State(-33);
    states[54] = new State(-11);
    states[55] = new State(new int[]{8,22,3,4,5,31,11,35,15,43,14,50,18,55,23,60,19,65},new int[]{-4,56,-5,41,-6,9,-14,10,-3,29,-7,30,-8,34,-9,42,-10,49,-11,54,-12,59,-13,64});
    states[56] = new State(new int[]{20,57,10,7});
    states[57] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,58,-14,21});
    states[58] = new State(new int[]{24,13,25,15,27,17,26,19,4,-34,10,-34,17,-34,20,-34});
    states[59] = new State(-12);
    states[60] = new State(new int[]{22,61});
    states[61] = new State(new int[]{8,22,6,25,22,26},new int[]{-15,62,-14,21});
    states[62] = new State(new int[]{21,63,24,13,25,15,27,17,26,19});
    states[63] = new State(-35);
    states[64] = new State(-13);
    states[65] = new State(new int[]{8,22},new int[]{-14,66});
    states[66] = new State(-17);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-2, new int[]{-1,2});
    rules[2] = new Rule(-1, new int[]{-3});
    rules[3] = new Rule(-4, new int[]{-5});
    rules[4] = new Rule(-4, new int[]{-4,10,-5});
    rules[5] = new Rule(-5, new int[]{-6});
    rules[6] = new Rule(-5, new int[]{-3});
    rules[7] = new Rule(-5, new int[]{-7});
    rules[8] = new Rule(-5, new int[]{-8});
    rules[9] = new Rule(-5, new int[]{-9});
    rules[10] = new Rule(-5, new int[]{-10});
    rules[11] = new Rule(-5, new int[]{-11});
    rules[12] = new Rule(-5, new int[]{-12});
    rules[13] = new Rule(-5, new int[]{-13});
    rules[14] = new Rule(-14, new int[]{8});
    rules[15] = new Rule(-14, new int[]{8,28,-14});
    rules[16] = new Rule(-6, new int[]{-14,9,-15});
    rules[17] = new Rule(-13, new int[]{19,-14});
    rules[18] = new Rule(-16, new int[]{24});
    rules[19] = new Rule(-16, new int[]{25});
    rules[20] = new Rule(-16, new int[]{27});
    rules[21] = new Rule(-16, new int[]{26});
    rules[22] = new Rule(-15, new int[]{-14});
    rules[23] = new Rule(-15, new int[]{6});
    rules[24] = new Rule(-15, new int[]{22,-15,21});
    rules[25] = new Rule(-15, new int[]{-15,24,-15});
    rules[26] = new Rule(-15, new int[]{-15,25,-15});
    rules[27] = new Rule(-15, new int[]{-15,27,-15});
    rules[28] = new Rule(-15, new int[]{-15,26,-15});
    rules[29] = new Rule(-3, new int[]{3,-4,4});
    rules[30] = new Rule(-7, new int[]{5,-15,-5});
    rules[31] = new Rule(-8, new int[]{11,-6,13,-15,12,-4});
    rules[32] = new Rule(-9, new int[]{15,-15,16,-4,17,-4});
    rules[33] = new Rule(-10, new int[]{14,-15,12,-5});
    rules[34] = new Rule(-11, new int[]{18,-4,20,-15});
    rules[35] = new Rule(-12, new int[]{23,22,-15,21});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
