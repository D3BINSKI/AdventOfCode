namespace CalorieCounting01
{
    public class Elf
    {
        private static int _id = 0;
        private int id;
        private List<Provision> _provisions;
        
        public List<Provision> Provisions => _provisions;

        public Elf(List<Provision> provisions)
        {
            id = _id++;
            _provisions = provisions;
        }
    
        public void AddProvision(Provision provision)
        {
            _provisions.Add(provision);
        }
    }
}

