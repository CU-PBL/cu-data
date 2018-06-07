static void CallLogin()
{
    var userData = new UserData {id = "admin1", passwd = "1234"};

    var result = Cson<UserData>.Parse(userData);
    var client = new RestClient("http://106.10.42.112:8000/login");
    var request = new RestRequest(Method.POST);
    request.AddHeader("content-type", "application/json");
    request.AddParameter("application/json", result, ParameterType.RequestBody);
    var response = client.Execute(request);

    var loginResult = Cson<LoginData>.DeParse(response.Content);
    Console.WriteLine($"로그인 결과: {loginResult.flag}");
}