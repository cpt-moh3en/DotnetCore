using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore.Models.Context;
using DotnetCore.Models.Entities;
using DotnetCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetCore.Controllers
{
    public class ReserveController : Controller
    {
        private readonly DonetCoreContext _context;
        private readonly IWebHostEnvironment _env;
        public ReserveController(DonetCoreContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Reserve_Vm vm_reserve)
        {
            try
            {
                Reserve tbl_reserve = new Reserve
                {
                    Name = vm_reserve.Name,
                    Family = vm_reserve.Family,
                    PhoneNumber = vm_reserve.PhoneNumber,
                    Email = vm_reserve.Email,
                    Age = vm_reserve.Age,
                    // RoomNumber = vm_reserve.RoomNumber,
                    ReserveDateTime = DateTime.Now,
                    StartDateTime = vm_reserve.StartDateTime,
                    EndDateTime = vm_reserve.EndDateTime,
                    Status = false
                };

                Random rnd = new Random();
                tbl_reserve.RoomNumber = Convert.ToByte(rnd.Next(1, 250));

                if (vm_reserve.fileImage != null)
                {
                    string FormatImage = Path.GetExtension(vm_reserve.fileImage.FileName);
                    string ImageName = String.Concat(Guid.NewGuid().ToString(), FormatImage);
                    tbl_reserve.Image = ImageName;

                    string path = $"{_env.WebRootPath}\\FileUpload\\{ImageName}";

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await vm_reserve.fileImage.CopyToAsync(stream);
                    }

                }

                _context.Tbl_Reserve.Add(tbl_reserve);
                _context.SaveChanges();

                ViewBag.Msg = "Ok";

            }
            catch (System.Exception ex)
            {
                ViewBag.Msg = "Error";
            }

            return View();
        }

        public IActionResult GetData()
        {
            var reserve = _context.Tbl_Reserve.ToList();

            List<Reserve_Vm> lvm_reserve = new List<Reserve_Vm>();

            foreach (var item in reserve)
            {
                Reserve_Vm model_reserve = new Reserve_Vm
                {
                    Id = item.Id,
                    Name = item.Name,
                    Family = item.Family,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    Age = item.Age,
                    RoomNumber = item.RoomNumber,
                    ReserveDateTime = item.ReserveDateTime,
                    StartDateTime = item.StartDateTime,
                    EndDateTime = item.EndDateTime,
                    Status = item.Status,
                    strImage = item.Image
                };
                lvm_reserve.Add(model_reserve);
            }


            return View(lvm_reserve);
        }

        public IActionResult Delete(long Id)
        {
            var reserveItem = _context.Tbl_Reserve.SingleOrDefault(i => i.Id == Id);

            _context.Tbl_Reserve.Remove(reserveItem);
            _context.SaveChanges();

            return RedirectToAction("GetData");
        }
        public IActionResult Edit(long Id)
        {
            var reserveItem = _context.Tbl_Reserve.SingleOrDefault(i => i.Id == Id);

            if (reserveItem.Status == false)
            {
                reserveItem.Status = true;
            }
            else
            {
                reserveItem.Status = false;
            }

            _context.Tbl_Reserve.Update(reserveItem);
            _context.SaveChanges();

            return RedirectToAction("GetData");
        }

        public IActionResult EditItem(long Id)
        {
            var reserveItem = _context.Tbl_Reserve.SingleOrDefault(i => i.Id == Id);

            Reserve_Vm model_reserve = new Reserve_Vm
            {
                Id = reserveItem.Id,
                Name = reserveItem.Name,
                Family = reserveItem.Family,
                PhoneNumber = reserveItem.PhoneNumber,
                Email = reserveItem.Email,
                Age = reserveItem.Age,
                RoomNumber = reserveItem.RoomNumber,
                ReserveDateTime = reserveItem.ReserveDateTime,
                StartDateTime = reserveItem.StartDateTime,
                EndDateTime = reserveItem.EndDateTime,
                Status = reserveItem.Status,
                strImage = reserveItem.Image
            };

            return View(model_reserve);
        }

        public IActionResult EditItemUpdate(Reserve_Vm vm_reserve)
        {
            var reserveItem = _context.Tbl_Reserve.SingleOrDefault(i => i.Id == vm_reserve.Id);

            reserveItem.Name = vm_reserve.Name;
            reserveItem.Family = vm_reserve.Family;
            reserveItem.PhoneNumber = vm_reserve.PhoneNumber;
            reserveItem.Email = vm_reserve.Email;
            reserveItem.Age = vm_reserve.Age;
            reserveItem.RoomNumber = vm_reserve.RoomNumber;
            reserveItem.StartDateTime = vm_reserve.StartDateTime;
            reserveItem.EndDateTime = vm_reserve.EndDateTime;

            _context.Tbl_Reserve.Update(reserveItem);
            _context.SaveChanges();

            return RedirectToAction("GetData");
        }

    }
}