// 물품 상세보기 
static void CallProductDetail()
{
    var client = new RestClient("http://localhost:8000/product/3"); // product/ 뒤에 숫자 입력(상품 코드)
    var request = new RestRequest(Method.GET);
    var response = client.Execute(request);

    var result = Cson<Product>.DeParse(response.Content);
    Console.WriteLine($"{result.id}, {result.price}, {result.name}");
}
