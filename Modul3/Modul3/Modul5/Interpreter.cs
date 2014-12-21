using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3.Modul5
{
    class Interpreter
    {
        public enum Orders : short
        {
            LOAD = 1, //1
            ADD = 2, //2
            SUB = 3, //3
            MUL = 4, //4
            DIV = 5, //5
            JUMP = 6, //6
            JMPZ = 7, //7
            JPNZ = 8, //8
            OUT = 9, //9
            BYE = 255, //255
        };

        public string translateOrder(string[] order)
        {
            string output = "";

            switch (order[0])
            {
                case "LOAD":
                    {
                        output += (short)Orders.LOAD;
                        output += order[2];
                        break;
                    }
                case "ADD":
                    {
                        output += (short)Orders.ADD;
                        output += order[1]+order[2];
                        break;
                    }
                case "SUB":
                    {
                        output += (short)Orders.SUB;
                        output += order[1] + order[2];
                        break;
                    }
                case "MUL":
                    {
                        output += (short)Orders.MUL;
                        output += order[1] + order[2];
                        break;
                    }
                case "DIV":
                    {
                        output += (short)Orders.DIV;
                        output += order[1] + order[2];
                        break;
                    }
                case "JUMP":
                    {
                        output += (short)Orders.JUMP;
                        output += order[1];
                        break;
                    }
                case "JMPZ":
                    {
                        output += (short)Orders.JMPZ;
                        output += order[1];
                        break;
                    }
                case "JPNZ":
                    {
                        output += (short)Orders.JPNZ;
                        output += order[1];
                        break;
                    }
                case "BYE":
                    {
                        output += (short)Orders.BYE;
                        break;
                    }
                case "OUT":
                    {
                        output += (short)Orders.OUT;
                        output += order[1];
                        break;
                    }
                default:
                    {
                        output = "ERROR";
                        break;
                    }
            }

            return output;
        }


    }
}
