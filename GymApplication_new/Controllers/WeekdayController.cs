using GymApplication_new.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace GymApplication_new.Controllers
{
    public class WeekdayController : Controller
    {
        private static readonly HttpClient client;

        static WeekdayController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44352/api/weekdaydata/");
        }
        // GET: Weekday/List
        public ActionResult List()
        {
            //communicate with our weekday data api to retrieve a list of weekdays
            // curl https://localhost:44324/api/weekdaydata/listweekdays

            
            string url = "listweekdays";
            HttpResponseMessage response = client.GetAsync(url).Result;
            // Debug.WriteLine("The response is :");
            // Debug.WriteLine(response.StatusCode);
            IEnumerable<WeekdayDto> weekdays = response.Content.ReadAsAsync<IEnumerable<WeekdayDto>>().Result;

            // Debug.WriteLine("number of weekdays:");
            // Debug.WriteLine(weekdays.Count());

            return View(weekdays);
        }

        // GET: Weekday/Details/5
        public ActionResult Details(int id)
        {
            //communicate with our weekday data api to retrieve a single weekday
            // curl https://localhost:44324/api/weekdaydata/findweekday/{id}

           
            string url = "findweekday/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            Debug.WriteLine("The response is :");
            Debug.WriteLine(response.StatusCode);
            WeekdayDto selectedweekday = response.Content.ReadAsAsync<WeekdayDto>().Result;

            Debug.WriteLine("number of weekdays:");
           
            return View(selectedweekday);
        }

        // GET: Weekday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weekday/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Weekday/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Weekday/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Weekday/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Weekday/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
