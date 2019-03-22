using System;

namespace _03_ByTheCake_AddParagraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>By The Cake : Add Paragraph</title>\r\n</head>\r\n<body>\r\n<h1>By The Cake</h1>\r\n<h2>Enjoy our awesome cakes</h2>\r\n<hr>\r\n<ul>\r\n    <li>Home\r\n        <ol>\r\n            <li>Our Cakes</li>\r\n            <li>Our Stores</li>\r\n        </ol>\r\n    </li>\r\n    <li>Add Cake</li>\r\n    <li>Browse Cakes</li>\r\n    <li>About Us</li>\r\n    <h2>Home</h2>\r\n    <section>\r\n        <h3>Our Cakes</h3>\r\n        <p>Cake is a form of sweet dessert that is typically baked. In its oldest forms, cakes were modifications of breads, but cakes now cover a wide range of preparations that can be simple or elaborate, and that share features with other desserts such as pastries, meringues, custards, and pies.</p>\r\n        <img src=\"https://images-na.ssl-images-amazon.com/images/I/71cd+thoF8L._SL256_.jpg\" alt=\"First Cake\" width=\"20%\" height=\"20%\"></section>\r\n    <section>\r\n        <h3>Our Stores</h3>\r\n        <p>Our stores are located in 21 cities all over the world. Come and see what we have for you</p>\r\n        <img src=\"http://static.wixstatic.com/media/77ad93_fcab44cd8d1b446b88d3335b6ceaad36~mv2_d_2448_2448_s_4_2.jpg_256\" alt=\"Some ugly cakes\" width=\"15%\" height=\"15%\"></section>\r\n</ul>\r\n</body>\r\n</html>");
        }
    }
}
