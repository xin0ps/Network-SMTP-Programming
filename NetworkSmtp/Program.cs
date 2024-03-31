using System.Net;
using System.Web;

using HttpListener listener = new HttpListener();

listener.Prefixes.Add("http://127.0.0.1:27001/");


listener.Start();

while (true)
{

    var context = listener.GetContext();

    _ = Task.Run(() =>
    {
        HttpListenerRequest? request = context.Request;

        HttpListenerResponse? response = context.Response;
        response.ContentType = "text/html";
        response.Headers.Add("Content-Type", "text/html");
        response.Headers.Add("Server", "Rasul");
        response.Headers.Add("Date", DateTime.Now.ToString());
        using var writer = new StreamWriter(response.OutputStream);


        var index = File.ReadAllText("index.html");
        writer.Write(index);




        var queryString = request.QueryString;
        if (queryString.Count != 0)
        {
            string fullname = queryString["fullname"];
            string email = queryString["email"];
            string message = queryString["message"];

            Console.WriteLine($"Name:{fullname}\n Email:{email} \nBody:{message}");
            try
            {
                SendEmail.sendEmail(fullname, email, message);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }







    });

}