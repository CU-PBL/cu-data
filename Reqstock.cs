// 재고 관리 
static void CallStock()
{
    var stockes = new List<StockData>();
    stockes.Add(new StockData() {id = 3, stock = 1});
    stockes.Add(new StockData() {id = 5, stock = 1});

    var result = Cson<List<StockData>>.Parse(stockes);
    var client = new RestClient("http://localhost:8000/stock?flag" + "add"/* sell */);
    var request = new RestRequest(Method.POST);
    request.AddHeader("content-type", "application/json");
    request.AddParameter("application/json", result, ParameterType.RequestBody);
    var response = client.Execute(request);

    Console.WriteLine(response.Content);
}
