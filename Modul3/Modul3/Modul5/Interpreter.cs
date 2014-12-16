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
            LOAD = 1 << 0, //1
            ADD = 1 << 1, //2
            SUB = 1 << 2, //3
            MUL = 1 << 3, //4
            DIV = 1 << 4, //5
            JUMP = 1 << 5, //6
            JMPZ = 1 << 6, //7
            JPNZ = 1 << 7, //8
            //IN1 = '9',
            //IN2 = '0',
            //OUT1 = 'a',
            BYE = 1 << 8, //256 ?
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
