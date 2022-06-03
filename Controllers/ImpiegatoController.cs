using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ImpiegatoController : Controller
    {
        public IActionResult CreaForm()
        {
            Impiegato TempImpiegato = new Impiegato()
            {
                Id = 1,
                FullName = "",
                Gender = "",
                City = "",
                EmailAddress = "",
                PersonalWebSite = "",
                Photo = "",
                AlternateText = "",
            };
            return View(TempImpiegato);
        }

        public IActionResult CreaScheda(Impiegato DatiImpiegato)
        {
            string sNomeImpiegato = DatiImpiegato.FullName.Split(' ')[0];
            string sCognomeImpiegato = DatiImpiegato.FullName.Split(' ')[1];
            Impiegato mioImpiegato = new Impiegato()
            {
                Id = DatiImpiegato.Id,
                FullName = DatiImpiegato.FullName,
                Gender = DatiImpiegato.Gender,
                City = DatiImpiegato.City,
                EmailAddress = DatiImpiegato.EmailAddress,
                PersonalWebSite = "www." + sNomeImpiegato + "_" + sCognomeImpiegato + ".com",
                Photo = DatiImpiegato.Photo,
                AlternateText = "Foto non ancora disponibile",
            };
            return View(mioImpiegato);
        }

        public IActionResult CreaFormConFoto()
        {
            ImpiegatoConFile TempImpiegato = new ImpiegatoConFile()
            {
                Id = 1,
                FullName = "",
                Gender = "",
                City = "",
                EmailAddress = "",
                PersonalWebSite = "",
                Photo = "",
                AlternateText = "",
            };
            return View(TempImpiegato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreaSchedaConFoto(ImpiegatoConFile DatiImpiegato)
        {
            //Qui gestisco il controllo dell'inserimento dei dati...se i dati obligatori non sono inseriti
            //ti riporto nel form di creazione della scheda impiegato
            if (!ModelState.IsValid)
            { 
                return View("CreaFormConFoto", DatiImpiegato);
            }

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");

            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileInfo fileInfo = new FileInfo(DatiImpiegato.File.FileName);
            string fileName = DatiImpiegato.FullName + fileInfo.Extension;

            string fileNameWhitPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWhitPath, FileMode.Create))
            { 
                DatiImpiegato.File.CopyTo(stream);
            }

            string sNomeImpiegato = DatiImpiegato.FullName.Split(' ')[0];
            string sCognomeImpiegato = DatiImpiegato.FullName.Split(' ')[1];
            
            ImpiegatoConFile mioImpiegato = new ImpiegatoConFile()
            {
                Id = DatiImpiegato.Id,
                FullName = DatiImpiegato.FullName,
                Gender = DatiImpiegato.Gender,
                City = DatiImpiegato.City,
                EmailAddress = DatiImpiegato.EmailAddress,
                PersonalWebSite = "www." + sNomeImpiegato + "_" + sCognomeImpiegato + ".com",
                Photo = "/img/" + fileName,
                AlternateText = "Foto non ancora disponibile",
            };
            return View(mioImpiegato);
        }
    }
}
