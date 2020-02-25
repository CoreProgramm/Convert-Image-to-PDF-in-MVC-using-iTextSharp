using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConvertImagetoPDF_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public FileResult Index(HttpPostedFileBase files)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                //This code is responsible for initialize the PDF document object.
                using (Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f))
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    //This code is responsible for to add the Image file to the PDF document object.
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(files.InputStream);
                    pdfDoc.Add(img);
                    pdfDoc.Close();

                    //This code is responsible for download the PDF file.
                    return File(stream.ToArray(), "application/pdf", "CoreProgramm_Image_PDF_Converter.pdf");
                }
            }
        }
         public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}