﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Models;
using FIT_Api_Examples.Models.eUniverzitet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FIT_Api_Examples.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.Student.Include(s => s.opstina_rodjenja.drzava).FirstOrDefault(s => s.id == id)); ;
        }
        public class StudentAddVM
        {
            public string ime { get; set; }
            public string prezime { get; set; }
            public string broj_indeksa { get; set; }
            public int? opstina_rodjenja_id { get; set; }
        }

        [HttpPost]
        public ActionResult Add([FromBody] StudentAddVM x)
        {
            var newEmployee = new Student
            {
                ime = x.ime,
                prezime = x.prezime,
                broj_indeksa = x.broj_indeksa,
                opstina_rodjenja_id = x.opstina_rodjenja_id,
                slika_studenta = Config.SlikeURL + "empty.png",
                created_time = DateTime.Now
            };

            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return Get(newEmployee.id);
        }
        public class StudentUpdateVM
        {
            public string ime { get; set; }
            public string prezime { get; set; }
            public string broj_indeksa { get; set; }
            public int opstina_rodjenja_id { get; set; }
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] StudentUpdateVM x)
        {
            Student student = _dbContext.Student.Include(s => s.opstina_rodjenja.drzava).FirstOrDefault(s => s.id == id);

            if (student == null)
                return BadRequest("pogresan ID");

            student.ime = x.ime;
            student.prezime = x.prezime;
            student.broj_indeksa = x.broj_indeksa;
            student.opstina_rodjenja_id = x.opstina_rodjenja_id;

            _dbContext.SaveChanges();
            return Get(id);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Student student = _dbContext.Student.Find(id);

            if (student == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(student);

            _dbContext.SaveChanges();
            return Ok(student);
        }

      
        [HttpGet]
        public PagedList<Student> GetAllPaged(string ime_prezime, int page_number, int items_per_page)
        {
            var data = _dbContext.Student
                .Include(s=>s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime)).OrderByDescending(s => s.prezime).ThenByDescending(s => s.ime)
                .AsQueryable();
            return PagedList<Student>.Create(data, page_number, items_per_page);
        }

        [HttpGet]
        public List<Student> GetAll(string ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime)).OrderByDescending(s => s.prezime).ThenByDescending(s => s.ime)
                .AsQueryable();
            return data.Take(100).ToList();
        }

        public class StudentImageAddVM
        {
            public IFormFile profile_image { set; get; }
        }

        [HttpPost("{id}")]
        public ActionResult AddProfileImage(int id, [FromForm] StudentImageAddVM x)
        {
            try
            {
                Student student = _dbContext.Student.Include(s=>s.opstina_rodjenja.drzava).FirstOrDefault(s => s.id == id);

                if (x.profile_image != null && student != null)
                {
                    if (x.profile_image.Length > 300 * 1000)
                        return BadRequest("max velicina fajla je 300 KB");

                    string ekstenzija = Path.GetExtension(x.profile_image.FileName);

                    var filename = $"{Guid.NewGuid()}{ekstenzija}";

                    x.profile_image.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
                    student.slika_studenta = Config.SlikeURL + filename;
                    _dbContext.SaveChanges();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }
    }
}
