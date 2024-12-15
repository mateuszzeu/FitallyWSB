namespace Fitally.Models
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int WorkoutDayId { get; set; }
        public int ExerciseId { get; set; }

        public WorkoutDay? WorkoutDay { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
