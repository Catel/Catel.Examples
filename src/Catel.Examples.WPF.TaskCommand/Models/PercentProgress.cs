namespace Catel.Examples.TaskCommand.Models
{
    using MVVM;

    public class PercentProgress : ITaskProgressReport
    {
        public PercentProgress(int percent, string status = null)
        {
            Percent = percent;
            Status = status;
        }

        public int Percent { get; private set; }
        public string Status { get; private set; }
    }
}
