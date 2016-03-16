using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tx_loadStream.Models;

namespace tx_loadStream.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Document document = new Models.Document();

            MemoryStream ms = new MemoryStream();
            FileStream fs;

            // load the document into a stream
            using (fs = System.IO.File.OpenRead(Server.MapPath("/App_Data/documents/document.docx")))
            {
                fs.CopyTo(ms);
                document.BinaryDocument = Convert.ToBase64String(ms.ToArray());
            }
            
            // forward the document to the view
            return View(document);
        }
    }
}