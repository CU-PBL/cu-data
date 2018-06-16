static void CallRefund()
{
    var refundData = new RefundData {hash = "해시값"}; // SaleDetailData class의 hash 변수를 넣는다.

    var result = Cson<RefundData>.Parse(refundData);
    var client = new RestClient("http://localhost:8000/refund");
    var request = new RestRequest(Method.POST);
    request.AddHeader("content-type", "application/json");
    request.AddParameter("application/json", result, ParameterType.RequestBody);
    var response = client.Execute(request);

    Console.WriteLine(response.Content);
}
