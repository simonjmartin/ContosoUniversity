﻿namespace ContosoUniversity.Features.Course
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using DAL;
    using MediatR;
    using Models;

    public class Create
    {
        public class Command : IRequest
        {
            [Display(Name = "Number")]
            public int CourseNumber { get; set; }
            public string Title { get; set; }
            public int Credits { get; set; }
            public Department Department { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly SchoolContext _db;

            public Handler(SchoolContext db)
            {
                _db = db;
            }

            protected override void HandleCore(Command message)
            {
                var course = Mapper.Map<Command, Course>(message);

                _db.Courses.Add(course);
            }
        }
    }
}