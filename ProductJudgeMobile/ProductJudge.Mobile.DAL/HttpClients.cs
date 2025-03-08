namespace ProductJudge.Mobile.DAL;

public static class HttpClients
{
    public static readonly string FAKE_API = "fake_api";

    public static class URLS
    {
        public static string URL_LOCAL_FAKE_API_BASE =
        //"http://localhost:5186"; 
        "https://productjudgetest2-c8dxgabzaxgvh6ab.francecentral-01.azurewebsites.net";
    }

    public static class Endpoints
    {
        public static readonly string GET_PRODUCTS = "products";
    }
}
