namespace humanemission.Model
{
    public class Emissions
    {

        public int Id { get; set; }

        public string TypeOfEmission { get; set; } = string.Empty;

        public string Cause { get; set; } = string.Empty;

        public string Effect { get; set; } = string.Empty;

        public string ControlMeasure { get; set; } = string.Empty;

        public byte[] ?EmissionImage { get; set; }
    }
}
