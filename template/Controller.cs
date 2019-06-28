using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using <%=Projeto%>.Models.Context;
using <%=Projeto%>.Models.Repository;
using <%=Projeto%>.Models.Repository.Interfaces;
using <%=Projeto%>.Models.ViewModel;

namespace <%=Projeto%>.Controllers
{
    <%if(Area != ""){%>[Area("<%=Area%>")] <%}%>
    public class <%=Controller%>Controller : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<User> _userManager;

        public <%=Controller%>Controller(IUnitOfWork context, UserManager<User> UserManager)
        {
            _context = context;
            _userManager = UserManager;
        }

        // GET: <%=Controller%>
        public IActionResult Index()
        {
            try{
                return View();
            }catch(Exception e)
            {
                ViewBag.Message = e.Message;
                ViewBag.Type    = "danger";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Lista<%=Controller%>(DataTableAjaxPostModel param)
        {
            try{
                var dados = _context.<%=ObjContext%>.GetIndexValues(param, out int qtdRegistros, out int qtdRegistrosFiltro );
			return Json(
				new 
				{
					draw = param.draw,
					data = dados,
					recordsTotal = qtdRegistros,
					recordsFiltered = qtdRegistrosFiltro
				});
			}
			catch(Exception e)
			{
				ViewBag.Message = e.Message;
				ViewBag.Type = "danger";
				return View();
			}		
        }

        // GET: <%=ObjContext%>/Details/5
        public IActionResult Details(int? id)
        {
            try{
                if (id == null)
                {
                    return NotFound();
                }

                var entity = _context.<%=ObjContext%>.GetId(id);
                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }catch(Exception e)
            {
             	ViewBag.Message = e.Message;
				ViewBag.Type = "danger";
				return View();   
            }
        }

        // GET: <%=ObjContext%>/Create
        public IActionResult Create()
        {
            try{
                <%=ObjContext%> <%=ObjContext%> = new <%=ObjContext%>();
                return View(<%=ObjContext%>);
            }catch(Exception e)
            {
             	ViewBag.Message = e.Message;
				ViewBag.Type = "danger";
				return View();   
            }
        }

        // POST: <%=ObjContext%>/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(<%=ObjContext%> entity)
        {
            try{
                if (ModelState.IsValid)
                {
                    _context.<%=ObjContext%>.Add(entity);
                    _context.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View(entity);
            }catch(Exception e)
            {
             	ViewBag.Message = e.Message;
				ViewBag.Type = "danger";
				return View(entity);   
            }
        }

        // GET: <%=ObjContext%>/Edit/5
        public IActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var entity = _context.<%=ObjContext%>.GetId(id);
                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }catch(Exception e)
            {
             	ViewBag.Message = e.Message;
				ViewBag.Type = "danger";
				return View();   
            }
        }

        // POST: <%=ObjContext%>/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, <%=ObjContext%> entity)
        {
            try{
                if (id != entity.<%=PrimaryKeyDb%>)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.<%=ObjContext%>.Edit(entity);
                        _context.Save();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EntityExists(entity.<%=PrimaryKeyDb%>))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(entity);
            }catch(Exception e)
            {
             	ViewBag.Message = e.Message;
				ViewBag.Type = "danger";
				return View(entity);   
            }
        }

        // GET: <%=ObjContext%>/Delete/5
        public IActionResult Delete(int? id)
        {
            try{
                if (id == null)
                {
                    return NotFound();
                }

                var entity = _context.<%=ObjContext%>.GetId(id);
                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }catch(Exception e)
            {
             	ViewBag.Message = e.Message;
				ViewBag.Type = "danger";
				return View();   
            }
        }

        // POST: <%=ObjContext%>/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try{
                var entity = _context.<%=ObjContext%>.GetId(id);
                _context.<%=ObjContext%>.Remove(entity);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }catch(Exception e)
            {
             	ViewBag.Message = e.Message;
				ViewBag.Type = "danger";
				return View();   
            }
        }

        private bool EntityExists(int id)
        {
            if(_context.<%=ObjContext%>.GetId(id) == null)
            {
                return false;
            }
            return true;
        }
        private async Task<User> GetUserLoginAsync()
        {
            var teste = User.Identity.Name;
            User usr = await _userManager.FindByNameAsync(teste);
            return usr;
        }
    }
}
