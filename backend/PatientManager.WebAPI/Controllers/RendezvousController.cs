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
    public class RendezvousController : ApiController
    {
        private readonly IRendezvousService rendezvousService;

        public RendezvousController(IRendezvousService rendezvousService)
        {
            this.rendezvousService = rendezvousService;
        }

        [HttpGet]
        [Route("api/rendezvous/count")]
        public long Count()
        {
            return rendezvousService.GetCount();
        }

        [HttpGet]
        [Route("api/rendezvous")]
        public IEnumerable<RendezModel> Get()
        {
            return rendezvousService.GetRendezvous().Select(p => new RendezModel
            {
                Id = p.Id,
                Date = p.Date,
                Comment = p.Comment,
                Patient_Id = p.Patient_Id,
                Patient = p.Patient
            });
        }

        [HttpGet]
        [Route("api/rendezvous/{id}")]
        public RendezModel Get(int id)
        {
            Rendez p = rendezvousService.GetRendezvous(id);
            RendezModel pm = new RendezModel();
            pm.Id = p.Id;
            pm.Date = p.Date;
            pm.Comment = p.Comment;
            pm.Patient_Id = p.Patient_Id;
            pm.Patient = p.Patient;
            return pm;
        }

        [Route("api/rendezvous/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            rendezvousService.DeleteRendezvous(id);
        }

        [Route("api/rendezvous/update")]
        [HttpPost]
        public void Update(RendezModel p)
        {
            Rendez pm = new Rendez();
            pm.Id = p.Id;
            pm.Date = p.Date;
            pm.Comment = p.Comment;
            pm.Patient_Id = p.Patient_Id;
            pm.Patient = p.Patient;
            rendezvousService.UpdateRendezvous(pm);
        }

        [Route("api/rendezvous/create")]
        [HttpPost]
        public void Create(RendezModel p)
        {
            Rendez pm = new Rendez();
            pm.Id = p.Id;
            pm.Date = p.Date;
            pm.Comment = p.Comment;
            pm.Patient_Id = p.Patient_Id;
            pm.Patient = p.Patient;
            rendezvousService.AddRendezvous(pm);
        }
    }
}

   
