using System;
namespace ConsoleApp2
{
    internal class Program
    {   static double a = 0.5;
	static double dvea=a*2;
        static double kanon(double co)
        {
            return co > 0.5 ? 1 - co : co;
        }
        static bool plati(double x,double y)
        {
            return x > y * dvea;

        }
        static void Main(string[] args)
        { const int HODNE = 100000000;
            double x1, y1, x2, y2,cx1,cy1,cx2,cy2,pom;
            Random r = new Random();
            int samplu, uspechu,uspechu2;
            for(a=0;a<0.503;a+=0.01)
            {	dvea=a*2;
                samplu = uspechu=uspechu2 = 0;
                while (samplu < HODNE)
                {
                    x1 = r.NextDouble();//generate 4 coordinates
                    y1 = r.NextDouble();
                    x2 = r.NextDouble();
                    y2 = r.NextDouble();
                    cx1 = kanon(x1);//compute their canonic version (smaller than 1/2)
                    cy1 = kanon(y1);
                    cx2 = kanon(x2);
                    cy2 = kanon(y2);
                    if (plati(cx1, cy1) && plati(cx2, cy2))//are both points in the set?
                    {
                        samplu++;//increase the number of successful samples
                        if ((y1 < 0.5 && y2 < 0.5) || (y1 > 0.5 && y2 > 0.5))
                        {//are they in the same vertical half?
                            uspechu++;
                            uspechu2++;//then they see each other in S and S'
                        }
                        else
                        {//find x-coord. of i-section of segment between (x1,y1)--(x2,y2) with line y==1/2
                            pom = x1 + (x2 - x1) * (0.5 - y1) / (y2 - y1);
                            if (pom > a && pom < 1 - a)
                                uspechu++;
                            pom = cx1 + (cx2 - cx1) * (0.5 - y1) / (y2 - y1);
                            if (pom > a)
                                uspechu2++;
                        }

                        
                    }

                }
                Console.WriteLine("{0} {1} {2} {3}", a, uspechu,uspechu2,((double)uspechu2)/uspechu);
            }
            

        }
    }
}
