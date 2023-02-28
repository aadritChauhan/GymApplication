using GymApplication_new.Migrations;
using GymApplication_new.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GymApplication_new.Controllers
{
    public class MuscleGroupController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static MuscleGroupController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44352/api/");
        }

        // GET: MuscleGroup
        public ActionResult List()
        {
            //objective: communicate with our muscleGroup data api to retrieve a list of musclegroups
            // GET: https://localhost:44352/api/musclegroupdata/listmusclegroups

            
            string url = "musclegroupdata/listmusclegroups";
            HttpResponseMessage response= client.GetAsync(url).Result;
            IEnumerable<MuscleGroupDto> muscleGroups = response.Content.ReadAsAsync<IEnumerable<MuscleGroupDto>>().Result;

            return View(muscleGroups);

        }

        // GET: MuscleGroup/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient() { };
            string url = "musclegroupdata/findmusclegroup/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            MuscleGroupDto selectedmusclegroup= response.Content.ReadAsAsync<MuscleGroupDto>().Result;
            return View(selectedmusclegroup);
        }

        public ActionResult Error()
        {
            return View();
        }


        // GET: MuscleGroup/New
        public ActionResult New()
        {

            return View();
        }

        // POST: MuscleGroup/Create
        [HttpPost]
        public ActionResult Create(MuscleGroup muscleGroup)
        {
            // objective: add a new muscle group/exercises into our system using the api
            // curl -H "Content-Type:application/json" -d @muscleGroup.json  https://localhost:44352/api/musclegroupdata/addmusclegroups
            string url = "musclegroupdata/addmuscleGroup";

            string jsonpayload = jss.Serialize(muscleGroup);

            HttpContent content= new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response= client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
            
        } 

        // GET: MuscleGroup/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "muclegroupdata/findmuscleGroup/" + id;
            HttpResponseMessage response= client.GetAsync(url).Result;
            MuscleGroupDto selectedmuscleGroup = response.Content.ReadAsAsync<MuscleGroupDto>().Result;
            return View(selectedmuscleGroup);
        }

        // POST: MuscleGroup/Update/5
        [HttpPost]
        public ActionResult Update(int id, MuscleGroup muscleGroup)
        {
            string url = "musclegroupdata/updatemusclegroup/" + id;
            string jsonpayload = jss.Serialize(muscleGroup);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType= "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: MuscleGroup/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "musclegroupdata/findmuscleGroup/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            MuscleGroupDto selectedmuscleGroup = response.Content.ReadAsAsync<MuscleGroupDto>().Result;
            return View(selectedmuscleGroup);
        }

        // POST: MuscleGroup/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "deletemusclegroup/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
