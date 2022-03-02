namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }
        public string ShininessDescription
        {
            get
            {
                switch (ShininessLevel)
                {
                    case < 2:
                        return "dull";
                    case < 6:
                        return "noticeable";
                    case < 10:
                        return "bright";
                    default:
                        return "blinding";
                }
            }
        }
    }
}