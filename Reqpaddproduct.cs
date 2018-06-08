// product 추가하는 기능 
static void CallAddProduct()
{
    var product = new Product
    {
        id = 102,
        category = "간편식사",
        name = "콩나물초콜렛",
        price = 3000,
        sub_category = "아이스크림"
    };

    var result = Cson<Product>.Parse(product);
    var client = new RestClient("http://localhost:8000/product");
    var request = new RestRequest(Method.POST);
    request.AddHeader("content-type", "application/json");
    request.AddParameter("application/json", result, ParameterType.RequestBody);
    var response = client.Execute(request);

    Console.WriteLine(response.Content);
}