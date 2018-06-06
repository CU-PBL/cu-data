class Program 
{
    static void Main(string[] args)
    {
        CallAddSell();
    }
        
    // 판매 기능
    static void CallAddSell()
    {
        var data = new SellData
        {
            PaymentOption = "bill",
            CardNumber = 1635,
            CashRecipt = "010-1234-5678",
            Sum = 19000
        };

        var sellData = Cson<SellData>.Parse(data);

        var client = new RestClient("http://localhost:8000/sell");
        var request = new RestRequest(Method.POST);
        request.AddHeader("content-type", "application/json");
        request.AddParameter("application/json", sellData, ParameterType.RequestBody);
        var response = client.Execute(request);

        Console.WriteLine(response.Content);
    }

    [DataContract]
    class SellData
    {
        [DataMember] private string paymentOption;
        [DataMember] private int cardNumber;
        [DataMember] private string cashRecipt;
        [DataMember] private int sum;

        public string PaymentOption
        {
            get => paymentOption;
            set => paymentOption = value;
        }

        public int CardNumber
        {
            get => cardNumber;
            set => cardNumber = value;
        }

        public string CashRecipt
        {
            get => cashRecipt;
            set => cashRecipt = value;
        }

        public int Sum
        {
            get => sum;
            set => sum = value;
        }
    }
}
