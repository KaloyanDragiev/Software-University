﻿namespace LearningSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;
    using Microsoft.AspNet.Identity;
    using Models.ViewModels;
    using Attributes;

    [RoutePrefix("Course")]
    [CustomAuthorize(Roles = "Student,Admin")]
    public class CourseController : Controller
    {
        private ICoursesService service;

        public CourseController(ICoursesService service)
        {          
            this.service = service;
        }

        [Route("Details/{id}")]
        [AllowAnonymous]
        public ActionResult Details(int id = 1)
        {
            string userId = HttpContext.User.Identity.GetUserId();
            CourseDetailsVm courseDetailsVm = this.service.GetCourseDetails(id, userId);
            if (courseDetailsVm == null)
            {
                return this.HttpNotFound();
            }
            return View(courseDetailsVm);
        }

        [Route("Enroll/{id}")]
        [HttpPost]
        public ActionResult Enroll(int id)
        {
            string userId = HttpContext.User.Identity.GetUserId();
            this.service.EnrollStudentInCourse(id, userId);
            return RedirectToAction("Index", "Home");
        }
    }
}