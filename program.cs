using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    
    class Program
    {
        static void sell()
        {
            int code;
            int set;
            int[] data = new int[100];


            do
            {

                Console.Write("코드(결제는 0 입력) : ");
                code = int.Parse(Console.ReadLine());
                if(code != 0)
                    data[code-1] += 1;

                int sum=0;
                Console.WriteLine("상품 번호   상품 이름          수량    단가    합계 ");
                for (int i = 0; i < 100; i++)
                {
                    if (data[i] != 0)
                    {
                        var cliName = new RestClient($"http://106.10.42.112:3000/product/{i+1}?para=name");
                        var reqName = new RestRequest(Method.GET);
                        IRestResponse resName = cliName.Execute(reqName);

                        
                        var cliPrice = new RestClient($"http://106.10.42.112:3000/product/{i+1}?para=price");
                        var reqPrice = new RestRequest(Method.GET);
                        IRestResponse resPrice = cliPrice.Execute(reqPrice);

                        Console.WriteLine((i+1) +"           "+ resName.Content + "  " + data[i] + "      " + resPrice.Content + "      "+int.Parse(resPrice.Content)*data[i] );
                        sum += int.Parse(resPrice.Content) * data[i];
                    }

                }
                Console.WriteLine("");
                Console.WriteLine("총 합계 : " + sum);


            } while (code != 0);

            Console.WriteLine("1.카드 2.현금");
            set = int.Parse(Console.ReadLine());
            if (set == 1)
                card(data);
    
            if (set == 2)
                cash(data);
        }

        static void cash(int[] data)
        {
            Console.WriteLine("현금영수증 발급 여부");
            Console.WriteLine("1. 발급  2. 안함");
            int set = int.Parse(Console.ReadLine());
            if(set == 1)
            {
                Console.Write("번호 : ");
                string number = Console.ReadLine();
                //판매 내역 db 넘기기
            }
            if(set == 2)
            {
                string number = "없음";
                //판매 내역 db 넘기기
            }

            //재고 db에 data[]넘겨서 재고 관리
        }

        static void card(int[] data)
        {
            Console.WriteLine("카드번호를 입력하세요");
            Console.Write("번호 : ");
            string number = Console.ReadLine();

            //재고 db에 data[]넘겨서 재고 관리
        }


        static void stock()
        {

        }


        static void Main(string[] args)
        {
            int set;
            Console.WriteLine("편의점 관리 프로그램");
            Console.WriteLine("");
            Console.WriteLine("1. 판매");
            Console.WriteLine("2. 재고");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("입력 : ");
            set = int.Parse(Console.ReadLine());
            if (set == 1)
                sell();
            if (set == 2)
                stock();
        }
    }
}
