using Mod02_01.DAL;
using Mod02_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using System.Diagnostics;

namespace Mod02_01.Controllers
{
    //[LogActionFilter]
    public class OperaController : Controller
    {
        // GET: Opera
        //public ActionResult Index(Opera opera)
        //{
        //    //var test = ModelState.IsValid;
        //    //Opera o = new Opera()
        //    //{
        //    //    OperaID = opera.OperaID,
        //    //    Title = opera.Title,
        //    //    Year = opera.Year,
        //    //    Composer = opera.Composer
        //    //};

        //    return View(opera);
        //} Lab2_4
        // GET:Opera/Index
        //Lab3_9 增加LogActionFilter。在實作的LogActionFilter class中寫好override，然後在這裡用attribute套用
        
        public ActionResult Index()
        {
            //輸出在output window
            //'iisexpress.exe' (CLR v4.0.30319: /LM/W3SVC/2/ROOT-1-131394069974227962): Loaded 'Anonymously Hosted DynamicMethods Assembly'. 
            //Opera.Index
            Debug.WriteLine("Opera.Index");
            OperaContext context = new OperaContext();
            return View(context.Operas.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperaContext context = new OperaContext();
            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();
            return View(o);
        }
        //Get:Opera/Create
        //預設是Http get，這裡是get表單
        //這裡的做法是get取下面這個Create
        //post取[HttpPost]後面的Create
        public ActionResult Create() {
            return View();
        }
        //post送出form的資料
        //opera是Data自動bind
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                OperaContext context = new OperaContext();
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }
        //LAB 3-6 修改時先顯示要修改那一筆
        //GET: Opera/Edit/1
        //GET: Opera/Edit?id=1
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperaContext context = new OperaContext();
            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();
            return View(o);
        }
        [HttpPost]
        public ActionResult Edit(Opera opera)
        {
            if (ModelState.IsValid)
            {
                OperaContext context = new OperaContext();
                //context.Entry(opera).State = EntityState.Modified;
                //上面這一行等於下面這一串，但是欄位太多不好用
                Opera o = context.Operas.Find(opera.OperaID);
                o.Title = opera.Title;
                o.Year = opera.Year;
                o.Composer = opera.Composer;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }

        //LAB3_8
        //GET: Opera/Delete/1
        //GET: Opera/Delete?id=1
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OperaContext context = new OperaContext();
        //    Opera o = context.Operas.Find(id);
        //    if (o == null)
        //        return HttpNotFound();
        //    return View(o);
        //}

        //POST: Opera/Delete/1
        //POST: Opera/Delete?id=1
        //[HttpPost, ActionName("Delete")] //POST時的Delete函式，可用以替代DeleteConfirmed
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    OperaContext context = new OperaContext();
        //    Opera o = context.Operas.Find(id);
        //    context.Operas.Remove(o);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //GET: Opera/Delete/1
        //GET: Opera/Delete?id=1
        //如果不要做確認直接刪除的話
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperaContext context = new OperaContext();
            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();
            context.Operas.Remove(o);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Lab4_6
        //GET: Opera/FilterData?number=2
        //同樣的回傳結構可以return 到同一個view，也就是共用view
        public ActionResult FilterData(int number)
        {
            OperaContext context = new OperaContext();
            var query = (from o in context.Operas
                         orderby o.Year descending
                         select o).Take(number).ToList();
            return View("Index", query);
        }

        [Route("Opera/Title/{title=Wozzeck}")]
        public ActionResult DetailsByTitle(string title)
        {
            //Lab06_03
            ViewBag.mycontroller = RouteData.Values["controller"];
            ViewBag.myaction = RouteData.Values["action"];
            ViewBag.mytitle = RouteData.Values["title"];

            OperaContext context = new OperaContext();
            Opera opera = context.Operas.FirstOrDefault<Opera>(o => o.Title == title);
            if (opera == null)
            {
                return HttpNotFound();
            }

            return View("Details", opera);
        }
    }
}