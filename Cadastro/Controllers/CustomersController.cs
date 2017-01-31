using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cadastro.Models;
using Data.Repositorios;
using Domain.Model;

namespace Cadastro.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        
            CustomersRepository _customersRepository = new CustomersRepository();
        public ActionResult Index()
        {
            var temp = _customersRepository.ConsultarTodos();
            List<CustomersViewModel> listView = new List<CustomersViewModel>();
            foreach (var item in temp)
            {
              CustomersViewModel view = new CustomersViewModel();
                view.customer_id = item.customer_id;
                view.contact_number = item.contact_number;
                view.contact_person = item.contact_person;
                view.email = item.email;
                view.name = item.name;
                view.physical_address = item.physical_address;
                view.postal_address = item.postal_address;
                listView.Add(view);

            }
            return View(listView);
        }
        public ActionResult Details(int id)
        {
            var item = _customersRepository.ConsultarPorId(id);
            CustomersViewModel view = new CustomersViewModel
            {
                customer_id = item.customer_id,
                contact_number = item.contact_number,
                contact_person = item.contact_person,
                email = item.email,
                name = item.name,
                physical_address = item.physical_address,
                postal_address = item.postal_address,
            };
            return View(view);
        }
        public ActionResult Create()
        {
            return View();
        }

        //  
        // POST: /Associates/Create  
        [HttpPost]
        public ActionResult Create(CustomersViewModel temp)
        {
            Customers customers = new Customers
            {
                name = temp.name,
                contact_number = temp.contact_number,
                postal_address = temp.postal_address,
                contact_person = temp.contact_person,
                physical_address = temp.physical_address,
                email = temp.email
            };
            _customersRepository.Salvar(customers);  
            return View();
        }
        //  
        // GET: /Associates/Edit/5  
        public ActionResult Edit(int id)
        {
            var item =_customersRepository.ConsultarPorId(id);
            

            CustomersViewModel view = new CustomersViewModel
            {
                customer_id = item.customer_id,
                contact_number = item.contact_number,
                contact_person = item.contact_person,
                email = item.email,
                name = item.name,
                physical_address = item.physical_address,
                postal_address = item.postal_address,
            };


            return View(view);


        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int? id, CustomersViewModel temp)
        {


            Customers customers = new Customers
            {
                customer_id = temp.customer_id,
                name = temp.name,
                contact_number = temp.contact_number,
                postal_address = temp.postal_address,
                contact_person = temp.contact_person,
                physical_address = temp.physical_address,
                email = temp.email,
                
                
            };
            _customersRepository.Editar(customers);
            
            return RedirectToAction("Index");
        }

        //  
        // GET: /Associates/Delete/5  
        public ActionResult Delete(int id)
        {

            var item = _customersRepository.ConsultarPorId(id);


            CustomersViewModel view = new CustomersViewModel
            {
                customer_id = item.customer_id,
                contact_number = item.contact_number,
                contact_person = item.contact_person,
                email = item.email,
                name = item.name,
                physical_address = item.physical_address,
                postal_address = item.postal_address,
            };


            return View(view);

        }

        //  
        // POST: /Associates/Delete/5  
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var temp = _customersRepository.ConsultarPorId(id);
            Customers customers = new Customers
            {
                customer_id = temp.customer_id,
                name = temp.name,
                contact_number = temp.contact_number,
                postal_address = temp.postal_address,
                contact_person = temp.contact_person,
                physical_address = temp.physical_address,
                email = temp.email
            };
            _customersRepository.Deletar(customers);
            return RedirectToAction("Index");
        }

    }
}