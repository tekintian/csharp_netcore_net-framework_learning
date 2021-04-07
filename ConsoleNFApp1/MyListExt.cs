using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNFApp1
{
   public static class MyListExt
    {
        //自定义扩展,实现where功能
        public static List<string> MyWhere(this List<string> list, Func<string,bool> funcWhere)
        {
            List<string>  retlist = new List<string>();
            foreach (var item in list)
            {
                //调用委托方法, 如果条件满足则将这个项目加到list中
                if (funcWhere(item))
                {
                    retlist.Add(item);
                }
            }
            return retlist;
        }

        public static void MyExt(this List<string> list) { }
    }
}
