using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoFinal.Uploadedfile
{
    public class UploadController : Controller
    {
        // GET: Uplaod
        public ActionResult Index()
        {
            return View();
        }
 
         [HttpPost]
         public ActionResult UploadFile(HttpPostedFileBase file)
         {
             try
             {
                 if (file.ContentLength > 0)
                 {
                     string _NomeArquivo = Path.GetFileName(file.FileName);
                     string _caminho = Path.Combine(Server.MapPath("~/UploadedFiles"), _NomeArquivo);
                     file.SaveAs(_caminho);
                 }
                 ViewBag.Message = "Salvo com suceso";
                 return RedirectToAction("Index");
             }
             catch(Exception e1)
             {
                 ViewBag.Message = "Envio de arquivo falhou !!";
                 return View();

             }
         }
    }
}