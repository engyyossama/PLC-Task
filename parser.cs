
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;


namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF = 0, // (EOF)
        SYMBOL_ERROR = 1, // (Error)
        SYMBOL_WHITESPACE = 2, // Whitespace
        SYMBOL_MINUS = 3, // '-'
        SYMBOL_MINUSMINUS = 4, // '--'
        SYMBOL_EXCLAMEQ = 5, // '!='
        SYMBOL_PERCENT = 6, // '%'
        SYMBOL_LPAREN = 7, // '('
        SYMBOL_RPAREN = 8, // ')'
        SYMBOL_TIMES = 9, // '*'
        SYMBOL_TIMESTIMES = 10, // '**'
        SYMBOL_COMMA = 11, // ','
        SYMBOL_DOT = 12, // '.'
        SYMBOL_DIV = 13, // '/'
        SYMBOL_COLON = 14, // ':'
        SYMBOL_SEMI = 15, // ';'
        SYMBOL_PLUS = 16, // '+'
        SYMBOL_PLUSPLUS = 17, // '++'
        SYMBOL_LT = 18, // '<'
        SYMBOL_EQ = 19, // '='
        SYMBOL_EQEQ = 20, // '=='
        SYMBOL_GT = 21, // '>'
        SYMBOL_BOOL = 22, // bool
        SYMBOL_BREAK = 23, // break
        SYMBOL_BYT = 24, // byt
        SYMBOL_CASE = 25, // case
        SYMBOL_DIGIT = 26, // Digit
        SYMBOL_DOUB = 27, // doub
        SYMBOL_ELSE = 28, // else
        SYMBOL_END = 29, // End
        SYMBOL_FLOUT = 30, // flout
        SYMBOL_FOR = 31, // for
        SYMBOL_ID = 32, // Id
        SYMBOL_IF = 33, // if
        SYMBOL_INT = 34, // int
        SYMBOL_PRINT = 35, // print
        SYMBOL_START = 36, // Start
        SYMBOL_STR = 37, // str
        SYMBOL_SWITCH = 38, // switch
        SYMBOL_VALUE = 39, // value
        SYMBOL_WHILE = 40, // while
        SYMBOL_ASSIGN = 41, // <assign>
        SYMBOL_CONCEPT = 42, // <concept>
        SYMBOL_COND = 43, // <cond>
        SYMBOL_DIGIT2 = 44, // <digit>
        SYMBOL_EXP = 45, // <exp>
        SYMBOL_EXPR = 46, // <expr>
        SYMBOL_FACTOR = 47, // <factor>
        SYMBOL_FOR_STMT = 48, // <for_stmt>
        SYMBOL_ID2 = 49, // <Id>
        SYMBOL_IF_STMT = 50, // <if_stmt>
        SYMBOL_OP = 51, // <op>
        SYMBOL_PRINT_STMT = 52, // <print_stmt>
        SYMBOL_PROGRAM = 53, // <program>
        SYMBOL_STEP = 54, // <step>
        SYMBOL_STMT_LIST = 55, // <stmt_list>
        SYMBOL_SWITCH_STMT = 56, // <switch_stmt>
        SYMBOL_TERM = 57, // <term>
        SYMBOL_TYPE = 58, // <type>
        SYMBOL_WHILE_STMT = 59  // <while_stmt>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END = 0, // <program> ::= Start <stmt_list> End
        RULE_STMT_LIST = 1, // <stmt_list> ::= <concept>
        RULE_STMT_LIST2 = 2, // <stmt_list> ::= <concept> <stmt_list>
        RULE_CONCEPT = 3, // <concept> ::= <assign>
        RULE_CONCEPT2 = 4, // <concept> ::= <for_stmt>
        RULE_CONCEPT3 = 5, // <concept> ::= <while_stmt>
        RULE_CONCEPT4 = 6, // <concept> ::= <print_stmt>
        RULE_CONCEPT5 = 7, // <concept> ::= <if_stmt>
        RULE_CONCEPT6 = 8, // <concept> ::= <switch_stmt>
        RULE_ASSIGN_EQ_SEMI = 9, // <assign> ::= <Id> '=' <expr> ';'
        RULE_ID_ID = 10, // <Id> ::= Id
        RULE_EXPR_PLUS = 11, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS = 12, // <expr> ::= <expr> '-' <term>
        RULE_EXPR = 13, // <expr> ::= <term>
        RULE_TERM_PERCENT = 14, // <term> ::= <term> '%' <factor>
        RULE_TERM_TIMES = 15, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV = 16, // <term> ::= <term> '/' <factor>
        RULE_TERM_TIMESTIMES = 17, // <term> ::= <term> '**' <factor>
        RULE_FACTOR_TIMESTIMES = 18, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR = 19, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN = 20, // <exp> ::= '(' <expr> ')'
        RULE_EXP = 21, // <exp> ::= <Id>
        RULE_EXP2 = 22, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT_DOT = 23, // <digit> ::= Digit '.'
        RULE_FOR_STMT_FOR_LPAREN_VALUE_COMMA_COMMA_RPAREN_START = 24, // <for_stmt> ::= for '(' <type> <Id> <assign> value ',' <cond> ',' <step> ')' Start <stmt_list>
        RULE_FOR_STMT_END = 25, // <for_stmt> ::= <for_stmt> End
        RULE_TYPE_BOOL = 26, // <type> ::= bool
        RULE_TYPE_FLOUT = 27, // <type> ::= flout
        RULE_TYPE_DOUB = 28, // <type> ::= doub
        RULE_TYPE_BYT = 29, // <type> ::= byt
        RULE_TYPE_INT = 30, // <type> ::= int
        RULE_TYPE_STR = 31, // <type> ::= str
        RULE_STEP_MINUSMINUS = 32, // <step> ::= '--' <Id>
        RULE_STEP_MINUSMINUS2 = 33, // <step> ::= <Id> '--'
        RULE_STEP_PLUSPLUS = 34, // <step> ::= '++' <Id>
        RULE_STEP_PLUSPLUS2 = 35, // <step> ::= <Id> '++'
        RULE_STEP = 36, // <step> ::= <assign>
        RULE_WHILE_STMT_WHILE_LPAREN_RPAREN_START_COMMA_END = 37, // <while_stmt> ::= while '(' <cond> ')' Start <stmt_list> ',' <step> End
        RULE_COND = 38, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT = 39, // <op> ::= '<'
        RULE_OP_GT_EQEQ = 40, // <op> ::= '>' '=='
        RULE_OP_EXCLAMEQ = 41, // <op> ::= '!='
        RULE_PRINT_STMT_PRINT_LPAREN_RPAREN = 42, // <print_stmt> ::= print '(' <stmt_list> ')'
        RULE_IF_STMT_IF_LPAREN_RPAREN_START_END = 43, // <if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End
        RULE_IF_STMT_IF_LPAREN_RPAREN_START_END_ELSE = 44, // <if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End else <stmt_list>
        RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN_COLON_CASE_COLON = 45, // <switch_stmt> ::= switch '(' <digit> ')' ':' case <digit> ':' <print_stmt>
        RULE_SWITCH_STMT_BREAK = 46  // <switch_stmt> ::= <stmt_list> break
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        public MyParser(string filename, ListBox lst)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            this.lst = lst;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF:
                    //(EOF)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ERROR:
                    //(Error)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE:
                    //Whitespace
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MINUS:
                    //'-'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS:
                    //'--'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ:
                    //'!='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PERCENT:
                    //'%'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LPAREN:
                    //'('
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_RPAREN:
                    //')'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TIMES:
                    //'*'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES:
                    //'**'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COMMA:
                    //','
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DOT:
                    //'.'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DIV:
                    //'/'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COLON:
                    //':'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SEMI:
                    //';'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PLUS:
                    //'+'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS:
                    //'++'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LT:
                    //'<'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EQ:
                    //'='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EQEQ:
                    //'=='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_GT:
                    //'>'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_BOOL:
                    //bool
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_BREAK:
                    //break
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_BYT:
                    //byt
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_CASE:
                    //case
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DIGIT:
                    //Digit
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DOUB:
                    //doub
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ELSE:
                    //else
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_END:
                    //End
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FLOUT:
                    //flout
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR:
                    //for
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ID:
                    //Id
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IF:
                    //if
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_INT:
                    //int
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PRINT:
                    //print
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_START:
                    //Start
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STR:
                    //str
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SWITCH:
                    //switch
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_VALUE:
                    //value
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILE:
                    //while
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN:
                    //<assign>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT:
                    //<concept>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COND:
                    //<cond>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2:
                    //<digit>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXP:
                    //<exp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXPR:
                    //<expr>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FACTOR:
                    //<factor>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT:
                    //<for_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ID2:
                    //<Id>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT:
                    //<if_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_OP:
                    //<op>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STMT:
                    //<print_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM:
                    //<program>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STEP:
                    //<step>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST:
                    //<stmt_list>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STMT:
                    //<switch_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TERM:
                    //<term>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TYPE:
                    //<type>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STMT:
                    //<while_stmt>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END:
                    //<program> ::= Start <stmt_list> End
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT_LIST:
                    //<stmt_list> ::= <concept>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STMT_LIST2:
                    //<stmt_list> ::= <concept> <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_CONCEPT:
                    //<concept> ::= <assign>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_CONCEPT2:
                    //<concept> ::= <for_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_CONCEPT3:
                    //<concept> ::= <while_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_CONCEPT4:
                    //<concept> ::= <print_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_CONCEPT5:
                    //<concept> ::= <if_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_CONCEPT6:
                    //<concept> ::= <switch_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_SEMI:
                    //<assign> ::= <Id> '=' <expr> ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ID_ID:
                    //<Id> ::= Id
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPR_PLUS:
                    //<expr> ::= <expr> '+' <term>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPR_MINUS:
                    //<expr> ::= <expr> '-' <term>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPR:
                    //<expr> ::= <term>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TERM_PERCENT:
                    //<term> ::= <term> '%' <factor>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TERM_TIMES:
                    //<term> ::= <term> '*' <factor>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TERM_DIV:
                    //<term> ::= <term> '/' <factor>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TERM_TIMESTIMES:
                    //<term> ::= <term> '**' <factor>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES:
                    //<factor> ::= <factor> '**' <exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FACTOR:
                    //<factor> ::= <exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN:
                    //<exp> ::= '(' <expr> ')'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP:
                    //<exp> ::= <Id>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP2:
                    //<exp> ::= <digit>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT_DOT:
                    //<digit> ::= Digit '.'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_LPAREN_VALUE_COMMA_COMMA_RPAREN_START:
                    //<for_stmt> ::= for '(' <type> <Id> <assign> value ',' <cond> ',' <step> ')' Start <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FOR_STMT_END:
                    //<for_stmt> ::= <for_stmt> End
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TYPE_BOOL:
                    //<type> ::= bool
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TYPE_FLOUT:
                    //<type> ::= flout
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TYPE_DOUB:
                    //<type> ::= doub
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TYPE_BYT:
                    //<type> ::= byt
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TYPE_INT:
                    //<type> ::= int
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_TYPE_STR:
                    //<type> ::= str
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS:
                    //<step> ::= '--' <Id>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2:
                    //<step> ::= <Id> '--'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS:
                    //<step> ::= '++' <Id>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2:
                    //<step> ::= <Id> '++'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STEP:
                    //<step> ::= <assign>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_WHILE_STMT_WHILE_LPAREN_RPAREN_START_COMMA_END:
                    //<while_stmt> ::= while '(' <cond> ')' Start <stmt_list> ',' <step> End
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_COND:
                    //<cond> ::= <expr> <op> <expr>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OP_LT:
                    //<op> ::= '<'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OP_GT_EQEQ:
                    //<op> ::= '>' '=='
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ:
                    //<op> ::= '!='
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PRINT_STMT_PRINT_LPAREN_RPAREN:
                    //<print_stmt> ::= print '(' <stmt_list> ')'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_START_END:
                    //<if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_START_END_ELSE:
                    //<if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End else <stmt_list>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SWITCH_STMT_SWITCH_LPAREN_RPAREN_COLON_CASE_COLON:
                    //<switch_stmt> ::= switch '(' <digit> ')' ':' case <digit> ':' <print_stmt>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SWITCH_STMT_BREAK:
                    //<switch_stmt> ::= <stmt_list> break
                    //todo: Create a new object using the stored tokens.
                    return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "'" + "In line: " + args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = "Expected token:" + args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
            //todo: Report message to UI?
        }

    }
}