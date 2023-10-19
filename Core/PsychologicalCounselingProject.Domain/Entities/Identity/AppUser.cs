﻿using Microsoft.AspNetCore.Identity;

namespace PsychologicalCounselingProject.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; }
    }
}
