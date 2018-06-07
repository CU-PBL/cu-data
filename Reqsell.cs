// 판매 기능
static void CallAddSell()
{
    var data = new SellData
    {
        paymentOption = "bill",
        cardNumber = 1635,
        cashRecipt = "010-1234-5678",
        sum = 19000
    };

    var sellData = Cson<SellData>.Parse(data);

    var client = new RestClient("http://localhost:8000/sell");
    var request = new RestRequest(Method.POST);
    request.AddHeader("content-type", "application/json");
    request.AddParameter("application/json", sellData, ParameterType.RequestBody);
    var response = client.Execute(request);

    Console.WriteLine(response.Content);
}
