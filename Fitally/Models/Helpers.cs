﻿using System.Security.Claims;

namespace Fitally.Models
{
    public static class Helpers
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
