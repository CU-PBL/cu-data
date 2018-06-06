class Cson<T>
{
    public static string Parse(T t)
    {
        var stream1 = new MemoryStream();
        var ser = new DataContractJsonSerializer(typeof(T));
        ser.WriteObject(stream1, t);

        stream1.Position = 0;
        StreamReader sr = new StreamReader(stream1);

        var strJson = sr.ReadToEnd();
        return strJson;
    }

    public static T DeParse(string strData)
    {
        var ser = new DataContractJsonSerializer(typeof(T));
        var stream1 = new MemoryStream(Encoding.Unicode.GetBytes(strData)) { Position = 0 };
        var p2 = (T)ser.ReadObject(stream1);

        return p2;
    }

    public static List<T> ArrParse(string mainData)
    {
        var resultArr = new List<T>();
        var jarr = JArray.Parse(mainData);
        foreach (var jstr in jarr)
        {
            resultArr.Add(DeParse(jstr.ToString()));
        }

        return resultArr;
    }
}
