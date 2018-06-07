class Program
{
    // Cson 클래스 추가 
    static void Main(string[] args)
    {
        CallPuductList();
    }

    // 물품 리스트 보기
    static void CallPuductList()
    {
        var client = new RestClient($"http://localhost:8000/product/list");
        var request = new RestRequest(Method.GET);
        var response = client.Execute(request);

        var productList = Cson<ProductData>.ArrParse(response.Content);
    }

    class ProductData
    {
        public string name, category, sub_category;
        public int id, price;

   
    }
}
