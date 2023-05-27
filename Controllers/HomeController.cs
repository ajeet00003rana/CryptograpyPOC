using CryptograpyPOC.Cryptography;
using CryptograpyPOC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptograpyPOC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string plainText = "I am ajeet";
            var decryptText=Encrypt(plainText);
            var reslt= Decrypt(decryptText);
            if(!plainText.Equals(reslt))
            {
                throw new Exception("cryptographic error");
            }

            return View();
        }


        private string Encrypt(string plain)
        {
            return plain.EncryptString();
        }
        private string Decrypt(string plain)
        {
            return plain.DecryptString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}