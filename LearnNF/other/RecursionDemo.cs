using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNF.other
{
    class RecursionDemo
    {
       public static void demo() {

           T1(); // 输出 A0 -> A1 -> A2 -> A3 -> B3 -> B2 -> B1 -> B0 ->
            Console.WriteLine(" ----T1 end---- ");

           T2(0); //输出顺序: A0 -> A1 -> A2 ->  B3 ->  B2 ->  B1 ->
            Console.WriteLine(" ----T2 end---- ");
        }

         static int index = 0;
        //输出 A0 -> A1 -> A2 -> A3 -> B3 -> B2 -> B1 -> B0 ->
        public static void T1() {
            Console.Write("A" + index + " -> ");
            if (index<3)
            {
                index++;
                T1();
            }
            Console.Write("B"+ index-- +" -> ");
        }
        // A0 -> A1 -> A2 ->  B3 ->  B2 ->  B1 ->
        static void T2(int i) {
            Console.Write("A"+i +" -> ");
            i++;
            if (i < 3) {
                T2(i);
            }
            Console.Write(" B"+ i + " -> ");
        }
    }
}
