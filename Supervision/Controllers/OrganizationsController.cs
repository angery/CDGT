using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supervision.Models;
using Ext.Net.MVC;

namespace Supervision.Controllers
{
    public class OrganizationsController : Controller
    {
        private SupervisionEntities db = new SupervisionEntities();

        //
        // GET: /Organizations/

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RestResult Create(Organization org)
        {
            try
            {
                db.ORGANIZATIONS.AddObject(org);

                return new RestResult
                {
                    Success = true,
                    Message = "Сведения об организации успешно занесены в реестр",
                    Data = org
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public RestResult Read()
        {
            try
            {
                return new RestResult
                {
                    Success = true,
                    Data = db.ORGANIZATIONS.ToList()
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Put)]
        public RestResult Update(Organization org)
        {
            try
            {
                db.ORGANIZATIONS.Attach(org);
                db.ObjectStateManager.ChangeObjectState(org, EntityState.Modified);
                db.SaveChanges();

                return new RestResult
                {
                    Success = true,
                    Message = "Сведения об организации успешно обновлены"
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public RestResult Destroy(int id)
        {
            try
            {
                Organization organization = db.ORGANIZATIONS.Single(o => o.ORGANIZATION_ID == id);
                db.ORGANIZATIONS.DeleteObject(organization);

                return new RestResult
                {
                    Success = true,
                    Message = "Сведения об организации успешно удалены"
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

    }
}