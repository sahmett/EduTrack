using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Models.Course
{
        public class CreateCourseRequest
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public bool InternalTrainer { get; set; }
            public int Capacity { get; set; }
            public decimal Cost { get; set; }
            public TimeSpan Duration { get; set; }
            public string CategoryId { get; set; }
        }
    }
