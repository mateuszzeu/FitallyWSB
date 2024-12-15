using Microsoft.AspNetCore.Identity;

namespace Fitally.Models
{
    public class WorkoutDay
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime WorkoutDate { get; set; }
        public string DayName { get; set; }
        public string Info { get; set; }

        public List<WorkoutExercise>? WorkoutExercises { get; set; }
    }
}
