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
