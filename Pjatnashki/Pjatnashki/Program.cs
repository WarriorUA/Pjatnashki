using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pjatnashki
{
    class Program
    {

       static bool Isnuv(int[,] first, int[,] second)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (first[i, j] != second[i, j]) return true;
                }
            }
            return false;
        }       
        static void Main(string[] args)
        {
            List<Pjatnash> dinam = new List<Pjatnash>();
            int[,] bestStatus = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
            bool flag = false;
            int[,] currentNArr = new int[4,4];
            for(int i=0;i<4;++i)
            {
                for(int j=0;j<4;++j)
                {
                    currentNArr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            int n = 0;
            dinam.Add(new Pjatnash(0,currentNArr));
            while (!flag)
            {
                for(int i=0;i<4;++i)
                {
                    for (int j = 0; j< 4;++j)
                    {

                        currentNArr[i,j] = dinam[n].status[i,j];
                    }
                }
                flag =true;
                for(int i=0;i<4;i++)
                {
                    for(int j=0;j<4;++j)
                    {
                        if(dinam[n].status[i,j]!=bestStatus[i,j])
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if(!flag)
                {
                   for(int i=0;i<4;++i)
                    {
                        for (int j = 0;j < 4;++j)
                        {
                            if(currentNArr[i,j]==0)
                            {
                                if (i < 3)
                                {
                                    int zn = currentNArr[i + 1, j];
                                    currentNArr[i + 1, j] = 0;
                                    currentNArr[i, j] = zn;
                                    bool add = true;
                                    foreach (var t in dinam)
                                    if (Isnuv(t.status, currentNArr)==false) add = false;
                                    if(add)
                                    dinam.Add(new Pjatnash(n, currentNArr));
                                    currentNArr[i + 1, j] = zn;
                                    currentNArr[i, j] = 0;
                                }
                                
                               if(i>1)
                                {
                                    int zn = currentNArr[i - 1, j];
                                    currentNArr[i - 1, j] = 0;
                                    currentNArr[i, j] = zn;
                                    bool add = true;
                                    foreach (var t in dinam)
                                        if (Isnuv(t.status, currentNArr)==false) add = false;
                                    if (add)
                                        dinam.Add(new Pjatnash(n, currentNArr));
                                    currentNArr[i - 1, j] = zn;
                                    currentNArr[i, j] = 0;
                                }
                               if(j<3)
                                {
                                    int zn = currentNArr[i, j+1];
                                    currentNArr[i, j+1] = 0;
                                    currentNArr[i, j] = zn;

                                    bool add = true;
                                    foreach (var t in dinam)
                                        if (Isnuv(t.status, currentNArr)==false) add = false;
                                    if (add)
                                        dinam.Add(new Pjatnash(n, currentNArr));
                                    currentNArr[i , j+1] = zn;
                                    currentNArr[i, j] = 0;
                                }
                               if(j>1)
                                {
                                    int zn = currentNArr[i, j-1];
                                    currentNArr[i, j-1] = 0;
                                    currentNArr[i, j] = zn;
                                    bool add = true;
                                    foreach (var t in dinam)
                                        if (Isnuv(t.status, currentNArr)==false) add = false;
                                    if (add)
                                        dinam.Add(new Pjatnash(n, currentNArr));
                                    currentNArr[i , j-1] = zn;
                                    currentNArr[i, j] = 0;
                                }
                                break;
                            }
                        }
                    }
                }
                ++n;
            }
            --n;
            List<Pjatnash> finish = new List<Pjatnash>();
            while(n!=0)
            {
                finish.Add(dinam[n]);
                n = dinam[n].previous;
            }
            finish.Reverse();
           foreach(var t in finish)
            {
                for(int i=0;i<4;++i)
                {
                    for(int j=0;j<4;++j)
                    {
                        Console.Write(t.status[i,j]+" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
    public class Pjatnash
    {
       public int previous;
       public int[,] status = new int[4, 4];
        public Pjatnash()
        {

        }
        public Pjatnash(int _previous, int[,] _status)
        {
            for(int i=0;i<4;++i)
            {
                for(int j=0;j<4;++j)
                {
                    status[i, j] = _status[i, j];
                }
            }
            previous = _previous;
        }
    }
}
