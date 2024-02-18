using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Utility
{
    public static class DateExtensions
    {
        public static string RenderFriendlyDateTime(this DateTime input)
        {
            TimeSpan timeDifference = DateTime.Now - input;

            if (timeDifference.TotalDays < 1)
            {
                return $"Posted Today at {input.TimeOfDay.ToString("hh\\:mm")}";
            }
            else if (timeDifference.TotalDays < 2)
            {
                return $"Posted Yesterday at {input.TimeOfDay.ToString("hh\\:mm")}";
            }
            else
            {
                return $"Posted on {input.ToString("dd/MM/yyyy")} at {input.TimeOfDay.ToString("hh\\:mm")}";
            }
        }
    }
}
