using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TakeREST.Models;

namespace TakeREST.Controllers
{
    public class PhotosController : Controller
    {
        public static string BaseUrl = "https://jsonplaceholder.typicode.com";
        // GET: Photos
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(BaseUrl + "/photos");
            if (response.IsSuccessStatusCode)
            {
                var photos = await response.Content.ReadAsAsync<IEnumerable<Photo>>();
                return View(photos);
            }
            return new HttpStatusCodeResult(response.StatusCode);
        }

        // GET: Photos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(BaseUrl + "/photos/" + id);
            if (response.IsSuccessStatusCode)
            {
                var photo = await response.Content.ReadAsAsync<Photo>();
                return View(photo);
            }
            return new HttpStatusCodeResult(response.StatusCode);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        [HttpPost]
        public async Task<ActionResult> Create(Photo photo)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(BaseUrl + "/photos", photo);
            if (response.IsSuccessStatusCode)
            {
                var photoResult = response.Content.ReadAsAsync<Photo>();
                return RedirectToAction("Details", new { id = photoResult.Id });
            }
            return new HttpStatusCodeResult(response.StatusCode);
        }

        // GET: Photos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await Details(id);
            var viewResult = result as ViewResult;
            if (viewResult != null)
            {
                var photo = viewResult.Model as Photo;
                return View();
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
        }

        // POST: Photos/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Photo photo)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(BaseUrl + "/photos/" + photo.Id, photo);
            if (response.IsSuccessStatusCode)
            {
                var photoResult = response.Content.ReadAsAsync<Photo>();
                return RedirectToAction("Details", new { id = photoResult.Id });
            }
            return new HttpStatusCodeResult(response.StatusCode);

        }

        // GET: Photos/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await Details(id);
            var viewResult = result as ViewResult;
            if (viewResult != null)
            {
                var photo = viewResult.Model as Photo;
                return View(photo);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
        }

        // POST: Photos/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Photo photo)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync(BaseUrl + "/photos/" + photo.Id);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
