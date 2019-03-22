namespace SimpleHttpServer.Models
{
    using Enums;

    public static class ResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            string content =
                "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>Internal Server Error</title>\r\n</head>\r\n<body>\r\n    <h1 style=\"text-align: center\">Hey look, it\'s me. Good ol\' error 500, back from the ol\' CGI Days</h1>\r\n    <div style=\"width: 30%; margin: 10px auto\">\r\n        <img src=\"http://s2.quickmeme.com/img/3a/3ad780387147f7cad1513fc6a83b734ca2d467bd5a16f5ca2cfc640d7cf5e1ec.jpg\" width=\"500px\">\r\n    </div>\r\n</body>\r\n</html>";
            var response = new HttpResponse(ResponseStatusCode.Internal_Server_Error);
            response.ContentAsUTF8 = content;
            return response;
        }

        public static HttpResponse NotFound()
        {
            string content =
                "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>Page Not Found</title>\r\n</head>\r\n<body>\r\n    <h1 style=\"text-align: center\">Move along, nothing to see here!</h1>\r\n</body>\r\n</html>";
            var response = new HttpResponse(ResponseStatusCode.Page_Not_Found);
            response.ContentAsUTF8 = content;
            return response;
        }
    }
}