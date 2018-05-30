using PatientManager.WebAPI.Models;
using PatientManager.Data.Model;
using PatientManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientManager.WebAPI.Controllers
{
    public class ComtabController : ApiController
    {
        private readonly IComtabService comtabService;

        public ComtabController(IComtabService comtabService)
        {
            this.comtabService = comtabService;
        }

        [HttpGet]
        [Route("api/comtab/count")]
        public long Count()
        {
            return comtabService.GetCount();
        }

        [HttpGet]
        [Route("api/comtab")]
        public IEnumerable<ComtabModel> Get()
        {
            return comtabService.GetComtab().Select(p => new ComtabModel
            {
                Id = p.Id,
                Code = p.Code,
                Date = p.Date,
                Mode = p.Mode,
                Montant = p.Montant,
                Type = p.Type,
                Patient_Id = p.Patient_Id,
                Patient = p.Patient
            });
        }

        [HttpGet]
        [Route("api/comtab/{id}")]
        public ComtabModel Get(int id)
        {
            Comtab p = comtabService.GetComtab(id);
            ComtabModel pm = new ComtabModel();
            pm.Id = p.Id;
            pm.Code = p.Code;
            pm.Date = p.Date;
            pm.Mode = p.Mode;
            pm.Montant = p.Montant;
            pm.Type = p.Type;
            pm.Patient_Id = p.Patient_Id;
            pm.Patient = p.Patient;
            return pm;
        }

        [Route("api/comtab/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            comtabService.DeleteComtab(id);
        }

        [Route("api/comtab/update")]
        [HttpPost]
        public void Update(ComtabModel p)
        {
            Comtab pm = new Comtab();
            pm.Id = p.Id;
            pm.Code = p.Code;
            pm.Date = p.Date;
            pm.Mode = p.Mode;
            pm.Montant = p.Montant;
            pm.Type = p.Type;
            pm.Patient_Id = p.Patient_Id;
            pm.Patient = p.Patient;
            comtabService.UpdateComtab(pm);
        }

        [Route("api/comtab/create")]
        [HttpPost]
        public void Create(ComtabModel p)
        {
            Comtab pm = new Comtab();
            pm.Id = p.Id;
            pm.Code = p.Code;
            pm.Date = p.Date;
            pm.Mode = p.Mode;
            pm.Montant = p.Montant;
            pm.Type = p.Type;
            pm.Patient_Id = p.Patient_Id;
            pm.Patient = p.Patient;
            comtabService.AddComtab(pm);
        }
    }
}

   
