using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repaso_pais_api.Models;
using repaso_pais_api.Utils;

namespace repaso_pais_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : Controller
    {
        private ITablapaiService _tablapais;
        public PaisController(ITablapaiService tablapais)
        {
            _tablapais = tablapais;
        }

        [HttpGet]
        // GET: PaisController
        public async Task<IActionResult> Index()
        {
            var paises = await _tablapais.GetTabs();
            return Ok(paises);
        }

        // GET: PaisController/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var pais = await _tablapais.Tablapais(id);
            return Ok(pais);
        }

        // GET: PaisController/Create
        //public ActionResult Create()
        //{

        //    return View();
        //}

        // POST: PaisController/Create
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tablapai model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(ModelState);
                }
                var pais = await _tablapais.PostTablaPais(model);
                return Ok(pais); ;
            }
            catch
            {
                return View();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tablapai model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }
            var pais = await _tablapais.PutTablaPais(id, model);
            return Ok(pais);
        }

        // POST: PaisController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: PaisController/Delete/5

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _tablapais.DeleteTablaPais(id);
            return Ok();
        }

        //// POST: PaisController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
