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

        var productList = Cson<Product>.ArrParse(response.Content);
    }

    [DataContract]
    class Product
    {
        [DataMember] private string name, category, sub_category;
        [DataMember] private int id, price;

        public override string ToString()
        {
            return $"{name} {category} {sub_category}";
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Category
        {
            get => category;
            set => category = value;
        }

        public string Sub_category
        {
            get => sub_category;
            set => sub_category = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }
    }
}
